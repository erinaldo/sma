namespace SMA.Usuarios
{
    partial class frmGestionPermisosPerfiles
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
            this.cbbPerfiles = new System.Windows.Forms.ComboBox();
            this.lbModulos = new System.Windows.Forms.ListBox();
            this.lbModulosAsignados = new System.Windows.Forms.ListBox();
            this.lbPermisos = new System.Windows.Forms.ListBox();
            this.lbPermisosAsignados = new System.Windows.Forms.ListBox();
            this.btnAgregarModulo = new DevComponents.DotNetBar.ButtonX();
            this.btnEliminarModulo = new DevComponents.DotNetBar.ButtonX();
            this.btnEliminarRol = new DevComponents.DotNetBar.ButtonX();
            this.btnAgregarRol = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // cbbPerfiles
            // 
            this.cbbPerfiles.FormattingEnabled = true;
            this.cbbPerfiles.Location = new System.Drawing.Point(12, 12);
            this.cbbPerfiles.Name = "cbbPerfiles";
            this.cbbPerfiles.Size = new System.Drawing.Size(480, 21);
            this.cbbPerfiles.TabIndex = 0;
            this.cbbPerfiles.SelectedValueChanged += new System.EventHandler(this.cbbPerfiles_SelectedValueChanged);
            // 
            // lbModulos
            // 
            this.lbModulos.FormattingEnabled = true;
            this.lbModulos.Location = new System.Drawing.Point(12, 59);
            this.lbModulos.Name = "lbModulos";
            this.lbModulos.Size = new System.Drawing.Size(216, 160);
            this.lbModulos.TabIndex = 1;
            this.lbModulos.Click += new System.EventHandler(this.lbModulos_Click);
            // 
            // lbModulosAsignados
            // 
            this.lbModulosAsignados.FormattingEnabled = true;
            this.lbModulosAsignados.Location = new System.Drawing.Point(277, 59);
            this.lbModulosAsignados.Name = "lbModulosAsignados";
            this.lbModulosAsignados.Size = new System.Drawing.Size(216, 160);
            this.lbModulosAsignados.TabIndex = 2;
            this.lbModulosAsignados.Click += new System.EventHandler(this.lbModulosAsignados_Click);
            this.lbModulosAsignados.SelectedValueChanged += new System.EventHandler(this.lbModulosAsignados_SelectedValueChanged);
            // 
            // lbPermisos
            // 
            this.lbPermisos.FormattingEnabled = true;
            this.lbPermisos.Location = new System.Drawing.Point(12, 238);
            this.lbPermisos.Name = "lbPermisos";
            this.lbPermisos.Size = new System.Drawing.Size(216, 95);
            this.lbPermisos.TabIndex = 3;
            // 
            // lbPermisosAsignados
            // 
            this.lbPermisosAsignados.FormattingEnabled = true;
            this.lbPermisosAsignados.Location = new System.Drawing.Point(277, 238);
            this.lbPermisosAsignados.Name = "lbPermisosAsignados";
            this.lbPermisosAsignados.Size = new System.Drawing.Size(216, 95);
            this.lbPermisosAsignados.TabIndex = 4;
            // 
            // btnAgregarModulo
            // 
            this.btnAgregarModulo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregarModulo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregarModulo.Location = new System.Drawing.Point(234, 113);
            this.btnAgregarModulo.Name = "btnAgregarModulo";
            this.btnAgregarModulo.Size = new System.Drawing.Size(37, 30);
            this.btnAgregarModulo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregarModulo.TabIndex = 5;
            this.btnAgregarModulo.Text = ">";
            this.btnAgregarModulo.Click += new System.EventHandler(this.btnAgregarModulo_Click);
            // 
            // btnEliminarModulo
            // 
            this.btnEliminarModulo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminarModulo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminarModulo.Location = new System.Drawing.Point(234, 149);
            this.btnEliminarModulo.Name = "btnEliminarModulo";
            this.btnEliminarModulo.Size = new System.Drawing.Size(37, 30);
            this.btnEliminarModulo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminarModulo.TabIndex = 6;
            this.btnEliminarModulo.Text = "<";
            this.btnEliminarModulo.Click += new System.EventHandler(this.btnEliminarModulo_Click);
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminarRol.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminarRol.Location = new System.Drawing.Point(234, 290);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(37, 30);
            this.btnEliminarRol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminarRol.TabIndex = 8;
            this.btnEliminarRol.Text = "<";
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregarRol.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregarRol.Location = new System.Drawing.Point(234, 254);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(37, 30);
            this.btnAgregarRol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregarRol.TabIndex = 7;
            this.btnAgregarRol.Text = ">";
            this.btnAgregarRol.Click += new System.EventHandler(this.btnAgregarRol_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Modulos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Modulos asignados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Permisos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Permisos asignados";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // frmGestionPermisosPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 341);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminarRol);
            this.Controls.Add(this.btnAgregarRol);
            this.Controls.Add(this.btnEliminarModulo);
            this.Controls.Add(this.btnAgregarModulo);
            this.Controls.Add(this.lbPermisosAsignados);
            this.Controls.Add(this.lbPermisos);
            this.Controls.Add(this.lbModulosAsignados);
            this.Controls.Add(this.lbModulos);
            this.Controls.Add(this.cbbPerfiles);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximumSize = new System.Drawing.Size(520, 379);
            this.MinimumSize = new System.Drawing.Size(520, 379);
            this.Name = "frmGestionPermisosPerfiles";
            this.Text = "Gestion de permisos";
            this.Load += new System.EventHandler(this.frmGestionPermisosPerfiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbPerfiles;
        private System.Windows.Forms.ListBox lbModulos;
        private System.Windows.Forms.ListBox lbModulosAsignados;
        private System.Windows.Forms.ListBox lbPermisos;
        private System.Windows.Forms.ListBox lbPermisosAsignados;
        private DevComponents.DotNetBar.ButtonX btnAgregarModulo;
        private DevComponents.DotNetBar.ButtonX btnEliminarModulo;
        private DevComponents.DotNetBar.ButtonX btnEliminarRol;
        private DevComponents.DotNetBar.ButtonX btnAgregarRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}