using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SMA.Vendedor
{
    public partial class frmBuscarVendedor : Office2007Form
    {
        private frmGestionVendedor GestionVendedor;

        public frmBuscarVendedor()
        {
            InitializeComponent();
        }
        public frmBuscarVendedor(frmGestionVendedor GestionVendedor):this()
        {
            this.GestionVendedor = GestionVendedor;
        }

        private void frmBuscarVendedor_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GestionVendedor.BuscarVendedor(cbbBusqueda.Text, txtStringFind.Text);
            DialogResult Resultado = MessageBox.Show("Desea realizar otra busqueda", "Busqueda de vendedores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
