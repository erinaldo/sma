namespace SMA.Compras.Reportes
{
    partial class frmParametroResumenCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametroResumenCompras));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbbFamilia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscarProveedorHasta = new System.Windows.Forms.Button();
            this.btnBuscarProveedorDesde = new System.Windows.Forms.Button();
            this.cbbProveedorHasta = new System.Windows.Forms.ComboBox();
            this.cbbProveedorDesde = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbbFamilia);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 48);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Productos";
            // 
            // cbbFamilia
            // 
            this.cbbFamilia.FormattingEnabled = true;
            this.cbbFamilia.Location = new System.Drawing.Point(62, 17);
            this.cbbFamilia.Name = "cbbFamilia";
            this.cbbFamilia.Size = new System.Drawing.Size(315, 21);
            this.cbbFamilia.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Familia:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnBuscarProveedorHasta);
            this.groupBox2.Controls.Add(this.btnBuscarProveedorDesde);
            this.groupBox2.Controls.Add(this.cbbProveedorHasta);
            this.groupBox2.Controls.Add(this.cbbProveedorDesde);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 83);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rango proveedores";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Hasta:";
            // 
            // btnBuscarProveedorHasta
            // 
            this.btnBuscarProveedorHasta.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarProveedorHasta.Location = new System.Drawing.Point(351, 46);
            this.btnBuscarProveedorHasta.Name = "btnBuscarProveedorHasta";
            this.btnBuscarProveedorHasta.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarProveedorHasta.TabIndex = 19;
            this.btnBuscarProveedorHasta.UseVisualStyleBackColor = true;
            this.btnBuscarProveedorHasta.Click += new System.EventHandler(this.btnBuscarProveedorHasta_Click);
            // 
            // btnBuscarProveedorDesde
            // 
            this.btnBuscarProveedorDesde.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarProveedorDesde.Location = new System.Drawing.Point(351, 19);
            this.btnBuscarProveedorDesde.Name = "btnBuscarProveedorDesde";
            this.btnBuscarProveedorDesde.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarProveedorDesde.TabIndex = 18;
            this.btnBuscarProveedorDesde.UseVisualStyleBackColor = true;
            this.btnBuscarProveedorDesde.Click += new System.EventHandler(this.btnBuscarProveedorDesde_Click);
            // 
            // cbbProveedorHasta
            // 
            this.cbbProveedorHasta.FormattingEnabled = true;
            this.cbbProveedorHasta.Location = new System.Drawing.Point(62, 48);
            this.cbbProveedorHasta.Name = "cbbProveedorHasta";
            this.cbbProveedorHasta.Size = new System.Drawing.Size(283, 21);
            this.cbbProveedorHasta.TabIndex = 2;
            // 
            // cbbProveedorDesde
            // 
            this.cbbProveedorDesde.FormattingEnabled = true;
            this.cbbProveedorDesde.Location = new System.Drawing.Point(62, 21);
            this.cbbProveedorDesde.Name = "cbbProveedorDesde";
            this.cbbProveedorDesde.Size = new System.Drawing.Size(283, 21);
            this.cbbProveedorDesde.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Desde:";
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
            this.dtpFechaHasta.Size = new System.Drawing.Size(84, 20);
            this.dtpFechaHasta.TabIndex = 6;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(93, 56);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(84, 20);
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
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(297, 250);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(178, 250);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 24;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // frmParametroResumenCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 295);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(429, 333);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(429, 333);
            this.Name = "frmParametroResumenCompras";
            this.Load += new System.EventHandler(this.frmParametroResumenCompras_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbbFamilia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscarProveedorHasta;
        private System.Windows.Forms.Button btnBuscarProveedorDesde;
        private System.Windows.Forms.ComboBox cbbProveedorHasta;
        private System.Windows.Forms.ComboBox cbbProveedorDesde;
        private System.Windows.Forms.Label label5;
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