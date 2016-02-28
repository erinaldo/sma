using Microsoft.Reporting.WinForms;
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

namespace SMA.Compras.Reportes
{
    public partial class frmrptResumenRecepciones : Office2007Form
    {
        private List<cReporteResumenFactura> Lista;

        public frmrptResumenRecepciones()
        {
            InitializeComponent();
        }

        public frmrptResumenRecepciones(List<cReporteResumenFactura> Lista):this()
        {
            this.Lista = Lista;
        }

        private void frmrptResumenRecepciones_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();

            try
            {
                Datasource.Name = "dsResumenFacturas";
                Datasource.Value = Lista;
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
