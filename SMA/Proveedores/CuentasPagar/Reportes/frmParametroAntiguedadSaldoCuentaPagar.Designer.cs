﻿namespace SMA.Clientes.CuentasPagar.Reportes
{
    partial class frmParametroAntiguedadSaldoCuentaPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametroAntiguedadSaldoCuentaPagar));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckbDetalle = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpFechaCorte = new System.Windows.Forms.DateTimePicker();
            this.rbFechaCorte = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbFechaVencimiento = new System.Windows.Forms.RadioButton();
            this.rbFechaEmision = new System.Windows.Forms.RadioButton();
            this.dtpFechaReferencia = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbProveedorHasta = new System.Windows.Forms.ComboBox();
            this.cbbProveedorDesde = new System.Windows.Forms.ComboBox();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckbDetalle);
            this.groupBox4.Location = new System.Drawing.Point(12, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(123, 44);
            this.groupBox4.TabIndex = 136;
            this.groupBox4.TabStop = false;
            // 
            // ckbDetalle
            // 
            this.ckbDetalle.AutoSize = true;
            this.ckbDetalle.Location = new System.Drawing.Point(12, 19);
            this.ckbDetalle.Name = "ckbDetalle";
            this.ckbDetalle.Size = new System.Drawing.Size(59, 17);
            this.ckbDetalle.TabIndex = 0;
            this.ckbDetalle.Text = "Detalle";
            this.ckbDetalle.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(282, 182);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 135;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(174, 182);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 134;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpFechaCorte);
            this.groupBox3.Controls.Add(this.rbFechaCorte);
            this.groupBox3.Location = new System.Drawing.Point(12, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 78);
            this.groupBox3.TabIndex = 133;
            this.groupBox3.TabStop = false;
            // 
            // dtpFechaCorte
            // 
            this.dtpFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCorte.Location = new System.Drawing.Point(12, 44);
            this.dtpFechaCorte.Name = "dtpFechaCorte";
            this.dtpFechaCorte.Size = new System.Drawing.Size(91, 20);
            this.dtpFechaCorte.TabIndex = 1;
            // 
            // rbFechaCorte
            // 
            this.rbFechaCorte.AutoSize = true;
            this.rbFechaCorte.Location = new System.Drawing.Point(12, 19);
            this.rbFechaCorte.Name = "rbFechaCorte";
            this.rbFechaCorte.Size = new System.Drawing.Size(97, 17);
            this.rbFechaCorte.TabIndex = 0;
            this.rbFechaCorte.TabStop = true;
            this.rbFechaCorte.Text = "Fecha de corte";
            this.rbFechaCorte.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFechaVencimiento);
            this.groupBox1.Controls.Add(this.rbFechaEmision);
            this.groupBox1.Controls.Add(this.dtpFechaReferencia);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(141, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 78);
            this.groupBox1.TabIndex = 132;
            this.groupBox1.TabStop = false;
            // 
            // rbFechaVencimiento
            // 
            this.rbFechaVencimiento.AutoSize = true;
            this.rbFechaVencimiento.Location = new System.Drawing.Point(118, 47);
            this.rbFechaVencimiento.Name = "rbFechaVencimiento";
            this.rbFechaVencimiento.Size = new System.Drawing.Size(115, 17);
            this.rbFechaVencimiento.TabIndex = 3;
            this.rbFechaVencimiento.TabStop = true;
            this.rbFechaVencimiento.Text = "Fecha vencimiento";
            this.rbFechaVencimiento.UseVisualStyleBackColor = true;
            // 
            // rbFechaEmision
            // 
            this.rbFechaEmision.AutoSize = true;
            this.rbFechaEmision.Location = new System.Drawing.Point(10, 47);
            this.rbFechaEmision.Name = "rbFechaEmision";
            this.rbFechaEmision.Size = new System.Drawing.Size(93, 17);
            this.rbFechaEmision.TabIndex = 2;
            this.rbFechaEmision.TabStop = true;
            this.rbFechaEmision.Text = "Fecha emisión";
            this.rbFechaEmision.UseVisualStyleBackColor = true;
            // 
            // dtpFechaReferencia
            // 
            this.dtpFechaReferencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReferencia.Location = new System.Drawing.Point(110, 19);
            this.dtpFechaReferencia.Name = "dtpFechaReferencia";
            this.dtpFechaReferencia.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaReferencia.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha referencia";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbbProveedorHasta);
            this.groupBox2.Controls.Add(this.cbbProveedorDesde);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 78);
            this.groupBox2.TabIndex = 131;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rango de proveedores";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde:";
            // 
            // cbbProveedorHasta
            // 
            this.cbbProveedorHasta.FormattingEnabled = true;
            this.cbbProveedorHasta.Location = new System.Drawing.Point(56, 46);
            this.cbbProveedorHasta.Name = "cbbProveedorHasta";
            this.cbbProveedorHasta.Size = new System.Drawing.Size(306, 21);
            this.cbbProveedorHasta.TabIndex = 1;
            // 
            // cbbProveedorDesde
            // 
            this.cbbProveedorDesde.FormattingEnabled = true;
            this.cbbProveedorDesde.Location = new System.Drawing.Point(56, 19);
            this.cbbProveedorDesde.Name = "cbbProveedorDesde";
            this.cbbProveedorDesde.Size = new System.Drawing.Size(306, 21);
            this.cbbProveedorDesde.TabIndex = 0;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // frmParametroAntiguedadSaldoCuentaPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 233);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximumSize = new System.Drawing.Size(408, 271);
            this.MinimumSize = new System.Drawing.Size(408, 271);
            this.Name = "frmParametroAntiguedadSaldoCuentaPagar";
            this.Text = "Antiguedad de Saldo";
            this.Load += new System.EventHandler(this.frmParametroAntiguedadSaldo_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ckbDetalle;
        internal DevComponents.DotNetBar.ButtonX btnCancelar;
        internal DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpFechaCorte;
        private System.Windows.Forms.RadioButton rbFechaCorte;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFechaVencimiento;
        private System.Windows.Forms.RadioButton rbFechaEmision;
        private System.Windows.Forms.DateTimePicker dtpFechaReferencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbProveedorHasta;
        private System.Windows.Forms.ComboBox cbbProveedorDesde;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}