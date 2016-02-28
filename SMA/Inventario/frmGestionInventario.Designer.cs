namespace SMA.Inventario
{
    partial class frmGestionInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionInventario));
            this.dgvInventario = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.btnEjecutarBusqueda = new DevComponents.DotNetBar.ButtonX();
            this.txtBusqueda = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.btnCambioPrecio = new DevComponents.DotNetBar.ButtonItem();
            this.btnKardex = new DevComponents.DotNetBar.ButtonItem();
            this.btnSalir = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonItem();
            this.btnFiltrar = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefrescar = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnNuevo = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditar = new DevComponents.DotNetBar.ButtonItem();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar4 = new DevComponents.DotNetBar.RibbonBar();
            this.btnReportes = new DevComponents.DotNetBar.ButtonItem();
            this.btnInventarioServicios = new DevComponents.DotNetBar.ButtonItem();
            this.btnCatalogo = new DevComponents.DotNetBar.ButtonItem();
            this.btnListaPrecios = new DevComponents.DotNetBar.ButtonItem();
            this.btnCostoInventario = new DevComponents.DotNetBar.ButtonItem();
            this.btnInventarioFisico = new DevComponents.DotNetBar.ButtonItem();
            this.btnProductosVencidos = new DevComponents.DotNetBar.ButtonItem();
            this.btnrptMovimientos = new DevComponents.DotNetBar.ButtonItem();
            this.btnMovInventario = new DevComponents.DotNetBar.ButtonItem();
            this.btnReporteKardex = new DevComponents.DotNetBar.ButtonItem();
            this.btnRotacionInventario = new DevComponents.DotNetBar.ButtonItem();
            this.btnVentasUtilidades = new DevComponents.DotNetBar.ButtonItem();
            this.btnVentasPorCliente = new DevComponents.DotNetBar.ButtonItem();
            this.btnComprasPorProveedor = new DevComponents.DotNetBar.ButtonItem();
            this.btnHistoricoExistencia = new DevComponents.DotNetBar.ButtonItem();
            this.btnProductoObsoletos = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem2 = new DevComponents.DotNetBar.RibbonTabItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cCodigo,
            this.cDescripcion,
            this.cTipoArticulo,
            this.cFamilia,
            this.cMarca,
            this.cExistencia,
            this.cPrecio});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventario.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvInventario.Location = new System.Drawing.Point(0, 162);
            this.dgvInventario.Name = "dgvInventario";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventario.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvInventario.Size = new System.Drawing.Size(1017, 317);
            this.dgvInventario.TabIndex = 4;
            this.dgvInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellClick);
            this.dgvInventario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellDoubleClick);
            this.dgvInventario.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_RowEnter_1);
            // 
            // cID
            // 
            this.cID.DataPropertyName = "ID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.Visible = false;
            // 
            // cCodigo
            // 
            this.cCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cCodigo.DataPropertyName = "CodigoArticulo";
            this.cCodigo.HeaderText = "Codigo";
            this.cCodigo.Name = "cCodigo";
            this.cCodigo.Width = 65;
            // 
            // cDescripcion
            // 
            this.cDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cDescripcion.DataPropertyName = "Descripcion";
            this.cDescripcion.HeaderText = "Descripcion";
            this.cDescripcion.Name = "cDescripcion";
            // 
            // cTipoArticulo
            // 
            this.cTipoArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cTipoArticulo.DataPropertyName = "TipoArticulo";
            dataGridViewCellStyle8.NullValue = null;
            this.cTipoArticulo.DefaultCellStyle = dataGridViewCellStyle8;
            this.cTipoArticulo.HeaderText = "Tipo articulo";
            this.cTipoArticulo.Name = "cTipoArticulo";
            this.cTipoArticulo.Width = 90;
            // 
            // cFamilia
            // 
            this.cFamilia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cFamilia.DataPropertyName = "FamiliaID";
            this.cFamilia.HeaderText = "Familia";
            this.cFamilia.Name = "cFamilia";
            this.cFamilia.Width = 64;
            // 
            // cMarca
            // 
            this.cMarca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cMarca.DataPropertyName = "MarcaID";
            this.cMarca.HeaderText = "Marca";
            this.cMarca.Name = "cMarca";
            this.cMarca.Width = 62;
            // 
            // cExistencia
            // 
            this.cExistencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cExistencia.DataPropertyName = "Existencia";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.cExistencia.DefaultCellStyle = dataGridViewCellStyle9;
            this.cExistencia.HeaderText = "Existencia";
            this.cExistencia.Name = "cExistencia";
            this.cExistencia.Width = 80;
            // 
            // cPrecio
            // 
            this.cPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cPrecio.DataPropertyName = "PrecioPublico";
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            this.cPrecio.DefaultCellStyle = dataGridViewCellStyle10;
            this.cPrecio.HeaderText = "Precio";
            this.cPrecio.Name = "cPrecio";
            this.cPrecio.Width = 62;
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.Class = "";
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel2);
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem1,
            this.ribbonTabItem2});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.Size = new System.Drawing.Size(1017, 162);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 5;
            this.ribbonControl1.Text = "ribbonControl1";
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.btnEjecutarBusqueda);
            this.ribbonPanel1.Controls.Add(this.txtBusqueda);
            this.ribbonPanel1.Controls.Add(this.ribbonBar3);
            this.ribbonPanel1.Controls.Add(this.ribbonBar2);
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 56);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(1017, 104);
            // 
            // 
            // 
            this.ribbonPanel1.Style.Class = "";
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.Class = "";
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.Class = "";
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            this.ribbonPanel1.Visible = false;
            // 
            // btnEjecutarBusqueda
            // 
            this.btnEjecutarBusqueda.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEjecutarBusqueda.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEjecutarBusqueda.Image = global::SMA.Properties.Resources.find_icon;
            this.btnEjecutarBusqueda.Location = new System.Drawing.Point(776, 31);
            this.btnEjecutarBusqueda.Name = "btnEjecutarBusqueda";
            this.btnEjecutarBusqueda.Size = new System.Drawing.Size(30, 30);
            this.btnEjecutarBusqueda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEjecutarBusqueda.TabIndex = 5;
            this.btnEjecutarBusqueda.Visible = false;
            this.btnEjecutarBusqueda.Click += new System.EventHandler(this.btnEjecutarBusqueda_Click);
            // 
            // txtBusqueda
            // 
            // 
            // 
            // 
            this.txtBusqueda.Border.Class = "TextBoxBorder";
            this.txtBusqueda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBusqueda.Location = new System.Drawing.Point(568, 36);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(202, 20);
            this.txtBusqueda.TabIndex = 3;
            this.txtBusqueda.Visible = false;
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundStyle.Class = "";
            this.ribbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ContainerControlProcessDialogKey = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCambioPrecio,
            this.btnKardex,
            this.btnSalir});
            this.ribbonBar3.Location = new System.Drawing.Point(378, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(184, 101);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar3.TabIndex = 2;
            this.ribbonBar3.Text = "Control";
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.Class = "";
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.Class = "";
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ItemClick += new System.EventHandler(this.ribbonBar3_ItemClick);
            // 
            // btnCambioPrecio
            // 
            this.btnCambioPrecio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCambioPrecio.Image = ((System.Drawing.Image)(resources.GetObject("btnCambioPrecio.Image")));
            this.btnCambioPrecio.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCambioPrecio.Name = "btnCambioPrecio";
            this.btnCambioPrecio.SubItemsExpandWidth = 14;
            this.btnCambioPrecio.Text = "Cambio de precio";
            this.btnCambioPrecio.Click += new System.EventHandler(this.btnCambioPrecio_Click);
            // 
            // btnKardex
            // 
            this.btnKardex.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnKardex.Image = ((System.Drawing.Image)(resources.GetObject("btnKardex.Image")));
            this.btnKardex.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnKardex.Name = "btnKardex";
            this.btnKardex.SubItemsExpandWidth = 14;
            this.btnKardex.Text = "Kardex";
            this.btnKardex.Click += new System.EventHandler(this.btnKardex_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.SubItemsExpandWidth = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.Class = "";
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnBuscar,
            this.btnFiltrar,
            this.btnRefrescar});
            this.ribbonBar2.Location = new System.Drawing.Point(196, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(182, 101);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 1;
            this.ribbonBar2.Text = "Busquedas y filtros";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.Class = "";
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.Class = "";
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.SubItemsExpandWidth = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.SubItemsExpandWidth = 14;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
            this.btnRefrescar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.SubItemsExpandWidth = 14;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.Class = "";
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(193, 101);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "Mantenimiento";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.Class = "";
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.Class = "";
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnNuevo
            // 
            this.btnNuevo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.SubItemsExpandWidth = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.SubItemsExpandWidth = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.SubItemsExpandWidth = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel2.Controls.Add(this.ribbonBar4);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 56);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(1017, 104);
            // 
            // 
            // 
            this.ribbonPanel2.Style.Class = "";
            this.ribbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseDown.Class = "";
            this.ribbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseOver.Class = "";
            this.ribbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel2.TabIndex = 2;
            // 
            // ribbonBar4
            // 
            this.ribbonBar4.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundStyle.Class = "";
            this.ribbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar4.ContainerControlProcessDialogKey = true;
            this.ribbonBar4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnReportes});
            this.ribbonBar4.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar4.Name = "ribbonBar4";
            this.ribbonBar4.Size = new System.Drawing.Size(84, 101);
            this.ribbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar4.TabIndex = 0;
            this.ribbonBar4.Text = "Reportes";
            // 
            // 
            // 
            this.ribbonBar4.TitleStyle.Class = "";
            this.ribbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyleMouseOver.Class = "";
            this.ribbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnReportes
            // 
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnInventarioServicios,
            this.btnrptMovimientos});
            this.btnReportes.SubItemsExpandWidth = 14;
            this.btnReportes.Text = "buttonItem2";
            // 
            // btnInventarioServicios
            // 
            this.btnInventarioServicios.Name = "btnInventarioServicios";
            this.btnInventarioServicios.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCatalogo,
            this.btnListaPrecios,
            this.btnCostoInventario,
            this.btnInventarioFisico,
            this.btnProductosVencidos});
            this.btnInventarioServicios.Text = "Inventarios y servicios";
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Text = "Catalogo de productos";
            this.btnCatalogo.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // btnListaPrecios
            // 
            this.btnListaPrecios.Name = "btnListaPrecios";
            this.btnListaPrecios.Text = "Lista de precios";
            this.btnListaPrecios.Click += new System.EventHandler(this.btnListaPrecios_Click);
            // 
            // btnCostoInventario
            // 
            this.btnCostoInventario.Name = "btnCostoInventario";
            this.btnCostoInventario.Text = "Costo inventario";
            this.btnCostoInventario.Click += new System.EventHandler(this.btnCostoInventario_Click);
            // 
            // btnInventarioFisico
            // 
            this.btnInventarioFisico.Name = "btnInventarioFisico";
            this.btnInventarioFisico.Text = "Inventario fisico";
            this.btnInventarioFisico.Click += new System.EventHandler(this.btnInventarioFisico_Click);
            // 
            // btnProductosVencidos
            // 
            this.btnProductosVencidos.Name = "btnProductosVencidos";
            this.btnProductosVencidos.Text = "Productos vencidos";
            this.btnProductosVencidos.Click += new System.EventHandler(this.btnProductosVencidos_Click);
            // 
            // btnrptMovimientos
            // 
            this.btnrptMovimientos.Name = "btnrptMovimientos";
            this.btnrptMovimientos.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnMovInventario,
            this.btnReporteKardex,
            this.btnRotacionInventario,
            this.btnVentasUtilidades,
            this.btnVentasPorCliente,
            this.btnComprasPorProveedor,
            this.btnHistoricoExistencia,
            this.btnProductoObsoletos});
            this.btnrptMovimientos.Text = "Movimientos";
            // 
            // btnMovInventario
            // 
            this.btnMovInventario.Name = "btnMovInventario";
            this.btnMovInventario.Text = "Movimientos inventarios";
            this.btnMovInventario.Click += new System.EventHandler(this.btnMovInventario_Click);
            // 
            // btnReporteKardex
            // 
            this.btnReporteKardex.Name = "btnReporteKardex";
            this.btnReporteKardex.Text = "Kárdex";
            this.btnReporteKardex.Click += new System.EventHandler(this.btnReporteKardex_Click);
            // 
            // btnRotacionInventario
            // 
            this.btnRotacionInventario.Name = "btnRotacionInventario";
            this.btnRotacionInventario.Text = "Rotacion inventario";
            this.btnRotacionInventario.Click += new System.EventHandler(this.btnRotacionInventario_Click);
            // 
            // btnVentasUtilidades
            // 
            this.btnVentasUtilidades.Name = "btnVentasUtilidades";
            this.btnVentasUtilidades.Text = "Ventas y Utilidades";
            this.btnVentasUtilidades.Click += new System.EventHandler(this.btnVentasUtilidades_Click);
            // 
            // btnVentasPorCliente
            // 
            this.btnVentasPorCliente.Name = "btnVentasPorCliente";
            this.btnVentasPorCliente.Text = "Ventas por cliente";
            this.btnVentasPorCliente.Click += new System.EventHandler(this.btnVentasPorCliente_Click);
            // 
            // btnComprasPorProveedor
            // 
            this.btnComprasPorProveedor.Name = "btnComprasPorProveedor";
            this.btnComprasPorProveedor.Text = "Compras por proveedor";
            this.btnComprasPorProveedor.Click += new System.EventHandler(this.btnComprasPorProveedor_Click);
            // 
            // btnHistoricoExistencia
            // 
            this.btnHistoricoExistencia.Name = "btnHistoricoExistencia";
            this.btnHistoricoExistencia.Text = "Historico de existencias";
            this.btnHistoricoExistencia.Click += new System.EventHandler(this.btnHistoricoExistencia_Click);
            // 
            // btnProductoObsoletos
            // 
            this.btnProductoObsoletos.Name = "btnProductoObsoletos";
            this.btnProductoObsoletos.Text = "Productos Obsoletos";
            this.btnProductoObsoletos.Click += new System.EventHandler(this.btnProductoObsoletos_Click);
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "Acciones";
            // 
            // ribbonTabItem2
            // 
            this.ribbonTabItem2.Checked = true;
            this.ribbonTabItem2.Name = "ribbonTabItem2";
            this.ribbonTabItem2.Panel = this.ribbonPanel2;
            this.ribbonTabItem2.Text = "Reportes";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1017, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmGestionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 501);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(814, 501);
            this.Name = "frmGestionInventario";
            this.Text = "Gestion inventario";
            this.Load += new System.EventHandler(this.frmGestionInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.ribbonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvInventario;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.ButtonItem btnKardex;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem btnBuscar;
        private DevComponents.DotNetBar.ButtonItem btnFiltrar;
        private DevComponents.DotNetBar.ButtonItem btnRefrescar;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnNuevo;
        private DevComponents.DotNetBar.ButtonItem btnEditar;
        private DevComponents.DotNetBar.ButtonItem btnEliminar;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonItem btnCambioPrecio;
        private DevComponents.DotNetBar.ButtonItem btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrecio;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevComponents.DotNetBar.ButtonX btnEjecutarBusqueda;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBusqueda;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar4;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem2;
        private DevComponents.DotNetBar.ButtonItem btnReportes;
        private DevComponents.DotNetBar.ButtonItem btnInventarioServicios;
        private DevComponents.DotNetBar.ButtonItem btnCatalogo;
        private DevComponents.DotNetBar.ButtonItem btnListaPrecios;
        private DevComponents.DotNetBar.ButtonItem btnCostoInventario;
        private DevComponents.DotNetBar.ButtonItem btnInventarioFisico;
        private DevComponents.DotNetBar.ButtonItem btnrptMovimientos;
        private DevComponents.DotNetBar.ButtonItem btnMovInventario;
        private DevComponents.DotNetBar.ButtonItem btnReporteKardex;
        private DevComponents.DotNetBar.ButtonItem btnRotacionInventario;
        private DevComponents.DotNetBar.ButtonItem btnVentasUtilidades;
        private DevComponents.DotNetBar.ButtonItem btnVentasPorCliente;
        private DevComponents.DotNetBar.ButtonItem btnComprasPorProveedor;
        private DevComponents.DotNetBar.ButtonItem btnHistoricoExistencia;
        private DevComponents.DotNetBar.ButtonItem btnProductoObsoletos;
        private DevComponents.DotNetBar.ButtonItem btnProductosVencidos;
    }
}