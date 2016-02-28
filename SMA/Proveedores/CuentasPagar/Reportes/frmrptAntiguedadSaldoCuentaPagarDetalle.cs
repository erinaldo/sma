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
    public partial class frmrptAntiguedadSaldoCuentaPagarDetalle : Office2007Form
    {
        private List<cAntiguedadSaldoDetalle> Lista;
   
        public frmrptAntiguedadSaldoCuentaPagarDetalle()
        {
            InitializeComponent();
        }

        public frmrptAntiguedadSaldoCuentaPagarDetalle(List<cAntiguedadSaldoDetalle> Lista):this()
        {
            this.Lista = Lista;
        }
        private void frmrptAntiguedadSaldoCuentaPagarDetalle_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();

            Datasource.Name = "dsAntiguedadSaldoDetalle";
            Datasource.Value = Lista;
            //reportViewer1.LocalReport.ReportPath = "rptEstadoCuentaGeneralCliente.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(Datasource);
            // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
