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


namespace SMA.Vendedor
{
    public partial class frmAgregarEditarVendedor : Office2007Form
    {
        private int? Codigo;
        VendedorBL ObjetoVendedor = new VendedorBL();

        public frmAgregarEditarVendedor()
        {
            InitializeComponent();
        }

        public frmAgregarEditarVendedor (int Codigo):this()
        {
           this.Codigo = Codigo;
        }
        private void frmAgregarEditarVendedor_Load(object sender, EventArgs e)
        {
            if(Codigo.HasValue)
            {
                try
                {
                    int ID = Convert.ToInt32(Codigo);
                    MostrarDatos(ObjetoVendedor.BuscarPorID(ID));
                }
                catch(Exception Ex)
                {
                    throw Ex;
                }
            }
            else
            {
                txtCodigo.Text = "-1";
            }
        }

        private void MostrarDatos(cVendedor Vendedor)
        {
            try
            {
                txtCodigo.Text = Vendedor.ID.ToString();
                txtNombre.Text = Vendedor.Nombre;
                txtApellido.Text = Vendedor.Apellido;
                txtCelular.Text = Vendedor.Celular;
                txtCedula.Text = Vendedor.Cedula;
                txtTelefono.Text = Vendedor.Telefono;
                txtComision.Text = Vendedor.Comision.ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al mostrar informacion de vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private cVendedor ObtenerDatos()
        {
            try
            {
                cVendedor Vendedor = new cVendedor();
                Vendedor.ID = Convert.ToInt32(txtCodigo.Text);
                Vendedor.Nombre = txtNombre.Text;
                Vendedor.Apellido = txtApellido.Text;
                Vendedor.Telefono = txtTelefono.Text;
                Vendedor.Celular = txtCelular.Text;
                Vendedor.Cedula = txtCedula.Text;
                Vendedor.Comision = ObtenerComision();

                return Vendedor;
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error en la obtencion de datos del vendedor" + ' ' + Ex.Message, "Error en obtencion de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private Decimal ObtenerComision()
        {
            if (txtComision.Text != String.Empty)
            {
                try
                {
                    return Convert.ToDecimal(txtComision.Text);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            else
            {
                return 0;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Guardmos los datos del vendedor
                ObjetoVendedor.GuardarCambios(ObtenerDatos());
                this.Close();
            }

            catch(Exception Ex)
            {
                //Error
                MessageBox.Show(Ex.Message, "Error al actualizar vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAceptar.Enabled = false;
            }
        }

        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            ValidacionCampos(txtNombre.Text, txtNombre);
        }

        private void ValidacionCampos(String Valor, Control Enviado)
        {
            //Validacion de nombre
            if (Valor == "")
            {
                epNombre.SetError(Enviado, "Debe especificar un valor para el campo");
                btnAceptar.Enabled = false;
               
            }
            else
            {
                epNombre.Clear();
                btnAceptar.Enabled = true;
            }
        }

        private void txtApellido_Validated(object sender, EventArgs e)
        {
            ValidacionCampos(txtApellido.Text, txtApellido);

        }

        private void txtCedula_Validated(object sender, EventArgs e)
        {
            ValidacionCampos(txtCedula.Text, txtCedula);
        }

        private void txtComision_Validated(object sender, EventArgs e)
        {
            ValidacionCampos(txtComision.Text, txtComision);
        }
    }
}
