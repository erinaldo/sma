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

namespace SMA.Factura.Reportes
{
    public partial class frmParametroRelacionFacturasNCF : Office2007Form
    {
        public frmParametroRelacionFacturasNCF()
        {
            InitializeComponent();
        }

        private void frmParametroRelacionFacturasNCF_Load(object sender, EventArgs e)
        {
            try
            {
                //CLIENTES
                ClienteBL ObjetoCliente = new ClienteBL();
                cbbClienteDesde.DataSource = ObjetoCliente.Listar();
                cbbClienteDesde.ValueMember = "ID";
                cbbClienteDesde.DisplayMember = "NombreComercial";
                cbbClienteDesde.SelectedValue = -1;


                cbbClienteHasta.DataSource = ObjetoCliente.Listar();
                cbbClienteHasta.ValueMember = "ID";
                cbbClienteHasta.DisplayMember = "NombreComercial";
                cbbClienteHasta.SelectedValue = -1;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde = dtpFechaDesde.Value;
            DateTime FechaHasta = dtpFechaHasta.Value;

            Int64? ClienteDesde = ObtenerCodigo(cbbClienteDesde.SelectedValue);
            Int64? ClienteHasta = ObtenerCodigo(cbbClienteHasta.SelectedValue);

            FacturaBL ObjetoFactura = new FacturaBL();

            List<cReporteFactura> Lista = ObjetoFactura.ResumenNCF(FechaDesde, FechaHasta, ClienteDesde, ClienteHasta);

            frmrptResumenNCF ResumenNCF = new frmrptResumenNCF(Lista);
            ResumenNCF.ShowDialog(this);
        }

        private Int64? ObtenerCodigo(object p)
        {
            //Obtenemos el codigo de cliente
            
            if(p!=null)
            {
                return Convert.ToInt64(p.ToString());
            }
            else
            {
               return null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
