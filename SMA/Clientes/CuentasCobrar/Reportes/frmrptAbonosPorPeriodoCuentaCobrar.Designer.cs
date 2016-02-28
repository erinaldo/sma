namespace SMA.Clientes.CuentasCobrar.Reportes
{
    partial class frmrptAbonosPorPeriodoCuentaCobrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cReporteEstadoCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.cReporteEstadoCuentaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cReporteEstadoCuentaBindingSource
            // 
            this.cReporteEstadoCuentaBindingSource.DataSource = typeof(SMA.Entity.cReporteEstadoCuenta);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsEstadoCuentaGeneralCliente";
            reportDataSource1.Value = this.cReporteEstadoCuentaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SMA.Clientes.CuentasCobrar.Reportes.rptAbonoPorPeriodoCuentaCobrar.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(553, 474);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmrptAbonosPorPeriodoCuentaCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 474);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmrptAbonosPorPeriodoCuentaCobrar";
            this.Text = "Abonos por periodo";
            this.Load += new System.EventHandler(this.frmrptAbonosPorPeriodoCuentaCobrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cReporteEstadoCuentaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cReporteEstadoCuentaBindingSource;
    }
}