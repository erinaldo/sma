using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.BL;
using SMA.Entity;
using DevComponents.DotNetBar;

namespace SMA.Clientes.CuentasPagar
{
    public partial class frmAgregarCxC : Office2007Form, IAgregarCxC
    {
        private Int32? CodigoCliente; //Codigo de cliente
        private Int32? CodigoCuenta; //Codigo de cuenta
        private frmGestionCuentasPorCobrar GestionCuentasPorCobrar;
        // private frmGestionClientes GestionClientes;

        #region Contructores
        public frmAgregarCxC()
        {
            InitializeComponent();
        }

        //Parametro de Codigo de Cliente y formulario para refrescar
        public frmAgregarCxC(Int32 CodigoCliente, frmGestionCuentasPorCobrar GestionCuentasPorCobrar): this()
        {
            this.CodigoCliente = CodigoCliente;
            this.GestionCuentasPorCobrar = GestionCuentasPorCobrar;
        }


        //Parametro de movimiento de Cuentas por Cobrar
        public frmAgregarCxC(Int32 CodigoCuenta): this()
        {
            this.CodigoCuenta = CodigoCuenta;
        }
        #endregion

        #region Implementacion de Interface
        public void SeleccionarDocumento(String Documento)
        {
            txtFactura.Text = Documento;
            txtDocumentoPagar.Text = Documento;
            txtReferencia.Text = Documento;
        }

        public void SeleccionarReferencia(String Referencia)
        {
            txtReferencia.Text = Referencia;
        }

        public void SeleccionarCliente(Int64 ClienteID)
        {
            //Sin Implementacion
        }
        #endregion

        private void frmAgregarCxC_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaClientes();

                if (CodigoCuenta.HasValue)
                {
                    //Cargamos las dependencias
                    CargarListaConceptos();

                    //Obtenemos el codigo de cliente proporcionado
                    Int32 ID = Convert.ToInt32(CodigoCuenta);
                    //Buscamos el movimiento de la cuenta
                    CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                    CargarMovimiento(ObjetoCuenta.BuscarPorID(ID));
                    
                }
                else 
                {
                    if(CodigoCliente.HasValue)
                    {
                        Int32 ID = Convert.ToInt32(CodigoCliente);
                        //Cargamos solo los conceptos de cargos manuales 
                        CargarListaConceptosCargos();
                        //Buscamos el cliente seleccionado
                        BuscarCliente(ID);
                        //Colocamos un identificador en el codigo
                        txtCodigo.Text = "-1";
                        txtMonto.Text = "0.00";
                        
                    }
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CargarListaClientes()
        {
            //Lista de Clientes
            ClienteBL ObjetoCliente = new ClienteBL();
            cbbClientes.DataSource = ObjetoCliente.Listar();
            cbbClientes.ValueMember = "Codigo";
            cbbClientes.DisplayMember = "NombreComercial";
        }

        private void CargarListaConceptos()
        {
            ConceptoCxCBL ObjetoConcepto = new ConceptoCxCBL();
            cbbConcepto.DataSource = ObjetoConcepto.Listar();
            cbbConcepto.ValueMember = "Codigo";
            cbbConcepto.DisplayMember = "Descripcion";
        }

        private void CargarListaConceptosCargos()
        {
            ConceptoCxCBL ObjetoConcepto = new ConceptoCxCBL();
            cbbConcepto.DataSource = ObjetoConcepto.ListarConceptoCargos();
            cbbConcepto.ValueMember = "Codigo";
            cbbConcepto.DisplayMember = "Descripcion";
        }

        private void CargarMovimiento(cCuentasCobrar Cuenta)
        {
            if (Cuenta != null)
            {
                //Cargamos el movimiento que se recibe como parametro para mostrarlo en los controles
                txtCodigo.Text = Cuenta.Codigo.ToString();
                cbbClientes.SelectedValue = Cuenta.CodigoCliente;
                cbbConcepto.SelectedValue = Cuenta.CodigoConcepto;
                txtFactura.Text = Cuenta.CodigoFactura.ToString();
                txtDocumentoPagar.Text = Cuenta.CodigoDocumento.ToString();
                txtReferencia.Text = Cuenta.CodigoReferencia;
                txtMonto.Text = Cuenta.Monto.ToString();
                dtpFecha_Emision.Value = Cuenta.FechaEmision;
                dtpFecha_Vencimiento.Value = Cuenta.FechaVencimiento;
                txtNotas.Text = Cuenta.Notas;
            }
            else
            {
                MessageBox.Show("Error al mostrar datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarCliente(Int32 ClienteID)
        {
            //Buscamos el cliente seleccionado
            ClienteBL ObjetoCliente=new ClienteBL();
            cbbClientes.DisplayMember = "NombreComercial";
            cbbClientes.ValueMember = "Codigo";
            cbbClientes.DataSource= ObjetoCliente.Filtrar(ClienteID, ClienteID);

            
        }

        //MOSTRAMOS EL TIPO DE CONCEPTO
        private void TipoConcepto(Int16 ConceptoID)
        {
            //Determinamos el tipo de concepto seleccionado
            ConceptoCxCBL ObjetoConcepto= new ConceptoCxCBL();
            cConcepto Concepto = ObjetoConcepto.BuscarPorID(ConceptoID);
            
            if(Concepto.Tipo=="C")
            {
                lblTipo.Text = "Cargo";
            }
            else if(Concepto.Tipo=="A")
            {
                lblTipo.Text = "Abono";
            }
            else
            {
                lblTipo.Text="";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //ENVIAMOS LOS CAMBIOS A LA BASE DE DATOS
            try
            {
                CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                ObjetoCuenta.GuardarCambios(ObtenerDatos());
                this.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al guardar cambios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarError(Ex.Message);
            }
        }

        //MOSTRAMOS ERRORES PREDETERMINADOS
        private void MostrarError(String Mensaje)
        {
            ErrorProvider epReferencia = new ErrorProvider();

            if(Mensaje=="Error al guardar movimiento, Debe especificar la referencia del movimiento")
            {
               
                epReferencia.SetError(txtReferencia, "Debe especificar el documento de referencia");
            }


            if (Mensaje == "Debe especificar un numero de documento")
            {
                
                epReferencia.SetError(txtDocumentoPagar, "Debe especificar un documento");
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private cCuentasCobrar ObtenerDatos()
        {
            try
            {
                cCuentasCobrar Cuenta = new cCuentasCobrar();
                Cuenta.Codigo = Convert.ToInt32(txtCodigo.Text);
                Cuenta.CodigoCliente = ObtenerCliente();
                Cuenta.CodigoConcepto = ObtenerConcepto();
                Cuenta.CodigoFactura = ObtenerFactura();
                Cuenta.Estatus = true;
                Cuenta.CodigoDocumento = txtDocumentoPagar.Text;
                Cuenta.CodigoReferencia = ObtenerReferencia();
                Cuenta.FechaEmision = dtpFecha_Emision.Value;
                Cuenta.FechaVencimiento = dtpFecha_Vencimiento.Value;
                Cuenta.Monto = ObtenerMonto();
                Cuenta.Notas = txtNotas.Text;

                return Cuenta;
            }
            catch(Exception Ex)
            {
                throw Ex;
            }

        }

        //OBTENEMOS LA REFERENCIA DEL CARGO
        private string ObtenerReferencia()
        {
            String Referencia = txtReferencia.Text;
            if(Referencia!=null && Referencia.Length>0)
            {
                return Referencia;
            }
            else
            {
                errorProvider1.SetError(btnVerReferencia, "Debe especificar una referencia al cargo que esta realizando");
                throw new Exception("Debe especificar una referencia al cargo que esta realizando");
            }
        }

        private decimal ObtenerMonto()
        {
            //OBTENEMOS EL MONTO DIGITADO
            Decimal Monto;
            if(Decimal.TryParse(txtMonto.Text,out Monto))
            {
                Monto= Convert.ToDecimal(txtMonto.Text);
                if(Monto<=0)
                {
                    errorProvider1.SetError(txtMonto, "El valor del monto no debe ser igual ni menor a 0");
                    throw new Exception("El valor del monto no debe ser igual ni menor a 0");
                }
                else
                {
                    return Monto;
                }
            }
            else
            {
                errorProvider1.SetError(txtMonto, "Debe especificar un monto valido");
                throw new Exception("Debe expecificar un monto valido");
            }
            
        }

        //OBTENEMOS EL NUMERO DE FACTURA
        private Int64 ObtenerFactura()
        {
            Int64 Codigo;
            if(Int64.TryParse(txtFactura.Text,out Codigo))
            {
                return Convert.ToInt64(txtFactura.Text);
            }
            else
            {
                return -1;
            }
        }

        //OBTENEMOS EL CONCEPTO PARA EL CARGO
        private Int16 ObtenerConcepto()
        {
            if (cbbConcepto.Text != String.Empty)
            {
                Int16 Codigo;
                if (Int16.TryParse(cbbConcepto.SelectedValue.ToString(), out Codigo))
                {
                    Codigo = Convert.ToInt16(cbbConcepto.SelectedValue);
                    return Codigo;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;

            }
            
        }

        //OBTENEMOS EL CODIGO DEL CLIENTE
        private Int32 ObtenerCliente()
        {
            if(cbbClientes.Text!=String.Empty)
            {
                Int32 Codigo;
                if(Int32.TryParse(cbbClientes.SelectedValue.ToString(), out Codigo))
                {
                    Codigo = Convert.ToInt32(cbbClientes.SelectedValue);
                    return Codigo;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                    return -1;
                
            }
            
        }

       

        private void btnVerDocumentos_Click(object sender, EventArgs e)

        {
            try
            {
                Int32 Codigo = Convert.ToInt32(cbbClientes.SelectedValue);
                frmListaFacturasPorCliente ListaDocumento = new frmListaFacturasPorCliente(Codigo, "Documento");
                ListaDocumento.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }

        private void btnVerReferencia_Click(object sender, EventArgs e)
        {
            
                Int32 Codigo = Convert.ToInt32(cbbClientes.SelectedValue);
                frmListaFacturasPorCliente ListaDocumento = new frmListaFacturasPorCliente(Codigo,"Referencia");
                ListaDocumento.ShowDialog(this);
            
            
        }

        private void txtFactura_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cbbConcepto_SelectedValueChanged(object sender, EventArgs e)
        {
            //Obtenemos el codigo del concepto seleccionado
            try
            {
                Int16 C;
                if (Int16.TryParse(cbbConcepto.SelectedValue.ToString(), out C))
                {
                    //Codigo del concepto
                    C = Convert.ToInt16(cbbConcepto.SelectedValue.ToString());
                    //Mostramos el tipo de concepto
                    TipoConcepto(C);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void txtFactura_Validated_1(object sender, EventArgs e)
        {
            txtDocumentoPagar.Text = txtFactura.Text;
            txtReferencia.Text = txtFactura.Text;
        }
    }
}
