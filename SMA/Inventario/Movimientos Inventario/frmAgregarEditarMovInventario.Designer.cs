namespace SMA.Inventario
{
    partial class frmAgregarEditarMovInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarMovInventario));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblCodigoArticulo = new System.Windows.Forms.Label();
            this.ckbModificarPrecio = new System.Windows.Forms.CheckBox();
            this.gpbCliente_Proveedor = new System.Windows.Forms.GroupBox();
            this.btnVerClienteProveedor = new System.Windows.Forms.Button();
            this.cbbProveedor = new System.Windows.Forms.ComboBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.lblPrecioPublico = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVerConceptos = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.cbConcepto = new System.Windows.Forms.ComboBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblDescripcionArticulo = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.Label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gpbCliente_Proveedor.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 247);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblCodigoArticulo);
            this.tabPage1.Controls.Add(this.ckbModificarPrecio);
            this.tabPage1.Controls.Add(this.gpbCliente_Proveedor);
            this.tabPage1.Controls.Add(this.GroupBox3);
            this.tabPage1.Controls.Add(this.GroupBox1);
            this.tabPage1.Controls.Add(this.lblDescripcionArticulo);
            this.tabPage1.Controls.Add(this.Label1);
            this.tabPage1.Controls.Add(this.Label14);
            this.tabPage1.Controls.Add(this.dtpFecha);
            this.tabPage1.Controls.Add(this.Label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(495, 221);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informacion";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblCodigoArticulo
            // 
            this.lblCodigoArticulo.BackColor = System.Drawing.SystemColors.Info;
            this.lblCodigoArticulo.Location = new System.Drawing.Point(78, 12);
            this.lblCodigoArticulo.Name = "lblCodigoArticulo";
            this.lblCodigoArticulo.Size = new System.Drawing.Size(121, 22);
            this.lblCodigoArticulo.TabIndex = 75;
            // 
            // ckbModificarPrecio
            // 
            this.ckbModificarPrecio.AutoSize = true;
            this.ckbModificarPrecio.Location = new System.Drawing.Point(317, 197);
            this.ckbModificarPrecio.Name = "ckbModificarPrecio";
            this.ckbModificarPrecio.Size = new System.Drawing.Size(133, 17);
            this.ckbModificarPrecio.TabIndex = 74;
            this.ckbModificarPrecio.Text = "Modificar Precio Venta";
            this.ckbModificarPrecio.UseVisualStyleBackColor = true;
            // 
            // gpbCliente_Proveedor
            // 
            this.gpbCliente_Proveedor.Controls.Add(this.btnVerClienteProveedor);
            this.gpbCliente_Proveedor.Controls.Add(this.cbbProveedor);
            this.gpbCliente_Proveedor.Location = new System.Drawing.Point(12, 162);
            this.gpbCliente_Proveedor.Margin = new System.Windows.Forms.Padding(4);
            this.gpbCliente_Proveedor.Name = "gpbCliente_Proveedor";
            this.gpbCliente_Proveedor.Padding = new System.Windows.Forms.Padding(4);
            this.gpbCliente_Proveedor.Size = new System.Drawing.Size(287, 52);
            this.gpbCliente_Proveedor.TabIndex = 71;
            this.gpbCliente_Proveedor.TabStop = false;
            this.gpbCliente_Proveedor.Text = "Cliente Proveedor";
            // 
            // btnVerClienteProveedor
            // 
            this.btnVerClienteProveedor.Image = global::SMA.Properties.Resources.find_icon;
            this.btnVerClienteProveedor.Location = new System.Drawing.Point(253, 19);
            this.btnVerClienteProveedor.Name = "btnVerClienteProveedor";
            this.btnVerClienteProveedor.Size = new System.Drawing.Size(26, 23);
            this.btnVerClienteProveedor.TabIndex = 17;
            this.btnVerClienteProveedor.UseVisualStyleBackColor = true;
            // 
            // cbbProveedor
            // 
            this.cbbProveedor.FormattingEnabled = true;
            this.cbbProveedor.Location = new System.Drawing.Point(7, 21);
            this.cbbProveedor.Name = "cbbProveedor";
            this.cbbProveedor.Size = new System.Drawing.Size(240, 21);
            this.cbbProveedor.TabIndex = 0;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.lblPrecioPublico);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.txtCosto);
            this.GroupBox3.Controls.Add(this.txtCantidad);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Location = new System.Drawing.Point(307, 71);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox3.Size = new System.Drawing.Size(182, 107);
            this.GroupBox3.TabIndex = 70;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Montos";
            // 
            // lblPrecioPublico
            // 
            this.lblPrecioPublico.BackColor = System.Drawing.SystemColors.Info;
            this.lblPrecioPublico.Location = new System.Drawing.Point(68, 76);
            this.lblPrecioPublico.Name = "lblPrecioPublico";
            this.lblPrecioPublico.Size = new System.Drawing.Size(107, 22);
            this.lblPrecioPublico.TabIndex = 17;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(10, 80);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(49, 13);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "Precio 1:";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(68, 51);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(107, 20);
            this.txtCosto.TabIndex = 6;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(68, 23);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(107, 20);
            this.txtCantidad.TabIndex = 4;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(10, 54);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(37, 13);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "Costo:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(10, 26);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(52, 13);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Cantidad:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnVerConceptos);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.cbConcepto);
            this.GroupBox1.Controls.Add(this.txtDocumento);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(9, 71);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(290, 83);
            this.GroupBox1.TabIndex = 69;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Referencia";
            // 
            // btnVerConceptos
            // 
            this.btnVerConceptos.Image = global::SMA.Properties.Resources.find_icon;
            this.btnVerConceptos.Location = new System.Drawing.Point(257, 48);
            this.btnVerConceptos.Name = "btnVerConceptos";
            this.btnVerConceptos.Size = new System.Drawing.Size(26, 23);
            this.btnVerConceptos.TabIndex = 16;
            this.btnVerConceptos.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(8, 53);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(73, 13);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Tipo de Mov.:";
            // 
            // cbConcepto
            // 
            this.cbConcepto.DisplayMember = "Descripcion_Concepto";
            this.cbConcepto.FormattingEnabled = true;
            this.cbConcepto.Location = new System.Drawing.Point(89, 49);
            this.cbConcepto.Margin = new System.Windows.Forms.Padding(4);
            this.cbConcepto.Name = "cbConcepto";
            this.cbConcepto.Size = new System.Drawing.Size(161, 21);
            this.cbConcepto.TabIndex = 4;
            this.cbConcepto.ValueMember = "Concepto_ID";
            this.cbConcepto.SelectedValueChanged += new System.EventHandler(this.cbConcepto_SelectedValueChanged);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(89, 21);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(82, 20);
            this.txtDocumento.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 26);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Documento:";
            // 
            // lblDescripcionArticulo
            // 
            this.lblDescripcionArticulo.BackColor = System.Drawing.SystemColors.Info;
            this.lblDescripcionArticulo.Location = new System.Drawing.Point(78, 40);
            this.lblDescripcionArticulo.Name = "lblDescripcionArticulo";
            this.lblDescripcionArticulo.Size = new System.Drawing.Size(399, 22);
            this.lblDescripcionArticulo.TabIndex = 66;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(326, 13);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 13);
            this.Label1.TabIndex = 63;
            this.Label1.Text = "Fecha:";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(6, 45);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(66, 13);
            this.Label14.TabIndex = 65;
            this.Label14.Text = "Descripcion:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(374, 10);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(103, 20);
            this.dtpFecha.TabIndex = 62;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(6, 17);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(43, 13);
            this.Label9.TabIndex = 64;
            this.Label9.Text = "Codigo:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNotas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(495, 221);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(6, 29);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(483, 175);
            this.txtNotas.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(402, 265);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 79;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(283, 265);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 78;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // frmAgregarEditarMovInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 309);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmAgregarEditarMovInventario";
            this.Load += new System.EventHandler(this.frmAgregarEditarMovInventario_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gpbCliente_Proveedor.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.Label lblCodigoArticulo;
        internal System.Windows.Forms.CheckBox ckbModificarPrecio;
        internal System.Windows.Forms.GroupBox gpbCliente_Proveedor;
        private System.Windows.Forms.Button btnVerClienteProveedor;
        internal System.Windows.Forms.ComboBox cbbProveedor;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label lblPrecioPublico;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtCosto;
        internal System.Windows.Forms.TextBox txtCantidad;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button btnVerConceptos;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox cbConcepto;
        internal System.Windows.Forms.TextBox txtDocumento;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblDescripcionArticulo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.DateTimePicker dtpFecha;
        internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtNotas;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
    }
}