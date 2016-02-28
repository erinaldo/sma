﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SMA.Entity;
using SMA.BL;
using DevComponents.DotNetBar;

namespace SMA.Factura.Reportes
{
    public partial class frmrptResumenFactura : Form
    {
        private List<cReporteResumenFactura> ListaFacturas;

        public frmrptResumenFactura()
        {
            InitializeComponent();
        }

        public frmrptResumenFactura(List<cReporteResumenFactura> ListaFacturas): this()
        {
            this.ListaFacturas = ListaFacturas;
        }
        private void frmrptResumenFactura_Load(object sender, EventArgs e)
        {

            ReportDataSource Datasource = new ReportDataSource();
            
            try
            {
                Datasource.Name = "dsResumenFacturas";
                Datasource.Value =ListaFacturas;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(Datasource);
                //reportViewer1.LocalReport.ReportEmbeddedResource = "GESTGYM.Cliente.Reportes.Formularios.rptListaClientes.rdlc";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
