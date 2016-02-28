using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.Entity;
using SMA.BL;
using DevComponents.DotNetBar; 
using Microsoft.Reporting.WinForms;


namespace SMA.Clientes.CuentasCobrar.Reportes
{
    public partial class frmrptReciboCuentasCobrar : Office2007Form
    {
        private List<cCuentasCobrar> Cuenta;

        public frmrptReciboCuentasCobrar()
        {
            InitializeComponent();
        }

        public frmrptReciboCuentasCobrar(List<cCuentasCobrar> Cuenta): this()
        {
            this.Cuenta = Cuenta;
        }

        private void frmReciboCuentasCobrar_Load(object sender, EventArgs e)
        {
            if (Cuenta.Count == 0)
            {
                this.Close();
            }
            else
            {
                try
                {

                    ReportDataSource Datasource = new ReportDataSource();


                    Datasource.Name = "dsCuentaCobrar";
                    Datasource.Value = Cuenta;
                    //reportViewer1.LocalReport.ReportPath = "rptEstadoCuentaGeneralCliente.rdlc";

                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(Datasource);
                    // reportViewer1.LocalReport.ReportEmbeddedResource = "rptClientesCumpleaneros.rdlc";
                    this.reportViewer1.RefreshReport();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
