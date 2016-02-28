using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.Entity;
using DevComponents.DotNetBar;
using Microsoft.Reporting.WinForms;

namespace SMA.Factura.Reportes
{
    public partial class frmrptComisionVentasDetalles : Form
    {
        private List<cReporteComisionVentaDetalle> Lista;

        public frmrptComisionVentasDetalles()
        {
            InitializeComponent();
        }

        public frmrptComisionVentasDetalles(List<cReporteComisionVentaDetalle> Lista):this()
        {
            this.Lista = Lista;
        }
        private void frmrptComisionVentasDetalles_Load(object sender, EventArgs e)
        {

            ReportDataSource Datasource = new ReportDataSource();


            try
            {
                Datasource.Name = "dsComisionVentaDetalle";
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
