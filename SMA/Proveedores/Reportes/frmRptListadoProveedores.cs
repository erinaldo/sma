using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.BL;
using Microsoft.Reporting.WinForms;
using SMA.Entity;


namespace SMA.Clientes.Reportes
{
    public partial class frmRptListadoProveedores : Office2007Form
    {
        //Lista de clientes
        private List<cProveedor> ListaProveedores;

        public frmRptListadoProveedores()
        {
            InitializeComponent();
        }

        public frmRptListadoProveedores(List<cProveedor> ListaProveedores): this()
        {
            this.ListaProveedores = ListaProveedores;
        }
        private void frmRptListadoProveedores_Load(object sender, EventArgs e)
        {
            {
                ReportDataSource Datasource = new ReportDataSource();
                ProveedorBL ObjetoProveedor = new ProveedorBL();

                Datasource.Name = "DataSet1";
                Datasource.Value = ListaProveedores;
                //reportViewer1.LocalReport.ReportPath = "rptListaClientes.rdlc";

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(Datasource);
                // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
