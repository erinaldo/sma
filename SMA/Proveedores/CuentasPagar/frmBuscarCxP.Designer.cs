﻿namespace SMA.Clientes.CuentasPagar
{
    partial class frmBuscarCxP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarCxP));
            this.gbPeriodo = new System.Windows.Forms.GroupBox();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.rdbFechaVencimiento = new System.Windows.Forms.RadioButton();
            this.rdbFechaAplicacion = new System.Windows.Forms.RadioButton();
            this.lbConceptos = new System.Windows.Forms.ListBox();
            this.rbSeleccionarConcepto = new System.Windows.Forms.RadioButton();
            this.rbTodosConceptos = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.gbValorDocumento = new System.Windows.Forms.GroupBox();
            this.cbCriterioBalance = new System.Windows.Forms.ComboBox();
            this.cbCriterioMonto = new System.Windows.Forms.ComboBox();
            this.lblCriterioSaldo = new System.Windows.Forms.Label();
            this.lblCriterioMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.gbConceptos = new System.Windows.Forms.GroupBox();
            this.StyleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.gbPeriodo.SuspendLayout();
            this.gbValorDocumento.SuspendLayout();
            this.gbConceptos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPeriodo
            // 
            this.gbPeriodo.Controls.Add(this.lblHasta);
            this.gbPeriodo.Controls.Add(this.lblDesde);
            this.gbPeriodo.Controls.Add(this.dtpHasta);
            this.gbPeriodo.Controls.Add(this.dtpDesde);
            this.gbPeriodo.Controls.Add(this.rdbFechaVencimiento);
            this.gbPeriodo.Controls.Add(this.rdbFechaAplicacion);
            this.gbPeriodo.Location = new System.Drawing.Point(13, 13);
            this.gbPeriodo.Margin = new System.Windows.Forms.Padding(4);
            this.gbPeriodo.Name = "gbPeriodo";
            this.gbPeriodo.Padding = new System.Windows.Forms.Padding(4);
            this.gbPeriodo.Size = new System.Drawing.Size(360, 104);
            this.gbPeriodo.TabIndex = 121;
            this.gbPeriodo.TabStop = false;
            this.gbPeriodo.Text = "Periodo";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(180, 59);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 5;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(8, 59);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 4;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(235, 56);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(105, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(68, 56);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(104, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // rdbFechaVencimiento
            // 
            this.rdbFechaVencimiento.AutoSize = true;
            this.rdbFechaVencimiento.Location = new System.Drawing.Point(183, 23);
            this.rdbFechaVencimiento.Margin = new System.Windows.Forms.Padding(4);
            this.rdbFechaVencimiento.Name = "rdbFechaVencimiento";
            this.rdbFechaVencimiento.Size = new System.Drawing.Size(116, 17);
            this.rdbFechaVencimiento.TabIndex = 1;
            this.rdbFechaVencimiento.TabStop = true;
            this.rdbFechaVencimiento.Text = "Fecha Vencimiento";
            this.rdbFechaVencimiento.UseVisualStyleBackColor = true;
            // 
            // rdbFechaAplicacion
            // 
            this.rdbFechaAplicacion.AutoSize = true;
            this.rdbFechaAplicacion.Location = new System.Drawing.Point(8, 23);
            this.rdbFechaAplicacion.Margin = new System.Windows.Forms.Padding(4);
            this.rdbFechaAplicacion.Name = "rdbFechaAplicacion";
            this.rdbFechaAplicacion.Size = new System.Drawing.Size(107, 17);
            this.rdbFechaAplicacion.TabIndex = 0;
            this.rdbFechaAplicacion.TabStop = true;
            this.rdbFechaAplicacion.Text = "Fecha Aplicacion";
            this.rdbFechaAplicacion.UseVisualStyleBackColor = true;
            // 
            // lbConceptos
            // 
            this.lbConceptos.DisplayMember = "DESCR_CPTO";
            this.lbConceptos.FormattingEnabled = true;
            this.lbConceptos.Location = new System.Drawing.Point(6, 81);
            this.lbConceptos.Name = "lbConceptos";
            this.lbConceptos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbConceptos.Size = new System.Drawing.Size(211, 108);
            this.lbConceptos.TabIndex = 2;
            this.lbConceptos.ValueMember = "CONCEPTO_ID";
            // 
            // rbSeleccionarConcepto
            // 
            this.rbSeleccionarConcepto.AutoSize = true;
            this.rbSeleccionarConcepto.Location = new System.Drawing.Point(20, 55);
            this.rbSeleccionarConcepto.Name = "rbSeleccionarConcepto";
            this.rbSeleccionarConcepto.Size = new System.Drawing.Size(134, 17);
            this.rbSeleccionarConcepto.TabIndex = 1;
            this.rbSeleccionarConcepto.TabStop = true;
            this.rbSeleccionarConcepto.Text = "Seleccionar conceptos";
            this.rbSeleccionarConcepto.UseVisualStyleBackColor = true;
            this.rbSeleccionarConcepto.CheckedChanged += new System.EventHandler(this.rbSeleccionarConcepto_CheckedChanged);
            // 
            // rbTodosConceptos
            // 
            this.rbTodosConceptos.AutoSize = true;
            this.rbTodosConceptos.Location = new System.Drawing.Point(20, 26);
            this.rbTodosConceptos.Name = "rbTodosConceptos";
            this.rbTodosConceptos.Size = new System.Drawing.Size(125, 17);
            this.rbTodosConceptos.TabIndex = 0;
            this.rbTodosConceptos.TabStop = true;
            this.rbTodosConceptos.Text = "Todos los Conceptos";
            this.rbTodosConceptos.UseVisualStyleBackColor = true;
            this.rbTodosConceptos.CheckedChanged += new System.EventHandler(this.rbTodosConceptos_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(380, 223);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 124;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbValorDocumento
            // 
            this.gbValorDocumento.Controls.Add(this.cbCriterioBalance);
            this.gbValorDocumento.Controls.Add(this.cbCriterioMonto);
            this.gbValorDocumento.Controls.Add(this.lblCriterioSaldo);
            this.gbValorDocumento.Controls.Add(this.lblCriterioMonto);
            this.gbValorDocumento.Controls.Add(this.txtMonto);
            this.gbValorDocumento.Controls.Add(this.txtBalance);
            this.gbValorDocumento.Controls.Add(this.lblSaldo);
            this.gbValorDocumento.Controls.Add(this.lblMonto);
            this.gbValorDocumento.Location = new System.Drawing.Point(12, 124);
            this.gbValorDocumento.Name = "gbValorDocumento";
            this.gbValorDocumento.Size = new System.Drawing.Size(362, 93);
            this.gbValorDocumento.TabIndex = 122;
            this.gbValorDocumento.TabStop = false;
            this.gbValorDocumento.Text = "Valor de Documentos";
            // 
            // cbCriterioBalance
            // 
            this.cbCriterioBalance.FormattingEnabled = true;
            this.cbCriterioBalance.Location = new System.Drawing.Point(239, 55);
            this.cbCriterioBalance.Name = "cbCriterioBalance";
            this.cbCriterioBalance.Size = new System.Drawing.Size(104, 21);
            this.cbCriterioBalance.TabIndex = 7;
            // 
            // cbCriterioMonto
            // 
            this.cbCriterioMonto.FormattingEnabled = true;
            this.cbCriterioMonto.Location = new System.Drawing.Point(239, 24);
            this.cbCriterioMonto.Name = "cbCriterioMonto";
            this.cbCriterioMonto.Size = new System.Drawing.Size(104, 21);
            this.cbCriterioMonto.TabIndex = 6;
            // 
            // lblCriterioSaldo
            // 
            this.lblCriterioSaldo.AutoSize = true;
            this.lblCriterioSaldo.Location = new System.Drawing.Point(194, 58);
            this.lblCriterioSaldo.Name = "lblCriterioSaldo";
            this.lblCriterioSaldo.Size = new System.Drawing.Size(31, 13);
            this.lblCriterioSaldo.TabIndex = 5;
            this.lblCriterioSaldo.Text = "Tipo:";
            // 
            // lblCriterioMonto
            // 
            this.lblCriterioMonto.AutoSize = true;
            this.lblCriterioMonto.Location = new System.Drawing.Point(194, 27);
            this.lblCriterioMonto.Name = "lblCriterioMonto";
            this.lblCriterioMonto.Size = new System.Drawing.Size(31, 13);
            this.lblCriterioMonto.TabIndex = 4;
            this.lblCriterioMonto.Text = "Tipo:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(60, 25);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(128, 20);
            this.txtMonto.TabIndex = 3;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(60, 56);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(128, 20);
            this.txtBalance.TabIndex = 2;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(7, 59);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(49, 13);
            this.lblSaldo.TabIndex = 1;
            this.lblSaldo.Text = "Balance:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(6, 28);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 0;
            this.lblMonto.Text = "Monto:";
            // 
            // gbConceptos
            // 
            this.gbConceptos.Controls.Add(this.lbConceptos);
            this.gbConceptos.Controls.Add(this.rbSeleccionarConcepto);
            this.gbConceptos.Controls.Add(this.rbTodosConceptos);
            this.gbConceptos.Location = new System.Drawing.Point(380, 13);
            this.gbConceptos.Name = "gbConceptos";
            this.gbConceptos.Size = new System.Drawing.Size(223, 204);
            this.gbConceptos.TabIndex = 123;
            this.gbConceptos.TabStop = false;
            this.gbConceptos.Text = "Lista de Conceptos";
            // 
            // StyleManager1
            // 
            this.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(501, 223);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 125;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmBuscarCxP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 279);
            this.Controls.Add(this.gbPeriodo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbValorDocumento);
            this.Controls.Add(this.gbConceptos);
            this.Controls.Add(this.btnCancelar);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmBuscarCxP";
            this.Text = "Buscar movimiento Cuentas por Pagar";
            this.Load += new System.EventHandler(this.frmBuscarCxP_Load);
            this.gbPeriodo.ResumeLayout(false);
            this.gbPeriodo.PerformLayout();
            this.gbValorDocumento.ResumeLayout(false);
            this.gbValorDocumento.PerformLayout();
            this.gbConceptos.ResumeLayout(false);
            this.gbConceptos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gbPeriodo;
        internal System.Windows.Forms.Label lblHasta;
        internal System.Windows.Forms.Label lblDesde;
        internal System.Windows.Forms.DateTimePicker dtpHasta;
        internal System.Windows.Forms.DateTimePicker dtpDesde;
        internal System.Windows.Forms.RadioButton rdbFechaVencimiento;
        internal System.Windows.Forms.RadioButton rdbFechaAplicacion;
        internal System.Windows.Forms.ListBox lbConceptos;
        internal System.Windows.Forms.RadioButton rbSeleccionarConcepto;
        internal System.Windows.Forms.RadioButton rbTodosConceptos;
        internal DevComponents.DotNetBar.ButtonX btnAceptar;
        internal System.Windows.Forms.GroupBox gbValorDocumento;
        internal System.Windows.Forms.ComboBox cbCriterioBalance;
        internal System.Windows.Forms.ComboBox cbCriterioMonto;
        internal System.Windows.Forms.Label lblCriterioSaldo;
        internal System.Windows.Forms.Label lblCriterioMonto;
        internal System.Windows.Forms.TextBox txtMonto;
        internal System.Windows.Forms.TextBox txtBalance;
        internal System.Windows.Forms.Label lblSaldo;
        internal System.Windows.Forms.Label lblMonto;
        internal System.Windows.Forms.GroupBox gbConceptos;
        internal DevComponents.DotNetBar.StyleManager StyleManager1;
        internal DevComponents.DotNetBar.ButtonX btnCancelar;
    }
}