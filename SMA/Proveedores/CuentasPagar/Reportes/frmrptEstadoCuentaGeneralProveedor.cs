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
using SMA.Entity;
using Microsoft.Reporting.WinForms;

namespace SMA.Clientes.CuentasPagar.Reportes
{
    public partial class frmrptEstadoCuentaGeneralProveedor : Office2007Form
    {
        //Lista de Cuentas
        private List<cReporteEstadoCuenta> EstadoCuentaGeneral;

        public frmrptEstadoCuentaGeneralProveedor()
        {
            InitializeComponent();
        }

        public frmrptEstadoCuentaGeneralProveedor(List<cReporteEstadoCuenta> EstadoCuentaGeneral):this()
        {
            this.EstadoCuentaGeneral = EstadoCuentaGeneral;
        }
        private void frmrptEstadoCuentaGeneralProveedor_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();
            CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();

            Datasource.Name = "dsEstadoCuentaGeneralCliente";
            Datasource.Value = EstadoCuentaGeneral;
            //reportViewer1.LocalReport.ReportPath = "rptEstadoCuentaGeneralCliente.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(Datasource);
            // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
            this.reportViewer1.RefreshReport();
            
        }
    }
}
