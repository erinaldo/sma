namespace SMA.Inventario.Reportes
{
    partial class frmParametroVentasPorCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametroVentasPorCliente));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDocumentoHasta = new System.Windows.Forms.TextBox();
            this.txtDocumentoDesde = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.cbbFamilia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbConceptos = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarHasta = new System.Windows.Forms.Button();
            this.btnBuscarDesde = new System.Windows.Forms.Button();
            this.cbbCodigoHasta = new System.Windows.Forms.ComboBox();
            this.cbbCodigoDesde = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbClienteProveedor = new System.Windows.Forms.GroupBox();
            this.btnBuscarClienteHasta = new System.Windows.Forms.Button();
            this.btnBuscarClienteDesde = new System.Windows.Forms.Button();
            this.cbbClienteHasta = new System.Windows.Forms.ComboBox();
            this.cbbClienteDesde = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.ckbDetalle = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbClienteProveedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDocumentoHasta);
            this.groupBox3.Controls.Add(this.txtDocumentoDesde);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(9, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 49);
            this.groupBox3.TabIndex = 152;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rango de documentos";
            // 
            // txtDocumentoHasta
            // 
            this.txtDocumentoHasta.Location = new System.Drawing.Point(199, 20);
            this.txtDocumentoHasta.Name = "txtDocumentoHasta";
            this.txtDocumentoHasta.Size = new System.Drawing.Size(98, 20);
            this.txtDocumentoHasta.TabIndex = 5;
            // 
            // txtDocumentoDesde
            // 
            this.txtDocumentoDesde.Location = new System.Drawing.Point(51, 20);
            this.txtDocumentoDesde.Name = "txtDocumentoDesde";
            this.txtDocumentoDesde.Size = new System.Drawing.Size(98, 20);
            this.txtDocumentoDesde.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Hasta:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpFechaHasta);
            this.groupBox2.Controls.Add(this.dtpFechaDesde);
            this.groupBox2.Location = new System.Drawing.Point(9, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 50);
            this.groupBox2.TabIndex = 151;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rango de fechas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Hasta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Desde:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(199, 18);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaHasta.TabIndex = 1;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(51, 18);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaDesde.TabIndex = 0;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // cbbFamilia
            // 
            this.cbbFamilia.FormattingEnabled = true;
            this.cbbFamilia.Location = new System.Drawing.Point(65, 287);
            this.cbbFamilia.Name = "cbbFamilia";
            this.cbbFamilia.Size = new System.Drawing.Size(241, 21);
            this.cbbFamilia.TabIndex = 149;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Familia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 146;
            this.label4.Text = "Conceptos";
            // 
            // lbConceptos
            // 
            this.lbConceptos.FormattingEnabled = true;
            this.lbConceptos.Location = new System.Drawing.Point(317, 189);
            this.lbConceptos.Name = "lbConceptos";
            this.lbConceptos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbConceptos.Size = new System.Drawing.Size(219, 121);
            this.lbConceptos.TabIndex = 145;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarHasta);
            this.groupBox1.Controls.Add(this.btnBuscarDesde);
            this.groupBox1.Controls.Add(this.cbbCodigoHasta);
            this.groupBox1.Controls.Add(this.cbbCodigoDesde);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 76);
            this.groupBox1.TabIndex = 144;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango de productos";
            // 
            // btnBuscarHasta
            // 
            this.btnBuscarHasta.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarHasta.Location = new System.Drawing.Point(491, 44);
            this.btnBuscarHasta.Name = "btnBuscarHasta";
            this.btnBuscarHasta.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarHasta.TabIndex = 19;
            this.btnBuscarHasta.UseVisualStyleBackColor = true;
            this.btnBuscarHasta.Click += new System.EventHandler(this.btnBuscarHasta_Click);
            // 
            // btnBuscarDesde
            // 
            this.btnBuscarDesde.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarDesde.Location = new System.Drawing.Point(491, 17);
            this.btnBuscarDesde.Name = "btnBuscarDesde";
            this.btnBuscarDesde.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarDesde.TabIndex = 18;
            this.btnBuscarDesde.UseVisualStyleBackColor = true;
            this.btnBuscarDesde.Click += new System.EventHandler(this.btnBuscarDesde_Click);
            // 
            // cbbCodigoHasta
            // 
            this.cbbCodigoHasta.FormattingEnabled = true;
            this.cbbCodigoHasta.Location = new System.Drawing.Point(51, 46);
            this.cbbCodigoHasta.Name = "cbbCodigoHasta";
            this.cbbCodigoHasta.Size = new System.Drawing.Size(434, 21);
            this.cbbCodigoHasta.TabIndex = 3;
            // 
            // cbbCodigoDesde
            // 
            this.cbbCodigoDesde.FormattingEnabled = true;
            this.cbbCodigoDesde.Location = new System.Drawing.Point(51, 19);
            this.cbbCodigoDesde.Name = "cbbCodigoDesde";
            this.cbbCodigoDesde.Size = new System.Drawing.Size(434, 21);
            this.cbbCodigoDesde.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde:";
            // 
            // gbClienteProveedor
            // 
            this.gbClienteProveedor.Controls.Add(this.btnBuscarClienteHasta);
            this.gbClienteProveedor.Controls.Add(this.btnBuscarClienteDesde);
            this.gbClienteProveedor.Controls.Add(this.cbbClienteHasta);
            this.gbClienteProveedor.Controls.Add(this.cbbClienteDesde);
            this.gbClienteProveedor.Controls.Add(this.label10);
            this.gbClienteProveedor.Controls.Add(this.label11);
            this.gbClienteProveedor.Location = new System.Drawing.Point(9, 94);
            this.gbClienteProveedor.Name = "gbClienteProveedor";
            this.gbClienteProveedor.Size = new System.Drawing.Size(528, 76);
            this.gbClienteProveedor.TabIndex = 153;
            this.gbClienteProveedor.TabStop = false;
            this.gbClienteProveedor.Text = "Rango de clientes";
            // 
            // btnBuscarClienteHasta
            // 
            this.btnBuscarClienteHasta.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarClienteHasta.Location = new System.Drawing.Point(491, 44);
            this.btnBuscarClienteHasta.Name = "btnBuscarClienteHasta";
            this.btnBuscarClienteHasta.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarClienteHasta.TabIndex = 19;
            this.btnBuscarClienteHasta.UseVisualStyleBackColor = true;
            this.btnBuscarClienteHasta.Click += new System.EventHandler(this.btnBuscarClienteHasta_Click);
            // 
            // btnBuscarClienteDesde
            // 
            this.btnBuscarClienteDesde.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarClienteDesde.Location = new System.Drawing.Point(491, 17);
            this.btnBuscarClienteDesde.Name = "btnBuscarClienteDesde";
            this.btnBuscarClienteDesde.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarClienteDesde.TabIndex = 18;
            this.btnBuscarClienteDesde.UseVisualStyleBackColor = true;
            this.btnBuscarClienteDesde.Click += new System.EventHandler(this.btnBuscarClienteDesde_Click);
            // 
            // cbbClienteHasta
            // 
            this.cbbClienteHasta.FormattingEnabled = true;
            this.cbbClienteHasta.Location = new System.Drawing.Point(51, 46);
            this.cbbClienteHasta.Name = "cbbClienteHasta";
            this.cbbClienteHasta.Size = new System.Drawing.Size(434, 21);
            this.cbbClienteHasta.TabIndex = 3;
            // 
            // cbbClienteDesde
            // 
            this.cbbClienteDesde.FormattingEnabled = true;
            this.cbbClienteDesde.Location = new System.Drawing.Point(51, 19);
            this.cbbClienteDesde.Name = "cbbClienteDesde";
            this.cbbClienteDesde.Size = new System.Drawing.Size(434, 21);
            this.cbbClienteDesde.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Hasta:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Desde:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(430, 316);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 155;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(311, 316);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 154;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // ckbDetalle
            // 
            this.ckbDetalle.AutoSize = true;
            this.ckbDetalle.Location = new System.Drawing.Point(9, 320);
            this.ckbDetalle.Name = "ckbDetalle";
            this.ckbDetalle.Size = new System.Drawing.Size(71, 17);
            this.ckbDetalle.TabIndex = 156;
            this.ckbDetalle.Text = "Detallado";
            this.ckbDetalle.UseVisualStyleBackColor = true;
            // 
            // frmParametroVentasPorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 362);
            this.Controls.Add(this.ckbDetalle);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbClienteProveedor);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbbFamilia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbConceptos);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(559, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(559, 400);
            this.Name = "frmParametroVentasPorCliente";
            this.Text = "Ventas por Cliente";
            this.Load += new System.EventHandler(this.frmParametroVentasPorCliente_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbClienteProveedor.ResumeLayout(false);
            this.gbClienteProveedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDocumentoHasta;
        private System.Windows.Forms.TextBox txtDocumentoDesde;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.ComboBox cbbFamilia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbConceptos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarHasta;
        private System.Windows.Forms.Button btnBuscarDesde;
        private System.Windows.Forms.ComboBox cbbCodigoHasta;
        private System.Windows.Forms.ComboBox cbbCodigoDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbClienteProveedor;
        private System.Windows.Forms.Button btnBuscarClienteHasta;
        private System.Windows.Forms.Button btnBuscarClienteDesde;
        private System.Windows.Forms.ComboBox cbbClienteHasta;
        private System.Windows.Forms.ComboBox cbbClienteDesde;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.CheckBox ckbDetalle;

    }
}