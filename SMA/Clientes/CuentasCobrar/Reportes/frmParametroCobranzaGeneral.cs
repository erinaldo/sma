using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.BL;
using SMA.Entity;
using DevComponents.DotNetBar;


namespace SMA.Clientes.CuentasCobrar.Reportes
{
    public partial class frmParametroCobranzaGeneral : Office2007Form
    {
        private Int64? ClienteID;

        public frmParametroCobranzaGeneral()
        {
            InitializeComponent();
        }

        public frmParametroCobranzaGeneral(Int64 ClienteID):this()
        {
            this.ClienteID = ClienteID;
        }

        private void frmParametroCobranzaGeneral_Load(object sender, EventArgs e)
        {

            ClienteBL ObjetoCliente = new ClienteBL();
            //Si el parametro de Proveedor tiene algun valor entonces filtramos al Proveedor seleccionado para que
            //solo muestre informacion de este
            Int64 Codigo = Convert.ToInt64(ClienteID);
            cbbClienteDesde.DataSource = ObjetoCliente.Listar();
            cbbClienteHasta.DataSource = ObjetoCliente.Listar();

            cbbClienteDesde.ValueMember = "ID";
            cbbClienteHasta.ValueMember = "ID";
            cbbClienteDesde.DisplayMember = "NombreComercial";
            cbbClienteHasta.DisplayMember = "NombreComercial";

            if (ClienteID.HasValue)
            {
                cbbClienteDesde.SelectedValue = ClienteID;
                cbbClienteHasta.SelectedValue = ClienteID;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 ClienteDesde = Convert.ToInt64(cbbClienteDesde.SelectedValue.ToString());
                Int64 ClienteHasta = Convert.ToInt64(cbbClienteHasta.SelectedValue.ToString());
                DateTime FechaCorte = dtpFechaCorte.Value;

                CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                List<cReporteEstadoCuenta> Lista = ObjetoCuenta.ReporteDocumentosPorCobrar(ClienteDesde, ClienteHasta, FechaCorte);
                frmrptCobranzaGeneral DocumentosPorCobrar = new frmrptCobranzaGeneral(Lista);
                DocumentosPorCobrar.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
