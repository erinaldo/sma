namespace SMA.Inventario.Reportes
{
    partial class frmParametrosCostoInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametrosCostoInventario));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarHasta = new System.Windows.Forms.Button();
            this.btnBuscarDesde = new System.Windows.Forms.Button();
            this.cbbCodigoHasta = new System.Windows.Forms.ComboBox();
            this.cbbCodigoDesde = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbFamilia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbExistencia = new System.Windows.Forms.RadioButton();
            this.rbFamilia = new System.Windows.Forms.RadioButton();
            this.rbDescripcion = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarHasta);
            this.groupBox1.Controls.Add(this.btnBuscarDesde);
            this.groupBox1.Controls.Add(this.cbbCodigoHasta);
            this.groupBox1.Controls.Add(this.cbbCodigoDesde);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 81);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango de productos";
            // 
            // btnBuscarHasta
            // 
            this.btnBuscarHasta.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarHasta.Location = new System.Drawing.Point(491, 44);
            this.btnBuscarHasta.Name = "btnBuscarHasta";
            this.btnBuscarHasta.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarHasta.TabIndex = 17;
            this.btnBuscarHasta.UseVisualStyleBackColor = true;
            this.btnBuscarHasta.Click += new System.EventHandler(this.btnBuscarHasta_Click);
            // 
            // btnBuscarDesde
            // 
            this.btnBuscarDesde.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarDesde.Location = new System.Drawing.Point(491, 17);
            this.btnBuscarDesde.Name = "btnBuscarDesde";
            this.btnBuscarDesde.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarDesde.TabIndex = 16;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbFamilia);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 51);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // cbFamilia
            // 
            this.cbFamilia.FormattingEnabled = true;
            this.cbFamilia.Location = new System.Drawing.Point(52, 19);
            this.cbFamilia.Name = "cbFamilia";
            this.cbFamilia.Size = new System.Drawing.Size(240, 21);
            this.cbFamilia.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Familia:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(434, 172);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(315, 172);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 22;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbExistencia);
            this.groupBox3.Controls.Add(this.rbFamilia);
            this.groupBox3.Controls.Add(this.rbDescripcion);
            this.groupBox3.Controls.Add(this.rbCodigo);
            this.groupBox3.Location = new System.Drawing.Point(318, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 66);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordenar por";
            // 
            // rbExistencia
            // 
            this.rbExistencia.AutoSize = true;
            this.rbExistencia.Location = new System.Drawing.Point(125, 22);
            this.rbExistencia.Name = "rbExistencia";
            this.rbExistencia.Size = new System.Drawing.Size(73, 17);
            this.rbExistencia.TabIndex = 3;
            this.rbExistencia.Text = "Existencia";
            this.rbExistencia.UseVisualStyleBackColor = true;
            // 
            // rbFamilia
            // 
            this.rbFamilia.AutoSize = true;
            this.rbFamilia.Location = new System.Drawing.Point(125, 45);
            this.rbFamilia.Name = "rbFamilia";
            this.rbFamilia.Size = new System.Drawing.Size(57, 17);
            this.rbFamilia.TabIndex = 2;
            this.rbFamilia.Text = "Familia";
            this.rbFamilia.UseVisualStyleBackColor = true;
            // 
            // rbDescripcion
            // 
            this.rbDescripcion.AutoSize = true;
            this.rbDescripcion.Location = new System.Drawing.Point(24, 43);
            this.rbDescripcion.Name = "rbDescripcion";
            this.rbDescripcion.Size = new System.Drawing.Size(81, 17);
            this.rbDescripcion.TabIndex = 1;
            this.rbDescripcion.Text = "Descripción";
            this.rbDescripcion.UseVisualStyleBackColor = true;
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Checked = true;
            this.rbCodigo.Location = new System.Drawing.Point(24, 20);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(95, 17);
            this.rbCodigo.TabIndex = 0;
            this.rbCodigo.TabStop = true;
            this.rbCodigo.Text = "Codigo articulo";
            this.rbCodigo.UseVisualStyleBackColor = true;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // frmParametrosCostoInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 216);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(559, 254);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(559, 254);
            this.Name = "frmParametrosCostoInventario";
            this.Text = "Costo de inventario";
            this.Load += new System.EventHandler(this.frmParametrosCostoInventario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarHasta;
        private System.Windows.Forms.Button btnBuscarDesde;
        private System.Windows.Forms.ComboBox cbbCodigoHasta;
        private System.Windows.Forms.ComboBox cbbCodigoDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbFamilia;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbExistencia;
        private System.Windows.Forms.RadioButton rbFamilia;
        private System.Windows.Forms.RadioButton rbDescripcion;
        private System.Windows.Forms.RadioButton rbCodigo;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}