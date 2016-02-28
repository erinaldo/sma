namespace SMA.Inventario
{
    partial class frmAgregarEditarInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarInventario));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpInfoGeneral = new System.Windows.Forms.TabPage();
            this.lblPorcientoPrecio4 = new System.Windows.Forms.Label();
            this.lblPorcientoPrecio3 = new System.Windows.Forms.Label();
            this.lblPorcientoPrecio2 = new System.Windows.Forms.Label();
            this.lblPorcientoPublico = new System.Windows.Forms.Label();
            this.txtMinimo = new System.Windows.Forms.TextBox();
            this.txtPrecio3 = new System.Windows.Forms.TextBox();
            this.txtPrecio2 = new System.Windows.Forms.TextBox();
            this.txtPrecioPublico = new System.Windows.Forms.TextBox();
            this.lblMinimo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.txtStockMin = new System.Windows.Forms.TextBox();
            this.txtStockMax = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModelo = new System.Windows.Forms.Button();
            this.cbImpuesto = new System.Windows.Forms.ComboBox();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.btnBuscarMarca = new System.Windows.Forms.Button();
            this.btnBuscarFamilia = new System.Windows.Forms.Button();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.cbFamilia = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipoArticulo = new System.Windows.Forms.ComboBox();
            this.tpInfoControl = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBuscarProveedor2 = new System.Windows.Forms.Button();
            this.btnBuscarProveedor1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbProveedor2 = new System.Windows.Forms.ComboBox();
            this.cbProveedor1 = new System.Windows.Forms.ComboBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.chbNotificarVencimiento = new System.Windows.Forms.CheckBox();
            this.chbFacturarSinExistencia = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaModificacion = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbUnidadSalida = new System.Windows.Forms.ComboBox();
            this.cbUnidadEntrada = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pbArticulo = new System.Windows.Forms.PictureBox();
            this.tpInfoRegistro = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtCostoPromedio = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtFechaUltCompra = new System.Windows.Forms.TextBox();
            this.txtMontoCompras = new System.Windows.Forms.TextBox();
            this.txtCantidadCompras = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtFechaUltVenta = new System.Windows.Forms.TextBox();
            this.txtMontoVentas = new System.Windows.Forms.TextBox();
            this.txtCantidadVentas = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tpComboKit = new System.Windows.Forms.TabPage();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonX();
            this.btnEditar = new DevComponents.DotNetBar.ButtonX();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.dgvArticulos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCodigoInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpObservaciones = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1.SuspendLayout();
            this.tpInfoGeneral.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpInfoControl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticulo)).BeginInit();
            this.tpInfoRegistro.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tpComboKit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.tpObservaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(83, 11);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(151, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Validated += new System.EventHandler(this.txtCodigo_Validated);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(83, 37);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(497, 20);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.Validated += new System.EventHandler(this.txtDescripcion_Validated);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpInfoGeneral);
            this.tabControl1.Controls.Add(this.tpInfoControl);
            this.tabControl1.Controls.Add(this.tpInfoRegistro);
            this.tabControl1.Controls.Add(this.tpComboKit);
            this.tabControl1.Controls.Add(this.tpObservaciones);
            this.tabControl1.Location = new System.Drawing.Point(12, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(572, 291);
            this.tabControl1.TabIndex = 3;
            // 
            // tpInfoGeneral
            // 
            this.tpInfoGeneral.Controls.Add(this.lblPorcientoPrecio4);
            this.tpInfoGeneral.Controls.Add(this.lblPorcientoPrecio3);
            this.tpInfoGeneral.Controls.Add(this.lblPorcientoPrecio2);
            this.tpInfoGeneral.Controls.Add(this.lblPorcientoPublico);
            this.tpInfoGeneral.Controls.Add(this.txtMinimo);
            this.tpInfoGeneral.Controls.Add(this.txtPrecio3);
            this.tpInfoGeneral.Controls.Add(this.txtPrecio2);
            this.tpInfoGeneral.Controls.Add(this.txtPrecioPublico);
            this.tpInfoGeneral.Controls.Add(this.lblMinimo);
            this.tpInfoGeneral.Controls.Add(this.label7);
            this.tpInfoGeneral.Controls.Add(this.label6);
            this.tpInfoGeneral.Controls.Add(this.label5);
            this.tpInfoGeneral.Controls.Add(this.groupBox2);
            this.tpInfoGeneral.Controls.Add(this.groupBox1);
            this.tpInfoGeneral.Controls.Add(this.txtCosto);
            this.tpInfoGeneral.Controls.Add(this.label4);
            this.tpInfoGeneral.Controls.Add(this.label3);
            this.tpInfoGeneral.Controls.Add(this.cbTipoArticulo);
            this.tpInfoGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpInfoGeneral.Name = "tpInfoGeneral";
            this.tpInfoGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpInfoGeneral.Size = new System.Drawing.Size(564, 265);
            this.tpInfoGeneral.TabIndex = 0;
            this.tpInfoGeneral.Text = "Info General";
            this.tpInfoGeneral.UseVisualStyleBackColor = true;
            // 
            // lblPorcientoPrecio4
            // 
            this.lblPorcientoPrecio4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcientoPrecio4.BackColor = System.Drawing.SystemColors.Info;
            this.lblPorcientoPrecio4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPorcientoPrecio4.Location = new System.Drawing.Point(428, 90);
            this.lblPorcientoPrecio4.Name = "lblPorcientoPrecio4";
            this.lblPorcientoPrecio4.Size = new System.Drawing.Size(110, 21);
            this.lblPorcientoPrecio4.TabIndex = 42;
            this.lblPorcientoPrecio4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPorcientoPrecio3
            // 
            this.lblPorcientoPrecio3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcientoPrecio3.BackColor = System.Drawing.SystemColors.Info;
            this.lblPorcientoPrecio3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPorcientoPrecio3.Location = new System.Drawing.Point(293, 90);
            this.lblPorcientoPrecio3.Name = "lblPorcientoPrecio3";
            this.lblPorcientoPrecio3.Size = new System.Drawing.Size(110, 21);
            this.lblPorcientoPrecio3.TabIndex = 41;
            this.lblPorcientoPrecio3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPorcientoPrecio2
            // 
            this.lblPorcientoPrecio2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcientoPrecio2.BackColor = System.Drawing.SystemColors.Info;
            this.lblPorcientoPrecio2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPorcientoPrecio2.Location = new System.Drawing.Point(160, 90);
            this.lblPorcientoPrecio2.Name = "lblPorcientoPrecio2";
            this.lblPorcientoPrecio2.Size = new System.Drawing.Size(110, 21);
            this.lblPorcientoPrecio2.TabIndex = 40;
            this.lblPorcientoPrecio2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPorcientoPublico
            // 
            this.lblPorcientoPublico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcientoPublico.BackColor = System.Drawing.SystemColors.Info;
            this.lblPorcientoPublico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPorcientoPublico.Location = new System.Drawing.Point(26, 90);
            this.lblPorcientoPublico.Name = "lblPorcientoPublico";
            this.lblPorcientoPublico.Size = new System.Drawing.Size(110, 20);
            this.lblPorcientoPublico.TabIndex = 39;
            this.lblPorcientoPublico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMinimo
            // 
            this.txtMinimo.Location = new System.Drawing.Point(428, 67);
            this.txtMinimo.Name = "txtMinimo";
            this.txtMinimo.Size = new System.Drawing.Size(110, 20);
            this.txtMinimo.TabIndex = 5;
            this.txtMinimo.Validated += new System.EventHandler(this.txtMinimo_Validated);
            // 
            // txtPrecio3
            // 
            this.txtPrecio3.Location = new System.Drawing.Point(294, 67);
            this.txtPrecio3.Name = "txtPrecio3";
            this.txtPrecio3.Size = new System.Drawing.Size(110, 20);
            this.txtPrecio3.TabIndex = 4;
            this.txtPrecio3.Validated += new System.EventHandler(this.txtPrecio3_Validated);
            // 
            // txtPrecio2
            // 
            this.txtPrecio2.Location = new System.Drawing.Point(160, 67);
            this.txtPrecio2.Name = "txtPrecio2";
            this.txtPrecio2.Size = new System.Drawing.Size(110, 20);
            this.txtPrecio2.TabIndex = 3;
            this.txtPrecio2.Validated += new System.EventHandler(this.txtPrecio2_Validated);
            // 
            // txtPrecioPublico
            // 
            this.txtPrecioPublico.Location = new System.Drawing.Point(26, 67);
            this.txtPrecioPublico.Name = "txtPrecioPublico";
            this.txtPrecioPublico.Size = new System.Drawing.Size(110, 20);
            this.txtPrecioPublico.TabIndex = 2;
            this.txtPrecioPublico.Validated += new System.EventHandler(this.txtPrecioPublico_Validated);
            // 
            // lblMinimo
            // 
            this.lblMinimo.AutoSize = true;
            this.lblMinimo.Location = new System.Drawing.Point(407, 51);
            this.lblMinimo.Name = "lblMinimo";
            this.lblMinimo.Size = new System.Drawing.Size(46, 13);
            this.lblMinimo.TabIndex = 34;
            this.lblMinimo.Text = "Precio 4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Precio 3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Precio 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Precio publico";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtExistencia);
            this.groupBox2.Controls.Add(this.txtStockMin);
            this.groupBox2.Controls.Add(this.txtStockMax);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(281, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 108);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Existencias";
            // 
            // txtExistencia
            // 
            this.txtExistencia.Location = new System.Drawing.Point(71, 72);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(188, 20);
            this.txtExistencia.TabIndex = 2;
            this.txtExistencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExistencia_KeyPress);
            // 
            // txtStockMin
            // 
            this.txtStockMin.Location = new System.Drawing.Point(71, 46);
            this.txtStockMin.Name = "txtStockMin";
            this.txtStockMin.Size = new System.Drawing.Size(188, 20);
            this.txtStockMin.TabIndex = 1;
            this.txtStockMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMin_KeyPress);
            this.txtStockMin.Validated += new System.EventHandler(this.txtStockMin_Validated);
            // 
            // txtStockMax
            // 
            this.txtStockMax.Location = new System.Drawing.Point(71, 19);
            this.txtStockMax.Name = "txtStockMax";
            this.txtStockMax.Size = new System.Drawing.Size(188, 20);
            this.txtStockMax.TabIndex = 0;
            this.txtStockMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMax_KeyPress);
            this.txtStockMax.Validated += new System.EventHandler(this.txtStockMax_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Existencia";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Stock Min";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Stock Max";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModelo);
            this.groupBox1.Controls.Add(this.cbImpuesto);
            this.groupBox1.Controls.Add(this.lblImpuesto);
            this.groupBox1.Controls.Add(this.btnBuscarMarca);
            this.groupBox1.Controls.Add(this.btnBuscarFamilia);
            this.groupBox1.Controls.Add(this.cbMarca);
            this.groupBox1.Controls.Add(this.cbFamilia);
            this.groupBox1.Controls.Add(this.lblMarca);
            this.groupBox1.Controls.Add(this.lblFamilia);
            this.groupBox1.Location = new System.Drawing.Point(10, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 108);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles";
            // 
            // btnModelo
            // 
            this.btnModelo.Image = global::SMA.Properties.Resources.find_icon;
            this.btnModelo.Location = new System.Drawing.Point(235, 70);
            this.btnModelo.Name = "btnModelo";
            this.btnModelo.Size = new System.Drawing.Size(26, 23);
            this.btnModelo.TabIndex = 19;
            this.btnModelo.UseVisualStyleBackColor = true;
            this.btnModelo.Visible = false;
            // 
            // cbImpuesto
            // 
            this.cbImpuesto.FormattingEnabled = true;
            this.cbImpuesto.Location = new System.Drawing.Point(60, 72);
            this.cbImpuesto.Name = "cbImpuesto";
            this.cbImpuesto.Size = new System.Drawing.Size(166, 21);
            this.cbImpuesto.TabIndex = 2;
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.AutoSize = true;
            this.lblImpuesto.Location = new System.Drawing.Point(6, 75);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(50, 13);
            this.lblImpuesto.TabIndex = 17;
            this.lblImpuesto.Text = "Impuesto";
            // 
            // btnBuscarMarca
            // 
            this.btnBuscarMarca.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarMarca.Location = new System.Drawing.Point(235, 44);
            this.btnBuscarMarca.Name = "btnBuscarMarca";
            this.btnBuscarMarca.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarMarca.TabIndex = 16;
            this.btnBuscarMarca.UseVisualStyleBackColor = true;
            this.btnBuscarMarca.Click += new System.EventHandler(this.btnBuscarMarca_Click);
            // 
            // btnBuscarFamilia
            // 
            this.btnBuscarFamilia.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarFamilia.Location = new System.Drawing.Point(235, 17);
            this.btnBuscarFamilia.Name = "btnBuscarFamilia";
            this.btnBuscarFamilia.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarFamilia.TabIndex = 15;
            this.btnBuscarFamilia.UseVisualStyleBackColor = true;
            this.btnBuscarFamilia.Click += new System.EventHandler(this.btnBuscarFamilia_Click);
            // 
            // cbMarca
            // 
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(60, 46);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(166, 21);
            this.cbMarca.TabIndex = 1;
            // 
            // cbFamilia
            // 
            this.cbFamilia.FormattingEnabled = true;
            this.cbFamilia.Location = new System.Drawing.Point(60, 19);
            this.cbFamilia.Name = "cbFamilia";
            this.cbFamilia.Size = new System.Drawing.Size(166, 21);
            this.cbFamilia.TabIndex = 0;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(6, 49);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMarca.TabIndex = 1;
            this.lblMarca.Text = "Marca";
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(6, 25);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(39, 13);
            this.lblFamilia.TabIndex = 0;
            this.lblFamilia.Text = "Familia";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(357, 18);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(181, 20);
            this.txtCosto.TabIndex = 1;
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            this.txtCosto.Validated += new System.EventHandler(this.txtCosto_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Costo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo articulo";
            // 
            // cbTipoArticulo
            // 
            this.cbTipoArticulo.FormattingEnabled = true;
            this.cbTipoArticulo.Items.AddRange(new object[] {
            "Fisico",
            "Combo",
            "Servicio"});
            this.cbTipoArticulo.Location = new System.Drawing.Point(78, 18);
            this.cbTipoArticulo.Name = "cbTipoArticulo";
            this.cbTipoArticulo.Size = new System.Drawing.Size(195, 21);
            this.cbTipoArticulo.TabIndex = 0;
            this.cbTipoArticulo.SelectedIndexChanged += new System.EventHandler(this.cbTipoArticulo_SelectedIndexChanged);
            // 
            // tpInfoControl
            // 
            this.tpInfoControl.Controls.Add(this.groupBox3);
            this.tpInfoControl.Controls.Add(this.btnCargar);
            this.tpInfoControl.Controls.Add(this.chbNotificarVencimiento);
            this.tpInfoControl.Controls.Add(this.chbFacturarSinExistencia);
            this.tpInfoControl.Controls.Add(this.label10);
            this.tpInfoControl.Controls.Add(this.dtpFechaVencimiento);
            this.tpInfoControl.Controls.Add(this.dtpFechaModificacion);
            this.tpInfoControl.Controls.Add(this.dtpFechaCreacion);
            this.tpInfoControl.Controls.Add(this.label18);
            this.tpInfoControl.Controls.Add(this.label17);
            this.tpInfoControl.Controls.Add(this.cbUnidadSalida);
            this.tpInfoControl.Controls.Add(this.cbUnidadEntrada);
            this.tpInfoControl.Controls.Add(this.label16);
            this.tpInfoControl.Controls.Add(this.label15);
            this.tpInfoControl.Controls.Add(this.pbArticulo);
            this.tpInfoControl.Location = new System.Drawing.Point(4, 22);
            this.tpInfoControl.Name = "tpInfoControl";
            this.tpInfoControl.Padding = new System.Windows.Forms.Padding(3);
            this.tpInfoControl.Size = new System.Drawing.Size(564, 265);
            this.tpInfoControl.TabIndex = 1;
            this.tpInfoControl.Text = "Info. Control ";
            this.tpInfoControl.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBuscarProveedor2);
            this.groupBox3.Controls.Add(this.btnBuscarProveedor1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cbProveedor2);
            this.groupBox3.Controls.Add(this.cbProveedor1);
            this.groupBox3.Location = new System.Drawing.Point(9, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 82);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Proveedores";
            // 
            // btnBuscarProveedor2
            // 
            this.btnBuscarProveedor2.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarProveedor2.Location = new System.Drawing.Point(292, 44);
            this.btnBuscarProveedor2.Name = "btnBuscarProveedor2";
            this.btnBuscarProveedor2.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarProveedor2.TabIndex = 37;
            this.btnBuscarProveedor2.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor2.Click += new System.EventHandler(this.btnBuscarProveedor2_Click);
            // 
            // btnBuscarProveedor1
            // 
            this.btnBuscarProveedor1.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarProveedor1.Location = new System.Drawing.Point(292, 17);
            this.btnBuscarProveedor1.Name = "btnBuscarProveedor1";
            this.btnBuscarProveedor1.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarProveedor1.TabIndex = 36;
            this.btnBuscarProveedor1.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor1.Click += new System.EventHandler(this.btnBuscarProveedor1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Proveedor 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Proveedor 1";
            // 
            // cbProveedor2
            // 
            this.cbProveedor2.FormattingEnabled = true;
            this.cbProveedor2.Location = new System.Drawing.Point(83, 46);
            this.cbProveedor2.Name = "cbProveedor2";
            this.cbProveedor2.Size = new System.Drawing.Size(203, 21);
            this.cbProveedor2.TabIndex = 1;
            // 
            // cbProveedor1
            // 
            this.cbProveedor1.FormattingEnabled = true;
            this.cbProveedor1.Location = new System.Drawing.Point(83, 19);
            this.cbProveedor1.Name = "cbProveedor1";
            this.cbProveedor1.Size = new System.Drawing.Size(203, 21);
            this.cbProveedor1.TabIndex = 0;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(354, 225);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(195, 23);
            this.btnCargar.TabIndex = 8;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // chbNotificarVencimiento
            // 
            this.chbNotificarVencimiento.AutoSize = true;
            this.chbNotificarVencimiento.Location = new System.Drawing.Point(92, 197);
            this.chbNotificarVencimiento.Name = "chbNotificarVencimiento";
            this.chbNotificarVencimiento.Size = new System.Drawing.Size(125, 17);
            this.chbNotificarVencimiento.TabIndex = 4;
            this.chbNotificarVencimiento.Text = "Notificar vencimiento";
            this.chbNotificarVencimiento.UseVisualStyleBackColor = true;
            // 
            // chbFacturarSinExistencia
            // 
            this.chbFacturarSinExistencia.AutoSize = true;
            this.chbFacturarSinExistencia.Location = new System.Drawing.Point(92, 220);
            this.chbFacturarSinExistencia.Name = "chbFacturarSinExistencia";
            this.chbFacturarSinExistencia.Size = new System.Drawing.Size(132, 17);
            this.chbFacturarSinExistencia.TabIndex = 5;
            this.chbFacturarSinExistencia.Text = "Facturar sin Existencia";
            this.chbFacturarSinExistencia.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Fecha de vencimiento";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(207, 171);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaVencimiento.TabIndex = 3;
            this.dtpFechaVencimiento.ValueChanged += new System.EventHandler(this.dtpFechaVencimiento_ValueChanged);
            // 
            // dtpFechaModificacion
            // 
            this.dtpFechaModificacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaModificacion.Location = new System.Drawing.Point(457, 37);
            this.dtpFechaModificacion.Name = "dtpFechaModificacion";
            this.dtpFechaModificacion.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaModificacion.TabIndex = 7;
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(457, 11);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaCreacion.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(351, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "Fecha Modificación";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(369, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "Fecha Creación";
            // 
            // cbUnidadSalida
            // 
            this.cbUnidadSalida.FormattingEnabled = true;
            this.cbUnidadSalida.Location = new System.Drawing.Point(92, 130);
            this.cbUnidadSalida.Name = "cbUnidadSalida";
            this.cbUnidadSalida.Size = new System.Drawing.Size(203, 21);
            this.cbUnidadSalida.TabIndex = 2;
            // 
            // cbUnidadEntrada
            // 
            this.cbUnidadEntrada.FormattingEnabled = true;
            this.cbUnidadEntrada.Location = new System.Drawing.Point(92, 103);
            this.cbUnidadEntrada.Name = "cbUnidadEntrada";
            this.cbUnidadEntrada.Size = new System.Drawing.Size(203, 21);
            this.cbUnidadEntrada.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 133);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Unidad Compra";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Unidad Venta";
            // 
            // pbArticulo
            // 
            this.pbArticulo.Location = new System.Drawing.Point(354, 63);
            this.pbArticulo.Name = "pbArticulo";
            this.pbArticulo.Size = new System.Drawing.Size(195, 156);
            this.pbArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArticulo.TabIndex = 40;
            this.pbArticulo.TabStop = false;
            // 
            // tpInfoRegistro
            // 
            this.tpInfoRegistro.Controls.Add(this.groupBox7);
            this.tpInfoRegistro.Controls.Add(this.groupBox6);
            this.tpInfoRegistro.Controls.Add(this.groupBox5);
            this.tpInfoRegistro.Location = new System.Drawing.Point(4, 22);
            this.tpInfoRegistro.Name = "tpInfoRegistro";
            this.tpInfoRegistro.Padding = new System.Windows.Forms.Padding(3);
            this.tpInfoRegistro.Size = new System.Drawing.Size(564, 265);
            this.tpInfoRegistro.TabIndex = 2;
            this.tpInfoRegistro.Text = "Info. Registro";
            this.tpInfoRegistro.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtCostoPromedio);
            this.groupBox7.Controls.Add(this.label33);
            this.groupBox7.Location = new System.Drawing.Point(6, 50);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(274, 50);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Costeo";
            // 
            // txtCostoPromedio
            // 
            this.txtCostoPromedio.Location = new System.Drawing.Point(89, 19);
            this.txtCostoPromedio.Name = "txtCostoPromedio";
            this.txtCostoPromedio.Size = new System.Drawing.Size(163, 20);
            this.txtCostoPromedio.TabIndex = 3;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(3, 23);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(80, 13);
            this.label33.TabIndex = 1;
            this.label33.Text = "Costo promedio";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtFechaUltCompra);
            this.groupBox6.Controls.Add(this.txtMontoCompras);
            this.groupBox6.Controls.Add(this.txtCantidadCompras);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Location = new System.Drawing.Point(287, 106);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(271, 109);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ultima Compra";
            // 
            // txtFechaUltCompra
            // 
            this.txtFechaUltCompra.Location = new System.Drawing.Point(106, 25);
            this.txtFechaUltCompra.Name = "txtFechaUltCompra";
            this.txtFechaUltCompra.Size = new System.Drawing.Size(149, 20);
            this.txtFechaUltCompra.TabIndex = 6;
            // 
            // txtMontoCompras
            // 
            this.txtMontoCompras.Location = new System.Drawing.Point(106, 77);
            this.txtMontoCompras.Name = "txtMontoCompras";
            this.txtMontoCompras.Size = new System.Drawing.Size(149, 20);
            this.txtMontoCompras.TabIndex = 5;
            // 
            // txtCantidadCompras
            // 
            this.txtCantidadCompras.Location = new System.Drawing.Point(106, 51);
            this.txtCantidadCompras.Name = "txtCantidadCompras";
            this.txtCantidadCompras.Size = new System.Drawing.Size(149, 20);
            this.txtCantidadCompras.TabIndex = 4;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 80);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(37, 13);
            this.label31.TabIndex = 2;
            this.label31.Text = "Monto";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 54);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 13);
            this.label30.TabIndex = 1;
            this.label30.Text = "Cantidad";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 29);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(93, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Fecha ult. Compra";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtFechaUltVenta);
            this.groupBox5.Controls.Add(this.txtMontoVentas);
            this.groupBox5.Controls.Add(this.txtCantidadVentas);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Location = new System.Drawing.Point(6, 106);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(274, 109);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ultima Venta";
            // 
            // txtFechaUltVenta
            // 
            this.txtFechaUltVenta.Location = new System.Drawing.Point(104, 25);
            this.txtFechaUltVenta.Name = "txtFechaUltVenta";
            this.txtFechaUltVenta.Size = new System.Drawing.Size(148, 20);
            this.txtFechaUltVenta.TabIndex = 6;
            // 
            // txtMontoVentas
            // 
            this.txtMontoVentas.Location = new System.Drawing.Point(104, 77);
            this.txtMontoVentas.Name = "txtMontoVentas";
            this.txtMontoVentas.Size = new System.Drawing.Size(148, 20);
            this.txtMontoVentas.TabIndex = 5;
            // 
            // txtCantidadVentas
            // 
            this.txtCantidadVentas.Location = new System.Drawing.Point(104, 51);
            this.txtCantidadVentas.Name = "txtCantidadVentas";
            this.txtCantidadVentas.Size = new System.Drawing.Size(148, 20);
            this.txtCantidadVentas.TabIndex = 4;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 80);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 2;
            this.label28.Text = "Monto";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 54);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(49, 13);
            this.label27.TabIndex = 1;
            this.label27.Text = "Cantidad";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 29);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(85, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "Fecha ult. Venta";
            // 
            // tpComboKit
            // 
            this.tpComboKit.Controls.Add(this.btnEliminar);
            this.tpComboKit.Controls.Add(this.btnEditar);
            this.tpComboKit.Controls.Add(this.btnAgregar);
            this.tpComboKit.Controls.Add(this.dgvArticulos);
            this.tpComboKit.Location = new System.Drawing.Point(4, 22);
            this.tpComboKit.Name = "tpComboKit";
            this.tpComboKit.Padding = new System.Windows.Forms.Padding(3);
            this.tpComboKit.Size = new System.Drawing.Size(564, 265);
            this.tpComboKit.TabIndex = 4;
            this.tpComboKit.Text = "Combo /Kit";
            this.tpComboKit.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminar.Location = new System.Drawing.Point(483, 228);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditar.Location = new System.Drawing.Point(402, 228);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Location = new System.Drawing.Point(321, 228);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cCodigoInventario,
            this.cDescripcion,
            this.cCantidad});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArticulos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArticulos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvArticulos.Location = new System.Drawing.Point(3, 3);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.Size = new System.Drawing.Size(555, 219);
            this.dgvArticulos.TabIndex = 2;
            this.dgvArticulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellClick);
            this.dgvArticulos.Click += new System.EventHandler(this.x);
            // 
            // cID
            // 
            this.cID.DataPropertyName = "ID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            this.cID.Visible = false;
            // 
            // cCodigoInventario
            // 
            this.cCodigoInventario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cCodigoInventario.DataPropertyName = "InventarioID";
            this.cCodigoInventario.HeaderText = "Codigo";
            this.cCodigoInventario.Name = "cCodigoInventario";
            this.cCodigoInventario.ReadOnly = true;
            this.cCodigoInventario.Visible = false;
            // 
            // cDescripcion
            // 
            this.cDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cDescripcion.DataPropertyName = "Descripcion";
            this.cDescripcion.HeaderText = "Descripcion";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            // 
            // cCantidad
            // 
            this.cCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cCantidad.DataPropertyName = "Cantidad";
            this.cCantidad.HeaderText = "Cantidad";
            this.cCantidad.Name = "cCantidad";
            this.cCantidad.ReadOnly = true;
            this.cCantidad.Width = 74;
            // 
            // tpObservaciones
            // 
            this.tpObservaciones.Controls.Add(this.label19);
            this.tpObservaciones.Controls.Add(this.txtNotas);
            this.tpObservaciones.Location = new System.Drawing.Point(4, 22);
            this.tpObservaciones.Name = "tpObservaciones";
            this.tpObservaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tpObservaciones.Size = new System.Drawing.Size(564, 265);
            this.tpObservaciones.TabIndex = 3;
            this.tpObservaciones.Text = "Observaciones";
            this.tpObservaciones.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "Notas";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(9, 32);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(549, 201);
            this.txtNotas.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(475, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Info;
            this.txtID.ForeColor = System.Drawing.Color.Red;
            this.txtID.Location = new System.Drawing.Point(499, 10);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(80, 20);
            this.txtID.TabIndex = 12;
            this.txtID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(477, 356);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(358, 356);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmAgregarEditarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 404);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(612, 442);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(612, 442);
            this.Name = "frmAgregarEditarInventario";
            this.Load += new System.EventHandler(this.frmAgregarEditarInventario_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpInfoGeneral.ResumeLayout(false);
            this.tpInfoGeneral.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpInfoControl.ResumeLayout(false);
            this.tpInfoControl.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticulo)).EndInit();
            this.tpInfoRegistro.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tpComboKit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.tpObservaciones.ResumeLayout(false);
            this.tpObservaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpInfoGeneral;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.TextBox txtStockMin;
        private System.Windows.Forms.TextBox txtStockMax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.ComboBox cbFamilia;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTipoArticulo;
        private System.Windows.Forms.Button btnBuscarFamilia;
        private System.Windows.Forms.Button btnBuscarMarca;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnModelo;
        private System.Windows.Forms.ComboBox cbImpuesto;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.TabPage tpInfoRegistro;
        private System.Windows.Forms.TabPage tpInfoControl;
        private System.Windows.Forms.CheckBox chbFacturarSinExistencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.PictureBox pbArticulo;
        private System.Windows.Forms.DateTimePicker dtpFechaModificacion;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbUnidadSalida;
        private System.Windows.Forms.ComboBox cbUnidadEntrada;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chbNotificarVencimiento;
        private System.Windows.Forms.TabPage tpObservaciones;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtCostoPromedio;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtMontoCompras;
        private System.Windows.Forms.TextBox txtCantidadCompras;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtMontoVentas;
        private System.Windows.Forms.TextBox txtCantidadVentas;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TabPage tpComboKit;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvArticulos;
        private DevComponents.DotNetBar.ButtonX btnEditar;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private System.Windows.Forms.Label lblPorcientoPrecio4;
        private System.Windows.Forms.Label lblPorcientoPrecio3;
        private System.Windows.Forms.Label lblPorcientoPrecio2;
        private System.Windows.Forms.Label lblPorcientoPublico;
        private System.Windows.Forms.TextBox txtMinimo;
        private System.Windows.Forms.TextBox txtPrecio3;
        private System.Windows.Forms.TextBox txtPrecio2;
        private System.Windows.Forms.TextBox txtPrecioPublico;
        private System.Windows.Forms.Label lblMinimo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBuscarProveedor2;
        private System.Windows.Forms.Button btnBuscarProveedor1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbProveedor2;
        private System.Windows.Forms.ComboBox cbProveedor1;
        private DevComponents.DotNetBar.ButtonX btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodigoInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidad;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.TextBox txtFechaUltCompra;
        private System.Windows.Forms.TextBox txtFechaUltVenta;
    }
}