namespace SMA
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnClientes = new DevComponents.DotNetBar.ButtonItem();
            this.btnOperacionesVenta = new DevComponents.DotNetBar.ButtonItem();
            this.btnFacturacion = new DevComponents.DotNetBar.ButtonItem();
            this.btnCotizacion = new DevComponents.DotNetBar.ButtonItem();
            this.btnDevolucionVentas = new DevComponents.DotNetBar.ButtonItem();
            this.btnInventario = new DevComponents.DotNetBar.ButtonItem();
            this.btnProveedores = new DevComponents.DotNetBar.ButtonItem();
            this.btnCompras = new DevComponents.DotNetBar.ButtonItem();
            this.btnOrden = new DevComponents.DotNetBar.ButtonItem();
            this.btnRecepcion = new DevComponents.DotNetBar.ButtonItem();
            this.btnDevolucionCompras = new DevComponents.DotNetBar.ButtonItem();
            this.btnHerramientas = new DevComponents.DotNetBar.ButtonItem();
            this.btnFamilia = new DevComponents.DotNetBar.ButtonItem();
            this.btnMarcas = new DevComponents.DotNetBar.ButtonItem();
            this.btnEmpresa = new DevComponents.DotNetBar.ButtonItem();
            this.btnVendedores = new DevComponents.DotNetBar.ButtonItem();
            this.btnUsuarios = new DevComponents.DotNetBar.ButtonItem();
            this.btnSalir = new DevComponents.DotNetBar.ButtonItem();
            this.rbtPrincipal = new DevComponents.DotNetBar.RibbonTabItem();
            this.cbAlmacenes = new DevComponents.Editors.ComboItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSeparador = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSeparador2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.Class = "";
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbtPrincipal});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.Size = new System.Drawing.Size(797, 156);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 4;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 56);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(797, 98);
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
            this.btnClientes,
            this.btnOperacionesVenta,
            this.btnInventario,
            this.btnProveedores,
            this.btnCompras,
            this.btnHerramientas,
            this.btnSalir});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(473, 95);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
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
            // btnClientes
            // 
            this.btnClientes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.SubItemsExpandWidth = 14;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnOperacionesVenta
            // 
            this.btnOperacionesVenta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnOperacionesVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnOperacionesVenta.Image")));
            this.btnOperacionesVenta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnOperacionesVenta.Name = "btnOperacionesVenta";
            this.btnOperacionesVenta.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnFacturacion,
            this.btnCotizacion,
            this.btnDevolucionVentas});
            this.btnOperacionesVenta.SubItemsExpandWidth = 14;
            this.btnOperacionesVenta.Text = "Ventas";
            this.btnOperacionesVenta.Click += new System.EventHandler(this.btnFacturas_Click);
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturacion.Image")));
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Text = "Facturacion";
            this.btnFacturacion.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // btnCotizacion
            // 
            this.btnCotizacion.Image = ((System.Drawing.Image)(resources.GetObject("btnCotizacion.Image")));
            this.btnCotizacion.Name = "btnCotizacion";
            this.btnCotizacion.Text = "Cotizacion";
            this.btnCotizacion.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // btnDevolucionVentas
            // 
            this.btnDevolucionVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolucionVentas.Image")));
            this.btnDevolucionVentas.Name = "btnDevolucionVentas";
            this.btnDevolucionVentas.Text = "Devolucion";
            this.btnDevolucionVentas.Click += new System.EventHandler(this.btnDevolucionVentas_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnInventario.Image")));
            this.btnInventario.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.SubItemsExpandWidth = 14;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedores.Image")));
            this.btnProveedores.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.SubItemsExpandWidth = 14;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnCompras.Image")));
            this.btnCompras.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOrden,
            this.btnRecepcion,
            this.btnDevolucionCompras});
            this.btnCompras.SubItemsExpandWidth = 14;
            this.btnCompras.Text = "Compras";
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnOrden
            // 
            this.btnOrden.Image = ((System.Drawing.Image)(resources.GetObject("btnOrden.Image")));
            this.btnOrden.Name = "btnOrden";
            this.btnOrden.Text = "Orden";
            this.btnOrden.Click += new System.EventHandler(this.btnOrden_Click);
            // 
            // btnRecepcion
            // 
            this.btnRecepcion.Image = ((System.Drawing.Image)(resources.GetObject("btnRecepcion.Image")));
            this.btnRecepcion.Name = "btnRecepcion";
            this.btnRecepcion.Text = "Recepcion";
            this.btnRecepcion.Click += new System.EventHandler(this.btnRecepcion_Click);
            // 
            // btnDevolucionCompras
            // 
            this.btnDevolucionCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolucionCompras.Image")));
            this.btnDevolucionCompras.Name = "btnDevolucionCompras";
            this.btnDevolucionCompras.Text = "Devolucion";
            this.btnDevolucionCompras.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // btnHerramientas
            // 
            this.btnHerramientas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHerramientas.Image = ((System.Drawing.Image)(resources.GetObject("btnHerramientas.Image")));
            this.btnHerramientas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHerramientas.Name = "btnHerramientas";
            this.btnHerramientas.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnFamilia,
            this.btnMarcas,
            this.btnEmpresa,
            this.btnVendedores,
            this.btnUsuarios});
            this.btnHerramientas.SubItemsExpandWidth = 14;
            this.btnHerramientas.Text = "Herramientas";
            this.btnHerramientas.Click += new System.EventHandler(this.buttonItem15_Click);
            // 
            // btnFamilia
            // 
            this.btnFamilia.Image = ((System.Drawing.Image)(resources.GetObject("btnFamilia.Image")));
            this.btnFamilia.Name = "btnFamilia";
            this.btnFamilia.Text = "Familias articulos";
            this.btnFamilia.Click += new System.EventHandler(this.btnFamilia_Click);
            // 
            // btnMarcas
            // 
            this.btnMarcas.Image = ((System.Drawing.Image)(resources.GetObject("btnMarcas.Image")));
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Text = "Marcas articulos";
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // btnEmpresa
            // 
            this.btnEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpresa.Image")));
            this.btnEmpresa.Name = "btnEmpresa";
            this.btnEmpresa.Text = "Empresa";
            this.btnEmpresa.Click += new System.EventHandler(this.btnEmpresa_Click);
            // 
            // btnVendedores
            // 
            this.btnVendedores.Image = ((System.Drawing.Image)(resources.GetObject("btnVendedores.Image")));
            this.btnVendedores.Name = "btnVendedores";
            this.btnVendedores.Text = "Vendedores";
            this.btnVendedores.Click += new System.EventHandler(this.btnVendedores_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.SubItemsExpandWidth = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.buttonItem16_Click);
            // 
            // rbtPrincipal
            // 
            this.rbtPrincipal.Checked = true;
            this.rbtPrincipal.Name = "rbtPrincipal";
            this.rbtPrincipal.Panel = this.ribbonPanel1;
            this.rbtPrincipal.Text = "Modulos";
            // 
            // cbAlmacenes
            // 
            this.cbAlmacenes.Image = ((System.Drawing.Image)(resources.GetObject("cbAlmacenes.Image")));
            this.cbAlmacenes.Text = "Almacenes";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssUsuario,
            this.tssSeparador,
            this.tssFecha,
            this.tssSeparador2,
            this.tssHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 378);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(797, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Usuario:";
            // 
            // tssUsuario
            // 
            this.tssUsuario.AutoSize = false;
            this.tssUsuario.BackColor = System.Drawing.Color.White;
            this.tssUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssUsuario.Name = "tssUsuario";
            this.tssUsuario.Size = new System.Drawing.Size(100, 17);
            // 
            // tssSeparador
            // 
            this.tssSeparador.Name = "tssSeparador";
            this.tssSeparador.Size = new System.Drawing.Size(97, 17);
            this.tssSeparador.Text = "------------------";
            // 
            // tssFecha
            // 
            this.tssFecha.BackColor = System.Drawing.Color.Transparent;
            this.tssFecha.Name = "tssFecha";
            this.tssFecha.Size = new System.Drawing.Size(0, 17);
            // 
            // tssSeparador2
            // 
            this.tssSeparador2.Name = "tssSeparador2";
            this.tssSeparador2.Size = new System.Drawing.Size(97, 17);
            this.tssSeparador2.Text = "------------------";
            // 
            // tssHora
            // 
            this.tssHora.Name = "tssHora";
            this.tssHora.Size = new System.Drawing.Size(0, 17);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(797, 400);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Text = "Sistema de Manejo Almacenes (SMA)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnInventario;
        private DevComponents.DotNetBar.ButtonItem btnHerramientas;
        private DevComponents.Editors.ComboItem cbAlmacenes;
        private DevComponents.DotNetBar.RibbonTabItem rbtPrincipal;
        private DevComponents.DotNetBar.ButtonItem btnFamilia;
        private DevComponents.DotNetBar.ButtonItem btnMarcas;
        private DevComponents.DotNetBar.ButtonItem btnSalir;
        private DevComponents.DotNetBar.ButtonItem btnOperacionesVenta;
        private DevComponents.DotNetBar.ButtonItem btnProveedores;
        private DevComponents.DotNetBar.ButtonItem btnCompras;
        private DevComponents.DotNetBar.ButtonItem btnClientes;
        private DevComponents.DotNetBar.ButtonItem btnEmpresa;
        private DevComponents.DotNetBar.ButtonItem btnVendedores;
        private DevComponents.DotNetBar.ButtonItem btnFacturacion;
        private DevComponents.DotNetBar.ButtonItem btnCotizacion;
        private DevComponents.DotNetBar.ButtonItem btnDevolucionVentas;
        private DevComponents.DotNetBar.ButtonItem btnRecepcion;
        private DevComponents.DotNetBar.ButtonItem btnOrden;
        private DevComponents.DotNetBar.ButtonItem btnDevolucionCompras;
        private DevComponents.DotNetBar.ButtonItem btnUsuarios;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssSeparador;
        private System.Windows.Forms.ToolStripStatusLabel tssFecha;
        private System.Windows.Forms.ToolStripStatusLabel tssSeparador2;
        private System.Windows.Forms.ToolStripStatusLabel tssHora;
    }
}

