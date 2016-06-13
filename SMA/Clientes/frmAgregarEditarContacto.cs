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
    public partial class frmAgregarEditarContacto : Office2007Form
    {
        private frmAgregarEditarCliente frmAgregarEditarCliente;
        private cContactos Contacto;

        
        public frmAgregarEditarContacto()
        {
            InitializeComponent();
        }

        public frmAgregarEditarContacto(frmAgregarEditarCliente frmAgregarEditarCliente):this()
        {
            // TODO: Complete member initialization
            this.frmAgregarEditarCliente = frmAgregarEditarCliente;
        }

        public frmAgregarEditarContacto(cContactos Contacto, Clientes.frmAgregarEditarCliente frmAgregarEditarCliente):this()
        {
            // TODO: Complete member initialization
            this.Contacto = Contacto;
            this.frmAgregarEditarCliente = frmAgregarEditarCliente;
        }

       
        private void frmAgregarEditarContacto_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDepartamentos();

                if (Contacto!=null)
                {
                    MostrarDatos(Contacto);
                }
                else
                {
                    txtCodigo.Text = "-1";
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CargarDepartamentos()
        {
            ContactosClientesBL ObjetoContacto = new ContactosClientesBL();
            cbbDepartamento.DataSource = ObjetoContacto.ListarDepartamentos();
            cbbDepartamento.DisplayMember = "Descripcion";
            cbbDepartamento.ValueMember = "Codigo";
        }

        private void MostrarDatos(cContactos Contacto)
        {
            txtCodigo.Text = Contacto.Codigo.ToString();
            txtNombre.Text = Contacto.Nombre;
            txtCargo.Text = Contacto.Cargo;
            cbbDepartamento.SelectedValue = ObtenerDepartamento(Contacto.CodigoDepartamento);
            txtTelefono1.Text = Contacto.Telefono1;
            txtTelefono2.Text = Contacto.Telefono2;
            txtFax1.Text = Contacto.Fax1;
            txtFax2.Text = Contacto.Fax2;
            txtCorreo.Text = Contacto.Correo;
            txtNotas.Text = Contacto.Notas;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarCliente.GuardarContacto(ObtenerDatos());
            this.Close();
        }

        private cContactos ObtenerDatos()
        {
            cContactos Contacto = new cContactos();
            Contacto.Codigo = Convert.ToInt32(txtCodigo.Text);
            Contacto.Nombre = txtNombre.Text;
            Contacto.CodigoDepartamento = ObtenerDepartamento(cbbDepartamento.SelectedValue);
            Contacto.Cargo = txtCargo.Text;
            Contacto.Correo = txtCorreo.Text;
            Contacto.Telefono1 = txtTelefono1.Text;
            Contacto.Telefono2 = txtTelefono2.Text;
            Contacto.Fax1 = txtFax1.Text;
            Contacto.Fax2 = txtFax2.Text;
            Contacto.Notas = txtNotas.Text;
            //Contacto.CodigoCliente = ;

            return Contacto;
        }

        private SByte? ObtenerDepartamento(object p)
        {
            //OBTENEMOS EL CODIGO DE DEPARTAMENTO
            try
            {
                if (p != null)
                {
                    SByte Codigo = Convert.ToSByte(p.ToString());
                    return Codigo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
