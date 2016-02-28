namespace SMA.Proveedor
{
    partial class frmBuscarProveedor
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
            this.tbcBuscar = new System.Windows.Forms.TabControl();
            this.tpBuscar = new System.Windows.Forms.TabPage();
            this.cbbBusqueda = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtStringFind = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.tbcBuscar.SuspendLayout();
            this.tpBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcBuscar
            // 
            this.tbcBuscar.Controls.Add(this.tpBuscar);
            this.tbcBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcBuscar.Location = new System.Drawing.Point(11, 11);
            this.tbcBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.tbcBuscar.Name = "tbcBuscar";
            this.tbcBuscar.SelectedIndex = 0;
            this.tbcBuscar.Size = new System.Drawing.Size(530, 110);
            this.tbcBuscar.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcBuscar.TabIndex = 1;
            // 
            // tpBuscar
            // 
            this.tpBuscar.Controls.Add(this.cbbBusqueda);
            this.tpBuscar.Controls.Add(this.btnCancelar);
            this.tpBuscar.Controls.Add(this.btnBuscar);
            this.tpBuscar.Controls.Add(this.txtStringFind);
            this.tpBuscar.Controls.Add(this.Label2);
            this.tpBuscar.Controls.Add(this.Label1);
            this.tpBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpBuscar.Location = new System.Drawing.Point(4, 25);
            this.tpBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.tpBuscar.Name = "tpBuscar";
            this.tpBuscar.Padding = new System.Windows.Forms.Padding(4);
            this.tpBuscar.Size = new System.Drawing.Size(522, 81);
            this.tpBuscar.TabIndex = 1;
            this.tpBuscar.Text = "Buscar";
            this.tpBuscar.UseVisualStyleBackColor = true;
            // 
            // cbbBusqueda
            // 
            this.cbbBusqueda.FormattingEnabled = true;
            this.cbbBusqueda.Items.AddRange(new object[] {
            "Código",
            "Nombre",
            "RNC / Cedula",
            "Teléfono"});
            this.cbbBusqueda.Location = new System.Drawing.Point(94, 41);
            this.cbbBusqueda.Name = "cbbBusqueda";
            this.cbbBusqueda.Size = new System.Drawing.Size(191, 24);
            this.cbbBusqueda.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(438, 44);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 28);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(438, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 28);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtStringFind
            // 
            this.txtStringFind.Location = new System.Drawing.Point(94, 13);
            this.txtStringFind.Name = "txtStringFind";
            this.txtStringFind.Size = new System.Drawing.Size(328, 22);
            this.txtStringFind.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(17, 44);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 16);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Buscar en:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(17, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Buscar:";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            // 
            // frmBuscarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 135);
            this.Controls.Add(this.tbcBuscar);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "frmBuscarProveedor";
            this.Text = "Buscar proveedor";
            this.Load += new System.EventHandler(this.frmBuscarCliente_Load);
            this.tbcBuscar.ResumeLayout(false);
            this.tpBuscar.ResumeLayout(false);
            this.tpBuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl tbcBuscar;
        internal System.Windows.Forms.TabPage tpBuscar;
        internal System.Windows.Forms.ComboBox cbbBusqueda;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.TextBox txtStringFind;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}