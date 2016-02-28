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
        private Int64? ClienteID;
        Decimal Monto_;

        #region Constructores
        public frmRecibirPago()
        {
            InitializeComponent();
        }


        public frmRecibirPago(Int64 ClienteID):this()
        {
            this.ClienteID = ClienteID;
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

                if (ClienteID.HasValue)
                {
                    cbbClientes.DataSource = ObjetoCliente.Filtrar(ClienteID, ClienteID, null, null, null);
                    cbbClientes.DisplayMember = "NombreComercial";
                    cbbClientes.ValueMember = "ID";
                }
                else
                {
                    cbbClientes.DataSource = ObjetoCliente.Listar();
                    cbbClientes.DisplayMember = "NombreComercial";
                    cbbClientes.ValueMember = "ID";
                }


                ConceptoCxCBL ObjetoConcepto = new ConceptoCxCBL();
                cbbConcepto.DataSource = ObjetoConcepto.ListarConceptoAbono();
                cbbConcepto.DisplayMember = "Descripcion";
                cbbConcepto.ValueMember = "ID";
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
                Int32 Concepto = ObtenerConcepto();             //Codigo del concepto
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
                        Cuenta.ID = -1;
                        Cuenta.ConceptoID = Item.Cells[0].Value;
                        Cuenta.ClienteID = ObtenerCliente();
                        Cuenta.DocumentoID = Item.Cells[2].Value;
                        Cuenta.ReferenciaID = Item.Cells[3].Value.ToString();
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

        private Int64 ObtenerCliente()
        {
            Int64 Codigo;
            if(Int64.TryParse(cbbClientes.SelectedValue.ToString(),out Codigo))
            {
                return Convert.ToInt64(cbbClientes.SelectedValue.ToString());
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

private void txtDocumentoPagar_Validated(object sender, EventArgs e)
{
    if (txtDocumentoPagar.Text != string.Empty)
    {
        BuscarMontoDocumento();
    }
}

private void BuscarMontoDocumento()
{
    try
    {
        //Buscamos el documento y asignamos los valores del mismo al formulario
        cCuentasCobrar Cuenta;
        CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();

        Cuenta = ObjetoCuenta.BuscarPorID(txtDocumentoPagar.Text);
        if ((Int64)Cuenta.ClienteID == (Int64)(cbbClientes.SelectedValue))
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

       

        private void LimpiarCampos()
        {
            txtMonto.Text = "0.00";
            txtDocumentoPagar.Text = "";
            txtDocumentoPagar.Focus();
        }

        private void btnVerDocumento_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
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
        
    }
}
