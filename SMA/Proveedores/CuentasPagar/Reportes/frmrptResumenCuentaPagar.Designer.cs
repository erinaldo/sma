namespace SMA.Clientes.CuentasPagar.Reportes
{
    partial class frmrptResumenCuentaPagar
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cReporteResumenCuentaPagarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cReporteResumenCuentaPagarBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsResumenCuentaCobrar";
            reportDataSource1.Value = this.cReporteResumenCuentaPagarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SMA.Proveedores.CuentasPagar.Reportes.rptResumenCuentaPagar.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(696, 418);
            this.reportViewer1.TabIndex = 0;
            // 
            // cReporteResumenCuentaPagarBindingSource
            // 
            this.cReporteResumenCuentaPagarBindingSource.DataSource = typeof(SMA.Entity.cReporteResumenCuentaPagar);
            // 
            // frmrptResumenCuentaPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 418);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmrptResumenCuentaPagar";
            this.Text = "frmrptResumenCuentaPagar";
            this.Load += new System.EventHandler(this.frmrptResumenCuentaPagar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cReporteResumenCuentaPagarBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cReporteResumenCuentaPagarBindingSource;
    }
}