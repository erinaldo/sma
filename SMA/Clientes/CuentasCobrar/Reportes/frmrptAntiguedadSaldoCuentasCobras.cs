using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.Entity;
using Microsoft.Reporting.WinForms;
using DevComponents.DotNetBar;

namespace SMA.Clientes.CuentasCobrar.Reportes
{
    public partial class frmrptAntiguedadSaldoCuentasCobras : Office2007Form
    {
        private List<cAntiguedadSaldo> Lista;

        public frmrptAntiguedadSaldoCuentasCobras()
        {
            InitializeComponent();
        }

        public frmrptAntiguedadSaldoCuentasCobras(List<cAntiguedadSaldo> Lista):this()
        {
            this.Lista = Lista;
        }
        private void frmrptAntiguedadSaldoCuentasCobras_Load(object sender, EventArgs e)
        {

            ReportDataSource Datasource = new ReportDataSource();

            Datasource.Name = "dsAntiguedadSaldo";
            Datasource.Value = Lista;
            //reportViewer1.LocalReport.ReportPath = "rptEstadoCuentaGeneralCliente.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(Datasource);
            // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
