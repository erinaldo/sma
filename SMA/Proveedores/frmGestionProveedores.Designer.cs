﻿namespace SMA.Clientes
{
    partial class frmGestionProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionProveedores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.Descripcion = new DevComponents.Editors.ComboItem();
            this.Codigo = new DevComponents.Editors.ComboItem();
            this.Acciones = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar4 = new DevComponents.DotNetBar.RibbonBar();
            this.btnSalir = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.btnCuentasPorPagar = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefrescar = new DevComponents.DotNetBar.ButtonItem();
            this.btnImprimir = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnNuevo = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditar = new DevComponents.DotNetBar.ButtonItem();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.dgvProveedor = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ribbonPanel1.SuspendLayout();
            this.ribbonControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            // 
            // Descripcion
            // 
            this.Descripcion.Text = "Descripcion";
            // 
            // Codigo
            // 
            this.Codigo.Text = "Codigo";
            // 
            // Acciones
            // 
            this.Acciones.Checked = true;
            this.Acciones.Name = "Acciones";
            this.Acciones.Panel = this.ribbonPanel1;
            this.Acciones.Text = "Acciones";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar4);
            this.ribbonPanel1.Controls.Add(this.ribbonBar3);
            this.ribbonPanel1.Controls.Add(this.ribbonBar2);
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(1119, 147);
            // 
            // 
            // 
            this.ribbonPanel1.Style.Class = "";
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.Class = "";
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.Class = "";
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            // 
            // ribbonBar4
            // 
            this.ribbonBar4.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundStyle.Class = "";
            this.ribbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar4.ContainerControlProcessDialogKey = true;
            this.ribbonBar4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSalir});
            this.ribbonBar4.Location = new System.Drawing.Point(447, 0);
            this.ribbonBar4.Name = "ribbonBar4";
            this.ribbonBar4.Size = new System.Drawing.Size(68, 144);
            this.ribbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar4.TabIndex = 3;
            this.ribbonBar4.Text = "Salir";
            // 
            // 
            // 
            this.ribbonBar4.TitleStyle.Class = "";
            this.ribbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyleMouseOver.Class = "";
            this.ribbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.SubItemsExpandWidth = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundStyle.Class = "";
            this.ribbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ContainerControlProcessDialogKey = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCuentasPorPagar});
            this.ribbonBar3.Location = new System.Drawing.Point(379, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(68, 144);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar3.TabIndex = 2;
            this.ribbonBar3.Text = "Balance";
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.Class = "";
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.Class = "";
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnCuentasPorPagar
            // 
            this.btnCuentasPorPagar.Image = ((System.Drawing.Image)(resources.GetObject("btnCuentasPorPagar.Image")));
            this.btnCuentasPorPagar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCuentasPorPagar.Name = "btnCuentasPorPagar";
            this.btnCuentasPorPagar.SubItemsExpandWidth = 14;
            this.btnCuentasPorPagar.Text = "Balance";
            this.btnCuentasPorPagar.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.Class = "";
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnBuscar,
            this.btnRefrescar,
            this.btnImprimir});
            this.ribbonBar2.Location = new System.Drawing.Point(186, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(193, 144);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 1;
            this.ribbonBar2.Text = "Busqueda";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.Class = "";
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.Class = "";
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.SubItemsExpandWidth = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
            this.btnRefrescar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.SubItemsExpandWidth = 14;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.SubItemsExpandWidth = 14;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.Class = "";
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(183, 144);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "Mantenimiento";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.Class = "";
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.Class = "";
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.SubItemsExpandWidth = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.SubItemsExpandWidth = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.SubItemsExpandWidth = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.Class = "";
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Acciones});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.Size = new System.Drawing.Size(1119, 149);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 10;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.AllowUserToAddRows = false;
            this.dgvProveedor.AllowUserToDeleteRows = false;
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCodigo,
            this.cNombre,
            this.cRNC,
            this.cTelefono,
            this.cBalance});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProveedor.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvProveedor.Location = new System.Drawing.Point(0, 149);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.ReadOnly = true;
            this.dgvProveedor.Size = new System.Drawing.Size(1119, 550);
            this.dgvProveedor.TabIndex = 11;
            this.dgvProveedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedor_CellClick);
            this.dgvProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedor_CellDoubleClick);
            // 
            // cCodigo
            // 
            this.cCodigo.DataPropertyName = "ID";
            this.cCodigo.HeaderText = "Codigo";
            this.cCodigo.Name = "cCodigo";
            this.cCodigo.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cNombre.DataPropertyName = "NombreComercial";
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cRNC
            // 
            this.cRNC.DataPropertyName = "RNC";
            this.cRNC.HeaderText = "RNC";
            this.cRNC.Name = "cRNC";
            this.cRNC.ReadOnly = true;
            // 
            // cTelefono
            // 
            this.cTelefono.DataPropertyName = "Telefono";
            this.cTelefono.HeaderText = "Telefono";
            this.cTelefono.Name = "cTelefono";
            this.cTelefono.ReadOnly = true;
            // 
            // cBalance
            // 
            this.cBalance.DataPropertyName = "Balance";
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.cBalance.DefaultCellStyle = dataGridViewCellStyle7;
            this.cBalance.HeaderText = "Balance";
            this.cBalance.Name = "cBalance";
            this.cBalance.ReadOnly = true;
            // 
            // frmGestionProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 699);
            this.Controls.Add(this.dgvProveedor);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionProveedores";
            this.Text = "Gestión de proveedores";
            this.Load += new System.EventHandler(this.frmGestionProveedores_Load);
            this.ribbonPanel1.ResumeLayout(false);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.Editors.ComboItem Descripcion;
        private DevComponents.Editors.ComboItem Codigo;
        private DevComponents.DotNetBar.RibbonTabItem Acciones;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem btnBuscar;
        private DevComponents.DotNetBar.ButtonItem btnRefrescar;
        private DevComponents.DotNetBar.ButtonItem btnImprimir;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnNuevo;
        private DevComponents.DotNetBar.ButtonItem btnEditar;
        private DevComponents.DotNetBar.ButtonItem btnEliminar;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvProveedor;
        private DevComponents.DotNetBar.RibbonBar ribbonBar4;
        private DevComponents.DotNetBar.ButtonItem btnSalir;
        private DevComponents.DotNetBar.ButtonItem btnCuentasPorPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRNC;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBalance;
    }
}