namespace SMA.Factura.Pagos
{
    partial class frmPagoFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoFactura));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExpiracionTarjeta = new System.Windows.Forms.TextBox();
            this.cbEntidad = new System.Windows.Forms.ComboBox();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.txtMontoTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMontoEfectivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDevolucion = new System.Windows.Forms.Label();
            this.lblSuPago = new System.Windows.Forms.Label();
            this.lblMontoFactura = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.btnImprimir = new DevComponents.DotNetBar.ButtonX();
            this.btnGuardar = new DevComponents.DotNetBar.ButtonX();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumeroAprobacion = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "FORMA DE PAGO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumeroAprobacion);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cbTipoTarjeta);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtExpiracionTarjeta);
            this.groupBox1.Controls.Add(this.cbEntidad);
            this.groupBox1.Controls.Add(this.txtNumeroTarjeta);
            this.groupBox1.Controls.Add(this.txtMontoTarjeta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMontoEfectivo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(73, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Emisor";
            // 
            // cbTipoTarjeta
            // 
            this.cbTipoTarjeta.FormattingEnabled = true;
            this.cbTipoTarjeta.Location = new System.Drawing.Point(117, 73);
            this.cbTipoTarjeta.Name = "cbTipoTarjeta";
            this.cbTipoTarjeta.Size = new System.Drawing.Size(118, 21);
            this.cbTipoTarjeta.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Exp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Numero";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Entidad";
            // 
            // txtExpiracionTarjeta
            // 
            this.txtExpiracionTarjeta.Location = new System.Drawing.Point(421, 46);
            this.txtExpiracionTarjeta.MaxLength = 4;
            this.txtExpiracionTarjeta.Name = "txtExpiracionTarjeta";
            this.txtExpiracionTarjeta.Size = new System.Drawing.Size(51, 20);
            this.txtExpiracionTarjeta.TabIndex = 6;
            // 
            // cbEntidad
            // 
            this.cbEntidad.FormattingEnabled = true;
            this.cbEntidad.Location = new System.Drawing.Point(290, 19);
            this.cbEntidad.Name = "cbEntidad";
            this.cbEntidad.Size = new System.Drawing.Size(182, 21);
            this.cbEntidad.TabIndex = 5;
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(333, 46);
            this.txtNumeroTarjeta.MaxLength = 4;
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(51, 20);
            this.txtNumeroTarjeta.TabIndex = 4;
            // 
            // txtMontoTarjeta
            // 
            this.txtMontoTarjeta.Location = new System.Drawing.Point(117, 45);
            this.txtMontoTarjeta.Name = "txtMontoTarjeta";
            this.txtMontoTarjeta.Size = new System.Drawing.Size(118, 20);
            this.txtMontoTarjeta.TabIndex = 3;
            this.txtMontoTarjeta.Text = "0";
            this.txtMontoTarjeta.Validated += new System.EventHandler(this.txtMontoTarjeta_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tarjeta de credito";
            // 
            // txtMontoEfectivo
            // 
            this.txtMontoEfectivo.Location = new System.Drawing.Point(117, 19);
            this.txtMontoEfectivo.Name = "txtMontoEfectivo";
            this.txtMontoEfectivo.Size = new System.Drawing.Size(118, 20);
            this.txtMontoEfectivo.TabIndex = 1;
            this.txtMontoEfectivo.Text = "0";
            this.txtMontoEfectivo.Validated += new System.EventHandler(this.txtMontoEfectivo_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "En efectivo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDevolucion);
            this.groupBox2.Controls.Add(this.lblSuPago);
            this.groupBox2.Controls.Add(this.lblMontoFactura);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(87, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle";
            // 
            // lblDevolucion
            // 
            this.lblDevolucion.BackColor = System.Drawing.SystemColors.Info;
            this.lblDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevolucion.ForeColor = System.Drawing.Color.Red;
            this.lblDevolucion.Location = new System.Drawing.Point(108, 79);
            this.lblDevolucion.Name = "lblDevolucion";
            this.lblDevolucion.Size = new System.Drawing.Size(183, 23);
            this.lblDevolucion.TabIndex = 5;
            this.lblDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSuPago
            // 
            this.lblSuPago.BackColor = System.Drawing.SystemColors.Info;
            this.lblSuPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblSuPago.Location = new System.Drawing.Point(108, 53);
            this.lblSuPago.Name = "lblSuPago";
            this.lblSuPago.Size = new System.Drawing.Size(183, 23);
            this.lblSuPago.TabIndex = 4;
            this.lblSuPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSuPago.TextChanged += new System.EventHandler(this.lblSuPago_TextChanged);
            // 
            // lblMontoFactura
            // 
            this.lblMontoFactura.BackColor = System.Drawing.SystemColors.Info;
            this.lblMontoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoFactura.ForeColor = System.Drawing.Color.Blue;
            this.lblMontoFactura.Location = new System.Drawing.Point(108, 27);
            this.lblMontoFactura.Name = "lblMontoFactura";
            this.lblMontoFactura.Size = new System.Drawing.Size(183, 23);
            this.lblMontoFactura.TabIndex = 3;
            this.lblMontoFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Devolucion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Su pago";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total a pagar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(123, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "FACTURA NO.";
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.BackColor = System.Drawing.SystemColors.Info;
            this.lblNumeroFactura.Location = new System.Drawing.Point(208, 53);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(169, 23);
            this.lblNumeroFactura.TabIndex = 5;
            this.lblNumeroFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnImprimir
            // 
            this.btnImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(354, 306);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(134, 55);
            this.btnImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(8, 306);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(134, 55);
            this.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "No. Aprobacion:";
            // 
            // txtNumeroAprobacion
            // 
            this.txtNumeroAprobacion.Location = new System.Drawing.Point(333, 73);
            this.txtNumeroAprobacion.Name = "txtNumeroAprobacion";
            this.txtNumeroAprobacion.Size = new System.Drawing.Size(139, 20);
            this.txtNumeroAprobacion.TabIndex = 17;
            // 
            // frmPagoFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 372);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblNumeroFactura);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmPagoFactura";
            this.Text = "frmPagoFactura";
            this.Load += new System.EventHandler(this.frmPagoFactura_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtExpiracionTarjeta;
        private System.Windows.Forms.ComboBox cbEntidad;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.TextBox txtMontoTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMontoEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDevolucion;
        private System.Windows.Forms.Label lblSuPago;
        private System.Windows.Forms.Label lblMontoFactura;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonX btnImprimir;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbTipoTarjeta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblNumeroFactura;
        private DevComponents.DotNetBar.ButtonX btnGuardar;
        private System.Windows.Forms.TextBox txtNumeroAprobacion;
        private System.Windows.Forms.Label label11;
    }
}