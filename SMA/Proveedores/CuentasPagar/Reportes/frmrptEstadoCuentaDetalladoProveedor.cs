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
    public partial class frmrptEstadoCuentaDetalladoProveedor : Office2007Form
    {
        //Lista de Cuentas
        private List<cReporteEstadoCuenta> EstadoCuentaDetallado;

        public frmrptEstadoCuentaDetalladoProveedor()
        {
            InitializeComponent();
        }

        public frmrptEstadoCuentaDetalladoProveedor(List<cReporteEstadoCuenta> EstadoCuentaDetallado):this()
        {
            this.EstadoCuentaDetallado = EstadoCuentaDetallado;
        }
        private void frmrptEstadoCuentaDetalladoProveedor_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();
            CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();

            Datasource.Name = "dsEstadoCuentaGeneralCliente";
            Datasource.Value = EstadoCuentaDetallado;
            //reportViewer1.LocalReport.ReportPath = "rptEstadoCuentaGeneralCliente.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(Datasource);
            // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
