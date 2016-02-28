using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.Entity;
using SMA.BL;
using DevComponents.DotNetBar;

namespace SMA.Clientes.CuentasPagar
{
    public partial class frmInfoProveedor : Office2007Form
    {

        private Int32 ProveedorID;

        public frmInfoProveedor()
        {
            InitializeComponent();
        }


        public frmInfoProveedor(Int32 ProveedorID):this()
        {
            //CODIGO DE PROVEEDOR
            this.ProveedorID = ProveedorID;
        }

        private void frmInfoProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                //BUSQUEDA DE PROVEEDOR POR CODIGO
                ProveedorBL ObjetoProveedor = new ProveedorBL();
                MostrarDatos(ObjetoProveedor.BuscarPorID(ProveedorID));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MostrarDatos(cProveedor Proveedor)
        {
            //Mostramos los datos del proveedor
            txtAtencionCobros.Text = Proveedor.ContactoPagos;
            txtTelefono.Text = Proveedor.Telefono;
            txtEmail.Text = Proveedor.Correo;
            txtDiasCredito.Text = Proveedor.DiasCredito.ToString("C2");
            txtLimiteCredito.Text = Proveedor.LimiteCredito.ToString("C2");
            txtBalance.Text = Proveedor.Balance.ToString("C2");

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //CIERRE FORMULARIO
            this.Close();
        }
    }
}
