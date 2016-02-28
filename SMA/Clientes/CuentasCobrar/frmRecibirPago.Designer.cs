namespace SMA.Clientes.CuentasPagar
{
    partial class frmRecibirPago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecibirPago));
            this.Label1 = new System.Windows.Forms.Label();
            this.txtDocumentoPagar = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.dgvPagos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cConceptoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReferenciaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNotas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.cbbClientes = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.StyleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.Label4 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.cbbConcepto = new System.Windows.Forms.ComboBox();
            this.btnVerDocumento = new DevComponents.DotNetBar.ButtonX();
            this.txtCodigo = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarPago = new DevComponents.DotNetBar.ButtonX();
            this.btnInsertarPago = new DevComponents.DotNetBar.ButtonX();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 73);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 13);
            this.Label1.TabIndex = 135;
            this.Label1.Text = "Documento:";
            // 
            // txtDocumentoPagar
            // 
            this.txtDocumentoPagar.Location = new System.Drawing.Point(84, 70);
            this.txtDocumentoPagar.Name = "txtDocumentoPagar";
            this.txtDocumentoPagar.Size = new System.Drawing.Size(84, 20);
            this.txtDocumentoPagar.TabIndex = 2;
            this.txtDocumentoPagar.Validated += new System.EventHandler(this.txtDocumentoPagar_Validated);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(436, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 13);
            this.Label2.TabIndex = 133;
            this.Label2.Text = "Fecha:";
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cConceptoID,
            this.cConcepto,
            this.cDocumentoID,
            this.cReferenciaID,
            this.cFecha,
            this.cMonto,
            this.cNotas});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPagos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPagos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPagos.Location = new System.Drawing.Point(13, 48);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.Size = new System.Drawing.Size(578, 153);
            this.dgvPagos.TabIndex = 3;
            // 
            // cConceptoID
            // 
            this.cConceptoID.HeaderText = "ConceptoID";
            this.cConceptoID.Name = "cConceptoID";
            this.cConceptoID.Visible = false;
            // 
            // cConcepto
            // 
            this.cConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cConcepto.HeaderText = "Concepto";
            this.cConcepto.Name = "cConcepto";
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.HeaderText = "Documento";
            this.cDocumentoID.Name = "cDocumentoID";
            // 
            // cReferenciaID
            // 
            this.cReferenciaID.HeaderText = "Referencia";
            this.cReferenciaID.Name = "cReferenciaID";
            // 
            // cFecha
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.cFecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.cFecha.HeaderText = "Fecha";
            this.cFecha.Name = "cFecha";
            // 
            // cMonto
            // 
            this.cMonto.HeaderText = "Monto";
            this.cMonto.Name = "cMonto";
            // 
            // cNotas
            // 
            this.cNotas.HeaderText = "Notas";
            this.cNotas.Name = "cNotas";
            this.cNotas.Visible = false;
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(482, 39);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(123, 20);
            this.dtpFechaPago.TabIndex = 5;
            // 
            // cbbClientes
            // 
            this.cbbClientes.DisplayMember = "Empresa";
            this.cbbClientes.FormattingEnabled = true;
            this.cbbClientes.Location = new System.Drawing.Point(84, 40);
            this.cbbClientes.Name = "cbbClientes";
            this.cbbClientes.Size = new System.Drawing.Size(346, 21);
            this.cbbClientes.TabIndex = 1;
            this.cbbClientes.ValueMember = "Cliente_ID";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(241, 24);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(30, 13);
            this.Label6.TabIndex = 119;
            this.Label6.Text = "Doc:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(277, 21);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(125, 20);
            this.txtDocumento.TabIndex = 1;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtMonto.Location = new System.Drawing.Point(454, 21);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(137, 20);
            this.txtMonto.TabIndex = 2;
            this.txtMonto.Validated += new System.EventHandler(this.txtMonto_Validated);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(408, 24);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(40, 13);
            this.Label5.TabIndex = 27;
            this.Label5.Text = "Monto:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(15, 44);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 130;
            this.lblCliente.Text = "Cliente:";
            // 
            // StyleManager1
            // 
            this.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 24);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(56, 13);
            this.Label4.TabIndex = 26;
            this.Label4.Text = "Concepto:";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(83, 98);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(522, 20);
            this.txtReferencia.TabIndex = 4;
            // 
            // cbbConcepto
            // 
            this.cbbConcepto.DisplayMember = "DESCR_CPTO";
            this.cbbConcepto.FormattingEnabled = true;
            this.cbbConcepto.Location = new System.Drawing.Point(85, 21);
            this.cbbConcepto.Name = "cbbConcepto";
            this.cbbConcepto.Size = new System.Drawing.Size(150, 21);
            this.cbbConcepto.TabIndex = 0;
            this.cbbConcepto.ValueMember = "CONCEPTO_ID";
            // 
            // btnVerDocumento
            // 
            this.btnVerDocumento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerDocumento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVerDocumento.Image = global::SMA.Properties.Resources.find_icon;
            this.btnVerDocumento.Location = new System.Drawing.Point(174, 67);
            this.btnVerDocumento.Name = "btnVerDocumento";
            this.btnVerDocumento.Size = new System.Drawing.Size(26, 23);
            this.btnVerDocumento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVerDocumento.TabIndex = 3;
            this.btnVerDocumento.Click += new System.EventHandler(this.btnVerDocumento_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtCodigo.Location = new System.Drawing.Point(84, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(87, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(15, 13);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(43, 13);
            this.Label7.TabIndex = 139;
            this.Label7.Text = "Codigo:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.dgvPagos);
            this.GroupBox1.Controls.Add(this.btnEliminarPago);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.btnInsertarPago);
            this.GroupBox1.Controls.Add(this.txtDocumento);
            this.GroupBox1.Controls.Add(this.txtMonto);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.cbbConcepto);
            this.GroupBox1.Location = new System.Drawing.Point(14, 126);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(604, 255);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Pagos";
            // 
            // btnEliminarPago
            // 
            this.btnEliminarPago.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminarPago.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminarPago.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarPago.Image")));
            this.btnEliminarPago.Location = new System.Drawing.Point(454, 208);
            this.btnEliminarPago.Name = "btnEliminarPago";
            this.btnEliminarPago.Size = new System.Drawing.Size(141, 42);
            this.btnEliminarPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminarPago.TabIndex = 4;
            this.btnEliminarPago.Text = "Eliminar pago";
            this.btnEliminarPago.Click += new System.EventHandler(this.btnEliminarPago_Click);
            // 
            // btnInsertarPago
            // 
            this.btnInsertarPago.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsertarPago.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInsertarPago.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertarPago.Image")));
            this.btnInsertarPago.Location = new System.Drawing.Point(304, 208);
            this.btnInsertarPago.Name = "btnInsertarPago";
            this.btnInsertarPago.Size = new System.Drawing.Size(141, 42);
            this.btnInsertarPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInsertarPago.TabIndex = 3;
            this.btnInsertarPago.Text = "Insertar pago";
            this.btnInsertarPago.Click += new System.EventHandler(this.btnInsertarPago_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(15, 101);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(62, 13);
            this.Label3.TabIndex = 136;
            this.Label3.Text = "Referencia:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(516, 387);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(408, 387);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmRecibirPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 439);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtDocumentoPagar);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dtpFechaPago);
            this.Controls.Add(this.cbbClientes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.btnVerDocumento);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label3);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmRecibirPago";
            this.Text = "Recibir Pago de Cliente";
            this.Load += new System.EventHandler(this.frmRecibirPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtDocumentoPagar;
        internal System.Windows.Forms.Label Label2;
        internal DevComponents.DotNetBar.Controls.DataGridViewX dgvPagos;
        internal System.Windows.Forms.DateTimePicker dtpFechaPago;
        internal System.Windows.Forms.ComboBox cbbClientes;
        internal DevComponents.DotNetBar.ButtonX btnEliminarPago;
        internal DevComponents.DotNetBar.ButtonX btnCancelar;
        internal DevComponents.DotNetBar.ButtonX btnAceptar;
        internal System.Windows.Forms.Label Label6;
        internal DevComponents.DotNetBar.ButtonX btnInsertarPago;
        internal System.Windows.Forms.TextBox txtDocumento;
        internal System.Windows.Forms.TextBox txtMonto;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label lblCliente;
        internal DevComponents.DotNetBar.StyleManager StyleManager1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtReferencia;
        internal System.Windows.Forms.ComboBox cbbConcepto;
        internal DevComponents.DotNetBar.ButtonX btnVerDocumento;
        internal System.Windows.Forms.Label txtCodigo;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cConceptoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReferenciaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNotas;
    }
}