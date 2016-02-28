using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.BL;
using DevComponents.DotNetBar;


namespace SMA.Clientes
{
    public partial class frmBuscarProveedor : Office2007Form
    {
        private frmGestionProveedores GestionProveedor;

        public frmBuscarProveedor()
        {
            InitializeComponent();
        }

        public frmBuscarProveedor(frmGestionProveedores GestionProveedor):this()
        {
            this.GestionProveedor = GestionProveedor;
        }

        private void frmBuscarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GestionProveedor.BuscarProveedor(cbbBusqueda.Text, txtStringFind.Text);
            DialogResult Resultado = MessageBox.Show("Desea realizar otra busqueda", "Busqueda de proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.No)
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
