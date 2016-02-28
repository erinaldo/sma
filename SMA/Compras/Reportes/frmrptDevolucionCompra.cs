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

namespace SMA.Compras.Reportes
{
    public partial class frmrptDevolucionCompra : Form
    {
        private Int64 CompraID;

        public frmrptDevolucionCompra()
        {
            InitializeComponent();
        }

        public frmrptDevolucionCompra(Int64 CompraID):this()
        {
            this.CompraID = CompraID;
        }

   
        private void frmrptDevolucionCompra_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();
            ComprasBL ObjetoFactura = new ComprasBL();

            try
            {
                Datasource.Name = "dsReporteFactura";
                Datasource.Value = ObjetoFactura.Reporte(CompraID);
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
