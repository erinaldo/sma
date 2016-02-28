namespace SMA.Inventario.Reportes
{
    partial class frmParametroListaPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametroListaPrecios));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbExistencia = new System.Windows.Forms.RadioButton();
            this.rbFamilia = new System.Windows.Forms.RadioButton();
            this.rbDescripcion = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbFamilia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarHasta = new System.Windows.Forms.Button();
            this.btnBuscarDesde = new System.Windows.Forms.Button();
            this.cbbCodigoHasta = new System.Windows.Forms.ComboBox();
            this.cbbCodigoDesde = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckbFisico = new System.Windows.Forms.CheckBox();
            this.ckbConExistencia = new System.Windows.Forms.CheckBox();
            this.ckbCombos = new System.Windows.Forms.CheckBox();
            this.ckbServicios = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbPrecio2 = new System.Windows.Forms.ComboBox();
            this.cbbPrecio1 = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbExistencia);
            this.groupBox3.Controls.Add(this.rbFamilia);
            this.groupBox3.Controls.Add(this.rbDescripcion);
            this.groupBox3.Controls.Add(this.rbCodigo);
            this.groupBox3.Location = new System.Drawing.Point(425, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 114);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordenar por";
            // 
            // rbExistencia
            // 
            this.rbExistencia.AutoSize = true;
            this.rbExistencia.Location = new System.Drawing.Point(6, 66);
            this.rbExistencia.Name = "rbExistencia";
            this.rbExistencia.Size = new System.Drawing.Size(73, 17);
            this.rbExistencia.TabIndex = 3;
            this.rbExistencia.Text = "Existencia";
            this.rbExistencia.UseVisualStyleBackColor = true;
            // 
            // rbFamilia
            // 
            this.rbFamilia.AutoSize = true;
            this.rbFamilia.Location = new System.Drawing.Point(6, 89);
            this.rbFamilia.Name = "rbFamilia";
            this.rbFamilia.Size = new System.Drawing.Size(57, 17);
            this.rbFamilia.TabIndex = 2;
            this.rbFamilia.Text = "Familia";
            this.rbFamilia.UseVisualStyleBackColor = true;
            // 
            // rbDescripcion
            // 
            this.rbDescripcion.AutoSize = true;
            this.rbDescripcion.Location = new System.Drawing.Point(6, 43);
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
            this.rbCodigo.Location = new System.Drawing.Point(6, 20);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(95, 17);
            this.rbCodigo.TabIndex = 0;
            this.rbCodigo.TabStop = true;
            this.rbCodigo.Text = "Codigo articulo";
            this.rbCodigo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbFamilia);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(10, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 51);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // cbbFamilia
            // 
            this.cbbFamilia.FormattingEnabled = true;
            this.cbbFamilia.Location = new System.Drawing.Point(52, 19);
            this.cbbFamilia.Name = "cbbFamilia";
            this.cbbFamilia.Size = new System.Drawing.Size(233, 21);
            this.cbbFamilia.TabIndex = 4;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarHasta);
            this.groupBox1.Controls.Add(this.btnBuscarDesde);
            this.groupBox1.Controls.Add(this.cbbCodigoHasta);
            this.groupBox1.Controls.Add(this.cbbCodigoDesde);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 81);
            this.groupBox1.TabIndex = 17;
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckbFisico);
            this.groupBox4.Controls.Add(this.ckbConExistencia);
            this.groupBox4.Controls.Add(this.ckbCombos);
            this.groupBox4.Controls.Add(this.ckbServicios);
            this.groupBox4.Location = new System.Drawing.Point(314, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(105, 114);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Incluye";
            // 
            // ckbFisico
            // 
            this.ckbFisico.AutoSize = true;
            this.ckbFisico.Checked = true;
            this.ckbFisico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbFisico.Location = new System.Drawing.Point(6, 18);
            this.ckbFisico.Name = "ckbFisico";
            this.ckbFisico.Size = new System.Drawing.Size(58, 17);
            this.ckbFisico.TabIndex = 15;
            this.ckbFisico.Text = "Fisicos";
            this.ckbFisico.UseVisualStyleBackColor = true;
            // 
            // ckbConExistencia
            // 
            this.ckbConExistencia.AutoSize = true;
            this.ckbConExistencia.Location = new System.Drawing.Point(6, 89);
            this.ckbConExistencia.Name = "ckbConExistencia";
            this.ckbConExistencia.Size = new System.Drawing.Size(95, 17);
            this.ckbConExistencia.TabIndex = 14;
            this.ckbConExistencia.Text = "Con existencia";
            this.ckbConExistencia.UseVisualStyleBackColor = true;
            // 
            // ckbCombos
            // 
            this.ckbCombos.AutoSize = true;
            this.ckbCombos.Location = new System.Drawing.Point(6, 66);
            this.ckbCombos.Name = "ckbCombos";
            this.ckbCombos.Size = new System.Drawing.Size(64, 17);
            this.ckbCombos.TabIndex = 13;
            this.ckbCombos.Text = "Combos";
            this.ckbCombos.UseVisualStyleBackColor = true;
            // 
            // ckbServicios
            // 
            this.ckbServicios.AutoSize = true;
            this.ckbServicios.Location = new System.Drawing.Point(6, 43);
            this.ckbServicios.Name = "ckbServicios";
            this.ckbServicios.Size = new System.Drawing.Size(69, 17);
            this.ckbServicios.TabIndex = 12;
            this.ckbServicios.Text = "Servicios";
            this.ckbServicios.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.cbbPrecio2);
            this.groupBox5.Controls.Add(this.cbbPrecio1);
            this.groupBox5.Location = new System.Drawing.Point(10, 156);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(298, 57);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Precio a imprimir";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "1";
            // 
            // cbbPrecio2
            // 
            this.cbbPrecio2.FormattingEnabled = true;
            this.cbbPrecio2.Items.AddRange(new object[] {
            "Ninguno",
            "Precio publico",
            "Precio 2",
            "Precio 3",
            "Minimo"});
            this.cbbPrecio2.Location = new System.Drawing.Point(164, 19);
            this.cbbPrecio2.Name = "cbbPrecio2";
            this.cbbPrecio2.Size = new System.Drawing.Size(121, 21);
            this.cbbPrecio2.TabIndex = 1;
            // 
            // cbbPrecio1
            // 
            this.cbbPrecio1.FormattingEnabled = true;
            this.cbbPrecio1.Items.AddRange(new object[] {
            "Ninguno",
            "Precio publico",
            "Precio 2",
            "Precio 3",
            "Minimo"});
            this.cbbPrecio1.Location = new System.Drawing.Point(22, 19);
            this.cbbPrecio1.Name = "cbbPrecio1";
            this.cbbPrecio1.Size = new System.Drawing.Size(121, 21);
            this.cbbPrecio1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(433, 221);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(314, 221);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // frmParametroListaPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 264);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(561, 302);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(561, 302);
            this.Name = "frmParametroListaPrecios";
            this.Text = "Lista de precios";
            this.Load += new System.EventHandler(this.frmParametroListaPrecios_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbExistencia;
        private System.Windows.Forms.RadioButton rbFamilia;
        private System.Windows.Forms.RadioButton rbDescripcion;
        private System.Windows.Forms.RadioButton rbCodigo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbFamilia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarHasta;
        private System.Windows.Forms.Button btnBuscarDesde;
        private System.Windows.Forms.ComboBox cbbCodigoHasta;
        private System.Windows.Forms.ComboBox cbbCodigoDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ckbConExistencia;
        private System.Windows.Forms.CheckBox ckbCombos;
        private System.Windows.Forms.CheckBox ckbServicios;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbPrecio2;
        private System.Windows.Forms.ComboBox cbbPrecio1;
        private System.Windows.Forms.CheckBox ckbFisico;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}