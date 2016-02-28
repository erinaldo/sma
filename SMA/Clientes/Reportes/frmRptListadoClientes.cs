using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.BL;
using Microsoft.Reporting.WinForms;
using SMA.Entity;
using DevComponents.DotNetBar;

namespace SMA.Clientes.Reportes
{
    public partial class frmRptListadoClientes : Office2007Form
    {

        //Lista de clientes
        private List<cCliente> ListaClientes;

        public frmRptListadoClientes()
        {
            InitializeComponent();
        }

        public frmRptListadoClientes(List<cCliente> ListaClientes):this()
        {
            this.ListaClientes = ListaClientes;
        }

        private void frmRptListadoClientes_Load(object sender, EventArgs e)
        {
            ReportDataSource Datasource = new ReportDataSource();
            ClienteBL ObjetoCliente = new ClienteBL();

            Datasource.Name = "dsListaClientes";
            Datasource.Value = ListaClientes;
            //reportViewer1.LocalReport.ReportPath = "rptListaClientes.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(Datasource);
            // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
