using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.Entity;
using SMA.BL;
using DevComponents.DotNetBar;

namespace SMA.Clientes.CuentasPagar
{
    public partial class frmRealizarPago : Office2007Form, IAgregarCxP
    {
        private Int64? ProveedorID;
        Decimal Monto_;

        #region Constructores
        public frmRealizarPago()
        {
            InitializeComponent();
        }

        public frmRealizarPago(Int64 ProveedorID):this()
        {
            this.ProveedorID = ProveedorID;
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

        public void SeleccionProveedor(Int64 ProveedorID)
        {
            //Sin Implementacion
        }
        #endregion
        private void frmRealizarPago_Load(object sender, EventArgs e)
        {

            ProveedorBL ObjetoProveedor = new ProveedorBL();

            if (ProveedorID.HasValue)
            {
                cbbProveedores.DataSource = ObjetoProveedor.Filtrar(ProveedorID, ProveedorID, null, null);
                cbbProveedores.DisplayMember = "NombreComercial";
                cbbProveedores.ValueMember = "ID";
            }
            else
            {
                cbbProveedores.DataSource = ObjetoProveedor.Listar();
                cbbProveedores.DisplayMember = "NombreComercial";
                cbbProveedores.ValueMember = "ID";
            }


            ConceptoCxPBL ObjetoConcepto = new ConceptoCxPBL();
            cbbConcepto.DataSource = ObjetoConcepto.ListarConceptoAbono();
            cbbConcepto.DisplayMember = "Descripcion";
            cbbConcepto.ValueMember = "ID";
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

        private Int32 ObtenerConcepto()
        {
            //Obtenemos el concepto de pago seleccionado
            Int32 ConceptoID;
            if (Int32.TryParse(cbbConcepto.SelectedValue.ToString(), out ConceptoID))
            {
                return Convert.ToInt32(cbbConcepto.SelectedValue.ToString());
            }
            else
            {
                //Retornamos el error
                throw new Exception("Debe seleccionar un concepto de abono para poder realizar la transaccion");
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
                if (Comparacion > Monto_)
                {
                    txtMonto.Text = Monto_.ToString();
                    throw new Exception("El monto proporcionado no puede exceder el monto adeudado por el cliente, favor verificar y volver a intentar");
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

        private void LimpiarCampos()
        {
            txtMonto.Text = "0.00";
            txtDocumentoPagar.Text = "";
            txtDocumentoPagar.Focus();
        }

        private void ButtonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidacionMonto())
                {
                    Int32 Concepto = ObtenerConcepto();             //Codigo del concepto
                    String DescripcionConcepto = cbbConcepto.Text;    //Descripcion de concepto
                    Decimal Monto = ObtenerMonto();                  //Monto de la transaccion
                    string Documento = txtDocumento.Text;           //Documento que identifica el pago
                    string Referencia = txtDocumentoPagar.Text;     //Documento al que va dirigido el pago
                    string Nota = txtReferencia.Text;               //Notas adicionales

                    dgvPagos.Rows.Add(Concepto, DescripcionConcepto, Documento, Referencia, dtpFechaPago.Value, Monto, Nota);
                    LimpiarCampos();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Error al realizar pago", "Error al realizar pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonX2_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPagos.Rows.RemoveAt(dgvPagos.CurrentRow.Index);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "Error al eliminar linea", "Error al eliminar linea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            InsertarPagos();
            
        }
        private void InsertarPagos()
        {
            try
            {
                CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();

                foreach (DataGridViewRow Item in dgvPagos.Rows)
                {
                    cCuentasPagar Cuenta = new cCuentasPagar();
                    Cuenta.ID = -1;
                    Cuenta.ConceptoID = Item.Cells[0].Value;
                    Cuenta.ProveedorID = ObtenerProveedor();
                    Cuenta.DocumentoID = Item.Cells[2].Value;
                    Cuenta.ReferenciaID = Item.Cells[3].Value.ToString();
                    Cuenta.Notas = Item.Cells[6].Value.ToString();
                    Cuenta.FechaEmision = Convert.ToDateTime(Item.Cells[4].Value);
                    Cuenta.FechaVencimiento = Convert.ToDateTime(Item.Cells[4].Value);
                    Cuenta.Monto = Convert.ToDecimal(Item.Cells[5].Value.ToString());
                    Cuenta.Estatus = true;
                    ObjetoCuenta.GuardarCambios(Cuenta);
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Error al intentar insertar transaccion", "Error al guardar cambios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Int32 ObtenerProveedor()
        {
            Int32 Codigo;
            if (Int32.TryParse(cbbProveedores.SelectedValue.ToString(), out Codigo))
            {
                return Convert.ToInt32(cbbProveedores.SelectedValue.ToString());
            }
            else
            {
                throw new Exception("Debe seleccionar un cliente para realizar la transaccion");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonX6_Click(object sender, EventArgs e)
        {
            if (ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                frmListaFacturasPorProveedor ListarDocumentos = new frmListaFacturasPorProveedor(Codigo, "Referencia");
                ListarDocumentos.ShowDialog(this);
            }
        }

        private void BuscarMontoDocumento()
        {
            try
            {
                //Buscamos el documento y asignamos los valores del mismo al formulario
                cCuentasPagar Cuenta;
                CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();

                Cuenta = ObjetoCuenta.BuscarPorID(txtDocumentoPagar.Text);
                if ((Int64)Cuenta.ProveedorID == (Int64)(cbbProveedores.SelectedValue))
                {
                    txtMonto.Text = Cuenta.Monto.ToString();
                    Monto_ = Cuenta.Monto;
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

        private void txtDocumentoPagar_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumentoPagar.Text != String.Empty)
                {
                    BuscarMontoDocumento();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "error al obtener monto de documento");
            }
        }

    }
}
