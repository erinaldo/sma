namespace SMA.Clientes.CuentasCobrar.Reportes
{
    partial class frmrptReciboCuentasCobrar
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
            this.cCuentasCobrarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cCuentasCobrarBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsCuentaCobrar";
            reportDataSource1.Value = this.cCuentasCobrarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SMA.Clientes.CuentasCobrar.Reportes.rptReciboCuentasCobrar.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(541, 434);
            this.reportViewer1.TabIndex = 0;
            // 
            // cCuentasCobrarBindingSource
            // 
            this.cCuentasCobrarBindingSource.DataSource = typeof(SMA.Entity.cCuentasCobrar);
            // 
            // frmrptReciboCuentasCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 434);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmrptReciboCuentasCobrar";
            this.Text = "Recibo cuentas por cobrar";
            this.Load += new System.EventHandler(this.frmReciboCuentasCobrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cCuentasCobrarBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cCuentasCobrarBindingSource;

    }
}