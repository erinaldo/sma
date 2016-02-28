using Microsoft.Reporting.WinForms;
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

namespace SMA.Clientes.CuentasCobrar.Reportes
{
    public partial class frmrptResumenCuentasCobrar : Office2007Form
    {
        List<cReporteResumenCuentaCobrar> Lista;

        public frmrptResumenCuentasCobrar()
        {
            InitializeComponent();
        }

        public frmrptResumenCuentasCobrar(List<cReporteResumenCuentaCobrar> Lista):this()
        {
            this.Lista = Lista;
        }
        private void frmrptResumenCuentasCobrar_Load(object sender, EventArgs e)
        {

            ReportDataSource Datasource = new ReportDataSource();
            CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();

            Datasource.Name = "dsResumenCuentaCobrar";
            Datasource.Value = Lista;
            //reportViewer1.LocalReport.ReportPath = "rptEstadoCuentaGeneralCliente.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(Datasource);
            // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
