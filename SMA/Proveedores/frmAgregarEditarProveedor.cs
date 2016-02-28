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
using SMA.Proveedores;


namespace SMA.Clientes
{
    public partial class frmAgregarEditarProveedor : Office2007Form
    {
        private Int64? ProveedorID;
        private frmGestionProveedores GestionProveedor;
        public frmAgregarEditarProveedor()
        {
            InitializeComponent();
        }

        public frmAgregarEditarProveedor(Int64 ProveedorID, frmGestionProveedores GestionProveedor): this()
        {
            this.ProveedorID = ProveedorID;
            this.GestionProveedor = GestionProveedor;
        }

        public frmAgregarEditarProveedor(frmGestionProveedores GestionProveedor):this()
        {
            this.GestionProveedor = GestionProveedor;
        }

        private void frmAgregarEditarProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                if (ProveedorID.HasValue)
                {
                    Int64 Codigo = (Int64)ProveedorID;
                    ProveedorBL ObjetoProveedor = new ProveedorBL();
                    MostrarDatos(ObjetoProveedor.BuscarPorID(Codigo));
                    txtBalance.ReadOnly = true;
                }
                else
                {
                    //INICIALIZAMOS CAMPOS REQUERIDOS
                    txtCodigoProveedor.Text = "-1";
                    txtBalance.Text = "0.00";
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ProveedorBL ObjetoCliente = new ProveedorBL();
                //Realiza los cambios
                ObjetoCliente.GuardarCambios(ObtenerDatos());
                //Actualiza la lista de proveedores
                GestionProveedor.ActualizarLista();
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

        private void MostrarDatos(cProveedor Proveedor)
        {
            //Mostramos la informacion del Proveedor buscado
            txtCodigoProveedor.Text = Convert.ToString(Proveedor.ID);
            txtNombreProveedor.Text = Proveedor.NombreComercial;
            txtDireccion.Text = Proveedor.Direccion;
            txtCiudad.Text = Proveedor.Ciudad;
            txtProvincia.Text = Proveedor.Provincia;
            txtEmail.Text = Proveedor.Correo;
            txtRNC_Cedula.Text = Proveedor.RNC;
            txtTelefono.Text = Proveedor.Telefono;
            txtFax.Text = Proveedor.Fax;
            txtObservacion.Text = Proveedor.Observaciones;
            txtTelefono2.Text = Proveedor.Telefono2;
            txtWeb.Text = Proveedor.PaginaWeb;
            cbEstatus.Checked = (Boolean)Proveedor.EstatusID;
            txtLimiteCredito.Text = Proveedor.LimiteCredito.ToString();
            nudDiasCredito.Value = Proveedor.DiasCredito;
            txtContactoVenta.Text = Proveedor.ContactoPagos;
            txtContactoCobro.Text = Proveedor.ContactoCompras;
            txtFechaCreacion.Text = Proveedor.FechaCreacion.ToShortDateString();
            txtFechaModificacion.Text = Proveedor.FechaModificacion.ToShortDateString();
            txtFechaUltVenta.Text = Proveedor.UltFechaCompra.ToString();
            txtUltDocVenta.Text = Proveedor.UltDocCompra.ToString();
            txtUltMontoVenta.Text = Proveedor.UltMontoCompra.ToString();
            txtDocUltPago.Text = Proveedor.UltDocPago.ToString();
            txtMontoUltPago.Text = Proveedor.UltMontoPago.ToString();
            txtFechaUltPago.Text = Proveedor.UltFechaPago.ToString();
            txtBalance.Text = Proveedor.Balance.ToString();
        }


        private cProveedor ObtenerDatos()
        {
            cProveedor Proveedor = new cProveedor();

            Proveedor.ID = Convert.ToInt64(txtCodigoProveedor.Text);
            Proveedor.NombreComercial = txtNombreProveedor.Text;
            Proveedor.EstatusID = cbEstatus.Checked;
            Proveedor.Direccion = txtDireccion.Text;
            Proveedor.Ciudad = txtCiudad.Text;
            Proveedor.Provincia = txtProvincia.Text;
            Proveedor.Correo = txtEmail.Text;
            Proveedor.RNC = txtRNC_Cedula.Text;
            Proveedor.Telefono = txtTelefono.Text;
            Proveedor.Telefono2 = txtTelefono2.Text;
            Proveedor.Fax = txtFax.Text;
            Proveedor.Observaciones = txtObservacion.Text;
            Proveedor.Correo = txtEmail.Text;
            Proveedor.LimiteCredito = ObtenerLimite(txtLimiteCredito.Text);
            Proveedor.DiasCredito = ObtenerDiasCredito(nudDiasCredito.Value.ToString());
            Proveedor.ContactoCompras = txtContactoVenta.Text;
            Proveedor.ContactoPagos = txtContactoCobro.Text;
            Proveedor.PaginaWeb = txtWeb.Text;
            Proveedor.Balance =ObtenerBalance();
            return Proveedor;
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

        private Decimal ObtenerBalance()
        {
            if(txtBalance.Text!=String.Empty)
            {
                Decimal Valor;
                if (Decimal.TryParse(txtBalance.Text, out Valor))
                {
                    return Convert.ToDecimal(txtBalance.Text);
                }
                else
                {
                    throw new Exception("Error al obtener valor del balance");
                }
            } 
            else 
            {
                return 0;
            }
        }

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


        private void txtRNC_Cedula_Validated(object sender, EventArgs e)
        {
            ValidacionCampos(txtRNC_Cedula.Text, txtRNC_Cedula);
        }

        private void txtNombreProveedor_Validated(object sender, EventArgs e)
        {
            ValidacionCampos(txtNombreProveedor.Text, txtNombreProveedor);
        }
    }
}
