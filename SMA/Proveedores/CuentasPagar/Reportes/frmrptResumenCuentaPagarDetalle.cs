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

namespace SMA.Clientes.CuentasPagar.Reportes
{
    public partial class frmrptResumenCuentaPagarDetalle : Form
    {
        private List<cReporteEstadoCuentaPagar> Lista;

        public frmrptResumenCuentaPagarDetalle()
        {
            InitializeComponent();
        }

        public frmrptResumenCuentaPagarDetalle(List<cReporteEstadoCuentaPagar> Lista):this()
        {
            this.Lista = Lista;
        }
        private void frmrptResumenCuentaPagarDetalle_Load(object sender, EventArgs e)
        {

            ReportDataSource Datasource = new ReportDataSource();
            //CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();

            Datasource.Name = "dsResumenMovCuentaPagar";
            Datasource.Value = Lista;
            //reportViewer1.LocalReport.ReportPath = "rptEstadoCuentaGeneralCliente.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(Datasource);
            // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
