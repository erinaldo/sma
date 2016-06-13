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
    public partial class frmRecibirPago : Office2007Form, IAgregarCxC
    {
        private Int32? CodigoCliente;
        Decimal Monto_;

        #region Constructores
        public frmRecibirPago()
        {
            InitializeComponent();
        }


        public frmRecibirPago(Int32 CodigoCliente):this()
        {
            this.CodigoCliente = CodigoCliente;
        }
        #endregion

        #region Implementacion de Interface
        public void SeleccionarDocumento(String Documento)
        {
            
        }

        public void SeleccionarReferencia(String Referencia)
        {
            txtDocumentoPagar.Text = Referencia;
            BuscarMontoDocumento();
        }

        public void SeleccionarCliente(Int64 ClienteID)
        {
            //Sin Implementacion
        }
        #endregion

        private void frmRecibirPago_Load(object sender, EventArgs e)
        {
            try
            {
                ClienteBL ObjetoCliente = new ClienteBL();

                if (CodigoCliente.HasValue)
                {
                    Int32 Codigo = Convert.ToInt32(CodigoCliente);
                    cbbClientes.DataSource = ObjetoCliente.Filtrar(Codigo, Codigo);
                    cbbClientes.DisplayMember = "NombreComercial";
                    cbbClientes.ValueMember = "Codigo";
                }
                else
                {
                    cbbClientes.DataSource = ObjetoCliente.Listar();
                    cbbClientes.DisplayMember = "NombreComercial";
                    cbbClientes.ValueMember = "Codigo";
                }


                ConceptoCxCBL ObjetoConcepto = new ConceptoCxCBL();
                cbbConcepto.DataSource = ObjetoConcepto.ListarConceptoAbono();
                cbbConcepto.DisplayMember = "Descripcion";
                cbbConcepto.ValueMember = "Codigo";
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnInsertarPago_Click(object sender, EventArgs e)
        {
            if (ValidacionMonto())
            try
            {
                Int16 Concepto = ObtenerConcepto();             //Codigo del concepto
                String DescripcionConcepto=cbbConcepto.Text;    //Descripcion de concepto
                Decimal Monto = ObtenerMonto();                  //Monto de la transaccion
                string Documento = txtDocumento.Text;           //Documento que identifica el pago
                string Referencia = txtDocumentoPagar.Text;     //Documento al que va dirigido el pago
                string Nota = txtReferencia.Text;               //Notas adicionales

                dgvPagos.Rows.Add(Concepto, DescripcionConcepto, Documento, Referencia,dtpFechaPago.Value, Monto, Nota);
                LimpiarCampos();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Error al realizar pago", "Error al realizar pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Decimal ObtenerMonto()
        {
            //Obtenemos el monto proporcionado para el pago
            Decimal Monto;
            if (Decimal.TryParse(txtMonto.Text, out Monto))
            {
                return Convert.ToDecimal(txtMonto.Text);
            }
            else
            {
                //Retornamos el error 
                throw new Exception("El valor proporcionado en el monto no es compatible o correcto");
            }
        }

        private Int16 ObtenerConcepto()
        {
            //Obtenemos el concepto de pago seleccionado
            Int16 ConceptoID;
            if (Int16.TryParse(cbbConcepto.SelectedValue.ToString(), out ConceptoID))
            {
                return Convert.ToInt16(cbbConcepto.SelectedValue.ToString());
            }
            else
            {
                //Retornamos el error
                throw new Exception("Debe seleccionar un concepto de abono para poder realizar la transaccion");
            }
        }

        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPagos.Rows.RemoveAt(dgvPagos.CurrentRow.Index);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message + "Error al eliminar linea", "Error al eliminar linea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarPagos();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void InsertarPagos()
        {
            //Insertamos los datos que se encuentran en el datagrid de pagos
            try
            {
                CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();

                if (dgvPagos.RowCount > 0)
                {
                    foreach (DataGridViewRow Item in dgvPagos.Rows)
                    {
                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.Codigo = -1;
                        Cuenta.CodigoFactura = -1;
                        Cuenta.CodigoConcepto = Item.Cells[0].Value;
                        Cuenta.CodigoCliente = ObtenerCliente();
                        Cuenta.CodigoDocumento = Item.Cells[2].Value;
                        Cuenta.CodigoReferencia = Item.Cells[3].Value.ToString();
                        Cuenta.Notas = Item.Cells[6].Value.ToString();
                        Cuenta.FechaEmision = Convert.ToDateTime(Item.Cells[4].Value);
                        Cuenta.FechaVencimiento = Convert.ToDateTime(Item.Cells[4].Value);
                        Cuenta.Monto = Convert.ToDecimal(Item.Cells[5].Value.ToString());
                        ObjetoCuenta.GuardarCambios(Cuenta);
                        this.Close();
                    }
                }
                else
                {
                    throw new Exception("Debe introducir al menos un pago para poder procesarse");
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Error al intentar insertar transaccion","Error al guardar cambios",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private Int32 ObtenerCliente()
        {
            Int32 Codigo;
            if(Int32.TryParse(cbbClientes.SelectedValue.ToString(),out Codigo))
            {
                return Convert.ToInt32(cbbClientes.SelectedValue.ToString());
            }
            else
            {
                throw new Exception ("Debe seleccionar un cliente para realizar la transaccion");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void BuscarMontoDocumento()
        {
            try
            {
                //Buscamos el documento y asignamos los valores del mismo al formulario
                List<cCuentasCobrar> Cuenta;
                CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();

                //buscamos los documentos de tipo cargo que tiene el cliente
                Cuenta = ObjetoCuenta.ListarCargosGenerales(ObtenerCliente());
                //Si posee alguno
                if (Cuenta.Count>0)
                {
                    //Buscamos el balance del documento seleccionado
                    Monto_ = (from x in Cuenta
                             where x.CodigoDocumento.ToString()==txtDocumentoPagar.Text
                             select x.Balance).FirstOrDefault();
                    txtMonto.Text = Monto_.ToString();
                  
                }
                else
                {
                    throw new Exception("El documento no pertenece al cliente seleccionado, favor validar");
                    LimpiarCampos();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "Error al seleccionar documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

       

        private void LimpiarCampos()
        {
            txtMonto.Text = "0.00";
            txtDocumentoPagar.Text = "";
            txtDocumentoPagar.Focus();
        }

        private void btnVerDocumento_Click(object sender, EventArgs e)
        {
            if (CodigoCliente.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(CodigoCliente);
                frmListaFacturasPorCliente ListarDocumentos = new frmListaFacturasPorCliente(Codigo, "Referencia");
                ListarDocumentos.ShowDialog(this);
            }
        }

        private void btnVerClientes_Click(object sender, EventArgs e)
        {

        }

        private void txtMonto_Validated(object sender, EventArgs e)
        {
            try
            {
                ValidacionMonto();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al realizar pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean ValidacionMonto()
        {
            //Validamos que el campo monto tenga valores correctos
            //Validamos que el monto proporcionado no sea superior al valor adeudado
            Decimal Comparacion;
            if (Decimal.TryParse(txtMonto.Text, out Comparacion))
            {
                Comparacion = Convert.ToDecimal(txtMonto.Text);
                if (Comparacion > Monto_ || Comparacion<0)
                {
                    txtMonto.Text = Monto_.ToString();
                    throw new Exception("El monto proporcionado no puede exceder el monto adeudado por el cliente y no puede ser menor a 0 favor verificar y volver a intentar");
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new Exception("Existe un error en el monto proporcionado, favor verifique");
            }
        }

        private void txtDocumentoPagar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDocumentoPagar_Validated(object sender, EventArgs e)
        {
            if (txtDocumentoPagar.Text != string.Empty)
            {
                BuscarMontoDocumento();
            }
        }
        
    }
}
