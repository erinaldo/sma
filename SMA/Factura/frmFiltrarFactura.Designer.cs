namespace SMA.Factura
{
    partial class frmFiltrarFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltrarFactura));
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.ckbDevueltas = new System.Windows.Forms.CheckBox();
            this.ckbCancelada = new System.Windows.Forms.CheckBox();
            this.ckbGenerada = new System.Windows.Forms.CheckBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtDocumentoHasta = new System.Windows.Forms.TextBox();
            this.txtDocumentoDesde = new System.Windows.Forms.TextBox();
            this.cbbCliente = new System.Windows.Forms.ComboBox();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnSeleccionar = new DevComponents.DotNetBar.ButtonX();
            this.btnVerReferencia = new DevComponents.DotNetBar.ButtonX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.cbbCriterio = new System.Windows.Forms.ComboBox();
            this.GroupBox4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(39, 13);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Cliente";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.ckbDevueltas);
            this.GroupBox4.Controls.Add(this.ckbCancelada);
            this.GroupBox4.Controls.Add(this.ckbGenerada);
            this.GroupBox4.Location = new System.Drawing.Point(9, 233);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(309, 54);
            this.GroupBox4.TabIndex = 21;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Estatus:";
            // 
            // ckbDevueltas
            // 
            this.ckbDevueltas.AutoSize = true;
            this.ckbDevueltas.Location = new System.Drawing.Point(223, 21);
            this.ckbDevueltas.Name = "ckbDevueltas";
            this.ckbDevueltas.Size = new System.Drawing.Size(74, 17);
            this.ckbDevueltas.TabIndex = 2;
            this.ckbDevueltas.Text = "Devueltas";
            this.ckbDevueltas.UseVisualStyleBackColor = true;
            // 
            // ckbCancelada
            // 
            this.ckbCancelada.AutoSize = true;
            this.ckbCancelada.Location = new System.Drawing.Point(115, 21);
            this.ckbCancelada.Name = "ckbCancelada";
            this.ckbCancelada.Size = new System.Drawing.Size(77, 17);
            this.ckbCancelada.TabIndex = 1;
            this.ckbCancelada.Text = "Cancelada";
            this.ckbCancelada.UseVisualStyleBackColor = true;
            // 
            // ckbGenerada
            // 
            this.ckbGenerada.AutoSize = true;
            this.ckbGenerada.Location = new System.Drawing.Point(11, 21);
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
            this.GroupBox2.Controls.Add(this.dtpFechaHasta);
            this.GroupBox2.Controls.Add(this.dtpFechaDesde);
            this.GroupBox2.Location = new System.Drawing.Point(9, 113);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(309, 55);
            this.GroupBox2.TabIndex = 20;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Fecha elaboracion";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(154, 27);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(35, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Hasta";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 27);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(41, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Desde:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(195, 23);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(103, 20);
            this.dtpFechaHasta.TabIndex = 1;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(53, 23);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaDesde.TabIndex = 0;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtDocumentoHasta);
            this.GroupBox1.Controls.Add(this.txtDocumentoDesde);
            this.GroupBox1.Location = new System.Drawing.Point(9, 52);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(309, 55);
            this.GroupBox1.TabIndex = 19;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Documento:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(153, 26);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 13);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Hasta:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 26);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Desde:";
            // 
            // txtDocumentoHasta
            // 
            this.txtDocumentoHasta.Location = new System.Drawing.Point(206, 23);
            this.txtDocumentoHasta.Name = "txtDocumentoHasta";
            this.txtDocumentoHasta.Size = new System.Drawing.Size(87, 20);
            this.txtDocumentoHasta.TabIndex = 1;
            // 
            // txtDocumentoDesde
            // 
            this.txtDocumentoDesde.Location = new System.Drawing.Point(53, 23);
            this.txtDocumentoDesde.Name = "txtDocumentoDesde";
            this.txtDocumentoDesde.Size = new System.Drawing.Size(87, 20);
            this.txtDocumentoDesde.TabIndex = 0;
            // 
            // cbbCliente
            // 
            this.cbbCliente.FormattingEnabled = true;
            this.cbbCliente.Location = new System.Drawing.Point(9, 25);
            this.cbbCliente.Name = "cbbCliente";
            this.cbbCliente.Size = new System.Drawing.Size(277, 21);
            this.cbbCliente.TabIndex = 28;
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
            this.btnCancelar.Location = new System.Drawing.Point(219, 293);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 39);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSeleccionar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.Image")));
            this.btnSeleccionar.Location = new System.Drawing.Point(114, 293);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(99, 39);
            this.btnSeleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSeleccionar.TabIndex = 29;
            this.btnSeleccionar.Text = "Aceptar";
            this.btnSeleccionar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnVerReferencia
            // 
            this.btnVerReferencia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerReferencia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVerReferencia.Image = global::SMA.Properties.Resources.find_icon;
            this.btnVerReferencia.Location = new System.Drawing.Point(292, 25);
            this.btnVerReferencia.Name = "btnVerReferencia";
            this.btnVerReferencia.Size = new System.Drawing.Size(26, 23);
            this.btnVerReferencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVerReferencia.TabIndex = 170;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtImporte);
            this.groupBox3.Controls.Add(this.cbbCriterio);
            this.groupBox3.Location = new System.Drawing.Point(9, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(309, 53);
            this.groupBox3.TabIndex = 171;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valor";
            // 
            // txtImporte
            // 
            this.txtImporte.AcceptsReturn = true;
            this.txtImporte.Location = new System.Drawing.Point(156, 20);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(4);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(141, 20);
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
            // frmFiltrarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 333);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnVerReferencia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.cbbCliente);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmFiltrarFactura";
            this.Text = "Buscar factura";
            this.Load += new System.EventHandler(this.frmFiltrarFactura_Load);
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

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.CheckBox ckbCancelada;
        internal System.Windows.Forms.CheckBox ckbGenerada;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DateTimePicker dtpFechaHasta;
        internal System.Windows.Forms.DateTimePicker dtpFechaDesde;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtDocumentoHasta;
        internal System.Windows.Forms.TextBox txtDocumentoDesde;
        private System.Windows.Forms.ComboBox cbbCliente;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnSeleccionar;
        private DevComponents.DotNetBar.ButtonX btnVerReferencia;
        internal System.Windows.Forms.CheckBox ckbDevueltas;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.TextBox txtImporte;
        internal System.Windows.Forms.ComboBox cbbCriterio;
    }
}