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
using Microsoft.Reporting.WinForms;
using DevComponents.DotNetBar;



namespace SMA.Inventario.Reportes
{
    public partial class frmrptCostoInventario : Office2007Form
    {
        
        List<cInventario> ListaProductos;

        public frmrptCostoInventario()
        {
            InitializeComponent();
        }

        public frmrptCostoInventario(List<cInventario> ListaProductos): this()
        {
            this.ListaProductos = ListaProductos;
        }

        private void frmrptCostoInventario_Load(object sender, EventArgs e)
        {

            ReportDataSource Datasource = new ReportDataSource();

            try
            {
                Datasource.Name = "dsCostoInventario";
                Datasource.Value = ListaProductos;
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
