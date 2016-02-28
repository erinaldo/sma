namespace SMA.Factura.Comprobantes
{
    partial class frmAgregarEditarComprobantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarComprobantes));
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.ckbEstatus = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblContador = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtContador = new System.Windows.Forms.TextBox();
            this.txtCantidadComprobantes = new System.Windows.Forms.TextBox();
            this.txtUltimosCaracteres = new System.Windows.Forms.TextBox();
            this.txtPrimerosCaracteres = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cbbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(341, 245);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 132;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(233, 245);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 131;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // ckbEstatus
            // 
            this.ckbEstatus.AutoSize = true;
            this.ckbEstatus.Location = new System.Drawing.Point(10, 81);
            this.ckbEstatus.Name = "ckbEstatus";
            this.ckbEstatus.Size = new System.Drawing.Size(118, 17);
            this.ckbEstatus.TabIndex = 130;
            this.ckbEstatus.Text = "Activo / Supendido";
            this.ckbEstatus.UseVisualStyleBackColor = true;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(325, 34);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(81, 13);
            this.Label6.TabIndex = 129;
            this.Label6.Text = "Fecha creacion";
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Enabled = false;
            this.dtpFechaCreacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(328, 53);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(109, 20);
            this.dtpFechaCreacion.TabIndex = 128;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblContador);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtContador);
            this.GroupBox1.Controls.Add(this.txtCantidadComprobantes);
            this.GroupBox1.Controls.Add(this.txtUltimosCaracteres);
            this.GroupBox1.Controls.Add(this.txtPrimerosCaracteres);
            this.GroupBox1.Location = new System.Drawing.Point(10, 107);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(431, 126);
            this.GroupBox1.TabIndex = 127;
            this.GroupBox1.TabStop = false;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(273, 74);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(50, 13);
            this.lblContador.TabIndex = 15;
            this.lblContador.Text = "Contador";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 75);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(134, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Cantidad de comprobantes";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(273, 19);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(103, 13);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "Ultimos 8 caracteres";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(196, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Primeros 11 caracteres letras y Numeros";
            // 
            // txtContador
            // 
            this.txtContador.Location = new System.Drawing.Point(273, 93);
            this.txtContador.Name = "txtContador";
            this.txtContador.Size = new System.Drawing.Size(149, 20);
            this.txtContador.TabIndex = 11;
            // 
            // txtCantidadComprobantes
            // 
            this.txtCantidadComprobantes.Location = new System.Drawing.Point(7, 94);
            this.txtCantidadComprobantes.Name = "txtCantidadComprobantes";
            this.txtCantidadComprobantes.Size = new System.Drawing.Size(126, 20);
            this.txtCantidadComprobantes.TabIndex = 10;
            // 
            // txtUltimosCaracteres
            // 
            this.txtUltimosCaracteres.Location = new System.Drawing.Point(273, 38);
            this.txtUltimosCaracteres.MaxLength = 8;
            this.txtUltimosCaracteres.Name = "txtUltimosCaracteres";
            this.txtUltimosCaracteres.Size = new System.Drawing.Size(149, 20);
            this.txtUltimosCaracteres.TabIndex = 9;
            // 
            // txtPrimerosCaracteres
            // 
            this.txtPrimerosCaracteres.Location = new System.Drawing.Point(7, 39);
            this.txtPrimerosCaracteres.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrimerosCaracteres.MaxLength = 11;
            this.txtPrimerosCaracteres.Name = "txtPrimerosCaracteres";
            this.txtPrimerosCaracteres.Size = new System.Drawing.Size(252, 20);
            this.txtPrimerosCaracteres.TabIndex = 8;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(10, 32);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(97, 13);
            this.Label5.TabIndex = 126;
            this.Label5.Text = "Tipo de Comprante";
            // 
            // cbbTipoComprobante
            // 
            this.cbbTipoComprobante.DisplayMember = "DESCRIPCION";
            this.cbbTipoComprobante.FormattingEnabled = true;
            this.cbbTipoComprobante.Location = new System.Drawing.Point(10, 51);
            this.cbbTipoComprobante.Name = "cbbTipoComprobante";
            this.cbbTipoComprobante.Size = new System.Drawing.Size(252, 21);
            this.cbbTipoComprobante.TabIndex = 125;
            this.cbbTipoComprobante.ValueMember = "COMPROBANTE_ID";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 133;
            this.label4.Text = "ID";
            // 
            // lblCodigo
            // 
            this.lblCodigo.BackColor = System.Drawing.SystemColors.Info;
            this.lblCodigo.Location = new System.Drawing.Point(371, 5);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(66, 20);
            this.lblCodigo.TabIndex = 134;
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAgregarEditarComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 299);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.ckbEstatus);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.dtpFechaCreacion);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.cbbTipoComprobante);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmAgregarEditarComprobantes";
            this.Load += new System.EventHandler(this.frmAgregarEditarComprobantes_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        internal System.Windows.Forms.CheckBox ckbEstatus;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lblContador;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtContador;
        internal System.Windows.Forms.TextBox txtCantidadComprobantes;
        internal System.Windows.Forms.TextBox txtUltimosCaracteres;
        internal System.Windows.Forms.TextBox txtPrimerosCaracteres;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox cbbTipoComprobante;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lblCodigo;
    }
}