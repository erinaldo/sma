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

namespace SMA.Clientes
{
    public partial class frmAgregarEditarCliente : Office2007Form, iAgregarEditarCliente
    {

        private Int32? Codigo;
        private Int32 CodigoContacto;
        private frmGestionClientes GestionClientes;

        #region Implementacion de Interface
        public void SeleccionarVendedor(Int32 ID)
        {
            cbbVendedor.SelectedValue = ID;
        }
        #endregion

        #region Procedimientos y funciones

        //Carga los combobox con informacion del cliente
        private void CargarDependencias()
        {
            VendedorBL ObjetoVendedor = new VendedorBL();
            cbbVendedor.DataSource = ObjetoVendedor.Listar();
            cbbVendedor.DisplayMember = "Nombre";
            cbbVendedor.ValueMember = "Codigo";
            cbbVendedor.SelectedValue = -1;

            TipoComprobanteFiscalBL ObjetoTipoCombrobante = new TipoComprobanteFiscalBL();
            cbbTipoComprobante.DataSource = ObjetoTipoCombrobante.Listar();
            cbbTipoComprobante.DisplayMember = "Descripcion";
            cbbTipoComprobante.ValueMember = "Codigo";
            cbbTipoComprobante.SelectedValue = -1;
        }

        //Muestra la informacion de cliente seleccionado
        private void MostrarDatos(cCliente Cliente)
        {
            try
            {
                //Mostramos la informacion del cliente buscado
                txtCodigoCliente.Text = Convert.ToString(Cliente.Codigo);
                txtNombreCliente.Text = Cliente.NombreComercial;
                txtDireccion.Text = Cliente.Direccion;
                txtCiudad.Text = Cliente.Ciudad;
                txtProvincia.Text = Cliente.Provincia;
                txtEmail.Text = Cliente.Correo;
                txtRNC_Cedula.Text = Cliente.RNC;
                txtTelefono.Text = Cliente.Telefono;
                txtFax.Text = Cliente.Fax;
                txtObservacion.Text = Cliente.Observaciones;
                //txtTelefono2.Text = Cliente.Telefono2;
                txtWeb.Text = Cliente.PaginaWeb;
                cbEstatus.Checked = (Boolean)Cliente.EstatusID;
                txtLimiteCredito.Text = Cliente.LimiteCredito.ToString();
                nudDiasCredito.Value = Cliente.DiasCredito;
                cbbVendedor.SelectedValue = Cliente.VendedorID;
                cbbTipoComprobante.SelectedValue = Cliente.TipoComprobanteID;
                nudDescuento.Value = Cliente.Descuento;
                txtFechaCreacion.Text = Cliente.FechaCreacion.ToShortDateString();
                txtFechaModificacion.Text = Cliente.FechaModificacion.ToShortDateString();
                txtFechaUltVenta.Text = Cliente.UltFechaVenta.ToString();
                txtUltDocVenta.Text = Cliente.UltDocVenta.ToString();
                txtUltMontoVenta.Text = Cliente.UltMontoVenta.ToString("C2");
                txtDocUltPago.Text = Cliente.UltDocPago.ToString();
                txtMontoUltPago.Text = Cliente.UltMontoPago.ToString("C2");
                txtFechaUltPago.Text = Cliente.UltFechaPago.ToString();
                txtSaldo.Text = Cliente.Balance.ToString();
                CargarContactos(Cliente.Codigo);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void CargarContactos(Int32 Codigo)
        {
            try
            {
                ContactosClientesBL ObjetoContacto = new ContactosClientesBL();
                dgvContactos.AutoGenerateColumns = false;
                dgvContactos.DataSource = ObjetoContacto.Listar(Codigo);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        //Obtenemos el numero de vendedor
        private Int32 ObtenerVendedor(String Valor)
        {
            //Obtenemos el valor del vendedor seleccionado
            try
            {
                Int32 ID;
                if (Int32.TryParse(Valor, out ID))
                {
                    return Convert.ToInt32(Valor);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        //Obtenemos los datos de los controles
        private cCliente ObtenerDatos()
        {
            cCliente Cliente = new cCliente();

            Cliente.Codigo = Convert.ToInt32(txtCodigoCliente.Text);
            Cliente.NombreComercial = txtNombreCliente.Text;
            Cliente.EstatusID = cbEstatus.Checked;
            Cliente.Direccion = txtDireccion.Text;
            Cliente.Ciudad = txtCiudad.Text;
            Cliente.Provincia = txtProvincia.Text;
            Cliente.Correo = txtEmail.Text;
            Cliente.RNC = txtRNC_Cedula.Text;
            Cliente.Telefono = txtTelefono.Text;
            //Cliente.Telefono2 = txtTelefono2.Text;
            Cliente.Fax = txtFax.Text;
            Cliente.Observaciones = txtObservacion.Text;
            Cliente.Correo = txtEmail.Text;
            Cliente.LimiteCredito = ObtenerLimite(txtLimiteCredito.Text);
            Cliente.DiasCredito = ObtenerDiasCredito(nudDiasCredito.Value.ToString());
            Cliente.VendedorID = ObtenerVendedor();
            Cliente.Descuento = nudDescuento.Value;
            Cliente.TipoComprobanteID = ObtenerTipoComprobante();
            Cliente.PaginaWeb = txtWeb.Text;
            Cliente.Balance = ObtenerSaldo();
            return Cliente;
        }

        private int ObtenerDiasCredito(String p)
        {
            Int32 Valor;
            if (Int32.TryParse(p, out Valor))
            {
                return Convert.ToInt32(p);
            }
            else
            {
                return 0;
            }
        }

        private Decimal ObtenerLimite(string p)
        {
            Decimal Valor;
            if (Decimal.TryParse(p, out Valor))
            {
                return Convert.ToDecimal(p);
            }
            else
            {
                return 0;
            }
        }

        private Decimal ObtenerSaldo()
        {
            if (txtSaldo.Text != String.Empty)
            {
                Decimal Valor;
                if (Decimal.TryParse(txtSaldo.Text, out Valor))
                {
                    return Convert.ToDecimal(txtSaldo.Text);
                }
                else
                {
                    throw new Exception("Error al obtener valor de saldo cliente");
                }
            }
            else
            {
                return 0;
            }
        }

        private Int32 ObtenerVendedor()
        {
            Int32 Vendedor;

            if (cbbVendedor.Text != string.Empty)
            {
                if (Int32.TryParse(cbbVendedor.SelectedValue.ToString(), out Vendedor))
                {
                    return Convert.ToInt32(cbbVendedor.SelectedValue.ToString());
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

        private SByte ObtenerTipoComprobante()
        {
            SByte TipoComprobante;

            if (cbbTipoComprobante.Text != string.Empty)
            {
                if (SByte.TryParse(cbbTipoComprobante.SelectedValue.ToString(), out TipoComprobante))
                {
                    return Convert.ToSByte(cbbTipoComprobante.SelectedValue.ToString());
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

        //Valida los campos obligatorios
        private void ValidacionCampos(String Valor, Control Enviado)
        {
            //Validamos que el valor no esta vacio
            if (Valor != "")
            {
                epNombre.Clear();
                btnAceptar.Enabled = true;
            }
            else
            {
                //Configuramos el error provider para que muestre el error en el campo
                epNombre.SetError(Enviado, "Debe especificar un valor para continuar");
                btnAceptar.Enabled = false;
            }
        }

        //Agrega o actualiza un contacto relacionado al cliente
        internal void GuardarContacto(cContactos Contacto)
        {
            try
            {
                if (Codigo.HasValue)
                {
                    Int32 Codigo_ = Convert.ToInt32(Codigo);
                    //ASIGNAMOS EL CONTACTO AL CLIENTE
                    Contacto.CodigoCliente = Codigo_;
                    ContactosClientesBL ObjetoContacto = new ContactosClientesBL();
                    ObjetoContacto.GuardarCambios(Contacto);
                    CargarContactos(Codigo_);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region Constructores

        public frmAgregarEditarCliente()
        {
            InitializeComponent();
        }

        public frmAgregarEditarCliente(Int32 Codigo, frmGestionClientes GestionClientes)
            : this()
        {
            this.Codigo = Codigo;
            this.GestionClientes = GestionClientes;
        }

        public frmAgregarEditarCliente(frmGestionClientes GestionClientes)
            : this()
        {
            this.GestionClientes = GestionClientes;
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                ClienteBL ObjetoCliente = new ClienteBL();
                //Guardamos los cambios a la lista de clientes
                ObjetoCliente.GuardarCambios(ObtenerDatos());
                //Actualizamos la lista de clientes
                GestionClientes.ActualizarLista();
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Existen errores, la operacion no puede ser completada", "Error en operacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombreCliente_Validated(object sender, EventArgs e)
        {
            ValidacionCampos(txtNombreCliente.Text, txtNombreCliente);
        }




        private void btnListaVendedores_Click(object sender, EventArgs e)
        {
            Vendedor.frmListaVendedor ListaVendedores = new Vendedor.frmListaVendedor();
            ListaVendedores.Show(this);
        }

        private void txtRNC_Cedula_Validated(object sender, EventArgs e)
        {
            ValidacionCampos(txtRNC_Cedula.Text, txtRNC_Cedula);
        }

        private void frmAgregarEditarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmAgregarEditarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDependencias();
                if (Codigo.HasValue)
                {
                    ClienteBL ObjetoCliente = new ClienteBL();
                    Int32 ID = Convert.ToInt32(Codigo);
                    MostrarDatos(ObjetoCliente.BuscarPorID(ID));

                    txtSaldo.ReadOnly = false;
                }
                else
                {
                    txtCodigoCliente.Text = "-1";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error editar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgrContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Codigo.HasValue)
                {
                    frmAgregarEditarContacto AgregarContacto = new frmAgregarEditarContacto(this);
                    AgregarContacto.Text = "Agregar contacto <<" + txtNombreCliente.Text + ">>";
                    AgregarContacto.ShowDialog(this);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


        private void btnEditContacto_Click(object sender, EventArgs e)
        {
            try
            {
                ContactosClientesBL ObjetoContacto = new ContactosClientesBL();
                cContactos Contacto = ObjetoContacto.BuscarPorID(CodigoContacto);
                if (Contacto != null)
                {
                    frmAgregarEditarContacto EditarContacto = new frmAgregarEditarContacto(Contacto, this);
                    EditarContacto.Text = "Editar contacto <<" + txtNombreCliente.Text + ">>";
                    EditarContacto.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("Error al tratar de mostrar contacto, por favor vuelva a internarlo", "Error en edicion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnElimContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Codigo.HasValue)
                {
                    Int32 Codigo_ = Convert.ToInt32(Codigo);
                    DialogResult Resultado = MessageBox.Show("Esta seguro que desea eliminar el contaco", "Eliminar contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resultado == DialogResult.Yes)
                    {
                        ContactosClientesBL ObjetoContacto = new ContactosClientesBL();
                        ObjetoContacto.Eliminar(CodigoContacto);
                        CargarContactos(Codigo_);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                CodigoContacto = Convert.ToInt32(dgvContactos.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAgregarDir_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarDir_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarDir_Click(object sender, EventArgs e)
        {

        }


    }
}
