using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SMA.Clientes
{
    public partial class frmBuscarCliente : Office2007Form
    {
        public frmGestionClientes GestionCliente;

        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        public frmBuscarCliente(frmGestionClientes GestionCliente):this()
        {
            this.GestionCliente = GestionCliente;
        }
        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GestionCliente.BuscarCliente(cbbBusqueda.Text, txtStringFind.Text);
            DialogResult Resultado = MessageBox.Show("Desea realizar otra busqueda", "Busqueda de clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado==DialogResult.No)
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
