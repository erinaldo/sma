namespace SMA.Inventario
{
    partial class frmCambioPrecioInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioPrecioInventario));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.gbTipoArticulo = new System.Windows.Forms.GroupBox();
            this.ckbCombos = new System.Windows.Forms.CheckBox();
            this.ckbServicios = new System.Windows.Forms.CheckBox();
            this.ckbFisico = new System.Windows.Forms.CheckBox();
            this.gpbPorcentajeMonto = new System.Windows.Forms.GroupBox();
            this.txtPorcentajeMonto = new System.Windows.Forms.TextBox();
            this.rdbMonto = new System.Windows.Forms.RadioButton();
            this.rdbPorcentaje = new System.Windows.Forms.RadioButton();
            this.gpbFechaVenta = new System.Windows.Forms.GroupBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHastaFecha = new System.Windows.Forms.Label();
            this.lblDesdeFecha = new System.Windows.Forms.Label();
            this.gbPrecios = new System.Windows.Forms.GroupBox();
            this.ckbPrecio4 = new System.Windows.Forms.CheckBox();
            this.ckbPrecio3 = new System.Windows.Forms.CheckBox();
            this.ckbPrecio2 = new System.Windows.Forms.CheckBox();
            this.ckbPrecio1 = new System.Windows.Forms.CheckBox();
            this.gpbApartirDelCosto = new System.Windows.Forms.GroupBox();
            this.rdbCostoPromedio = new System.Windows.Forms.RadioButton();
            this.rdbUltimoCosto = new System.Windows.Forms.RadioButton();
            this.ckbPrecioPartirCosto = new System.Windows.Forms.CheckBox();
            this.gpbLineaInventario = new System.Windows.Forms.GroupBox();
            this.btnSeleccionLinea = new System.Windows.Forms.Button();
            this.cbFamilia = new System.Windows.Forms.ComboBox();
            this.gpbRangoArticulo = new System.Windows.Forms.GroupBox();
            this.cbbArticuloHasta = new System.Windows.Forms.ComboBox();
            this.cbbArticuloDesde = new System.Windows.Forms.ComboBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnSeleccionar = new DevComponents.DotNetBar.ButtonX();
            this.gbTipoArticulo.SuspendLayout();
            this.gpbPorcentajeMonto.SuspendLayout();
            this.gpbFechaVenta.SuspendLayout();
            this.gbPrecios.SuspendLayout();
            this.gpbApartirDelCosto.SuspendLayout();
            this.gpbLineaInventario.SuspendLayout();
            this.gpbRangoArticulo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // gbTipoArticulo
            // 
            this.gbTipoArticulo.Controls.Add(this.ckbCombos);
            this.gbTipoArticulo.Controls.Add(this.ckbServicios);
            this.gbTipoArticulo.Controls.Add(this.ckbFisico);
            this.gbTipoArticulo.Location = new System.Drawing.Point(12, 103);
            this.gbTipoArticulo.Margin = new System.Windows.Forms.Padding(4);
            this.gbTipoArticulo.Name = "gbTipoArticulo";
            this.gbTipoArticulo.Padding = new System.Windows.Forms.Padding(4);
            this.gbTipoArticulo.Size = new System.Drawing.Size(446, 45);
            this.gbTipoArticulo.TabIndex = 35;
            this.gbTipoArticulo.TabStop = false;
            this.gbTipoArticulo.Text = "Tipo Articulo";
            // 
            // ckbCombos
            // 
            this.ckbCombos.AutoSize = true;
            this.ckbCombos.Location = new System.Drawing.Point(372, 20);
            this.ckbCombos.Name = "ckbCombos";
            this.ckbCombos.Size = new System.Drawing.Size(64, 17);
            this.ckbCombos.TabIndex = 3;
            this.ckbCombos.Text = "Combos";
            this.ckbCombos.UseVisualStyleBackColor = true;
            // 
            // ckbServicios
            // 
            this.ckbServicios.AutoSize = true;
            this.ckbServicios.Location = new System.Drawing.Point(194, 20);
            this.ckbServicios.Name = "ckbServicios";
            this.ckbServicios.Size = new System.Drawing.Size(69, 17);
            this.ckbServicios.TabIndex = 2;
            this.ckbServicios.Text = "Servicios";
            this.ckbServicios.UseVisualStyleBackColor = true;
            // 
            // ckbFisico
            // 
            this.ckbFisico.AutoSize = true;
            this.ckbFisico.Location = new System.Drawing.Point(16, 20);
            this.ckbFisico.Name = "ckbFisico";
            this.ckbFisico.Size = new System.Drawing.Size(74, 17);
            this.ckbFisico.TabIndex = 1;
            this.ckbFisico.Text = "Productos";
            this.ckbFisico.UseVisualStyleBackColor = true;
            // 
            // gpbPorcentajeMonto
            // 
            this.gpbPorcentajeMonto.Controls.Add(this.txtPorcentajeMonto);
            this.gpbPorcentajeMonto.Controls.Add(this.rdbMonto);
            this.gpbPorcentajeMonto.Controls.Add(this.rdbPorcentaje);
            this.gpbPorcentajeMonto.Location = new System.Drawing.Point(12, 374);
            this.gpbPorcentajeMonto.Name = "gpbPorcentajeMonto";
            this.gpbPorcentajeMonto.Size = new System.Drawing.Size(174, 66);
            this.gpbPorcentajeMonto.TabIndex = 31;
            this.gpbPorcentajeMonto.TabStop = false;
            // 
            // txtPorcentajeMonto
            // 
            this.txtPorcentajeMonto.Location = new System.Drawing.Point(10, 39);
            this.txtPorcentajeMonto.Name = "txtPorcentajeMonto";
            this.txtPorcentajeMonto.Size = new System.Drawing.Size(137, 20);
            this.txtPorcentajeMonto.TabIndex = 2;
            // 
            // rdbMonto
            // 
            this.rdbMonto.AutoSize = true;
            this.rdbMonto.Location = new System.Drawing.Point(92, 16);
            this.rdbMonto.Name = "rdbMonto";
            this.rdbMonto.Size = new System.Drawing.Size(55, 17);
            this.rdbMonto.TabIndex = 1;
            this.rdbMonto.TabStop = true;
            this.rdbMonto.Text = "Monto";
            this.rdbMonto.UseVisualStyleBackColor = true;
            // 
            // rdbPorcentaje
            // 
            this.rdbPorcentaje.AutoSize = true;
            this.rdbPorcentaje.Location = new System.Drawing.Point(11, 16);
            this.rdbPorcentaje.Name = "rdbPorcentaje";
            this.rdbPorcentaje.Size = new System.Drawing.Size(76, 17);
            this.rdbPorcentaje.TabIndex = 0;
            this.rdbPorcentaje.TabStop = true;
            this.rdbPorcentaje.Text = "Procentaje";
            this.rdbPorcentaje.UseVisualStyleBackColor = true;
            // 
            // gpbFechaVenta
            // 
            this.gpbFechaVenta.Controls.Add(this.dtpHasta);
            this.gpbFechaVenta.Controls.Add(this.dtpDesde);
            this.gpbFechaVenta.Controls.Add(this.lblHastaFecha);
            this.gpbFechaVenta.Controls.Add(this.lblDesdeFecha);
            this.gpbFechaVenta.Location = new System.Drawing.Point(287, 155);
            this.gpbFechaVenta.Name = "gpbFechaVenta";
            this.gpbFechaVenta.Size = new System.Drawing.Size(171, 74);
            this.gpbFechaVenta.TabIndex = 30;
            this.gpbFechaVenta.TabStop = false;
            this.gpbFechaVenta.Text = "Fecha Venta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(52, 46);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(98, 20);
            this.dtpHasta.TabIndex = 3;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(52, 18);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(98, 20);
            this.dtpDesde.TabIndex = 2;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // lblHastaFecha
            // 
            this.lblHastaFecha.AutoSize = true;
            this.lblHastaFecha.Location = new System.Drawing.Point(8, 50);
            this.lblHastaFecha.Name = "lblHastaFecha";
            this.lblHastaFecha.Size = new System.Drawing.Size(38, 13);
            this.lblHastaFecha.TabIndex = 1;
            this.lblHastaFecha.Text = "Hasta:";
            // 
            // lblDesdeFecha
            // 
            this.lblDesdeFecha.AutoSize = true;
            this.lblDesdeFecha.Location = new System.Drawing.Point(8, 22);
            this.lblDesdeFecha.Name = "lblDesdeFecha";
            this.lblDesdeFecha.Size = new System.Drawing.Size(41, 13);
            this.lblDesdeFecha.TabIndex = 0;
            this.lblDesdeFecha.Text = "Desde:";
            // 
            // gbPrecios
            // 
            this.gbPrecios.Controls.Add(this.ckbPrecio4);
            this.gbPrecios.Controls.Add(this.ckbPrecio3);
            this.gbPrecios.Controls.Add(this.ckbPrecio2);
            this.gbPrecios.Controls.Add(this.ckbPrecio1);
            this.gbPrecios.Location = new System.Drawing.Point(11, 325);
            this.gbPrecios.Name = "gbPrecios";
            this.gbPrecios.Size = new System.Drawing.Size(447, 43);
            this.gbPrecios.TabIndex = 29;
            this.gbPrecios.TabStop = false;
            this.gbPrecios.Text = "Precios";
            // 
            // ckbPrecio4
            // 
            this.ckbPrecio4.AutoSize = true;
            this.ckbPrecio4.Location = new System.Drawing.Point(359, 19);
            this.ckbPrecio4.Name = "ckbPrecio4";
            this.ckbPrecio4.Size = new System.Drawing.Size(65, 17);
            this.ckbPrecio4.TabIndex = 3;
            this.ckbPrecio4.Text = "Precio 4";
            this.ckbPrecio4.UseVisualStyleBackColor = true;
            // 
            // ckbPrecio3
            // 
            this.ckbPrecio3.AutoSize = true;
            this.ckbPrecio3.Location = new System.Drawing.Point(243, 19);
            this.ckbPrecio3.Name = "ckbPrecio3";
            this.ckbPrecio3.Size = new System.Drawing.Size(65, 17);
            this.ckbPrecio3.TabIndex = 2;
            this.ckbPrecio3.Text = "Precio 3";
            this.ckbPrecio3.UseVisualStyleBackColor = true;
            // 
            // ckbPrecio2
            // 
            this.ckbPrecio2.AutoSize = true;
            this.ckbPrecio2.Location = new System.Drawing.Point(127, 19);
            this.ckbPrecio2.Name = "ckbPrecio2";
            this.ckbPrecio2.Size = new System.Drawing.Size(65, 17);
            this.ckbPrecio2.TabIndex = 1;
            this.ckbPrecio2.Text = "Precio 2";
            this.ckbPrecio2.UseVisualStyleBackColor = true;
            // 
            // ckbPrecio1
            // 
            this.ckbPrecio1.AutoSize = true;
            this.ckbPrecio1.Location = new System.Drawing.Point(11, 19);
            this.ckbPrecio1.Name = "ckbPrecio1";
            this.ckbPrecio1.Size = new System.Drawing.Size(65, 17);
            this.ckbPrecio1.TabIndex = 0;
            this.ckbPrecio1.Text = "Precio 1";
            this.ckbPrecio1.UseVisualStyleBackColor = true;
            // 
            // gpbApartirDelCosto
            // 
            this.gpbApartirDelCosto.Controls.Add(this.rdbCostoPromedio);
            this.gpbApartirDelCosto.Controls.Add(this.rdbUltimoCosto);
            this.gpbApartirDelCosto.Controls.Add(this.ckbPrecioPartirCosto);
            this.gpbApartirDelCosto.Location = new System.Drawing.Point(287, 235);
            this.gpbApartirDelCosto.Name = "gpbApartirDelCosto";
            this.gpbApartirDelCosto.Size = new System.Drawing.Size(171, 84);
            this.gpbApartirDelCosto.TabIndex = 28;
            this.gpbApartirDelCosto.TabStop = false;
            // 
            // rdbCostoPromedio
            // 
            this.rdbCostoPromedio.AutoSize = true;
            this.rdbCostoPromedio.Enabled = false;
            this.rdbCostoPromedio.Location = new System.Drawing.Point(16, 40);
            this.rdbCostoPromedio.Name = "rdbCostoPromedio";
            this.rdbCostoPromedio.Size = new System.Drawing.Size(98, 17);
            this.rdbCostoPromedio.TabIndex = 2;
            this.rdbCostoPromedio.TabStop = true;
            this.rdbCostoPromedio.Text = "Costo promedio";
            this.rdbCostoPromedio.UseVisualStyleBackColor = true;
            // 
            // rdbUltimoCosto
            // 
            this.rdbUltimoCosto.AutoSize = true;
            this.rdbUltimoCosto.Enabled = false;
            this.rdbUltimoCosto.Location = new System.Drawing.Point(16, 62);
            this.rdbUltimoCosto.Name = "rdbUltimoCosto";
            this.rdbUltimoCosto.Size = new System.Drawing.Size(83, 17);
            this.rdbUltimoCosto.TabIndex = 1;
            this.rdbUltimoCosto.TabStop = true;
            this.rdbUltimoCosto.Text = "Ultimo costo";
            this.rdbUltimoCosto.UseVisualStyleBackColor = true;
            // 
            // ckbPrecioPartirCosto
            // 
            this.ckbPrecioPartirCosto.AutoSize = true;
            this.ckbPrecioPartirCosto.Location = new System.Drawing.Point(16, 18);
            this.ckbPrecioPartirCosto.Name = "ckbPrecioPartirCosto";
            this.ckbPrecioPartirCosto.Size = new System.Drawing.Size(137, 17);
            this.ckbPrecioPartirCosto.TabIndex = 0;
            this.ckbPrecioPartirCosto.Text = "Precio a partir del costo";
            this.ckbPrecioPartirCosto.UseVisualStyleBackColor = true;
            this.ckbPrecioPartirCosto.CheckedChanged += new System.EventHandler(this.ckbPrecioPartirCosto_CheckedChanged);
            // 
            // gpbLineaInventario
            // 
            this.gpbLineaInventario.Controls.Add(this.btnSeleccionLinea);
            this.gpbLineaInventario.Controls.Add(this.cbFamilia);
            this.gpbLineaInventario.Location = new System.Drawing.Point(12, 169);
            this.gpbLineaInventario.Name = "gpbLineaInventario";
            this.gpbLineaInventario.Size = new System.Drawing.Size(269, 66);
            this.gpbLineaInventario.TabIndex = 27;
            this.gpbLineaInventario.TabStop = false;
            this.gpbLineaInventario.Text = "Familia";
            // 
            // btnSeleccionLinea
            // 
            this.btnSeleccionLinea.Image = global::SMA.Properties.Resources.find_icon;
            this.btnSeleccionLinea.Location = new System.Drawing.Point(234, 24);
            this.btnSeleccionLinea.Name = "btnSeleccionLinea";
            this.btnSeleccionLinea.Size = new System.Drawing.Size(26, 24);
            this.btnSeleccionLinea.TabIndex = 67;
            this.btnSeleccionLinea.UseVisualStyleBackColor = true;
            this.btnSeleccionLinea.Click += new System.EventHandler(this.btnSeleccionLinea_Click);
            // 
            // cbFamilia
            // 
            this.cbFamilia.DisplayMember = "DESCRIPCION";
            this.cbFamilia.FormattingEnabled = true;
            this.cbFamilia.Location = new System.Drawing.Point(7, 27);
            this.cbFamilia.Name = "cbFamilia";
            this.cbFamilia.Size = new System.Drawing.Size(221, 21);
            this.cbFamilia.TabIndex = 66;
            this.cbFamilia.ValueMember = "LINEA_ID";
            // 
            // gpbRangoArticulo
            // 
            this.gpbRangoArticulo.Controls.Add(this.cbbArticuloHasta);
            this.gpbRangoArticulo.Controls.Add(this.cbbArticuloDesde);
            this.gpbRangoArticulo.Controls.Add(this.Button1);
            this.gpbRangoArticulo.Controls.Add(this.Button3);
            this.gpbRangoArticulo.Controls.Add(this.lblHasta);
            this.gpbRangoArticulo.Controls.Add(this.lblDesde);
            this.gpbRangoArticulo.Location = new System.Drawing.Point(12, 12);
            this.gpbRangoArticulo.Name = "gpbRangoArticulo";
            this.gpbRangoArticulo.Size = new System.Drawing.Size(447, 84);
            this.gpbRangoArticulo.TabIndex = 26;
            this.gpbRangoArticulo.TabStop = false;
            // 
            // cbbArticuloHasta
            // 
            this.cbbArticuloHasta.DisplayMember = "DESCRIPCION";
            this.cbbArticuloHasta.FormattingEnabled = true;
            this.cbbArticuloHasta.Location = new System.Drawing.Point(50, 51);
            this.cbbArticuloHasta.Name = "cbbArticuloHasta";
            this.cbbArticuloHasta.Size = new System.Drawing.Size(359, 21);
            this.cbbArticuloHasta.TabIndex = 68;
            this.cbbArticuloHasta.ValueMember = "LINEA_ID";
            // 
            // cbbArticuloDesde
            // 
            this.cbbArticuloDesde.DisplayMember = "DESCRIPCION";
            this.cbbArticuloDesde.FormattingEnabled = true;
            this.cbbArticuloDesde.Location = new System.Drawing.Point(50, 24);
            this.cbbArticuloDesde.Name = "cbbArticuloDesde";
            this.cbbArticuloDesde.Size = new System.Drawing.Size(359, 21);
            this.cbbArticuloDesde.TabIndex = 67;
            this.cbbArticuloDesde.ValueMember = "LINEA_ID";
            // 
            // Button1
            // 
            this.Button1.Image = ((System.Drawing.Image)(resources.GetObject("Button1.Image")));
            this.Button1.Location = new System.Drawing.Point(415, 48);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(26, 24);
            this.Button1.TabIndex = 63;
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button3
            // 
            this.Button3.Image = ((System.Drawing.Image)(resources.GetObject("Button3.Image")));
            this.Button3.Location = new System.Drawing.Point(415, 21);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(26, 24);
            this.Button3.TabIndex = 62;
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(6, 54);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 1;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(6, 27);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cbMarca);
            this.groupBox1.Location = new System.Drawing.Point(12, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 66);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Marca";
            // 
            // button2
            // 
            this.button2.Image = global::SMA.Properties.Resources.find_icon;
            this.button2.Location = new System.Drawing.Point(234, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 24);
            this.button2.TabIndex = 67;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbMarca
            // 
            this.cbMarca.DisplayMember = "DESCRIPCION";
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(10, 27);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(218, 21);
            this.cbMarca.TabIndex = 66;
            this.cbMarca.ValueMember = "LINEA_ID";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(351, 391);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSeleccionar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.Image")));
            this.btnSeleccionar.Location = new System.Drawing.Point(238, 391);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(107, 42);
            this.btnSeleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSeleccionar.TabIndex = 37;
            this.btnSeleccionar.Text = "Aplicar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // frmCambioPrecioInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 452);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbTipoArticulo);
            this.Controls.Add(this.gpbPorcentajeMonto);
            this.Controls.Add(this.gpbFechaVenta);
            this.Controls.Add(this.gbPrecios);
            this.Controls.Add(this.gpbApartirDelCosto);
            this.Controls.Add(this.gpbLineaInventario);
            this.Controls.Add(this.gpbRangoArticulo);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioPrecioInventario";
            this.Text = "Cambio de precio";
            this.Load += new System.EventHandler(this.frmCambioPrecioInventario_Load);
            this.gbTipoArticulo.ResumeLayout(false);
            this.gbTipoArticulo.PerformLayout();
            this.gpbPorcentajeMonto.ResumeLayout(false);
            this.gpbPorcentajeMonto.PerformLayout();
            this.gpbFechaVenta.ResumeLayout(false);
            this.gpbFechaVenta.PerformLayout();
            this.gbPrecios.ResumeLayout(false);
            this.gbPrecios.PerformLayout();
            this.gpbApartirDelCosto.ResumeLayout(false);
            this.gpbApartirDelCosto.PerformLayout();
            this.gpbLineaInventario.ResumeLayout(false);
            this.gpbRangoArticulo.ResumeLayout(false);
            this.gpbRangoArticulo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        internal System.Windows.Forms.GroupBox gbTipoArticulo;
        internal System.Windows.Forms.CheckBox ckbCombos;
        internal System.Windows.Forms.CheckBox ckbServicios;
        internal System.Windows.Forms.CheckBox ckbFisico;
        internal System.Windows.Forms.GroupBox gpbPorcentajeMonto;
        internal System.Windows.Forms.TextBox txtPorcentajeMonto;
        internal System.Windows.Forms.RadioButton rdbMonto;
        internal System.Windows.Forms.RadioButton rdbPorcentaje;
        internal System.Windows.Forms.GroupBox gpbFechaVenta;
        internal System.Windows.Forms.DateTimePicker dtpHasta;
        internal System.Windows.Forms.DateTimePicker dtpDesde;
        internal System.Windows.Forms.Label lblHastaFecha;
        internal System.Windows.Forms.Label lblDesdeFecha;
        internal System.Windows.Forms.GroupBox gbPrecios;
        internal System.Windows.Forms.CheckBox ckbPrecio4;
        internal System.Windows.Forms.CheckBox ckbPrecio3;
        internal System.Windows.Forms.CheckBox ckbPrecio2;
        internal System.Windows.Forms.CheckBox ckbPrecio1;
        internal System.Windows.Forms.GroupBox gpbApartirDelCosto;
        internal System.Windows.Forms.RadioButton rdbCostoPromedio;
        internal System.Windows.Forms.RadioButton rdbUltimoCosto;
        internal System.Windows.Forms.CheckBox ckbPrecioPartirCosto;
        internal System.Windows.Forms.GroupBox gpbLineaInventario;
        internal System.Windows.Forms.Button btnSeleccionLinea;
        internal System.Windows.Forms.ComboBox cbFamilia;
        internal System.Windows.Forms.GroupBox gpbRangoArticulo;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Label lblHasta;
        internal System.Windows.Forms.Label lblDesde;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.ComboBox cbMarca;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnSeleccionar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.ComboBox cbbArticuloHasta;
        internal System.Windows.Forms.ComboBox cbbArticuloDesde;
    }
}