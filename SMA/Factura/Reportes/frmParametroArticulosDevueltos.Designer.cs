namespace SMA.Factura.Reportes
{
    partial class frmParametroArticulosDevueltos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametroArticulosDevueltos));
            this.label8 = new System.Windows.Forms.Label();
            this.cbbVendedor = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbFamilia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbCombos = new System.Windows.Forms.CheckBox();
            this.ckbServicios = new System.Windows.Forms.CheckBox();
            this.ckbFisicos = new System.Windows.Forms.CheckBox();
            this.ckbTodos = new System.Windows.Forms.CheckBox();
            this.cbbProducto = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbbCliente = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarDocumentoHasta = new System.Windows.Forms.Button();
            this.btnBuscarDocumentoDesde = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.txtDocumentoHasta = new System.Windows.Forms.TextBox();
            this.txtDocumentoDesde = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Vendedor:";
            // 
            // cbbVendedor
            // 
            this.cbbVendedor.FormattingEnabled = true;
            this.cbbVendedor.Location = new System.Drawing.Point(162, 275);
            this.cbbVendedor.Name = "cbbVendedor";
            this.cbbVendedor.Size = new System.Drawing.Size(242, 21);
            this.cbbVendedor.TabIndex = 26;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(297, 302);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(178, 302);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 24;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.cbbFamilia);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.ckbCombos);
            this.groupBox3.Controls.Add(this.ckbServicios);
            this.groupBox3.Controls.Add(this.ckbFisicos);
            this.groupBox3.Controls.Add(this.ckbTodos);
            this.groupBox3.Controls.Add(this.cbbProducto);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 100);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            // 
            // button3
            // 
            this.button3.Image = global::SMA.Properties.Resources.find_icon;
            this.button3.Location = new System.Drawing.Point(351, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 23);
            this.button3.TabIndex = 28;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::SMA.Properties.Resources.find_icon;
            this.button1.Location = new System.Drawing.Point(351, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 27;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbbFamilia
            // 
            this.cbbFamilia.FormattingEnabled = true;
            this.cbbFamilia.Location = new System.Drawing.Point(68, 44);
            this.cbbFamilia.Name = "cbbFamilia";
            this.cbbFamilia.Size = new System.Drawing.Size(277, 21);
            this.cbbFamilia.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Familia:";
            // 
            // ckbCombos
            // 
            this.ckbCombos.AutoSize = true;
            this.ckbCombos.Location = new System.Drawing.Point(309, 74);
            this.ckbCombos.Name = "ckbCombos";
            this.ckbCombos.Size = new System.Drawing.Size(64, 17);
            this.ckbCombos.TabIndex = 24;
            this.ckbCombos.Text = "Combos";
            this.ckbCombos.UseVisualStyleBackColor = true;
            // 
            // ckbServicios
            // 
            this.ckbServicios.AutoSize = true;
            this.ckbServicios.Location = new System.Drawing.Point(215, 74);
            this.ckbServicios.Name = "ckbServicios";
            this.ckbServicios.Size = new System.Drawing.Size(69, 17);
            this.ckbServicios.TabIndex = 23;
            this.ckbServicios.Text = "Servicios";
            this.ckbServicios.UseVisualStyleBackColor = true;
            // 
            // ckbFisicos
            // 
            this.ckbFisicos.AutoSize = true;
            this.ckbFisicos.Location = new System.Drawing.Point(132, 74);
            this.ckbFisicos.Name = "ckbFisicos";
            this.ckbFisicos.Size = new System.Drawing.Size(58, 17);
            this.ckbFisicos.TabIndex = 22;
            this.ckbFisicos.Text = "Fisicos";
            this.ckbFisicos.UseVisualStyleBackColor = true;
            // 
            // ckbTodos
            // 
            this.ckbTodos.AutoSize = true;
            this.ckbTodos.Checked = true;
            this.ckbTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbTodos.Location = new System.Drawing.Point(51, 74);
            this.ckbTodos.Name = "ckbTodos";
            this.ckbTodos.Size = new System.Drawing.Size(56, 17);
            this.ckbTodos.TabIndex = 21;
            this.ckbTodos.Text = "Todos";
            this.ckbTodos.UseVisualStyleBackColor = true;
            // 
            // cbbProducto
            // 
            this.cbbProducto.FormattingEnabled = true;
            this.cbbProducto.Location = new System.Drawing.Point(68, 17);
            this.cbbProducto.Name = "cbbProducto";
            this.cbbProducto.Size = new System.Drawing.Size(277, 21);
            this.cbbProducto.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Producto:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.cbbCliente);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 56);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente";
            // 
            // button2
            // 
            this.button2.Image = global::SMA.Properties.Resources.find_icon;
            this.button2.Location = new System.Drawing.Point(351, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 18;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbbCliente
            // 
            this.cbbCliente.FormattingEnabled = true;
            this.cbbCliente.Location = new System.Drawing.Point(9, 21);
            this.cbbCliente.Name = "cbbCliente";
            this.cbbCliente.Size = new System.Drawing.Size(336, 21);
            this.cbbCliente.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarDocumentoHasta);
            this.groupBox1.Controls.Add(this.btnBuscarDocumentoDesde);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpFechaHasta);
            this.groupBox1.Controls.Add(this.dtpFechaDesde);
            this.groupBox1.Controls.Add(this.txtDocumentoHasta);
            this.groupBox1.Controls.Add(this.txtDocumentoDesde);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 89);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango documentos";
            // 
            // btnBuscarDocumentoHasta
            // 
            this.btnBuscarDocumentoHasta.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarDocumentoHasta.Location = new System.Drawing.Point(351, 32);
            this.btnBuscarDocumentoHasta.Name = "btnBuscarDocumentoHasta";
            this.btnBuscarDocumentoHasta.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarDocumentoHasta.TabIndex = 17;
            this.btnBuscarDocumentoHasta.UseVisualStyleBackColor = true;
            this.btnBuscarDocumentoHasta.Click += new System.EventHandler(this.btnBuscarDocumentoHasta_Click);
            // 
            // btnBuscarDocumentoDesde
            // 
            this.btnBuscarDocumentoDesde.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarDocumentoDesde.Location = new System.Drawing.Point(201, 30);
            this.btnBuscarDocumentoDesde.Name = "btnBuscarDocumentoDesde";
            this.btnBuscarDocumentoDesde.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarDocumentoDesde.TabIndex = 16;
            this.btnBuscarDocumentoDesde.UseVisualStyleBackColor = true;
            this.btnBuscarDocumentoDesde.Click += new System.EventHandler(this.btnBuscarDocumentoDesde_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Desde";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(243, 57);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaHasta.TabIndex = 6;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(93, 56);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaDesde.TabIndex = 5;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // txtDocumentoHasta
            // 
            this.txtDocumentoHasta.Location = new System.Drawing.Point(243, 33);
            this.txtDocumentoHasta.Name = "txtDocumentoHasta";
            this.txtDocumentoHasta.Size = new System.Drawing.Size(102, 20);
            this.txtDocumentoHasta.TabIndex = 4;
            // 
            // txtDocumentoDesde
            // 
            this.txtDocumentoDesde.Location = new System.Drawing.Point(93, 32);
            this.txtDocumentoDesde.Name = "txtDocumentoDesde";
            this.txtDocumentoDesde.Size = new System.Drawing.Size(102, 20);
            this.txtDocumentoDesde.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha creación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Documento";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // frmParametroArticulosDevueltos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 356);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbbVendedor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.EnableGlass = false;
            this.Name = "frmParametroArticulosDevueltos";
            this.Text = "Reporte articulos devueltos";
            this.Load += new System.EventHandler(this.frmParametroArticulosDevueltos_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbVendedor;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbFamilia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckbCombos;
        private System.Windows.Forms.CheckBox ckbServicios;
        private System.Windows.Forms.CheckBox ckbFisicos;
        private System.Windows.Forms.CheckBox ckbTodos;
        private System.Windows.Forms.ComboBox cbbProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbbCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarDocumentoHasta;
        private System.Windows.Forms.Button btnBuscarDocumentoDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.TextBox txtDocumentoHasta;
        private System.Windows.Forms.TextBox txtDocumentoDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}