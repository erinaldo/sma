namespace SMA.Factura.Cotizacion
{
    partial class frmBuscarCotizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarCotizacion));
            this.tbcBuscar = new System.Windows.Forms.TabControl();
            this.tpBuscar = new System.Windows.Forms.TabPage();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtStringFind = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cbbBusqueda = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cbbCriterio = new System.Windows.Forms.ComboBox();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.tbcBuscar.SuspendLayout();
            this.tpBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcBuscar
            // 
            this.tbcBuscar.Controls.Add(this.tpBuscar);
            this.tbcBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcBuscar.Location = new System.Drawing.Point(12, 11);
            this.tbcBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbcBuscar.Name = "tbcBuscar";
            this.tbcBuscar.SelectedIndex = 0;
            this.tbcBuscar.Size = new System.Drawing.Size(512, 167);
            this.tbcBuscar.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcBuscar.TabIndex = 25;
            // 
            // tpBuscar
            // 
            this.tpBuscar.Controls.Add(this.Label4);
            this.tpBuscar.Controls.Add(this.Label1);
            this.tpBuscar.Controls.Add(this.txtImporte);
            this.tpBuscar.Controls.Add(this.txtStringFind);
            this.tpBuscar.Controls.Add(this.Label3);
            this.tpBuscar.Controls.Add(this.cbbBusqueda);
            this.tpBuscar.Controls.Add(this.Label2);
            this.tpBuscar.Controls.Add(this.cbbCriterio);
            this.tpBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpBuscar.Location = new System.Drawing.Point(4, 25);
            this.tpBuscar.Margin = new System.Windows.Forms.Padding(5);
            this.tpBuscar.Name = "tpBuscar";
            this.tpBuscar.Padding = new System.Windows.Forms.Padding(5);
            this.tpBuscar.Size = new System.Drawing.Size(504, 138);
            this.tpBuscar.TabIndex = 1;
            this.tpBuscar.Text = "Buscar";
            this.tpBuscar.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(9, 79);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(56, 16);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Importe:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 17);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 16);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Buscar:";
            // 
            // txtImporte
            // 
            this.txtImporte.AcceptsReturn = true;
            this.txtImporte.Location = new System.Drawing.Point(88, 76);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(4);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(162, 22);
            this.txtImporte.TabIndex = 16;
            // 
            // txtStringFind
            // 
            this.txtStringFind.Location = new System.Drawing.Point(88, 14);
            this.txtStringFind.Margin = new System.Windows.Forms.Padding(4);
            this.txtStringFind.Name = "txtStringFind";
            this.txtStringFind.Size = new System.Drawing.Size(407, 22);
            this.txtStringFind.TabIndex = 13;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(9, 109);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(53, 16);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Criterio:";
            // 
            // cbbBusqueda
            // 
            this.cbbBusqueda.FormattingEnabled = true;
            this.cbbBusqueda.Items.AddRange(new object[] {
            "No. Documento",
            "Fecha Elaboración",
            "Nombre de Cliente"});
            this.cbbBusqueda.Location = new System.Drawing.Point(88, 44);
            this.cbbBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.cbbBusqueda.Name = "cbbBusqueda";
            this.cbbBusqueda.Size = new System.Drawing.Size(243, 24);
            this.cbbBusqueda.TabIndex = 14;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(9, 47);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 16);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Buscar en:";
            // 
            // cbbCriterio
            // 
            this.cbbCriterio.FormattingEnabled = true;
            this.cbbCriterio.Items.AddRange(new object[] {
            "Todos",
            "Exacto",
            "Mayor",
            "Mayor o Igual ",
            "Menor",
            "Menor o Igual"});
            this.cbbCriterio.Location = new System.Drawing.Point(88, 106);
            this.cbbCriterio.Margin = new System.Windows.Forms.Padding(4);
            this.cbbCriterio.Name = "cbbCriterio";
            this.cbbCriterio.Size = new System.Drawing.Size(162, 24);
            this.cbbCriterio.TabIndex = 15;
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
            this.btnCancelar.Location = new System.Drawing.Point(417, 183);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 40);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(308, 183);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(103, 40);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 26;
            this.btnAceptar.Text = "Buscar";
            this.btnAceptar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmBuscarCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 225);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tbcBuscar);
            this.EnableGlass = false;
            this.Name = "frmBuscarCotizacion";
            this.Text = "Buscar Cotización";
            this.Load += new System.EventHandler(this.frmBuscarCotizacion_Load);
            this.tbcBuscar.ResumeLayout(false);
            this.tpBuscar.ResumeLayout(false);
            this.tpBuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        internal System.Windows.Forms.TabControl tbcBuscar;
        internal System.Windows.Forms.TabPage tpBuscar;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtImporte;
        internal System.Windows.Forms.TextBox txtStringFind;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox cbbBusqueda;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cbbCriterio;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}