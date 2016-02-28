﻿namespace SMA.Compras.Ordenes
{
    partial class frmFiltrarOrdenCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltrarOrdenCompra));
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.ckbFacturada = new System.Windows.Forms.CheckBox();
            this.ckbCancelada = new System.Windows.Forms.CheckBox();
            this.ckbGenerada = new System.Windows.Forms.CheckBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarDocumentoHasta = new DevComponents.DotNetBar.ButtonX();
            this.btnBuscarDocumentoDesde = new DevComponents.DotNetBar.ButtonX();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.cbbCriterio = new System.Windows.Forms.ComboBox();
            this.btnVerProveedores = new DevComponents.DotNetBar.ButtonX();
            this.GroupBox4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbProveedor
            // 
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(77, 12);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(244, 21);
            this.cbProveedor.TabIndex = 43;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.TabIndex = 42;
            this.Label1.Text = "Proveedor:";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.ckbFacturada);
            this.GroupBox4.Controls.Add(this.ckbCancelada);
            this.GroupBox4.Controls.Add(this.ckbGenerada);
            this.GroupBox4.Location = new System.Drawing.Point(12, 243);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(337, 54);
            this.GroupBox4.TabIndex = 41;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Estatus:";
            // 
            // ckbFacturada
            // 
            this.ckbFacturada.AutoSize = true;
            this.ckbFacturada.Location = new System.Drawing.Point(242, 21);
            this.ckbFacturada.Name = "ckbFacturada";
            this.ckbFacturada.Size = new System.Drawing.Size(68, 17);
            this.ckbFacturada.TabIndex = 2;
            this.ckbFacturada.Text = "Recibida";
            this.ckbFacturada.UseVisualStyleBackColor = true;
            // 
            // ckbCancelada
            // 
            this.ckbCancelada.AutoSize = true;
            this.ckbCancelada.Location = new System.Drawing.Point(137, 21);
            this.ckbCancelada.Name = "ckbCancelada";
            this.ckbCancelada.Size = new System.Drawing.Size(77, 17);
            this.ckbCancelada.TabIndex = 1;
            this.ckbCancelada.Text = "Cancelada";
            this.ckbCancelada.UseVisualStyleBackColor = true;
            // 
            // ckbGenerada
            // 
            this.ckbGenerada.AutoSize = true;
            this.ckbGenerada.Location = new System.Drawing.Point(27, 21);
            this.ckbGenerada.Name = "ckbGenerada";
            this.ckbGenerada.Size = new System.Drawing.Size(73, 17);
            this.ckbGenerada.TabIndex = 0;
            this.ckbGenerada.Text = "Generada";
            this.ckbGenerada.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.dtpHasta);
            this.GroupBox2.Controls.Add(this.dtpDesde);
            this.GroupBox2.Location = new System.Drawing.Point(12, 112);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(337, 67);
            this.GroupBox2.TabIndex = 40;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Fecha elaboracion";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(178, 35);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(35, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Hasta";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(23, 35);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(41, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Desde:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(219, 31);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(95, 20);
            this.dtpHasta.TabIndex = 1;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(70, 31);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(95, 20);
            this.dtpDesde.TabIndex = 0;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnBuscarDocumentoHasta);
            this.GroupBox1.Controls.Add(this.btnBuscarDocumentoDesde);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtHasta);
            this.GroupBox1.Controls.Add(this.txtDesde);
            this.GroupBox1.Location = new System.Drawing.Point(12, 39);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(337, 67);
            this.GroupBox1.TabIndex = 39;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Documento:";
            // 
            // btnBuscarDocumentoHasta
            // 
            this.btnBuscarDocumentoHasta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscarDocumentoHasta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscarDocumentoHasta.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarDocumentoHasta.Location = new System.Drawing.Point(300, 28);
            this.btnBuscarDocumentoHasta.Name = "btnBuscarDocumentoHasta";
            this.btnBuscarDocumentoHasta.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarDocumentoHasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscarDocumentoHasta.TabIndex = 212;
            this.btnBuscarDocumentoHasta.Click += new System.EventHandler(this.btnBuscarDocumentoHasta_Click);
            // 
            // btnBuscarDocumentoDesde
            // 
            this.btnBuscarDocumentoDesde.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscarDocumentoDesde.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscarDocumentoDesde.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarDocumentoDesde.Location = new System.Drawing.Point(139, 28);
            this.btnBuscarDocumentoDesde.Name = "btnBuscarDocumentoDesde";
            this.btnBuscarDocumentoDesde.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarDocumentoDesde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscarDocumentoDesde.TabIndex = 211;
            this.btnBuscarDocumentoDesde.Click += new System.EventHandler(this.btnBuscarDocumentoDesde_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(171, 33);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 13);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Hasta:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 33);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Desde:";
            // 
            // txtHasta
            // 
            this.txtHasta.Location = new System.Drawing.Point(216, 29);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(78, 20);
            this.txtHasta.TabIndex = 1;
            // 
            // txtDesde
            // 
            this.txtDesde.Location = new System.Drawing.Point(55, 29);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(78, 20);
            this.txtDesde.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(219, 303);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 45;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(111, 303);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 44;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtImporte);
            this.groupBox3.Controls.Add(this.cbbCriterio);
            this.groupBox3.Location = new System.Drawing.Point(12, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(337, 53);
            this.groupBox3.TabIndex = 173;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valor";
            // 
            // txtImporte
            // 
            this.txtImporte.AcceptsReturn = true;
            this.txtImporte.Location = new System.Drawing.Point(156, 20);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(4);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(158, 20);
            this.txtImporte.TabIndex = 20;
            // 
            // cbbCriterio
            // 
            this.cbbCriterio.FormattingEnabled = true;
            this.cbbCriterio.Items.AddRange(new object[] {
            "Todos",
            "Exacto",
            "Mayor",
            "Mayor o Igual ",
            "Menor",
            "Menor o Igual"});
            this.cbbCriterio.Location = new System.Drawing.Point(11, 20);
            this.cbbCriterio.Margin = new System.Windows.Forms.Padding(4);
            this.cbbCriterio.Name = "cbbCriterio";
            this.cbbCriterio.Size = new System.Drawing.Size(137, 21);
            this.cbbCriterio.TabIndex = 19;
            // 
            // btnVerProveedores
            // 
            this.btnVerProveedores.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerProveedores.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVerProveedores.Image = global::SMA.Properties.Resources.find_icon;
            this.btnVerProveedores.Location = new System.Drawing.Point(327, 10);
            this.btnVerProveedores.Name = "btnVerProveedores";
            this.btnVerProveedores.Size = new System.Drawing.Size(26, 23);
            this.btnVerProveedores.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVerProveedores.TabIndex = 210;
            this.btnVerProveedores.Click += new System.EventHandler(this.btnVerProveedores_Click);
            // 
            // frmFiltrarOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 348);
            this.Controls.Add(this.btnVerProveedores);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(371, 386);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(371, 386);
            this.Name = "frmFiltrarOrdenCompra";
            this.Text = "Buscar orden";
            this.Load += new System.EventHandler(this.frmFiltrarOrdenCompra_Load);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.ComboBox cbProveedor;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.CheckBox ckbFacturada;
        internal System.Windows.Forms.CheckBox ckbCancelada;
        internal System.Windows.Forms.CheckBox ckbGenerada;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DateTimePicker dtpHasta;
        internal System.Windows.Forms.DateTimePicker dtpDesde;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtHasta;
        internal System.Windows.Forms.TextBox txtDesde;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.TextBox txtImporte;
        internal System.Windows.Forms.ComboBox cbbCriterio;
        private DevComponents.DotNetBar.ButtonX btnVerProveedores;
        private DevComponents.DotNetBar.ButtonX btnBuscarDocumentoHasta;
        private DevComponents.DotNetBar.ButtonX btnBuscarDocumentoDesde;
    }
}