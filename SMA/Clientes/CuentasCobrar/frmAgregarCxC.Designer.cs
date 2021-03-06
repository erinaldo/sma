﻿namespace SMA.Clientes.CuentasPagar
{
    partial class frmAgregarCxC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarCxC));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btnVerReferencia = new DevComponents.DotNetBar.ButtonX();
            this.btnVerDocumentos = new DevComponents.DotNetBar.ButtonX();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.dtpFecha_Emision = new System.Windows.Forms.DateTimePicker();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.dtpFecha_Vencimiento = new System.Windows.Forms.DateTimePicker();
            this.Label4 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbbClientes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbConcepto = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtFactura = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDocumentoPagar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtReferencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(12, 12);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(603, 233);
            this.TabControl1.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.txtReferencia);
            this.TabPage1.Controls.Add(this.txtDocumentoPagar);
            this.TabPage1.Controls.Add(this.txtFactura);
            this.TabPage1.Controls.Add(this.cbbConcepto);
            this.TabPage1.Controls.Add(this.cbbClientes);
            this.TabPage1.Controls.Add(this.btnVerReferencia);
            this.TabPage1.Controls.Add(this.btnVerDocumentos);
            this.TabPage1.Controls.Add(this.txtMonto);
            this.TabPage1.Controls.Add(this.lblTipo);
            this.TabPage1.Controls.Add(this.lblCliente);
            this.TabPage1.Controls.Add(this.Label10);
            this.TabPage1.Controls.Add(this.dtpFecha_Emision);
            this.TabPage1.Controls.Add(this.Label9);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.Label6);
            this.TabPage1.Controls.Add(this.btnBuscarCliente);
            this.TabPage1.Controls.Add(this.Label5);
            this.TabPage1.Controls.Add(this.Label7);
            this.TabPage1.Controls.Add(this.txtCodigo);
            this.TabPage1.Controls.Add(this.Label8);
            this.TabPage1.Controls.Add(this.dtpFecha_Vencimiento);
            this.TabPage1.Controls.Add(this.Label4);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(595, 207);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Movimiento";
            this.TabPage1.UseVisualStyleBackColor = true;
            this.TabPage1.Click += new System.EventHandler(this.TabPage1_Click);
            // 
            // btnVerReferencia
            // 
            this.btnVerReferencia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerReferencia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVerReferencia.Image = global::SMA.Properties.Resources.find_icon;
            this.btnVerReferencia.Location = new System.Drawing.Point(235, 144);
            this.btnVerReferencia.Name = "btnVerReferencia";
            this.btnVerReferencia.Size = new System.Drawing.Size(26, 23);
            this.btnVerReferencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVerReferencia.TabIndex = 7;
            this.btnVerReferencia.Click += new System.EventHandler(this.btnVerReferencia_Click);
            // 
            // btnVerDocumentos
            // 
            this.btnVerDocumentos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerDocumentos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVerDocumentos.Image = global::SMA.Properties.Resources.find_icon;
            this.btnVerDocumentos.Location = new System.Drawing.Point(235, 92);
            this.btnVerDocumentos.Name = "btnVerDocumentos";
            this.btnVerDocumentos.Size = new System.Drawing.Size(26, 23);
            this.btnVerDocumentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVerDocumentos.TabIndex = 4;
            this.btnVerDocumentos.Click += new System.EventHandler(this.btnVerDocumentos_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtMonto.Location = new System.Drawing.Point(91, 173);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(240, 20);
            this.txtMonto.TabIndex = 8;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblTipo
            // 
            this.lblTipo.BackColor = System.Drawing.Color.Cornsilk;
            this.lblTipo.Location = new System.Drawing.Point(442, 71);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(144, 22);
            this.lblTipo.TabIndex = 135;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(16, 44);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 110;
            this.lblCliente.Text = "Cliente:";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(397, 76);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(31, 13);
            this.Label10.TabIndex = 134;
            this.Label10.Text = "Tipo:";
            // 
            // dtpFecha_Emision
            // 
            this.dtpFecha_Emision.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha_Emision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha_Emision.Location = new System.Drawing.Point(486, 147);
            this.dtpFecha_Emision.Name = "dtpFecha_Emision";
            this.dtpFecha_Emision.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha_Emision.TabIndex = 9;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(16, 150);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(59, 13);
            this.Label9.TabIndex = 132;
            this.Label9.Text = "Referencia";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(379, 151);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(78, 13);
            this.Label2.TabIndex = 113;
            this.Label2.Text = "Fecha emision:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 124);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 13);
            this.Label1.TabIndex = 115;
            this.Label1.Text = "Documento:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(16, 98);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(66, 13);
            this.Label6.TabIndex = 129;
            this.Label6.Text = "No. Factura:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.Image")));
            this.btnBuscarCliente.Location = new System.Drawing.Point(594, -34);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(26, 24);
            this.btnBuscarCliente.TabIndex = 117;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(16, 176);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(40, 13);
            this.Label5.TabIndex = 27;
            this.Label5.Text = "Monto:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(16, 18);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(43, 13);
            this.Label7.TabIndex = 124;
            this.Label7.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtCodigo.Location = new System.Drawing.Point(89, 13);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(87, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(379, 176);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(101, 13);
            this.Label8.TabIndex = 127;
            this.Label8.Text = "Fecha Vencimiento:";
            // 
            // dtpFecha_Vencimiento
            // 
            this.dtpFecha_Vencimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha_Vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha_Vencimiento.Location = new System.Drawing.Point(486, 173);
            this.dtpFecha_Vencimiento.Name = "dtpFecha_Vencimiento";
            this.dtpFecha_Vencimiento.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha_Vencimiento.TabIndex = 10;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(16, 71);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(56, 13);
            this.Label4.TabIndex = 26;
            this.Label4.Text = "Concepto:";
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.txtNotas);
            this.TabPage2.Controls.Add(this.Label3);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(595, 207);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Observaciones";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(6, 49);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(583, 116);
            this.txtNotas.TabIndex = 119;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 33);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 13);
            this.Label3.TabIndex = 118;
            this.Label3.Text = "Notas:";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(513, 251);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(405, 251);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbbClientes
            // 
            this.cbbClientes.DisplayMember = "Text";
            this.cbbClientes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbClientes.FocusHighlightColor = System.Drawing.Color.LemonChiffon;
            this.cbbClientes.FocusHighlightEnabled = true;
            this.cbbClientes.FormattingEnabled = true;
            this.cbbClientes.ItemHeight = 14;
            this.cbbClientes.Location = new System.Drawing.Point(92, 42);
            this.cbbClientes.Name = "cbbClientes";
            this.cbbClientes.Size = new System.Drawing.Size(494, 20);
            this.cbbClientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbClientes.TabIndex = 3;
            // 
            // cbbConcepto
            // 
            this.cbbConcepto.DisplayMember = "Text";
            this.cbbConcepto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbConcepto.FocusHighlightColor = System.Drawing.Color.LemonChiffon;
            this.cbbConcepto.FocusHighlightEnabled = true;
            this.cbbConcepto.FormattingEnabled = true;
            this.cbbConcepto.ItemHeight = 14;
            this.cbbConcepto.Location = new System.Drawing.Point(92, 68);
            this.cbbConcepto.Name = "cbbConcepto";
            this.cbbConcepto.Size = new System.Drawing.Size(215, 20);
            this.cbbConcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbConcepto.TabIndex = 3;
            this.cbbConcepto.SelectedValueChanged += new System.EventHandler(this.cbbConcepto_SelectedValueChanged);
            // 
            // txtFactura
            // 
            // 
            // 
            // 
            this.txtFactura.Border.Class = "TextBoxBorder";
            this.txtFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFactura.FocusHighlightColor = System.Drawing.Color.LemonChiffon;
            this.txtFactura.FocusHighlightEnabled = true;
            this.txtFactura.Location = new System.Drawing.Point(91, 94);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(137, 20);
            this.txtFactura.TabIndex = 3;
            this.txtFactura.Validated += new System.EventHandler(this.txtFactura_Validated_1);
            // 
            // txtDocumentoPagar
            // 
            // 
            // 
            // 
            this.txtDocumentoPagar.Border.Class = "TextBoxBorder";
            this.txtDocumentoPagar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDocumentoPagar.FocusHighlightColor = System.Drawing.Color.LemonChiffon;
            this.txtDocumentoPagar.FocusHighlightEnabled = true;
            this.txtDocumentoPagar.Location = new System.Drawing.Point(91, 120);
            this.txtDocumentoPagar.Name = "txtDocumentoPagar";
            this.txtDocumentoPagar.Size = new System.Drawing.Size(137, 20);
            this.txtDocumentoPagar.TabIndex = 3;
            // 
            // txtReferencia
            // 
            // 
            // 
            // 
            this.txtReferencia.Border.Class = "TextBoxBorder";
            this.txtReferencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReferencia.FocusHighlightColor = System.Drawing.Color.LemonChiffon;
            this.txtReferencia.FocusHighlightEnabled = true;
            this.txtReferencia.Location = new System.Drawing.Point(91, 146);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(136, 20);
            this.txtReferencia.TabIndex = 3;
            // 
            // frmAgregarCxC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 301);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.TabControl1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(638, 339);
            this.MinimumSize = new System.Drawing.Size(638, 339);
            this.Name = "frmAgregarCxC";
            this.Load += new System.EventHandler(this.frmAgregarCxC_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.TextBox txtMonto;
        internal System.Windows.Forms.Label lblTipo;
        internal System.Windows.Forms.Label lblCliente;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.DateTimePicker dtpFecha_Emision;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnBuscarCliente;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label txtCodigo;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.DateTimePicker dtpFecha_Vencimiento;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.TextBox txtNotas;
        internal System.Windows.Forms.Label Label3;
        internal DevComponents.DotNetBar.ButtonX btnCancelar;
        internal DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonX btnVerDocumentos;
        private DevComponents.DotNetBar.ButtonX btnVerReferencia;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbClientes;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbConcepto;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFactura;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReferencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDocumentoPagar;
    }
}