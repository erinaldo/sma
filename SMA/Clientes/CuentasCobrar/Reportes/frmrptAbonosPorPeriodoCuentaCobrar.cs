﻿using System;
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


namespace SMA.Clientes.CuentasCobrar.Reportes
{
    public partial class frmrptAbonosPorPeriodoCuentaCobrar : Office2007Form
    {
        private List<cReporteEstadoCuenta> Lista;
        
        public frmrptAbonosPorPeriodoCuentaCobrar()
        {
            InitializeComponent();
        }

        public frmrptAbonosPorPeriodoCuentaCobrar(List<cReporteEstadoCuenta> Lista):this()
        {
            this.Lista = Lista;
        }

        private void frmrptAbonosPorPeriodoCuentaCobrar_Load(object sender, EventArgs e)
        {

             ReportDataSource Datasource = new ReportDataSource();
            CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();

            Datasource.Name = "dsEstadoCuentaGeneralCliente";
            Datasource.Value = Lista;
            //reportViewer1.LocalReport.ReportPath = "rptEstadoCuentaGeneralCliente.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(Datasource);
            // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
            this.reportViewer1.RefreshReport();
        }
        
    }
}