﻿namespace SMA.Inventario
{
    partial class frmListarComponentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarComponentes));
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.dgvComponente = new System.Windows.Forms.DataGridView();
            this.cCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionar = new DevComponents.DotNetBar.ButtonX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponente)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(12, 12);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(476, 20);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // dgvComponente
            // 
            this.dgvComponente.AllowUserToAddRows = false;
            this.dgvComponente.AllowUserToDeleteRows = false;
            this.dgvComponente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCodigo,
            this.cDescripcion});
            this.dgvComponente.Location = new System.Drawing.Point(12, 38);
            this.dgvComponente.Name = "dgvComponente";
            this.dgvComponente.ReadOnly = true;
            this.dgvComponente.Size = new System.Drawing.Size(476, 279);
            this.dgvComponente.TabIndex = 1;
            this.dgvComponente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponente_CellClick);
            this.dgvComponente.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponente_RowEnter);
            // 
            // cCodigo
            // 
            this.cCodigo.DataPropertyName = "ID";
            this.cCodigo.HeaderText = "Codigo";
            this.cCodigo.Name = "cCodigo";
            this.cCodigo.ReadOnly = true;
            // 
            // cDescripcion
            // 
            this.cDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cDescripcion.DataPropertyName = "Descripcion";
            this.cDescripcion.HeaderText = "Descripción";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSeleccionar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.Image")));
            this.btnSeleccionar.Location = new System.Drawing.Point(136, 328);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(107, 42);
            this.btnSeleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(258, 328);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmListarComponentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 382);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dgvComponente);
            this.Controls.Add(this.txtBusqueda);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(516, 420);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(516, 420);
            this.Name = "frmListarComponentes";
            this.Load += new System.EventHandler(this.ListarComponentes_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmListarComponentes_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridView dgvComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private DevComponents.DotNetBar.ButtonX btnSeleccionar;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
    }
}