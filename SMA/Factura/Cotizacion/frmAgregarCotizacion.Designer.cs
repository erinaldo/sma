﻿namespace SMA.Factura.Cotizacion
{
    partial class frmAgregarCotizacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarCotizacion));
            this.lblTotalTrasaccion = new System.Windows.Forms.Label();
            this.cUnidadVentaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcImporte_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescuentoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cImpuestosTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcCantidad_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcDescripcion_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcCodigo_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cArticuloID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label18 = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.cTipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.erDescuento = new System.Windows.Forms.ErrorProvider(this.components);
            this.erPrecio = new System.Windows.Forms.ErrorProvider(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.Label6 = new System.Windows.Forms.Label();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnGuardar = new DevComponents.DotNetBar.ButtonX();
            this.btnVerProducto = new DevComponents.DotNetBar.ButtonX();
            this.btnEliminarLinea = new DevComponents.DotNetBar.ButtonX();
            this.lblRNC = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.erCantidad = new System.Windows.Forms.ErrorProvider(this.components);
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBuscarArticulos = new DevComponents.DotNetBar.ButtonX();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.Label27 = new System.Windows.Forms.Label();
            this.txtEnviarA = new System.Windows.Forms.TextBox();
            this.Label26 = new System.Windows.Forms.Label();
            this.dtpFechaEnvio = new System.Windows.Forms.DateTimePicker();
            this.Label10 = new System.Windows.Forms.Label();
            this.cbbCliente = new System.Windows.Forms.ComboBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtFactura_ID = new System.Windows.Forms.TextBox();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.Label9 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbContado = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erPrecio)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erCantidad)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalTrasaccion
            // 
            this.lblTotalTrasaccion.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblTotalTrasaccion.Location = new System.Drawing.Point(92, 111);
            this.lblTotalTrasaccion.Name = "lblTotalTrasaccion";
            this.lblTotalTrasaccion.Size = new System.Drawing.Size(172, 25);
            this.lblTotalTrasaccion.TabIndex = 54;
            this.lblTotalTrasaccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cUnidadVentaID
            // 
            this.cUnidadVentaID.HeaderText = "Unidad Venta";
            this.cUnidadVentaID.Name = "cUnidadVentaID";
            this.cUnidadVentaID.Visible = false;
            // 
            // cCosto
            // 
            this.cCosto.HeaderText = "Costo";
            this.cCosto.Name = "cCosto";
            this.cCosto.Visible = false;
            // 
            // txtcImporte_Total
            // 
            this.txtcImporte_Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.txtcImporte_Total.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtcImporte_Total.HeaderText = "Importe Total";
            this.txtcImporte_Total.Name = "txtcImporte_Total";
            this.txtcImporte_Total.Width = 94;
            // 
            // cDescuentoTotal
            // 
            this.cDescuentoTotal.HeaderText = "Descuento Total";
            this.cDescuentoTotal.Name = "cDescuentoTotal";
            this.cDescuentoTotal.Visible = false;
            // 
            // txtcDescuento
            // 
            this.txtcDescuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.txtcDescuento.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtcDescuento.HeaderText = "Desc. %";
            this.txtcDescuento.Name = "txtcDescuento";
            this.txtcDescuento.Width = 71;
            // 
            // cImpuestosTotal
            // 
            this.cImpuestosTotal.HeaderText = "Impuestos Total";
            this.cImpuestosTotal.Name = "cImpuestosTotal";
            this.cImpuestosTotal.Visible = false;
            // 
            // txtcImpuesto
            // 
            this.txtcImpuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.txtcImpuesto.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtcImpuesto.HeaderText = "Imp. %";
            this.txtcImpuesto.Name = "txtcImpuesto";
            this.txtcImpuesto.Width = 63;
            // 
            // txtcPrecio
            // 
            this.txtcPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.txtcPrecio.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtcPrecio.HeaderText = "Precio";
            this.txtcPrecio.Name = "txtcPrecio";
            this.txtcPrecio.Width = 62;
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
            // txtcDescripcion_Articulo
            // 
            this.txtcDescripcion_Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtcDescripcion_Articulo.HeaderText = "Descripcion";
            this.txtcDescripcion_Articulo.Name = "txtcDescripcion_Articulo";
            // 
            // txtcCodigo_Articulo
            // 
            this.txtcCodigo_Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.txtcCodigo_Articulo.HeaderText = "Codigo articulo";
            this.txtcCodigo_Articulo.Name = "txtcCodigo_Articulo";
            this.txtcCodigo_Articulo.Width = 102;
            // 
            // cArticuloID
            // 
            this.cArticuloID.HeaderText = "ArticuloID";
            this.cArticuloID.Name = "cArticuloID";
            this.cArticuloID.Visible = false;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(10, 53);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(62, 13);
            this.Label18.TabIndex = 55;
            this.Label18.Text = "Descuento:";
            // 
            // lblDescuento
            // 
            this.lblDescuento.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblDescuento.Location = new System.Drawing.Point(92, 49);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(172, 25);
            this.lblDescuento.TabIndex = 56;
            this.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(44, 115);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(34, 13);
            this.Label22.TabIndex = 53;
            this.Label22.Text = "Total:";
            // 
            // cTipoArticulo
            // 
            this.cTipoArticulo.HeaderText = "Tipo Articulo";
            this.cTipoArticulo.Name = "cTipoArticulo";
            this.cTipoArticulo.Visible = false;
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
            this.txtcDescuento,
            this.cDescuentoTotal,
            this.txtcImporte_Total,
            this.cCosto,
            this.cUnidadVentaID,
            this.cTipoArticulo});
            this.dgvDetalleFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleFactura.Location = new System.Drawing.Point(3, 16);
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.Size = new System.Drawing.Size(893, 124);
            this.dgvDetalleFactura.TabIndex = 0;
            // 
            // erDescuento
            // 
            this.erDescuento.ContainerControl = this;
            // 
            // erPrecio
            // 
            this.erPrecio.ContainerControl = this;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(702, 15);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(38, 13);
            this.Label6.TabIndex = 72;
            this.Label6.Text = "Imp. %";
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImpuesto.Location = new System.Drawing.Point(702, 36);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(57, 20);
            this.txtImpuesto.TabIndex = 13;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(765, 14);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(34, 13);
            this.Label14.TabIndex = 69;
            this.Label14.Text = "Total:";
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporteTotal.Location = new System.Drawing.Point(765, 36);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.ReadOnly = true;
            this.txtImporteTotal.Size = new System.Drawing.Size(96, 20);
            this.txtImporteTotal.TabIndex = 14;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(638, 16);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(46, 13);
            this.Label13.TabIndex = 67;
            this.Label13.Text = "Desc. %";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(639, 36);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(57, 20);
            this.txtDescuento.TabIndex = 3;
            this.txtDescuento.Validated += new System.EventHandler(this.txtDescuento_Validated);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(537, 16);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 65;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(540, 36);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(93, 20);
            this.txtPrecio.TabIndex = 2;
            this.txtPrecio.Validated += new System.EventHandler(this.txtPrecio_Validated);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(451, 16);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 63;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(454, 36);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(80, 20);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.Validated += new System.EventHandler(this.txtCantidad_Validated);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(157, 16);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(66, 13);
            this.Label7.TabIndex = 61;
            this.Label7.Text = "Descripcion:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblDescripcion.Location = new System.Drawing.Point(157, 36);
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
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(20, 84);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(53, 13);
            this.Label20.TabIndex = 51;
            this.Label20.Text = "Impuesto:";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.CustomFormat = "";
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(114, 379);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaVencimiento.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 196;
            this.label2.Text = "Fecha vencimiento:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Location = new System.Drawing.Point(794, 512);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGuardar.Location = new System.Drawing.Point(686, 512);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 42);
            this.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVerProducto
            // 
            this.btnVerProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVerProducto.Location = new System.Drawing.Point(122, 349);
            this.btnVerProducto.Name = "btnVerProducto";
            this.btnVerProducto.Size = new System.Drawing.Size(102, 23);
            this.btnVerProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVerProducto.TabIndex = 8;
            this.btnVerProducto.Text = "Ver producto";
            this.btnVerProducto.Click += new System.EventHandler(this.btnVerProducto_Click);
            // 
            // btnEliminarLinea
            // 
            this.btnEliminarLinea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminarLinea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminarLinea.Location = new System.Drawing.Point(14, 349);
            this.btnEliminarLinea.Name = "btnEliminarLinea";
            this.btnEliminarLinea.Size = new System.Drawing.Size(102, 23);
            this.btnEliminarLinea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminarLinea.TabIndex = 7;
            this.btnEliminarLinea.Text = "Eliminar Linea";
            this.btnEliminarLinea.Click += new System.EventHandler(this.btnEliminarLinea_Click);
            // 
            // lblRNC
            // 
            this.lblRNC.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblRNC.Location = new System.Drawing.Point(99, 99);
            this.lblRNC.Name = "lblRNC";
            this.lblRNC.Size = new System.Drawing.Size(143, 20);
            this.lblRNC.TabIndex = 189;
            this.lblRNC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label18);
            this.GroupBox2.Controls.Add(this.lblDescuento);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Controls.Add(this.lblTotalTrasaccion);
            this.GroupBox2.Controls.Add(this.Label20);
            this.GroupBox2.Controls.Add(this.lblImpuesto);
            this.GroupBox2.Controls.Add(this.Label17);
            this.GroupBox2.Controls.Add(this.lblSubTotal);
            this.GroupBox2.Location = new System.Drawing.Point(635, 352);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(275, 143);
            this.GroupBox2.TabIndex = 188;
            this.GroupBox2.TabStop = false;
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblImpuesto.Location = new System.Drawing.Point(92, 80);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(172, 25);
            this.lblImpuesto.TabIndex = 52;
            this.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(16, 22);
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
            this.lblSubTotal.Size = new System.Drawing.Size(172, 25);
            this.lblSubTotal.TabIndex = 47;
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(11, 449);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(352, 94);
            this.txtObservaciones.TabIndex = 10;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.dgvDetalleFactura);
            this.GroupBox1.Location = new System.Drawing.Point(11, 200);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(899, 143);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            // 
            // erCantidad
            // 
            this.erCantidad.ContainerControl = this;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnBuscarArticulos);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Controls.Add(this.txtImpuesto);
            this.GroupBox3.Controls.Add(this.btnInsertar);
            this.GroupBox3.Controls.Add(this.Label14);
            this.GroupBox3.Controls.Add(this.txtImporteTotal);
            this.GroupBox3.Controls.Add(this.Label13);
            this.GroupBox3.Controls.Add(this.txtDescuento);
            this.GroupBox3.Controls.Add(this.lblPrecio);
            this.GroupBox3.Controls.Add(this.txtPrecio);
            this.GroupBox3.Controls.Add(this.lblCantidad);
            this.GroupBox3.Controls.Add(this.txtCantidad);
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.lblDescripcion);
            this.GroupBox3.Controls.Add(this.lblCodigo);
            this.GroupBox3.Controls.Add(this.txtCodigo);
            this.GroupBox3.Location = new System.Drawing.Point(8, 122);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(899, 72);
            this.GroupBox3.TabIndex = 5;
            this.GroupBox3.TabStop = false;
            // 
            // btnBuscarArticulos
            // 
            this.btnBuscarArticulos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscarArticulos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscarArticulos.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarArticulos.Location = new System.Drawing.Point(125, 33);
            this.btnBuscarArticulos.Name = "btnBuscarArticulos";
            this.btnBuscarArticulos.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarArticulos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscarArticulos.TabIndex = 161;
            this.btnBuscarArticulos.Click += new System.EventHandler(this.btnBuscarArticulos_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertar.Image")));
            this.btnInsertar.Location = new System.Drawing.Point(867, 35);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(26, 24);
            this.btnInsertar.TabIndex = 4;
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(11, 103);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(33, 13);
            this.Label27.TabIndex = 185;
            this.Label27.Text = "RNC:";
            // 
            // txtEnviarA
            // 
            this.txtEnviarA.Location = new System.Drawing.Point(601, 34);
            this.txtEnviarA.Multiline = true;
            this.txtEnviarA.Name = "txtEnviarA";
            this.txtEnviarA.Size = new System.Drawing.Size(306, 54);
            this.txtEnviarA.TabIndex = 3;
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Location = new System.Drawing.Point(539, 37);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(49, 13);
            this.Label26.TabIndex = 184;
            this.Label26.Text = "Enviar a:";
            // 
            // dtpFechaEnvio
            // 
            this.dtpFechaEnvio.CustomFormat = "";
            this.dtpFechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEnvio.Location = new System.Drawing.Point(764, 8);
            this.dtpFechaEnvio.Name = "dtpFechaEnvio";
            this.dtpFechaEnvio.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaEnvio.TabIndex = 2;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(721, 11);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(37, 13);
            this.Label10.TabIndex = 183;
            this.Label10.Text = "Envio:";
            // 
            // cbbCliente
            // 
            this.cbbCliente.DisplayMember = "Empresa";
            this.cbbCliente.FormattingEnabled = true;
            this.cbbCliente.Location = new System.Drawing.Point(99, 42);
            this.cbbCliente.Name = "cbbCliente";
            this.cbbCliente.Size = new System.Drawing.Size(309, 21);
            this.cbbCliente.TabIndex = 0;
            this.cbbCliente.ValueMember = "Cliente_ID";
            this.cbbCliente.SelectedValueChanged += new System.EventHandler(this.cbbCliente_SelectedValueChanged);
            // 
            // lblDireccion
            // 
            this.lblDireccion.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblDireccion.Location = new System.Drawing.Point(99, 71);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(309, 20);
            this.lblDireccion.TabIndex = 182;
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(11, 75);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(55, 13);
            this.Label4.TabIndex = 181;
            this.Label4.Text = "Direccion:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(11, 45);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(42, 13);
            this.Label3.TabIndex = 180;
            this.Label3.Text = "Cliente:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(82, 13);
            this.Label1.TabIndex = 179;
            this.Label1.Text = "No. Documento";
            // 
            // txtFactura_ID
            // 
            this.txtFactura_ID.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtFactura_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFactura_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactura_ID.ForeColor = System.Drawing.Color.Red;
            this.txtFactura_ID.Location = new System.Drawing.Point(99, 12);
            this.txtFactura_ID.Name = "txtFactura_ID";
            this.txtFactura_ID.ReadOnly = true;
            this.txtFactura_ID.Size = new System.Drawing.Size(103, 22);
            this.txtFactura_ID.TabIndex = 178;
            this.txtFactura_ID.TabStop = false;
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.CustomFormat = "";
            this.dtpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFactura.Location = new System.Drawing.Point(601, 8);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaFactura.TabIndex = 1;
            this.dtpFechaFactura.ValueChanged += new System.EventHandler(this.dtpFechaFactura_ValueChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(539, 11);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(40, 13);
            this.Label9.TabIndex = 177;
            this.Label9.Text = "Fecha:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscarCliente.Image = global::SMA.Properties.Resources.find_icon;
            this.btnBuscarCliente.Location = new System.Drawing.Point(414, 40);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscarCliente.TabIndex = 192;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(539, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 197;
            this.label5.Text = "Vendedor:";
            // 
            // cbVendedor
            // 
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Location = new System.Drawing.Point(601, 97);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(306, 21);
            this.cbVendedor.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbCredito);
            this.groupBox4.Controls.Add(this.rbContado);
            this.groupBox4.Location = new System.Drawing.Point(8, 405);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(355, 38);
            this.groupBox4.TabIndex = 199;
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
            // frmAgregarCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 557);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cbVendedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.btnVerProducto);
            this.Controls.Add(this.btnEliminarLinea);
            this.Controls.Add(this.lblRNC);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.Label27);
            this.Controls.Add(this.txtEnviarA);
            this.Controls.Add(this.Label26);
            this.Controls.Add(this.dtpFechaEnvio);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.cbbCliente);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtFactura_ID);
            this.Controls.Add(this.dtpFechaFactura);
            this.Controls.Add(this.Label9);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmAgregarCotizacion";
            this.Text = "Agregar nueva cotizacion";
            this.Load += new System.EventHandler(this.frmAgregarCotizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erPrecio)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erCantidad)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTotalTrasaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidadVentaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcImporte_Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescuentoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cImpuestosTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcCantidad_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcDescripcion_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcCodigo_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cArticuloID;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label lblDescuento;
        internal System.Windows.Forms.Label Label22;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoArticulo;
        internal System.Windows.Forms.DataGridView dgvDetalleFactura;
        private DevComponents.DotNetBar.ButtonX btnBuscarArticulos;
        private System.Windows.Forms.ErrorProvider erDescuento;
        internal System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        internal System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnGuardar;
        private DevComponents.DotNetBar.ButtonX btnBuscarCliente;
        private DevComponents.DotNetBar.ButtonX btnVerProducto;
        private DevComponents.DotNetBar.ButtonX btnEliminarLinea;
        internal System.Windows.Forms.Label lblRNC;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label lblImpuesto;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label lblSubTotal;
        internal System.Windows.Forms.TextBox txtObservaciones;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtImpuesto;
        internal System.Windows.Forms.Button btnInsertar;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txtImporteTotal;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txtDescuento;
        internal System.Windows.Forms.Label lblPrecio;
        internal System.Windows.Forms.TextBox txtPrecio;
        internal System.Windows.Forms.Label lblCantidad;
        internal System.Windows.Forms.TextBox txtCantidad;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label lblDescripcion;
        internal System.Windows.Forms.Label lblCodigo;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.TextBox txtEnviarA;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.DateTimePicker dtpFechaEnvio;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.ComboBox cbbCliente;
        internal System.Windows.Forms.Label lblDireccion;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtFactura_ID;
        internal System.Windows.Forms.DateTimePicker dtpFechaFactura;
        internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.ErrorProvider erPrecio;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ErrorProvider erCantidad;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.RadioButton rbContado;
    }
}