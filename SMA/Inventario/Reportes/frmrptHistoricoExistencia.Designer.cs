namespace SMA.Inventario.Reportes
{
    partial class frmrptHistoricoExistencia
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
            this.cReporteHistoricoExistenciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.cReporteHistoricoExistenciaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cReporteHistoricoExistenciaBindingSource
            // 
            this.cReporteHistoricoExistenciaBindingSource.DataSource = typeof(SMA.Entity.cReporteHistoricoExistencia);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsHistoricoInventario";
            reportDataSource1.Value = this.cReporteHistoricoExistenciaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SMA.Inventario.Reportes.rptHistoricoExistencia.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(585, 383);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmrptHistoricoExistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 383);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmrptHistoricoExistencia";
            this.Text = "Historico de existencia";
            this.Load += new System.EventHandler(this.frmrptHistoricoExistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cReporteHistoricoExistenciaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cReporteHistoricoExistenciaBindingSource;
    }
}