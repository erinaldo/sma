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


namespace SMA.Clientes.Reportes
{
    public partial class frmrptCatalogoCliente : Office2007Form
    {
        List<cCliente> Listado;

        public frmrptCatalogoCliente()
        {
            InitializeComponent();
        }

        public frmrptCatalogoCliente(List<cCliente> Listado):this()
        {
            this.Listado = Listado;
        }

        private void frmrptCatalogoCliente_Load(object sender, EventArgs e)
        {

            ReportDataSource Datasource = new ReportDataSource();
            FacturaBL ObjetoFactura = new FacturaBL();

            try
            {
                Datasource.Name = "dsClientes";
                Datasource.Value = Listado;
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
