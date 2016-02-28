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
using Microsoft.Reporting.WinForms;

namespace SMA.Factura.Reportes
{
    public partial class frmrptCotizacion : Office2007Form
    {
        private Int64 FacturaID;

        public frmrptCotizacion()
        {
            InitializeComponent();
        }

        public frmrptCotizacion(Int64 FacturaID):this()
        {
            this.FacturaID = FacturaID;
        }
        private void frmrptCotizacion_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();
            FacturaBL ObjetoFactura = new FacturaBL();

            try
            {
                Datasource.Name = "dsReporteFactura";
                Datasource.Value = ObjetoFactura.Reporte(FacturaID);
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
