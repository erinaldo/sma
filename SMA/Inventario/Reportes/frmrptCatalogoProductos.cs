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

namespace SMA.Inventario.Reportes
{
    public partial class frmrptCatalogoProductos : Office2007Form
    {
        private List<cInventario> Lista;

        public frmrptCatalogoProductos()
        {
            InitializeComponent();
        }

        public frmrptCatalogoProductos(List<cInventario> Lista):this()
        {
            this.Lista = Lista;
        }
        private void frmrptCatalogoProductos_Load(object sender, EventArgs e)
        {

            ReportDataSource Datasource = new ReportDataSource();

            try
            {
                Datasource.Name = "dsInventario";
                Datasource.Value = Lista;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(Datasource);
                //reportViewer1.LocalReport.ReportEmbeddedResource = "GESTGYM.Cliente.Reportes.Formularios.rptListaClientes.rdlc";
                this.reportViewer1.RefreshReport();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }
    }
}