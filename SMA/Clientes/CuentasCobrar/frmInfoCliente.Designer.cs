namespace SMA.Clientes.CuentasPagar
{
    partial class frmInfoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoCliente));
            this.btnSalir = new DevComponents.DotNetBar.ButtonX();
            this.txtBalance = new System.Windows.Forms.Label();
            this.txtLimiteCredito = new System.Windows.Forms.Label();
            this.txtDiasCredito = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.Label();
            this.txtAtencionCobros = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(112, 175);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(101, 40);
            this.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSalir.TabIndex = 40;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.Color.White;
            this.txtBalance.Location = new System.Drawing.Point(110, 139);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(200, 22);
            this.txtBalance.TabIndex = 39;
            this.txtBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLimiteCredito
            // 
            this.txtLimiteCredito.BackColor = System.Drawing.Color.White;
            this.txtLimiteCredito.Location = new System.Drawing.Point(110, 113);
            this.txtLimiteCredito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtLimiteCredito.Name = "txtLimiteCredito";
            this.txtLimiteCredito.Size = new System.Drawing.Size(200, 22);
            this.txtLimiteCredito.TabIndex = 38;
            this.txtLimiteCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiasCredito
            // 
            this.txtDiasCredito.BackColor = System.Drawing.Color.White;
            this.txtDiasCredito.Location = new System.Drawing.Point(110, 87);
            this.txtDiasCredito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtDiasCredito.Name = "txtDiasCredito";
            this.txtDiasCredito.Size = new System.Drawing.Size(200, 22);
            this.txtDiasCredito.TabIndex = 37;
            this.txtDiasCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(110, 61);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 36;
            this.txtEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.White;
            this.txtTelefono.Location = new System.Drawing.Point(110, 35);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 22);
            this.txtTelefono.TabIndex = 35;
            this.txtTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAtencionCobros
            // 
            this.txtAtencionCobros.BackColor = System.Drawing.Color.White;
            this.txtAtencionCobros.Location = new System.Drawing.Point(110, 9);
            this.txtAtencionCobros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtAtencionCobros.Name = "txtAtencionCobros";
            this.txtAtencionCobros.Size = new System.Drawing.Size(200, 22);
            this.txtAtencionCobros.TabIndex = 34;
            this.txtAtencionCobros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(14, 144);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(49, 13);
            this.Label6.TabIndex = 33;
            this.Label6.Text = "Balance:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(14, 118);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(85, 13);
            this.Label5.TabIndex = 32;
            this.Label5.Text = "Limite de Crédito";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(14, 92);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(84, 13);
            this.Label4.TabIndex = 31;
            this.Label4.Text = "Días de Crédito:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(14, 66);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(35, 13);
            this.Label3.TabIndex = 30;
            this.Label3.Text = "Email:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 40);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 13);
            this.Label2.TabIndex = 29;
            this.Label2.Text = "Teléfono:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 14);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(88, 13);
            this.Label1.TabIndex = 28;
            this.Label1.Text = "Atención Cobros:";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            // 
            // frmInfoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 229);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtLimiteCredito);
            this.Controls.Add(this.txtDiasCredito);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtAtencionCobros);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmInfoCliente";
            this.Text = "Informacion de Cliente";
            this.Load += new System.EventHandler(this.frmInfoCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevComponents.DotNetBar.ButtonX btnSalir;
        internal System.Windows.Forms.Label txtBalance;
        internal System.Windows.Forms.Label txtLimiteCredito;
        internal System.Windows.Forms.Label txtDiasCredito;
        internal System.Windows.Forms.Label txtEmail;
        internal System.Windows.Forms.Label txtTelefono;
        internal System.Windows.Forms.Label txtAtencionCobros;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}