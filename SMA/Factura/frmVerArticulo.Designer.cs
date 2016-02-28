namespace SMA.Factura
{
    partial class frmVerArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerArticulo));
            this.lblLinea = new System.Windows.Forms.Label();
            this.lblTituloLinea = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblTituloMarca = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTituloExistencia = new System.Windows.Forms.Label();
            this.lblExistencia = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblTituloPrecio = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblTituloDescripcion = new System.Windows.Forms.Label();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.pcbImagenArticulo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new DevComponents.DotNetBar.ButtonX();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLinea
            // 
            this.lblLinea.BackColor = System.Drawing.Color.White;
            this.lblLinea.Location = new System.Drawing.Point(221, 144);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(152, 22);
            this.lblLinea.TabIndex = 89;
            this.lblLinea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloLinea
            // 
            this.lblTituloLinea.AutoSize = true;
            this.lblTituloLinea.Location = new System.Drawing.Point(221, 131);
            this.lblTituloLinea.Name = "lblTituloLinea";
            this.lblTituloLinea.Size = new System.Drawing.Size(42, 13);
            this.lblTituloLinea.TabIndex = 88;
            this.lblTituloLinea.Text = "Familia:";
            // 
            // lblMarca
            // 
            this.lblMarca.BackColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(418, 146);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(166, 22);
            this.lblMarca.TabIndex = 87;
            this.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloMarca
            // 
            this.lblTituloMarca.AutoSize = true;
            this.lblTituloMarca.Location = new System.Drawing.Point(418, 133);
            this.lblTituloMarca.Name = "lblTituloMarca";
            this.lblTituloMarca.Size = new System.Drawing.Size(40, 13);
            this.lblTituloMarca.TabIndex = 86;
            this.lblTituloMarca.Text = "Marca:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblTituloExistencia);
            this.GroupBox1.Controls.Add(this.lblExistencia);
            this.GroupBox1.Controls.Add(this.lblPrecio);
            this.GroupBox1.Controls.Add(this.lblTituloPrecio);
            this.GroupBox1.Controls.Add(this.lblDescripcion);
            this.GroupBox1.Controls.Add(this.lblTituloDescripcion);
            this.GroupBox1.Location = new System.Drawing.Point(210, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(384, 116);
            this.GroupBox1.TabIndex = 83;
            this.GroupBox1.TabStop = false;
            // 
            // lblTituloExistencia
            // 
            this.lblTituloExistencia.AutoSize = true;
            this.lblTituloExistencia.Location = new System.Drawing.Point(208, 72);
            this.lblTituloExistencia.Name = "lblTituloExistencia";
            this.lblTituloExistencia.Size = new System.Drawing.Size(58, 13);
            this.lblTituloExistencia.TabIndex = 5;
            this.lblTituloExistencia.Text = "Existencia:";
            // 
            // lblExistencia
            // 
            this.lblExistencia.BackColor = System.Drawing.Color.White;
            this.lblExistencia.Location = new System.Drawing.Point(211, 85);
            this.lblExistencia.Name = "lblExistencia";
            this.lblExistencia.Size = new System.Drawing.Size(163, 22);
            this.lblExistencia.TabIndex = 4;
            this.lblExistencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrecio
            // 
            this.lblPrecio.BackColor = System.Drawing.Color.White;
            this.lblPrecio.Location = new System.Drawing.Point(11, 85);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(152, 22);
            this.lblPrecio.TabIndex = 3;
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloPrecio
            // 
            this.lblTituloPrecio.AutoSize = true;
            this.lblTituloPrecio.Location = new System.Drawing.Point(11, 72);
            this.lblTituloPrecio.Name = "lblTituloPrecio";
            this.lblTituloPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblTituloPrecio.TabIndex = 2;
            this.lblTituloPrecio.Text = "Precio:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(11, 29);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(363, 22);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloDescripcion
            // 
            this.lblTituloDescripcion.AutoSize = true;
            this.lblTituloDescripcion.Location = new System.Drawing.Point(11, 16);
            this.lblTituloDescripcion.Name = "lblTituloDescripcion";
            this.lblTituloDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblTituloDescripcion.TabIndex = 0;
            this.lblTituloDescripcion.Text = "Descripción";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // pcbImagenArticulo
            // 
            this.pcbImagenArticulo.Location = new System.Drawing.Point(9, 12);
            this.pcbImagenArticulo.Name = "pcbImagenArticulo";
            this.pcbImagenArticulo.Size = new System.Drawing.Size(195, 156);
            this.pcbImagenArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagenArticulo.TabIndex = 91;
            this.pcbImagenArticulo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(492, 178);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 42);
            this.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSalir.TabIndex = 92;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmVerArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 227);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pcbImagenArticulo);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.lblTituloLinea);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblTituloMarca);
            this.Controls.Add(this.GroupBox1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmVerArticulo";
            this.Text = "Ver Producto";
            this.Load += new System.EventHandler(this.frmVerArticulo_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblLinea;
        internal System.Windows.Forms.Label lblTituloLinea;
        internal System.Windows.Forms.Label lblMarca;
        internal System.Windows.Forms.Label lblTituloMarca;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lblTituloExistencia;
        internal System.Windows.Forms.Label lblExistencia;
        internal System.Windows.Forms.Label lblPrecio;
        internal System.Windows.Forms.Label lblTituloPrecio;
        internal System.Windows.Forms.Label lblDescripcion;
        internal System.Windows.Forms.Label lblTituloDescripcion;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.PictureBox pcbImagenArticulo;
        private DevComponents.DotNetBar.ButtonX btnSalir;
    }
}