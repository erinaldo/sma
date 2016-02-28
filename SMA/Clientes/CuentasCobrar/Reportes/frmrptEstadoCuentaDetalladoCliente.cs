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
    public partial class frmrptEstadoCuentaDetalladoCliente : Office2007Form
    {
         //Lista de Cuentas
        private List<cReporteEstadoCuenta> EstadoCuentaDetallado;

        public frmrptEstadoCuentaDetalladoCliente()
        {
            InitializeComponent();
        }

        public frmrptEstadoCuentaDetalladoCliente(List<cReporteEstadoCuenta> EstadoCuentaDetallado):this()
        {
            this.EstadoCuentaDetallado=EstadoCuentaDetallado;
        }

        private void frmrptEstadoCuentaDetalladoCliente_Load(object sender, EventArgs e)
        {

            ReportDataSource Datasource = new ReportDataSource();
            CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();

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
