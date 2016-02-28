namespace SMA.Inventario.Movimientos_Inventario
{
    partial class frmBuscarMovimientoInventario
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
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.cbbClienteProveedor = new System.Windows.Forms.ComboBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cbbCriterio = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbOtros = new System.Windows.Forms.CheckBox();
            this.lbTipoMovimiento = new System.Windows.Forms.ListBox();
            this.ckbCompras = new System.Windows.Forms.CheckBox();
            this.ckbVentas = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.GroupBox4.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.cbbClienteProveedor);
            this.GroupBox4.Controls.Add(this.txtDocumento);
            this.GroupBox4.Controls.Add(this.Label6);
            this.GroupBox4.Controls.Add(this.Label5);
            this.GroupBox4.Location = new System.Drawing.Point(13, 180);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(419, 76);
            this.GroupBox4.TabIndex = 19;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Referencias";
            // 
            // cbbClienteProveedor
            // 
            this.cbbClienteProveedor.DisplayMember = "Empresa";
            this.cbbClienteProveedor.FormattingEnabled = true;
            this.cbbClienteProveedor.Location = new System.Drawing.Point(114, 43);
            this.cbbClienteProveedor.Name = "cbbClienteProveedor";
            this.cbbClienteProveedor.Size = new System.Drawing.Size(291, 21);
            this.cbbClienteProveedor.TabIndex = 3;
            this.cbbClienteProveedor.ValueMember = "Codigo";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(114, 17);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(116, 20);
            this.txtDocumento.TabIndex = 2;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(6, 46);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(102, 13);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Cliente / Proveedor:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 18);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(65, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Documento:";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Controls.Add(this.cbbCriterio);
            this.GroupBox3.Controls.Add(this.txtCantidad);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Location = new System.Drawing.Point(258, 13);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(174, 73);
            this.GroupBox3.TabIndex = 18;
            this.GroupBox3.TabStop = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 19);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(42, 13);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Criterio:";
            // 
            // cbbCriterio
            // 
            this.cbbCriterio.FormattingEnabled = true;
            this.cbbCriterio.Items.AddRange(new object[] {
            "Igual",
            "Mayor",
            "Menor"});
            this.cbbCriterio.Location = new System.Drawing.Point(64, 16);
            this.cbbCriterio.Name = "cbbCriterio";
            this.cbbCriterio.Size = new System.Drawing.Size(93, 21);
            this.cbbCriterio.TabIndex = 2;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(64, 46);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(93, 20);
            this.txtCantidad.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 49);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 13);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Cantidad:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.dtpHasta);
            this.GroupBox2.Controls.Add(this.dtpDesde);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Location = new System.Drawing.Point(260, 92);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(172, 82);
            this.GroupBox2.TabIndex = 17;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Fechas";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(53, 52);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(102, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(53, 24);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(102, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 54);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(38, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Hasta:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Desde:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ckbOtros);
            this.GroupBox1.Controls.Add(this.lbTipoMovimiento);
            this.GroupBox1.Controls.Add(this.ckbCompras);
            this.GroupBox1.Controls.Add(this.ckbVentas);
            this.GroupBox1.Location = new System.Drawing.Point(13, 13);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(238, 161);
            this.GroupBox1.TabIndex = 16;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Tipo Movimiento";
            // 
            // ckbOtros
            // 
            this.ckbOtros.AutoSize = true;
            this.ckbOtros.Location = new System.Drawing.Point(164, 45);
            this.ckbOtros.Margin = new System.Windows.Forms.Padding(4);
            this.ckbOtros.Name = "ckbOtros";
            this.ckbOtros.Size = new System.Drawing.Size(51, 17);
            this.ckbOtros.TabIndex = 4;
            this.ckbOtros.Text = "Otros";
            this.ckbOtros.UseVisualStyleBackColor = true;
            // 
            // lbTipoMovimiento
            // 
            this.lbTipoMovimiento.DisplayMember = "Descripcion_Concepto";
            this.lbTipoMovimiento.FormattingEnabled = true;
            this.lbTipoMovimiento.Location = new System.Drawing.Point(9, 22);
            this.lbTipoMovimiento.Name = "lbTipoMovimiento";
            this.lbTipoMovimiento.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbTipoMovimiento.Size = new System.Drawing.Size(148, 121);
            this.lbTipoMovimiento.TabIndex = 3;
            this.lbTipoMovimiento.ValueMember = "Descripcion_Concepto";
            // 
            // ckbCompras
            // 
            this.ckbCompras.AutoSize = true;
            this.ckbCompras.Location = new System.Drawing.Point(164, 101);
            this.ckbCompras.Margin = new System.Windows.Forms.Padding(4);
            this.ckbCompras.Name = "ckbCompras";
            this.ckbCompras.Size = new System.Drawing.Size(67, 17);
            this.ckbCompras.TabIndex = 2;
            this.ckbCompras.Text = "Compras";
            this.ckbCompras.UseVisualStyleBackColor = true;
            // 
            // ckbVentas
            // 
            this.ckbVentas.AutoSize = true;
            this.ckbVentas.Location = new System.Drawing.Point(164, 73);
            this.ckbVentas.Margin = new System.Windows.Forms.Padding(4);
            this.ckbVentas.Name = "ckbVentas";
            this.ckbVentas.Size = new System.Drawing.Size(59, 17);
            this.ckbVentas.TabIndex = 1;
            this.ckbVentas.Text = "Ventas";
            this.ckbVentas.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(238, 263);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(101, 42);
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(347, 263);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 42);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(13, 263);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(101, 42);
            this.btnSalir.TabIndex = 22;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // frmBuscarMovimientoInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 312);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.DoubleBuffered = true;
            this.Name = "frmBuscarMovimientoInventario";
            this.Text = "frmBuscarMovimientoInventario";
            this.Load += new System.EventHandler(this.frmBuscarMovimientoInventario_Load);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.ComboBox cbbClienteProveedor;
        internal System.Windows.Forms.TextBox txtDocumento;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cbbCriterio;
        internal System.Windows.Forms.TextBox txtCantidad;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.DateTimePicker dtpHasta;
        internal System.Windows.Forms.DateTimePicker dtpDesde;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox ckbOtros;
        internal System.Windows.Forms.ListBox lbTipoMovimiento;
        internal System.Windows.Forms.CheckBox ckbCompras;
        internal System.Windows.Forms.CheckBox ckbVentas;
        internal System.Windows.Forms.Button btnAceptar;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnSalir;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}