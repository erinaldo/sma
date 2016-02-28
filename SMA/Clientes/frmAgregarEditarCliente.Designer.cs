namespace SMA.Clientes
{
    partial class frmAgregarEditarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarCliente));
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.tbcClientes = new System.Windows.Forms.TabControl();
            this.tpInfoGeneral = new System.Windows.Forms.TabPage();
            this.Label28 = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtTelefono2 = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtRNC_Cedula = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.tpInfoFincanciera = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.txtLimiteCredito = new System.Windows.Forms.TextBox();
            this.nudDiasCredito = new System.Windows.Forms.NumericUpDown();
            this.cbbVendedor = new System.Windows.Forms.ComboBox();
            this.txtContactoVenta = new System.Windows.Forms.TextBox();
            this.txtContactoCobro = new System.Windows.Forms.TextBox();
            this.btnListaVendedores = new DevComponents.DotNetBar.ButtonX();
            this.tpHistorico = new System.Windows.Forms.TabPage();
            this.Label29 = new System.Windows.Forms.Label();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.Label26 = new System.Windows.Forms.Label();
            this.txtFechaCreacion = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFechaUltVenta = new System.Windows.Forms.TextBox();
            this.txtUltMontoVenta = new System.Windows.Forms.TextBox();
            this.txtUltDocVenta = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFechaUltPago = new System.Windows.Forms.TextBox();
            this.txtMontoUltPago = new System.Windows.Forms.TextBox();
            this.txtDocUltPago = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.tpNotas = new System.Windows.Forms.TabPage();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.epNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.epRNC = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbEstatus = new System.Windows.Forms.CheckBox();
            this.tbcClientes.SuspendLayout();
            this.tpInfoGeneral.SuspendLayout();
            this.tpInfoFincanciera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasCredito)).BeginInit();
            this.tpHistorico.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.tpNotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRNC)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 47);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(47, 13);
            this.Label2.TabIndex = 75;
            this.Label2.Text = "Nombre:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 17);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 13);
            this.Label1.TabIndex = 74;
            this.Label1.Text = "Codigo:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(63, 42);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(591, 20);
            this.txtNombreCliente.TabIndex = 0;
            this.txtNombreCliente.Validated += new System.EventHandler(this.txtNombreCliente_Validated);
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtCodigoCliente.Location = new System.Drawing.Point(63, 14);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.ReadOnly = true;
            this.txtCodigoCliente.Size = new System.Drawing.Size(81, 20);
            this.txtCodigoCliente.TabIndex = 0;
            this.txtCodigoCliente.TabStop = false;
            // 
            // tbcClientes
            // 
            this.tbcClientes.Controls.Add(this.tpInfoGeneral);
            this.tbcClientes.Controls.Add(this.tpInfoFincanciera);
            this.tbcClientes.Controls.Add(this.tpHistorico);
            this.tbcClientes.Controls.Add(this.tpNotas);
            this.tbcClientes.Location = new System.Drawing.Point(11, 93);
            this.tbcClientes.Margin = new System.Windows.Forms.Padding(4);
            this.tbcClientes.Name = "tbcClientes";
            this.tbcClientes.SelectedIndex = 0;
            this.tbcClientes.Size = new System.Drawing.Size(647, 183);
            this.tbcClientes.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tbcClientes.TabIndex = 2;
            // 
            // tpInfoGeneral
            // 
            this.tpInfoGeneral.Controls.Add(this.Label28);
            this.tpInfoGeneral.Controls.Add(this.txtWeb);
            this.tpInfoGeneral.Controls.Add(this.txtDireccion);
            this.tpInfoGeneral.Controls.Add(this.Label27);
            this.tpInfoGeneral.Controls.Add(this.txtProvincia);
            this.tpInfoGeneral.Controls.Add(this.txtTelefono2);
            this.tpInfoGeneral.Controls.Add(this.txtCiudad);
            this.tpInfoGeneral.Controls.Add(this.Label10);
            this.tpInfoGeneral.Controls.Add(this.txtRNC_Cedula);
            this.tpInfoGeneral.Controls.Add(this.Label9);
            this.tpInfoGeneral.Controls.Add(this.txtTelefono);
            this.tpInfoGeneral.Controls.Add(this.Label8);
            this.tpInfoGeneral.Controls.Add(this.txtFax);
            this.tpInfoGeneral.Controls.Add(this.Label7);
            this.tpInfoGeneral.Controls.Add(this.txtEmail);
            this.tpInfoGeneral.Controls.Add(this.Label6);
            this.tpInfoGeneral.Controls.Add(this.Label4);
            this.tpInfoGeneral.Controls.Add(this.Label5);
            this.tpInfoGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpInfoGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.tpInfoGeneral.Name = "tpInfoGeneral";
            this.tpInfoGeneral.Padding = new System.Windows.Forms.Padding(4);
            this.tpInfoGeneral.Size = new System.Drawing.Size(639, 157);
            this.tpInfoGeneral.TabIndex = 0;
            this.tpInfoGeneral.Text = "Info. General";
            this.tpInfoGeneral.UseVisualStyleBackColor = true;
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.BackColor = System.Drawing.Color.Transparent;
            this.Label28.Location = new System.Drawing.Point(346, 133);
            this.Label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(33, 13);
            this.Label28.TabIndex = 35;
            this.Label28.Text = "Web:";
            // 
            // txtWeb
            // 
            this.txtWeb.Location = new System.Drawing.Point(415, 130);
            this.txtWeb.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(181, 20);
            this.txtWeb.TabIndex = 8;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(96, 10);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(235, 52);
            this.txtDireccion.TabIndex = 0;
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.BackColor = System.Drawing.Color.Transparent;
            this.Label27.Location = new System.Drawing.Point(346, 43);
            this.Label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(61, 13);
            this.Label27.TabIndex = 33;
            this.Label27.Text = "Telefono 2:";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(96, 70);
            this.txtProvincia.Margin = new System.Windows.Forms.Padding(4);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(191, 20);
            this.txtProvincia.TabIndex = 1;
            // 
            // txtTelefono2
            // 
            this.txtTelefono2.Location = new System.Drawing.Point(415, 40);
            this.txtTelefono2.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Size = new System.Drawing.Size(181, 20);
            this.txtTelefono2.TabIndex = 5;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(96, 100);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(191, 20);
            this.txtCiudad.TabIndex = 2;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Location = new System.Drawing.Point(346, 101);
            this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(41, 13);
            this.Label10.TabIndex = 31;
            this.Label10.Text = "Correo:";
            // 
            // txtRNC_Cedula
            // 
            this.txtRNC_Cedula.Location = new System.Drawing.Point(96, 130);
            this.txtRNC_Cedula.Margin = new System.Windows.Forms.Padding(4);
            this.txtRNC_Cedula.Name = "txtRNC_Cedula";
            this.txtRNC_Cedula.Size = new System.Drawing.Size(147, 20);
            this.txtRNC_Cedula.TabIndex = 3;
            this.txtRNC_Cedula.Validated += new System.EventHandler(this.txtRNC_Cedula_Validated);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Location = new System.Drawing.Point(346, 72);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(27, 13);
            this.Label9.TabIndex = 30;
            this.Label9.Text = "Fax:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(415, 10);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(181, 20);
            this.txtTelefono.TabIndex = 4;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Location = new System.Drawing.Point(346, 13);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(61, 13);
            this.Label8.TabIndex = 29;
            this.Label8.Text = "Telefono 1:";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(415, 70);
            this.txtFax.Margin = new System.Windows.Forms.Padding(4);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(181, 20);
            this.txtFax.TabIndex = 6;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Location = new System.Drawing.Point(11, 133);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(77, 13);
            this.Label7.TabIndex = 28;
            this.Label7.Text = "RNC / Cedula:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(415, 100);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(181, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Location = new System.Drawing.Point(11, 103);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(43, 13);
            this.Label6.TabIndex = 27;
            this.Label6.Text = "Ciudad:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Location = new System.Drawing.Point(11, 13);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(55, 13);
            this.Label4.TabIndex = 23;
            this.Label4.Text = "Direccion:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Location = new System.Drawing.Point(11, 73);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(54, 13);
            this.Label5.TabIndex = 25;
            this.Label5.Text = "Provincia:";
            // 
            // tpInfoFincanciera
            // 
            this.tpInfoFincanciera.Controls.Add(this.label3);
            this.tpInfoFincanciera.Controls.Add(this.cbbTipoComprobante);
            this.tpInfoFincanciera.Controls.Add(this.Label11);
            this.tpInfoFincanciera.Controls.Add(this.Label12);
            this.tpInfoFincanciera.Controls.Add(this.Label14);
            this.tpInfoFincanciera.Controls.Add(this.Label15);
            this.tpInfoFincanciera.Controls.Add(this.Label16);
            this.tpInfoFincanciera.Controls.Add(this.txtDescuento);
            this.tpInfoFincanciera.Controls.Add(this.Label17);
            this.tpInfoFincanciera.Controls.Add(this.txtLimiteCredito);
            this.tpInfoFincanciera.Controls.Add(this.nudDiasCredito);
            this.tpInfoFincanciera.Controls.Add(this.cbbVendedor);
            this.tpInfoFincanciera.Controls.Add(this.txtContactoVenta);
            this.tpInfoFincanciera.Controls.Add(this.txtContactoCobro);
            this.tpInfoFincanciera.Controls.Add(this.btnListaVendedores);
            this.tpInfoFincanciera.Location = new System.Drawing.Point(4, 22);
            this.tpInfoFincanciera.Name = "tpInfoFincanciera";
            this.tpInfoFincanciera.Padding = new System.Windows.Forms.Padding(3);
            this.tpInfoFincanciera.Size = new System.Drawing.Size(639, 157);
            this.tpInfoFincanciera.TabIndex = 4;
            this.tpInfoFincanciera.Text = "Info. Financiera";
            this.tpInfoFincanciera.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Comprobante:";
            // 
            // cbbTipoComprobante
            // 
            this.cbbTipoComprobante.FormattingEnabled = true;
            this.cbbTipoComprobante.Location = new System.Drawing.Point(88, 100);
            this.cbbTipoComprobante.Name = "cbbTipoComprobante";
            this.cbbTipoComprobante.Size = new System.Drawing.Size(225, 21);
            this.cbbTipoComprobante.TabIndex = 4;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Location = new System.Drawing.Point(7, 19);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(73, 13);
            this.Label11.TabIndex = 41;
            this.Label11.Text = "Limite Credito:";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Location = new System.Drawing.Point(7, 47);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(67, 13);
            this.Label12.TabIndex = 42;
            this.Label12.Text = "Dias Credito:";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.Location = new System.Drawing.Point(322, 15);
            this.Label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(84, 13);
            this.Label14.TabIndex = 43;
            this.Label14.Text = "Contacto Venta:";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.BackColor = System.Drawing.Color.Transparent;
            this.Label15.Location = new System.Drawing.Point(322, 43);
            this.Label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(84, 13);
            this.Label15.TabIndex = 44;
            this.Label15.Text = "Contacto Cobro:";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.BackColor = System.Drawing.Color.Transparent;
            this.Label16.Location = new System.Drawing.Point(7, 73);
            this.Label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(56, 13);
            this.Label16.TabIndex = 45;
            this.Label16.Text = "Vendedor:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(414, 68);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(56, 20);
            this.txtDescuento.TabIndex = 7;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Location = new System.Drawing.Point(322, 71);
            this.Label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(62, 13);
            this.Label17.TabIndex = 46;
            this.Label17.Text = "Descuento:";
            // 
            // txtLimiteCredito
            // 
            this.txtLimiteCredito.Location = new System.Drawing.Point(88, 15);
            this.txtLimiteCredito.Margin = new System.Windows.Forms.Padding(4);
            this.txtLimiteCredito.Name = "txtLimiteCredito";
            this.txtLimiteCredito.Size = new System.Drawing.Size(192, 20);
            this.txtLimiteCredito.TabIndex = 0;
            // 
            // nudDiasCredito
            // 
            this.nudDiasCredito.Location = new System.Drawing.Point(88, 43);
            this.nudDiasCredito.Margin = new System.Windows.Forms.Padding(4);
            this.nudDiasCredito.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudDiasCredito.Name = "nudDiasCredito";
            this.nudDiasCredito.Size = new System.Drawing.Size(49, 20);
            this.nudDiasCredito.TabIndex = 1;
            // 
            // cbbVendedor
            // 
            this.cbbVendedor.DisplayMember = "Nombre";
            this.cbbVendedor.FormattingEnabled = true;
            this.cbbVendedor.Location = new System.Drawing.Point(88, 69);
            this.cbbVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.cbbVendedor.Name = "cbbVendedor";
            this.cbbVendedor.Size = new System.Drawing.Size(192, 21);
            this.cbbVendedor.TabIndex = 2;
            this.cbbVendedor.ValueMember = "Vendedor_ID";
            // 
            // txtContactoVenta
            // 
            this.txtContactoVenta.Location = new System.Drawing.Point(414, 12);
            this.txtContactoVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactoVenta.Name = "txtContactoVenta";
            this.txtContactoVenta.Size = new System.Drawing.Size(186, 20);
            this.txtContactoVenta.TabIndex = 5;
            // 
            // txtContactoCobro
            // 
            this.txtContactoCobro.Location = new System.Drawing.Point(414, 40);
            this.txtContactoCobro.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactoCobro.Name = "txtContactoCobro";
            this.txtContactoCobro.Size = new System.Drawing.Size(186, 20);
            this.txtContactoCobro.TabIndex = 6;
            // 
            // btnListaVendedores
            // 
            this.btnListaVendedores.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnListaVendedores.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnListaVendedores.Image = global::SMA.Properties.Resources.find_icon;
            this.btnListaVendedores.Location = new System.Drawing.Point(287, 67);
            this.btnListaVendedores.Name = "btnListaVendedores";
            this.btnListaVendedores.Size = new System.Drawing.Size(26, 23);
            this.btnListaVendedores.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnListaVendedores.TabIndex = 3;
            this.btnListaVendedores.Click += new System.EventHandler(this.btnListaVendedores_Click);
            // 
            // tpHistorico
            // 
            this.tpHistorico.Controls.Add(this.Label29);
            this.tpHistorico.Controls.Add(this.txtFechaModificacion);
            this.tpHistorico.Controls.Add(this.Label26);
            this.tpHistorico.Controls.Add(this.txtFechaCreacion);
            this.tpHistorico.Controls.Add(this.GroupBox1);
            this.tpHistorico.Controls.Add(this.GroupBox2);
            this.tpHistorico.Location = new System.Drawing.Point(4, 22);
            this.tpHistorico.Name = "tpHistorico";
            this.tpHistorico.Padding = new System.Windows.Forms.Padding(3);
            this.tpHistorico.Size = new System.Drawing.Size(639, 157);
            this.tpHistorico.TabIndex = 5;
            this.tpHistorico.Text = "Historico";
            this.tpHistorico.UseVisualStyleBackColor = true;
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.BackColor = System.Drawing.Color.Transparent;
            this.Label29.Location = new System.Drawing.Point(347, 15);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(100, 13);
            this.Label29.TabIndex = 11;
            this.Label29.Text = "Fecha Modificacion";
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtFechaModificacion.Location = new System.Drawing.Point(453, 11);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.ReadOnly = true;
            this.txtFechaModificacion.Size = new System.Drawing.Size(172, 20);
            this.txtFechaModificacion.TabIndex = 2;
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.BackColor = System.Drawing.Color.Transparent;
            this.Label26.Location = new System.Drawing.Point(6, 15);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(81, 13);
            this.Label26.TabIndex = 9;
            this.Label26.Text = "Fecha creación";
            // 
            // txtFechaCreacion
            // 
            this.txtFechaCreacion.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtFechaCreacion.Location = new System.Drawing.Point(93, 11);
            this.txtFechaCreacion.Name = "txtFechaCreacion";
            this.txtFechaCreacion.ReadOnly = true;
            this.txtFechaCreacion.Size = new System.Drawing.Size(180, 20);
            this.txtFechaCreacion.TabIndex = 0;
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.txtFechaUltVenta);
            this.GroupBox1.Controls.Add(this.txtUltMontoVenta);
            this.GroupBox1.Controls.Add(this.txtUltDocVenta);
            this.GroupBox1.Controls.Add(this.Label20);
            this.GroupBox1.Controls.Add(this.Label19);
            this.GroupBox1.Controls.Add(this.Label18);
            this.GroupBox1.Location = new System.Drawing.Point(9, 48);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(264, 105);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Ultima Factura";
            // 
            // txtFechaUltVenta
            // 
            this.txtFechaUltVenta.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtFechaUltVenta.Location = new System.Drawing.Point(91, 18);
            this.txtFechaUltVenta.Name = "txtFechaUltVenta";
            this.txtFechaUltVenta.Size = new System.Drawing.Size(167, 20);
            this.txtFechaUltVenta.TabIndex = 0;
            // 
            // txtUltMontoVenta
            // 
            this.txtUltMontoVenta.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtUltMontoVenta.Location = new System.Drawing.Point(92, 74);
            this.txtUltMontoVenta.Name = "txtUltMontoVenta";
            this.txtUltMontoVenta.Size = new System.Drawing.Size(167, 20);
            this.txtUltMontoVenta.TabIndex = 3;
            // 
            // txtUltDocVenta
            // 
            this.txtUltDocVenta.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtUltDocVenta.Location = new System.Drawing.Point(92, 46);
            this.txtUltDocVenta.Name = "txtUltDocVenta";
            this.txtUltDocVenta.Size = new System.Drawing.Size(167, 20);
            this.txtUltDocVenta.TabIndex = 1;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(38, 77);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(40, 13);
            this.Label20.TabIndex = 2;
            this.Label20.Text = "Monto:";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(6, 49);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(65, 13);
            this.Label19.TabIndex = 1;
            this.Label19.Text = "Documento:";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(36, 21);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(40, 13);
            this.Label18.TabIndex = 0;
            this.Label18.Text = "Fecha:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.txtFechaUltPago);
            this.GroupBox2.Controls.Add(this.txtMontoUltPago);
            this.GroupBox2.Controls.Add(this.txtDocUltPago);
            this.GroupBox2.Controls.Add(this.Label23);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Controls.Add(this.Label21);
            this.GroupBox2.Location = new System.Drawing.Point(361, 44);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(264, 109);
            this.GroupBox2.TabIndex = 3;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Ultimo Pago";
            // 
            // txtFechaUltPago
            // 
            this.txtFechaUltPago.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtFechaUltPago.Location = new System.Drawing.Point(92, 21);
            this.txtFechaUltPago.Name = "txtFechaUltPago";
            this.txtFechaUltPago.Size = new System.Drawing.Size(166, 20);
            this.txtFechaUltPago.TabIndex = 0;
            // 
            // txtMontoUltPago
            // 
            this.txtMontoUltPago.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtMontoUltPago.Location = new System.Drawing.Point(92, 77);
            this.txtMontoUltPago.Name = "txtMontoUltPago";
            this.txtMontoUltPago.Size = new System.Drawing.Size(166, 20);
            this.txtMontoUltPago.TabIndex = 3;
            // 
            // txtDocUltPago
            // 
            this.txtDocUltPago.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtDocUltPago.Location = new System.Drawing.Point(92, 49);
            this.txtDocUltPago.Name = "txtDocUltPago";
            this.txtDocUltPago.Size = new System.Drawing.Size(166, 20);
            this.txtDocUltPago.TabIndex = 1;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(38, 80);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(40, 13);
            this.Label23.TabIndex = 2;
            this.Label23.Text = "Monto:";
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(6, 52);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(65, 13);
            this.Label22.TabIndex = 1;
            this.Label22.Text = "Documento:";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(37, 24);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(40, 13);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "Fecha:";
            // 
            // tpNotas
            // 
            this.tpNotas.Controls.Add(this.txtObservacion);
            this.tpNotas.Location = new System.Drawing.Point(4, 22);
            this.tpNotas.Name = "tpNotas";
            this.tpNotas.Padding = new System.Windows.Forms.Padding(3);
            this.tpNotas.Size = new System.Drawing.Size(639, 157);
            this.tpNotas.TabIndex = 3;
            this.tpNotas.Text = "Notas";
            this.tpNotas.UseVisualStyleBackColor = true;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(7, 18);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(617, 124);
            this.txtObservacion.TabIndex = 0;
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtSaldo.Location = new System.Drawing.Point(73, 298);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(254, 20);
            this.txtSaldo.TabIndex = 3;
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.BackColor = System.Drawing.Color.Transparent;
            this.Label24.Location = new System.Drawing.Point(18, 301);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(49, 13);
            this.Label24.TabIndex = 53;
            this.Label24.Text = "Balance:";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // epNombre
            // 
            this.epNombre.ContainerControl = this;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(552, 283);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(436, 283);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 42);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // epRNC
            // 
            this.epRNC.ContainerControl = this;
            // 
            // cbEstatus
            // 
            this.cbEstatus.AutoSize = true;
            this.cbEstatus.Location = new System.Drawing.Point(63, 69);
            this.cbEstatus.Name = "cbEstatus";
            this.cbEstatus.Size = new System.Drawing.Size(123, 17);
            this.cbEstatus.TabIndex = 1;
            this.cbEstatus.Text = "Activo / Suspendido";
            this.cbEstatus.UseVisualStyleBackColor = true;
            // 
            // frmAgregarEditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 330);
            this.Controls.Add(this.cbEstatus);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.tbcClientes);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.Label24);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(685, 368);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(685, 368);
            this.Name = "frmAgregarEditarCliente";
            this.Load += new System.EventHandler(this.frmAgregarEditarCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAgregarEditarCliente_KeyDown);
            this.tbcClientes.ResumeLayout(false);
            this.tpInfoGeneral.ResumeLayout(false);
            this.tpInfoGeneral.PerformLayout();
            this.tpInfoFincanciera.ResumeLayout(false);
            this.tpInfoFincanciera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasCredito)).EndInit();
            this.tpHistorico.ResumeLayout(false);
            this.tpHistorico.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.tpNotas.ResumeLayout(false);
            this.tpNotas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRNC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtNombreCliente;
        internal System.Windows.Forms.TextBox txtCodigoCliente;
        internal System.Windows.Forms.TabControl tbcClientes;
        internal System.Windows.Forms.TabPage tpInfoGeneral;
        internal System.Windows.Forms.TabPage tpNotas;
        internal System.Windows.Forms.TextBox txtObservacion;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private System.Windows.Forms.ErrorProvider epNombre;
        private System.Windows.Forms.ErrorProvider epRNC;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.TextBox txtWeb;
        internal System.Windows.Forms.TextBox txtDireccion;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.TextBox txtProvincia;
        internal System.Windows.Forms.TextBox txtTelefono2;
        internal System.Windows.Forms.TextBox txtCiudad;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtRNC_Cedula;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtTelefono;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtFax;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TabPage tpInfoFincanciera;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox txtDescuento;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.TextBox txtLimiteCredito;
        internal System.Windows.Forms.NumericUpDown nudDiasCredito;
        internal System.Windows.Forms.TextBox txtSaldo;
        internal System.Windows.Forms.ComboBox cbbVendedor;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.TextBox txtContactoVenta;
        internal System.Windows.Forms.TextBox txtContactoCobro;
        internal DevComponents.DotNetBar.ButtonX btnListaVendedores;
        private System.Windows.Forms.TabPage tpHistorico;
        internal System.Windows.Forms.Label Label29;
        internal System.Windows.Forms.TextBox txtFechaModificacion;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.TextBox txtFechaCreacion;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtFechaUltVenta;
        internal System.Windows.Forms.TextBox txtUltMontoVenta;
        internal System.Windows.Forms.TextBox txtUltDocVenta;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtFechaUltPago;
        internal System.Windows.Forms.TextBox txtMontoUltPago;
        internal System.Windows.Forms.TextBox txtDocUltPago;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbTipoComprobante;
        private System.Windows.Forms.CheckBox cbEstatus;
    }
}