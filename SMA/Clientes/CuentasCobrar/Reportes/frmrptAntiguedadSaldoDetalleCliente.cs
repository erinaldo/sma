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

namespace SMA.Clientes.CuentasCobrar.Reportes
{
    public partial class frmrptAntiguedadSaldoDetalleCliente : Office2007Form
    {
        private List<cAntiguedadSaldoDetalle> Lista;

        public frmrptAntiguedadSaldoDetalleCliente()
        {
            InitializeComponent();
        }

        public frmrptAntiguedadSaldoDetalleCliente(List<cAntiguedadSaldoDetalle> Lista)
            : this()
        {
            this.Lista = Lista;
        }

        private void frmrptAntiguedadSaldoDetalleCliente_Load(object sender, EventArgs e)
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
