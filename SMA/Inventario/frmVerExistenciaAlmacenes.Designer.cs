namespace SMA.Inventario
{
    partial class frmVerExistenciaAlmacenes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerExistenciaAlmacenes));
            this.dgvExistenciaAlmacen = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistenciaAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExistenciaAlmacen
            // 
            this.dgvExistenciaAlmacen.AllowUserToAddRows = false;
            this.dgvExistenciaAlmacen.AllowUserToDeleteRows = false;
            this.dgvExistenciaAlmacen.AllowUserToResizeRows = false;
            this.dgvExistenciaAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExistenciaAlmacen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cAlmacen,
            this.cExistencia});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExistenciaAlmacen.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExistenciaAlmacen.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvExistenciaAlmacen.Location = new System.Drawing.Point(12, 12);
            this.dgvExistenciaAlmacen.MaximumSize = new System.Drawing.Size(393, 307);
            this.dgvExistenciaAlmacen.MinimumSize = new System.Drawing.Size(393, 307);
            this.dgvExistenciaAlmacen.Name = "dgvExistenciaAlmacen";
            this.dgvExistenciaAlmacen.Size = new System.Drawing.Size(393, 307);
            this.dgvExistenciaAlmacen.TabIndex = 11;
            // 
            // cAlmacen
            // 
            this.cAlmacen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cAlmacen.DataPropertyName = "AlmacenID";
            this.cAlmacen.HeaderText = "Almacen";
            this.cAlmacen.Name = "cAlmacen";
            // 
            // cExistencia
            // 
            this.cExistencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cExistencia.DataPropertyName = "Existencia";
            dataGridViewCellStyle1.Format = "N2";
            this.cExistencia.DefaultCellStyle = dataGridViewCellStyle1;
            this.cExistencia.HeaderText = "Existencia";
            this.cExistencia.Name = "cExistencia";
            this.cExistencia.Width = 80;
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(157, 325);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 43);
            this.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            // 
            // frmVerExistenciaAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 372);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvExistenciaAlmacen);
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(433, 410);
            this.MinimumSize = new System.Drawing.Size(433, 410);
            this.Name = "frmVerExistenciaAlmacenes";
            this.Text = "Existencia por Almacen";
            this.Load += new System.EventHandler(this.frmVerExistenciaAlmacenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistenciaAlmacen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvExistenciaAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExistencia;
        private DevComponents.DotNetBar.ButtonX btnSalir;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}