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

namespace SMA.Clientes.CuentasPagar.Reportes
{
    public partial class frmrptCatalogoProveedores : Form
    {
        private List<cProveedor> Lista;

        public frmrptCatalogoProveedores()
        {
            InitializeComponent();
        }

        public frmrptCatalogoProveedores(List<cProveedor> Lista):this()
        {
            this.Lista = Lista;
        }
        private void frmrptCatalogoProveedores_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();
            ///FacturaBL ObjetoFactura = new FacturaBL();

            try
            {
                Datasource.Name = "dsProveedores";
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
