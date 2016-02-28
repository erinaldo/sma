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
    public partial class frmrptResumenNCF : Form
    {
        List<cReporteFactura> ListaFactura;

        public frmrptResumenNCF()
        {
            InitializeComponent();
        }

        public frmrptResumenNCF(List<cReporteFactura> listaFactura):this()
        {
            this.ListaFactura = listaFactura;    
        }

        private void frmrptResumenNCF_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();
            FacturaBL ObjetoFactura = new FacturaBL();

            try
            {
                Datasource.Name = "dsRelacionNCF";
                Datasource.Value = ListaFactura;
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
