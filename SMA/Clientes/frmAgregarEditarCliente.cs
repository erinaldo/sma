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

        private Int64? Codigo;
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
            cbbVendedor.ValueMember = "ID";
            cbbVendedor.SelectedValue = -1;

            TipoComprobanteFiscalBL ObjetoTipoCombrobante = new TipoComprobanteFiscalBL();
            cbbTipoComprobante.DataSource = ObjetoTipoCombrobante.Listar();
            cbbTipoComprobante.DisplayMember = "Descripcion";
            cbbTipoComprobante.ValueMember = "ID";
            cbbTipoComprobante.SelectedValue = -1;
        }

        //Muestra la informacion de cliente seleccionado
        private void MostrarDatos(cCliente Cliente)
        {
            try
            {
                //Mostramos la informacion del cliente buscado
                txtCodigoCliente.Text = Convert.ToString(Cliente.ID);
                txtNombreCliente.Text = Cliente.NombreComercial;
                txtDireccion.Text = Cliente.Direccion;
                txtCiudad.Text = Cliente.Ciudad;
                txtProvincia.Text = Cliente.Provincia;
                txtEmail.Text = Cliente.Correo;
                txtRNC_Cedula.Text = Cliente.RNC;
                txtTelefono.Text = Cliente.Telefono;
                txtFax.Text = Cliente.Fax;
                txtObservacion.Text = Cliente.Observaciones;
                txtTelefono2.Text = Cliente.Telefono2;
                txtWeb.Text = Cliente.PaginaWeb;
                cbEstatus.Checked = (Boolean)Cliente.EstatusID;
                txtLimiteCredito.Text = Cliente.LimiteCredito.ToString();
                nudDiasCredito.Value = Cliente.DiasCredito;
                cbbVendedor.SelectedValue = Cliente.VendedorID;
                cbbTipoComprobante.SelectedValue = Cliente.TipoComprobanteID;
                txtContactoVenta.Text = Cliente.ContactoVentas;
                txtContactoCobro.Text = Cliente.ContactoCobros;
                txtDescuento.Text = Cliente.Descuento.ToString();
                txtFechaCreacion.Text = Cliente.FechaCreacion.ToShortDateString();
                txtFechaModificacion.Text = Cliente.FechaModificacion.ToShortDateString();
                txtFechaUltVenta.Text = Cliente.UltFechaVenta.ToString();
                txtUltDocVenta.Text = Cliente.UltDocVenta.ToString();
                txtUltMontoVenta.Text = Cliente.UltMontoVenta.ToString("C2");
                txtDocUltPago.Text = Cliente.UltDocPago.ToString();
                txtMontoUltPago.Text = Cliente.UltMontoPago.ToString("C2");
                txtFechaUltPago.Text = Cliente.UltFechaPago.ToString();
                txtSaldo.Text = Cliente.Balance.ToString();
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

            Cliente.ID = Convert.ToInt64(txtCodigoCliente.Text);
            Cliente.NombreComercial = txtNombreCliente.Text;
            Cliente.EstatusID = cbEstatus.Checked;
            Cliente.Direccion = txtDireccion.Text;
            Cliente.Ciudad = txtCiudad.Text;
            Cliente.Provincia = txtProvincia.Text;
            Cliente.Correo = txtEmail.Text;
            Cliente.RNC = txtRNC_Cedula.Text;
            Cliente.Telefono = txtTelefono.Text;
            Cliente.Telefono2 = txtTelefono2.Text;
            Cliente.Fax = txtFax.Text;
            Cliente.Observaciones = txtObservacion.Text;
            Cliente.Correo = txtEmail.Text;
            Cliente.LimiteCredito = ObtenerLimite(txtLimiteCredito.Text);
            Cliente.DiasCredito = ObtenerDiasCredito(nudDiasCredito.Value.ToString());
            Cliente.VendedorID = ObtenerVendedor();
            Cliente.ContactoVentas = txtContactoVenta.Text;
            Cliente.ContactoCobros = txtContactoCobro.Text;
            Cliente.Descuento = ObtenerDescuento(txtDescuento.Text);
            Cliente.TipoComprobanteID = ObtenerTipoComprobante();
            Cliente.PaginaWeb = txtWeb.Text;
            Cliente.Balance = ObtenerSaldo();
            return Cliente;
        }

        private int ObtenerDiasCredito(String p)
        {
            Int32 Valor;
            if(Int32.TryParse(p,out Valor))
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
                if(Decimal.TryParse(p,out Valor))
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
            if(txtSaldo.Text!=String.Empty)
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
        
        private Int32 ObtenerTipoComprobante()
        {
            Int32 TipoComprobante;

            if (cbbTipoComprobante.Text != string.Empty)
            {
                if (Int32.TryParse(cbbTipoComprobante.SelectedValue.ToString(), out TipoComprobante))
                {
                    return Convert.ToInt32(cbbTipoComprobante.SelectedValue.ToString());
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
        
        //Obtenemos el valor del descuento
        private Decimal ObtenerDescuento(String Valor)
        {
            //Convertimos el valor en Entero
            if (Valor != String.Empty)
            {
                Decimal ID;
                if (Decimal.TryParse(Valor, out ID))
                {
                    return Convert.ToDecimal(Valor);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
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

        #endregion
        
        public frmAgregarEditarCliente()
        {
            InitializeComponent();
        }

        public frmAgregarEditarCliente(Int64 Codigo,frmGestionClientes GestionClientes):this()
        {
            this.Codigo = Codigo;
            this.GestionClientes = GestionClientes;
        }

        public frmAgregarEditarCliente(frmGestionClientes GestionClientes):this()
        {
            this.GestionClientes = GestionClientes;
        }

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
            ValidacionCampos(txtNombreCliente.Text,txtNombreCliente);
        }

     

      
        private void btnListaVendedores_Click(object sender, EventArgs e)
        {
            Vendedor.frmListaVendedor ListaVendedores=new Vendedor.frmListaVendedor();
            ListaVendedores.Show(this);
        }

        private void txtRNC_Cedula_Validated(object sender, EventArgs e)
        {
            ValidacionCampos(txtRNC_Cedula.Text, txtRNC_Cedula);
        }

        private void frmAgregarEditarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmAgregarEditarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDependencias();
                if(Codigo.HasValue)
                {
                    ClienteBL ObjetoCliente = new ClienteBL();
                    Int64 ID = Convert.ToInt64(Codigo);
                    MostrarDatos(ObjetoCliente.BuscarPorID(ID));
                    txtSaldo.ReadOnly = false;
                }
                else
                {
                    txtCodigoCliente.Text = "-1";
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error editar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
