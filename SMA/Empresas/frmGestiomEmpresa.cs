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

namespace SMA.Empresa
{
    public partial class frmGestiomEmpresa : Office2007Form
    {
        public frmGestiomEmpresa()
        {
            InitializeComponent();
        }

        private void frmGestiomEmpresa_Load(object sender, EventArgs e)
        {
            EmpresaBL ObjetoEmpresa=new EmpresaBL();
            cEmpresa Empresa = ObjetoEmpresa.Lista();
            MostrarDatos(Empresa);

        }

        private void MostrarDatos(cEmpresa Empresa)
        {
            txtID.Text = Empresa.ID.ToString();
            txtNombre.Text = Empresa.RazonSocial;
            txtTelefono.Text = Empresa.Telefono;
            txtDireccion.Text = Empresa.Direccion;
            txtProvincia.Text = Empresa.Provincia;
            txtRNC.Text = Empresa.RNC;
            txtCiudad.Text = Empresa.Ciudad;
            txtFax.Text = Empresa.Fax;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpresaBL ObjetoEmpresa = new EmpresaBL();
                ObjetoEmpresa.Actualizar(ObtenerDatos());
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al actualizar empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private cEmpresa ObtenerDatos()
        {
            cEmpresa Empresa = new cEmpresa();
            Empresa.ID = Convert.ToInt32(txtID.Text);
            Empresa.RazonSocial = txtNombre.Text;
            Empresa.Telefono = txtTelefono.Text;
            Empresa.RNC = txtRNC.Text;
            Empresa.Provincia = txtProvincia.Text;
            Empresa.Fax = txtFax.Text;
            Empresa.Ciudad = txtCiudad.Text;
            Empresa.Direccion = txtDireccion.Text;

            return Empresa;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
