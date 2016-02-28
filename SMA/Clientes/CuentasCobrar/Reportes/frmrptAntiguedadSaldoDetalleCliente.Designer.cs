namespace SMA.Clientes.CuentasCobrar.Reportes
{
    partial class frmrptAntiguedadSaldoDetalleCliente
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cAntiguedadSaldoDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cAntiguedadSaldoDetalleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dsAntiguedadSaldoDetalle";
            reportDataSource2.Value = this.cAntiguedadSaldoDetalleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SMA.Clientes.CuentasCobrar.Reportes.rptAntiguedadSaldoDetalleCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(622, 486);
            this.reportViewer1.TabIndex = 0;
            // 
            // cAntiguedadSaldoDetalleBindingSource
            // 
            this.cAntiguedadSaldoDetalleBindingSource.DataSource = typeof(SMA.Entity.cAntiguedadSaldoDetalle);
            // 
            // frmrptAntiguedadSaldoDetalleCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 486);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmrptAntiguedadSaldoDetalleCliente";
            this.Text = "Antiguedad de Saldo detallado de cliente";
            this.Load += new System.EventHandler(this.frmrptAntiguedadSaldoDetalleCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cAntiguedadSaldoDetalleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cAntiguedadSaldoDetalleBindingSource;
    }
}