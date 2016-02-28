﻿using Microsoft.Reporting.WinForms;
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

namespace SMA.Clientes.CuentasPagar.Reportes
{
    public partial class frmrptAntiguedadSaldoCuentaPagar : Office2007Form
    {
        private List<cAntiguedadSaldo> Lista;

        public frmrptAntiguedadSaldoCuentaPagar()
        {
            InitializeComponent();
        }

        public frmrptAntiguedadSaldoCuentaPagar(List<cAntiguedadSaldo> Lista):this()
        {
            this.Lista = Lista;
        }
        private void frmrptAntiguedadSaldoCuentaPagar_Load(object sender, EventArgs e)
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