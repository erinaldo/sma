namespace SMA.Compras
{
    partial class frmRecepcionArticulos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionArticulos));
            this.lblRNC = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.lblTotalTrasaccion = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.cArticuloID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcCodigo_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcDescripcion_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcCantidad_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cImpuestosTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcImporte_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidadVentaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBuscarArticulo = new DevComponents.DotNetBar.ButtonX();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtFactura_ID = new System.Windows.Forms.TextBox();
            this.dtpFechaRecepcion = new System.Windows.Forms.DateTimePicker();
            this.Label9 = new System.Windows.Forms.Label();
            this.btnEliminarLinea = new DevComponents.DotNetBar.ButtonX();
            this.btnCrearProducto = new DevComponents.DotNetBar.ButtonX();
            this.btnVerProducto = new DevComponents.DotNetBar.ButtonX();
            this.btnGuardar = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnBuscarCliente = new DevComponents.DotNetBar.ButtonX();
            this.txtNCF = new System.Windows.Forms.TextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.btnVerReferencia = new DevComponents.DotNetBar.ButtonX();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.dtpFechaEnvio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbContado = new System.Windows.Forms.RadioButton();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRNC
            // 
            this.lblRNC.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblRNC.Location = new System.Drawing.Point(97, 99);
            this.lblRNC.Name = "lblRNC";
            this.lblRNC.Size = new System.Drawing.Size(155, 20);
            this.lblRNC.TabIndex = 182;
            this.lblRNC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Controls.Add(this.lblTotalTrasaccion);
            this.GroupBox2.Controls.Add(this.Label20);
            this.GroupBox2.Controls.Add(this.lblImpuesto);
            this.GroupBox2.Controls.Add(this.Label17);
            this.GroupBox2.Controls.Add(this.lblSubTotal);
            this.GroupBox2.Location = new System.Drawing.Point(562, 381);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(291, 119);
            this.GroupBox2.TabIndex = 181;
            this.GroupBox2.TabStop = false;
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(24, 92);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(34, 13);
            this.Label22.TabIndex = 53;
            this.Label22.Text = "Total:";
            // 
            // lblTotalTrasaccion
            // 
            this.lblTotalTrasaccion.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblTotalTrasaccion.Location = new System.Drawing.Point(92, 86);
            this.lblTotalTrasaccion.Name = "lblTotalTrasaccion";
            this.lblTotalTrasaccion.Size = new System.Drawing.Size(193, 25);
            this.lblTotalTrasaccion.TabIndex = 54;
            this.lblTotalTrasaccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(24, 58);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(53, 13);
            this.Label20.TabIndex = 51;
            this.Label20.Text = "Impuesto:";
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblImpuesto.Location = new System.Drawing.Point(92, 52);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(193, 25);
            this.lblImpuesto.TabIndex = 52;
            this.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(24, 24);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(56, 13);
            this.Label17.TabIndex = 46;
            this.Label17.Text = "Sub-Total:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblSubTotal.Location = new System.Drawing.Point(92, 18);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(193, 25);
            this.lblSubTotal.TabIndex = 47;
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(12, 493);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(355, 55);
            this.txtObservaciones.TabIndex = 6;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.dgvDetalleFactura);
            this.GroupBox1.Location = new System.Drawing.Point(12, 205);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(841, 170);
            this.GroupBox1.TabIndex = 177;
            this.GroupBox1.TabStop = false;
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.AllowUserToDeleteRows = false;
            this.dgvDetalleFactura.AllowUserToResizeColumns = false;
            this.dgvDetalleFactura.AllowUserToResizeRows = false;
            this.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cArticuloID,
            this.txtcCodigo_Articulo,
            this.txtcDescripcion_Articulo,
            this.txtcCantidad_Articulo,
            this.txtcPrecio,
            this.txtcImpuesto,
            this.cImpuestosTotal,
            this.txtcImporte_Total,
            this.cUnidadVentaID,
            this.cTipoArticulo});
            this.dgvDetalleFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleFactura.Location = new System.Drawing.Point(3, 16);
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.Size = new System.Drawing.Size(835, 151);
            this.dgvDetalleFactura.TabIndex = 0;
            // 
            // cArticuloID
            // 
            this.cArticuloID.HeaderText = "ArticuloID";
            this.cArticuloID.Name = "cArticuloID";
            this.cArticuloID.Visible = false;
            // 
            // txtcCodigo_Articulo
            // 
            this.txtcCodigo_Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.txtcCodigo_Articulo.HeaderText = "Codigo articulo";
            this.txtcCodigo_Articulo.Name = "txtcCodigo_Articulo";
            this.txtcCodigo_Articulo.Width = 102;
            // 
            // txtcDescripcion_Articulo
            // 
            this.txtcDescripcion_Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtcDescripcion_Articulo.HeaderText = "Descripcion";
            this.txtcDescripcion_Articulo.Name = "txtcDescripcion_Articulo";
            // 
            // txtcCantidad_Articulo
            // 
            this.txtcCantidad_Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.txtcCantidad_Articulo.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtcCantidad_Articulo.HeaderText = "Cant.";
            this.txtcCantidad_Articulo.Name = "txtcCantidad_Articulo";
            this.txtcCantidad_Articulo.Width = 57;
            // 
            // txtcPrecio
            // 
            this.txtcPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.txtcPrecio.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtcPrecio.HeaderText = "Precio";
            this.txtcPrecio.Name = "txtcPrecio";
            this.txtcPrecio.Width = 62;
            // 
            // txtcImpuesto
            // 
            this.txtcImpuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.txtcImpuesto.DefaultCellStyle = dataGridViewCellStyle7;
            this.txtcImpuesto.HeaderText = "Imp. %";
            this.txtcImpuesto.Name = "txtcImpuesto";
            this.txtcImpuesto.Width = 63;
            // 
            // cImpuestosTotal
            // 
            this.cImpuestosTotal.HeaderText = "Impuestos Total";
            this.cImpuestosTotal.Name = "cImpuestosTotal";
            this.cImpuestosTotal.Visible = false;
            // 
            // txtcImporte_Total
            // 
            this.txtcImporte_Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.txtcImporte_Total.DefaultCellStyle = dataGridViewCellStyle8;
            this.txtcImporte_Total.HeaderText = "Importe Total";
            this.txtcImporte_Total.Name = "txtcImporte_Total";
            this.txtcImporte_Total.Width = 94;
            // 
            // cUnidadVentaID
            // 
            this.cUnidadVentaID.HeaderText = "Unidad Venta";
            this.cUnidadVentaID.Name = "cUnidadVentaID";
            this.cUnidadVentaID.Visible = false;
            // 
            // cTipoArticulo
            // 
            this.cTipoArticulo.HeaderText = "Tipo Articulo";
            this.cTipoArticulo.Name = "cTipoArticulo";
            this.cTipoArticulo.Visible = false;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnBuscarArticulo);
            this.GroupBox3.Controls.Add(this.txtImpuesto);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Controls.Add(this.btnInsertar);
            this.GroupBox3.Controls.Add(this.Label14);
            this.GroupBox3.Controls.Add(this.txtImporteTotal);
            this.GroupBox3.Controls.Add(this.lblPrecio);
            this.GroupBox3.Controls.Add(this.txtPrecio);
            this.GroupBox3.Controls.Add(this.lblCantidad);
            this.GroupBox3.Controls.Add(this.txtCantidad);
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.lblDescripcion);
            this.GroupBox3.Controls.Add(this.lblCodigo);
            this.GroupBox3.Controls.Add(this.txtCodigo);
            this.GroupBox3.Location = new System.Drawing.Point(12, 127);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(841, 72);
            this.GroupBox3.TabIndex = 164;
            this.GroupBox3.TabStop = false;
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscarArticulo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscarArticulo.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarArticulo.Location = new System.Drawing.Point(125, 35);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarArticulo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscarArticulo.TabIndex = 1;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(639, 35);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(57, 20);
            this.txtImpuesto.TabIndex = 4;
            this.txtImpuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImpuesto_KeyPress);
            this.txtImpuesto.Validated += new System.EventHandler(this.txtImpuesto_Validated);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(636, 16);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(38, 13);
            this.Label6.TabIndex = 72;
            this.Label6.Text = "Imp. %";
            // 
            // btnInsertar
            // 
            this.btnInsertar.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertar.Image")));
            this.btnInsertar.Location = new System.Drawing.Point(804, 32);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(26, 24);
            this.btnInsertar.TabIndex = 5;
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(702, 16);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(34, 13);
            this.Label14.TabIndex = 69;
            this.Label14.Text = "Total:";
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporteTotal.Location = new System.Drawing.Point(702, 35);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.ReadOnly = true;
            this.txtImporteTotal.Size = new System.Drawing.Size(96, 20);
            this.txtImporteTotal.TabIndex = 14;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(537, 15);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 65;
            this.lblPrecio.Text = "Costo:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(540, 35);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(93, 20);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            this.txtPrecio.Validated += new System.EventHandler(this.txtPrecio_Validated);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(451, 17);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 63;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(454, 35);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(80, 20);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validated += new System.EventHandler(this.txtCantidad_Validated);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(125, 15);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(66, 13);
            this.Label7.TabIndex = 61;
            this.Label7.Text = "Descripcion:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblDescripcion.Location = new System.Drawing.Point(157, 35);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(291, 20);
            this.lblDescripcion.TabIndex = 60;
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(11, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 59;
            this.lblCodigo.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(11, 36);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(108, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Validated += new System.EventHandler(this.txtCodigo_Validated);
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(12, 103);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(33, 13);
            this.Label27.TabIndex = 175;
            this.Label27.Text = "RNC:";
            // 
            // cbProveedor
            // 
            this.cbProveedor.DisplayMember = "Empresa";
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(97, 42);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(354, 21);
            this.cbProveedor.TabIndex = 0;
            this.cbProveedor.ValueMember = "Cliente_ID";
            this.cbProveedor.SelectedValueChanged += new System.EventHandler(this.cbProveedor_SelectedValueChanged);
            // 
            // lblDireccion
            // 
            this.lblDireccion.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblDireccion.Location = new System.Drawing.Point(97, 71);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(295, 20);
            this.lblDireccion.TabIndex = 172;
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(12, 76);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(55, 13);
            this.Label4.TabIndex = 171;
            this.Label4.Text = "Direccion:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 45);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(59, 13);
            this.Label3.TabIndex = 170;
            this.Label3.Text = "Proveedor:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(79, 13);
            this.Label1.TabIndex = 169;
            this.Label1.Text = "No. Recepcion";
            // 
            // txtFactura_ID
            // 
            this.txtFactura_ID.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtFactura_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFactura_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactura_ID.ForeColor = System.Drawing.Color.Red;
            this.txtFactura_ID.Location = new System.Drawing.Point(97, 11);
            this.txtFactura_ID.Name = "txtFactura_ID";
            this.txtFactura_ID.ReadOnly = true;
            this.txtFactura_ID.Size = new System.Drawing.Size(134, 22);
            this.txtFactura_ID.TabIndex = 168;
            this.txtFactura_ID.TabStop = false;
            // 
            // dtpFechaRecepcion
            // 
            this.dtpFechaRecepcion.CustomFormat = "";
            this.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRecepcion.Location = new System.Drawing.Point(733, 12);
            this.dtpFechaRecepcion.Name = "dtpFechaRecepcion";
            this.dtpFechaRecepcion.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaRecepcion.TabIndex = 2;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(637, 16);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(90, 13);
            this.Label9.TabIndex = 167;
            this.Label9.Text = "Fecha recepción:";
            // 
            // btnEliminarLinea
            // 
            this.btnEliminarLinea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminarLinea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminarLinea.Location = new System.Drawing.Point(15, 384);
            this.btnEliminarLinea.Name = "btnEliminarLinea";
            this.btnEliminarLinea.Size = new System.Drawing.Size(112, 24);
            this.btnEliminarLinea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminarLinea.TabIndex = 3;
            this.btnEliminarLinea.Text = "Eliminar Linea";
            this.btnEliminarLinea.Click += new System.EventHandler(this.btnEliminarLinea_Click);
            // 
            // btnCrearProducto
            // 
            this.btnCrearProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCrearProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCrearProducto.Location = new System.Drawing.Point(251, 384);
            this.btnCrearProducto.Name = "btnCrearProducto";
            this.btnCrearProducto.Size = new System.Drawing.Size(112, 24);
            this.btnCrearProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCrearProducto.TabIndex = 5;
            this.btnCrearProducto.Text = "Crear producto";
            this.btnCrearProducto.Click += new System.EventHandler(this.btnCrearProducto_Click);
            // 
            // btnVerProducto
            // 
            this.btnVerProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVerProducto.Location = new System.Drawing.Point(133, 384);
            this.btnVerProducto.Name = "btnVerProducto";
            this.btnVerProducto.Size = new System.Drawing.Size(112, 24);
            this.btnVerProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVerProducto.TabIndex = 4;
            this.btnVerProducto.Text = "Ver producto";
            this.btnVerProducto.Click += new System.EventHandler(this.btnVerProducto_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(645, 506);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 42);
            this.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.Image = ((System.Drawing.Image)(resources.GetObject("buttonX6.Image")));
            this.buttonX6.Location = new System.Drawing.Point(751, 506);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(102, 42);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.TabIndex = 8;
            this.buttonX6.Text = "Cancelar";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscarCliente.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarCliente.Location = new System.Drawing.Point(457, 40);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscarCliente.TabIndex = 1;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtNCF
            // 
            this.txtNCF.Location = new System.Drawing.Point(520, 103);
            this.txtNCF.MaxLength = 19;
            this.txtNCF.Name = "txtNCF";
            this.txtNCF.Size = new System.Drawing.Size(330, 20);
            this.txtNCF.TabIndex = 203;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(441, 106);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(73, 13);
            this.Label25.TabIndex = 204;
            this.Label25.Text = "Comprobante:";
            // 
            // btnVerReferencia
            // 
            this.btnVerReferencia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerReferencia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVerReferencia.Image = global::SMA.Properties.Resources.find_icon;
            this.btnVerReferencia.Location = new System.Drawing.Point(641, 73);
            this.btnVerReferencia.Name = "btnVerReferencia";
            this.btnVerReferencia.Size = new System.Drawing.Size(26, 23);
            this.btnVerReferencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVerReferencia.TabIndex = 207;
            this.btnVerReferencia.Click += new System.EventHandler(this.btnVerReferencia_Click);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(520, 76);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(115, 20);
            this.txtReferencia.TabIndex = 206;
            this.txtReferencia.Validated += new System.EventHandler(this.txtReferencia_Validated);
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(441, 79);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(62, 13);
            this.lblReferencia.TabIndex = 205;
            this.lblReferencia.Text = "Referencia:";
            this.lblReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpFechaEnvio
            // 
            this.dtpFechaEnvio.CustomFormat = "";
            this.dtpFechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEnvio.Location = new System.Drawing.Point(520, 12);
            this.dtpFechaEnvio.Name = "dtpFechaEnvio";
            this.dtpFechaEnvio.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaEnvio.TabIndex = 208;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 209;
            this.label2.Text = "Fecha Envio:";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.CustomFormat = "";
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(266, 423);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaVencimiento.TabIndex = 210;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 211;
            this.label5.Text = "Fecha Vencimiento:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbCredito);
            this.groupBox4.Controls.Add(this.rbContado);
            this.groupBox4.Location = new System.Drawing.Point(12, 449);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(355, 38);
            this.groupBox4.TabIndex = 212;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Condición";
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Location = new System.Drawing.Point(228, 15);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(68, 17);
            this.rbCredito.TabIndex = 1;
            this.rbCredito.Text = "A Crédito";
            this.rbCredito.UseVisualStyleBackColor = true;
            // 
            // rbContado
            // 
            this.rbContado.AutoSize = true;
            this.rbContado.Checked = true;
            this.rbContado.Location = new System.Drawing.Point(17, 15);
            this.rbContado.Name = "rbContado";
            this.rbContado.Size = new System.Drawing.Size(81, 17);
            this.rbContado.TabIndex = 0;
            this.rbContado.TabStop = true;
            this.rbContado.Text = "De contado";
            this.rbContado.UseVisualStyleBackColor = true;
            // 
            // frmRecepcionArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 549);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpFechaEnvio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVerReferencia);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.lblReferencia);
            this.Controls.Add(this.txtNCF);
            this.Controls.Add(this.Label25);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnVerProducto);
            this.Controls.Add(this.btnCrearProducto);
            this.Controls.Add(this.btnEliminarLinea);
            this.Controls.Add(this.lblRNC);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.Label27);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtFactura_ID);
            this.Controls.Add(this.dtpFechaRecepcion);
            this.Controls.Add(this.Label9);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(878, 587);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(878, 587);
            this.Name = "frmRecepcionArticulos";
            this.Text = "Agregar recepción";
            this.Load += new System.EventHandler(this.frmRecepcionArticulos_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblRNC;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label lblTotalTrasaccion;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label lblImpuesto;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label lblSubTotal;
        internal System.Windows.Forms.TextBox txtObservaciones;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnInsertar;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txtImporteTotal;
        internal System.Windows.Forms.Label lblPrecio;
        internal System.Windows.Forms.TextBox txtPrecio;
        internal System.Windows.Forms.Label lblCantidad;
        internal System.Windows.Forms.TextBox txtCantidad;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label lblDescripcion;
        internal System.Windows.Forms.Label lblCodigo;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.ComboBox cbProveedor;
        internal System.Windows.Forms.Label lblDireccion;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtFactura_ID;
        internal System.Windows.Forms.DateTimePicker dtpFechaRecepcion;
        internal System.Windows.Forms.Label Label9;
        private DevComponents.DotNetBar.ButtonX btnEliminarLinea;
        private DevComponents.DotNetBar.ButtonX btnCrearProducto;
        private DevComponents.DotNetBar.ButtonX btnVerProducto;
        private DevComponents.DotNetBar.ButtonX btnGuardar;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        internal System.Windows.Forms.TextBox txtImpuesto;
        private DevComponents.DotNetBar.ButtonX btnBuscarArticulo;
        private DevComponents.DotNetBar.ButtonX btnBuscarCliente;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        internal System.Windows.Forms.DataGridView dgvDetalleFactura;
        private System.Windows.Forms.TextBox txtNCF;
        internal System.Windows.Forms.Label Label25;
        private DevComponents.DotNetBar.ButtonX btnVerReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblReferencia;
        internal System.Windows.Forms.DateTimePicker dtpFechaEnvio;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.RadioButton rbContado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cArticuloID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcCodigo_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcDescripcion_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcCantidad_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cImpuestosTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcImporte_Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidadVentaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoArticulo;

    }
}