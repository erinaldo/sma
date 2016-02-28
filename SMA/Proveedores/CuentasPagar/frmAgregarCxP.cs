using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.BL;
using SMA.Entity;

namespace SMA.Clientes.CuentasPagar
{
    public partial class frmAgregarCxP : Office2007Form, IAgregarCxP
    {
        private Int64? ProveedorID; //Codigo de Proveedor
        private Int64? CuentaID; //Codigo de cuenta
        private frmGestionCuentasPorPagar GestionCuentasPorPagar;

        #region Constructores
        public frmAgregarCxP()
        {
            InitializeComponent();
        }

        public frmAgregarCxP(Int64 ProveedorID, frmGestionCuentasPorPagar GestionCuentasPorPagar):this()
        {
            this.ProveedorID = ProveedorID;
            this.GestionCuentasPorPagar = GestionCuentasPorPagar;
        }

        public frmAgregarCxP(Int64 CuentaID):this()
        {
            this.CuentaID = CuentaID;
        }
        #endregion

        #region Implementacion Interface
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

        public void SeleccionProveedor(Int64 ProveedorID)
        {
            //Sin Implementacion
        }
        #endregion

        private void frmAgregarCxP_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaProveedores();

                if (CuentaID.HasValue)
                {
                    //Cargamos las dependencias
                    CargarListaConceptos();

                    //Obtenemos el codigo de cliente proporcionado
                    Int32 ID = Convert.ToInt32(CuentaID);
                    //Buscamos el movimiento de la cuenta
                    CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
                    CargarMovimiento(ObjetoCuenta.BuscarPorID(ID));

                }
                else
                {
                    if (ProveedorID.HasValue)
                    {
                        Int32 ID = Convert.ToInt32(ProveedorID);
                        //Cargamos solo los conceptos de cargos manuales 
                        CargarListaConceptosCargos();
                        //Buscamos el cliente seleccionado
                        BuscarProveedor(ID);
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

        private void CargarListaProveedores()
        {
            //Lista de Proveedors
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            cbbProveedor.DataSource = ObjetoProveedor.Listar();
            cbbProveedor.ValueMember = "ID";
            cbbProveedor.DisplayMember = "NombreComercial";
        }

        private void CargarListaConceptos()
        {
            ConceptoCxPBL ObjetoConcepto = new ConceptoCxPBL();
            cbbConcepto.DataSource = ObjetoConcepto.Listar();
            cbbConcepto.ValueMember = "ID";
            cbbConcepto.DisplayMember = "Descripcion";
        }

        private void CargarListaConceptosCargos()
        {
            ConceptoCxPBL ObjetoConcepto = new ConceptoCxPBL();
            cbbConcepto.DataSource = ObjetoConcepto.ListarConceptoCargos();
            cbbConcepto.ValueMember = "ID";
            cbbConcepto.DisplayMember = "Descripcion";
        }


        private void CargarMovimiento(cCuentasPagar Cuenta)
        {
            //Cargamos el movimiento que se recibe como parametro para mostrarlo en los controles
            txtCodigo.Text = Cuenta.ID.ToString();
            cbbProveedor.SelectedValue = Cuenta.ProveedorID;
            cbbConcepto.SelectedValue = Cuenta.ConceptoID;
            txtFactura.Text = Cuenta.FacturaID.ToString();
            txtDocumentoPagar.Text = Cuenta.DocumentoID.ToString();
            txtReferencia.Text = Cuenta.ReferenciaID;
            txtMonto.Text = Cuenta.Monto.ToString();
            dtpFecha_Emision.Value = Cuenta.FechaEmision;
            dtpFecha_Vencimiento.Value = Cuenta.FechaVencimiento;
            txtNotas.Text = Cuenta.Notas;

        }

        private void BuscarProveedor(Int32 ProveedorID)
        {
            //Buscamos el cliente seleccionado
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            cbbProveedor.DisplayMember = "NombreComercial";
            cbbProveedor.ValueMember = "ID";
            cbbProveedor.DataSource = ObjetoProveedor.Filtrar(ProveedorID, ProveedorID,null,null);


        }

        private void TipoConcepto(Int32 ConceptoID)
        {
            //Determinamos el tipo de concepto seleccionado
            ConceptoCxPBL ObjetoConcepto = new ConceptoCxPBL();
            cConcepto Concepto = ObjetoConcepto.BuscarPorID(ConceptoID);

            if (Concepto.Tipo == "C")
            {
                lblTipo.Text = "Cargo";
            }
            else if (Concepto.Tipo == "A")
            {
                lblTipo.Text = "Abono";
            }
            else
            {
                lblTipo.Text = "";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
                ObjetoCuenta.GuardarCambios(ObtenerDatos());
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al guardar cambios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarError(Ex.Message);
            }

        }

        private cCuentasPagar ObtenerDatos()
        {
            try
            {
                cCuentasPagar Cuenta = new cCuentasPagar();
                Cuenta.ID = Convert.ToInt32(txtCodigo.Text);
                Cuenta.ProveedorID = ObtenerProveedor();
                Cuenta.ConceptoID = ObtenerConcepto();
                Cuenta.FacturaID = ObtenerFactura();
                Cuenta.Estatus = true;
                Cuenta.DocumentoID = txtDocumentoPagar.Text;
                Cuenta.ReferenciaID = ObtenerReferencia();
                Cuenta.FechaEmision = dtpFecha_Emision.Value;
                Cuenta.FechaVencimiento = dtpFecha_Vencimiento.Value;
                Cuenta.Monto = Convert.ToDecimal(txtMonto.Text);
                Cuenta.Notas = txtNotas.Text;

                return Cuenta;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        private string ObtenerReferencia()
        {
            String Referencia = txtReferencia.Text;
            if (Referencia != null && Referencia.Length > 0)
            {
                return Referencia;
            }
            else
            {
                errorProvider1.SetError(btnVerReferencia, "Debe especificar una referencia al cargo que esta realizando");
                throw new Exception("Debe especificar una referencia al cargo que esta realizando");
            }
        }

        private void MostrarError(String Mensaje)
        {
            ErrorProvider epReferencia = new ErrorProvider();

            if (Mensaje == "Error al guardar movimiento, Debe especificar la referencia del movimiento")
            {

                epReferencia.SetError(txtReferencia, "Debe especificar el documento de referencia");
            }


            if (Mensaje == "Debe especificar un numero de documento")
            {

                epReferencia.SetError(txtDocumentoPagar, "Debe especificar un documento");
            }

        }

        private Int32 ObtenerFactura()
        {
            Int32 Codigo;
            if (Int32.TryParse(txtFactura.Text, out Codigo))
            {
                return Convert.ToInt32(txtFactura.Text);
            }
            else
            {
                return -1;
            }
        }
        private Int32 ObtenerConcepto()
        {
            if (cbbConcepto.Text != String.Empty)
            {
                Int32 Codigo;
                if (Int32.TryParse(cbbConcepto.SelectedValue.ToString(), out Codigo))
                {
                    Codigo = Convert.ToInt32(cbbConcepto.SelectedValue);
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

        private Int32 ObtenerProveedor()
        {
            if (cbbProveedor.Text != String.Empty)
            {
                Int32 Codigo;
                if (Int32.TryParse(cbbProveedor.SelectedValue.ToString(), out Codigo))
                {
                    Codigo = Convert.ToInt32(cbbProveedor.SelectedValue);
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

        private void cbbConcepto_SelectedValueChanged(object sender, EventArgs e)
        {
            //Obtenemos el codigo del concepto seleccionado
            try
            {
                Int32 C;
                if (Int32.TryParse(cbbConcepto.SelectedValue.ToString(), out C))
                {
                    //Codigo del concepto
                    C = Convert.ToInt32(cbbConcepto.SelectedValue.ToString());
                    //Mostramos el tipo de concepto
                    TipoConcepto(C);
                }
            }
            catch (Exception Ex)
            {

            }
        }

        private void btnVerDocumentos_Click(object sender, EventArgs e)
        {

            Int32 Codigo = Convert.ToInt32(cbbProveedor.SelectedValue);
            frmListaFacturasPorProveedor ListaDocumento = new frmListaFacturasPorProveedor(Codigo, "Documento");
            ListaDocumento.ShowDialog(this);
            
            
        }

        private void btnVerReferencia_Click(object sender, EventArgs e)
        {

            Int32 Codigo = Convert.ToInt32(cbbProveedor.SelectedValue);
            frmListaFacturasPorProveedor ListaDocumento = new frmListaFacturasPorProveedor(Codigo, "Referencia");
            ListaDocumento.ShowDialog(this);
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
