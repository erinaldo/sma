using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SMA.Entity;
using SMA.BL;
using DevComponents.DotNetBar;

namespace SMA.Factura.Reportes
{
    public partial class frmrptCuadreCaja : Form
    {
        List<cMovCajaCobro> ListaCaja;

        public frmrptCuadreCaja()
        {
            InitializeComponent();
        }

        public frmrptCuadreCaja(List<cMovCajaCobro> ListaCaja):this()
        {
            this.ListaCaja = ListaCaja;
        }
        private void frmrptCuadreCaja_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();
            FacturaBL ObjetoFactura = new FacturaBL();

            try
            {
                Datasource.Name = "dsCaja";
                Datasource.Value = ListaCaja;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(Datasource);
                //reportViewer1.LocalReport.ReportEmbeddedResource = "GESTGYM.Cliente.Reportes.Formularios.rptListaClientes.rdlc";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
