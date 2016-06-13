using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.Entity;
using SMA.BL;

namespace SMA.Clientes.CuentasPagar
{
    public partial class frmInfoCliente : Office2007Form
    {
        private Int32 CodigoCliente;

        public frmInfoCliente()
        {
            InitializeComponent();
        }

        public frmInfoCliente(Int32 CodigoCliente):this()
        {
            this.CodigoCliente = CodigoCliente;
        }
        private void frmInfoCliente_Load(object sender, EventArgs e)
        {
            try
            {
                ClienteBL ObjetoCliente = new ClienteBL();
                MostrarDatos(ObjetoCliente.BuscarPorID(CodigoCliente));
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void MostrarDatos(cCliente Cliente)
        {
            //Mostramos los datos del cliente
            //txtAtencionCobros.Text = Cliente.ContactoCobros;
            txtTelefono.Text = Cliente.Telefono;
            txtEmail.Text = Cliente.Correo;
            txtDiasCredito.Text = Cliente.DiasCredito.ToString();
            txtLimiteCredito.Text = Cliente.LimiteCredito.ToString("C2");
            txtBalance.Text = Cliente.Balance.ToString("C2");
            
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
