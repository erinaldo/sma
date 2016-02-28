using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.Entity;
using SMA.BL;
using DevComponents.DotNetBar;
using System.IO;

namespace SMA.Inventario
{
    public partial class frmAgregarEditarInventario : Office2007Form, IfrmAgregarEditarInventario
    {
        private Int64? InventarioID = null;
        private Int64 ArticuloID; //En el caso de combos este representa el codigo de los articulos que lo componen
        private frmGestionInventario GestionInventario; //Variable utilizada para llamar procedimientos publicos en formulario

        public frmAgregarEditarInventario()
        {
            InitializeComponent();

        }

        public frmAgregarEditarInventario(frmGestionInventario GestionInventario):this()
        {
            this.GestionInventario = GestionInventario;
        }
        public frmAgregarEditarInventario(Int64 InventarioID, frmGestionInventario GestionInventario): this()
        {
            this.InventarioID=InventarioID;
            this.GestionInventario = GestionInventario;
        }

        #region Implementacion de Interfase
        public void SeleccionarFamilia(int ID)
        {
            //REFRESCAMOS LA LISTA DE FAMILIA
            CargarFamilias();
            //Seleccionamos la familia
            cbFamilia.SelectedValue = ID;
        }

        public void SeleccionarMarca(int ID)
        {
            //REFRESCAMOS LA LISTA DE MARCAS
            CargarMarcas();
            //Seleccionamos la marca
            cbMarca.SelectedValue = ID;
        }

        public void SeleccionarUnidadEntrada(int ID)
        {
            //Seleccionamos la Unidad Entrada
            cbUnidadEntrada.SelectedValue = ID;
        }

        public void SeleccionarUnidadSalida(int ID)
        {
            //Seleccionamos la Unidad Salida
            cbUnidadSalida.SelectedValue = ID;
        }

        public void AgregarArticulo(Int64 _InventarioID)
        {
            RelacionCombosBL ObjetoRelacion = new RelacionCombosBL();
            
            try
            {
                
                cRelacionCombos Combo = new cRelacionCombos();

                Combo.InventComboID = InventarioID;
                Combo.InventarioID = _InventarioID;
                //Combo.AlmacenID = AlmacenID;
                Combo.Cantidad = 1;

                //Agrega el articulo al combo
                ObjetoRelacion.Crear(Combo);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Error al agregar articulo a combo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        public void Refrescar()
        {
            //Refresca el grid de articulos pertenecientes a un combo
            if (InventarioID.HasValue)
            {
                try
                {
                    int I = Convert.ToInt32(InventarioID);
                    RelacionCombosBL ObjetoRelacion = new RelacionCombosBL();
                    dgvArticulos.AutoGenerateColumns = false;
                    dgvArticulos.DataSource = ObjetoRelacion.Listar(I);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        public void ModificarCantidad(Int64 _InventarioID, Decimal Cantidad)
        {
            try
            {
                Int64 I = Convert.ToInt64(InventarioID);
                RelacionCombosBL ObjetoRelacion = new RelacionCombosBL();
                ObjetoRelacion.ActualizarCantidad(_InventarioID, I, Cantidad);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Error en cambio de cantidad",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void SeleccionarProveedor1(Int64 ID)
        {
            cbProveedor1.SelectedValue = ID;
        }

        public void SeleccionarProveedor2(Int64 ID)
        {
            cbProveedor2.SelectedValue = ID;
        }
        #endregion

        private Boolean IndCambioFechaVencimiento; //Indicador del cambio de valor en el campo fecha de vencimiento

        private void frmAgregarEditarInventario_Load(object sender, EventArgs e)
        {
            try
            {
                //CARGAMOS DEPENDENCIAS EN LOS COMBOBOX
                CargarDepedencias();
                /*SI LA VARIABLE CONTIENE VALOR ENTONCES BUSCAMOS LOS DATOS
                 DEL PRODUCTO SELECCIONADO EN EL FORMULARIO DE GESTION*/
                if (InventarioID.HasValue)
                {
                    try
                    {
                        Int64 I = Convert.ToInt64(InventarioID);
                        InventarioBL ObjetoInventario = new InventarioBL();
                        //MOSTRAMOS EL RESULTADO DE LA BUSQUEDA DE ARTICULO
                        MostarResultado(ObjetoInventario.BuscarPorID(I));
                        //BLOQUEAMOS LOS CAMPOS NO EDITABLES
                        BloqueoCampos();

                        RelacionCombosBL ObjetoRelacion = new RelacionCombosBL();
                        dgvArticulos.AutoGenerateColumns = false;
                        dgvArticulos.DataSource = ObjetoRelacion.Listar(I);

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                else
                {
                    btnAgregar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    txtID.Text = "-1";
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void BloqueoCampos()
        {
            txtExistencia.ReadOnly = true;
            txtCosto.ReadOnly = true;
            txtCodigo.ReadOnly = true;
            cbTipoArticulo.Enabled = false;
        }
        private void CargarDepedencias()
        {
            CargarFamilias();

            CargarMarcas();

            //Unidad Entrada
            UnidadInventarioBL Unidad = new UnidadInventarioBL();
            cbUnidadEntrada.DataSource = Unidad.Listar();
            cbUnidadEntrada.DisplayMember = "Descripcion";
            cbUnidadEntrada.ValueMember = "ID";

            //Unidad Salida
            cbUnidadSalida.DataSource = Unidad.Listar();
            cbUnidadSalida.DisplayMember = "Descripcion";
            cbUnidadSalida.ValueMember = "ID";

            //Impuestos
            ImpuestosBL ObjetoImpuesto = new ImpuestosBL();
            cbImpuesto.DataSource = ObjetoImpuesto.Listar();
            cbImpuesto.DisplayMember = "Descripcion";
            cbImpuesto.ValueMember = "ID";

            //Proveedores
            ProveedorBL ObjetoProveedor=new ProveedorBL();

            cbProveedor1.DataSource =ObjetoProveedor.Listar();
            cbProveedor1.DisplayMember = "NombreComercial";
            cbProveedor1.ValueMember = "ID";

            //Proveedores
            cbProveedor2.DataSource =ObjetoProveedor.Listar();
            cbProveedor2.DisplayMember = "NombreComercial";
            cbProveedor2.ValueMember = "ID";
        }

        private void CargarMarcas()
        {
            //Marcas
            MarcaBL ObjetoMarca = new MarcaBL();
            cbMarca.DataSource = ObjetoMarca.Listar();
            cbMarca.DisplayMember = "Descripcion";
            cbMarca.ValueMember = "ID";
        }

        private void CargarFamilias()
        {
            //Familias
            FamiliaBL ObjetoFamilia = new FamiliaBL();
            cbFamilia.DataSource = ObjetoFamilia.Listar();
            cbFamilia.DisplayMember = "Descripcion";
            cbFamilia.ValueMember = "ID";
        }
        private void MostarResultado(cInventario Inventario)
        {
            txtID.Text = Inventario.ID.ToString();
            txtCodigo.Text = Inventario.CodigoArticulo;
            txtDescripcion.Text = Inventario.Descripcion;
            cbTipoArticulo.SelectedIndex = SeleccionTipo(Inventario.TipoArticulo);
            txtCosto.Text = Inventario.UltCosto.ToString();
            txtPrecioPublico.Text =Inventario.PrecioPublico.ToString();
            txtPrecio2.Text = Inventario.Precio2.ToString();
            txtPrecio3.Text = Inventario.Precio3.ToString();
            txtMinimo.Text = Inventario.Precio4.ToString();
            cbFamilia.SelectedValue = Inventario.FamiliaID;
            cbMarca.SelectedValue = Inventario.MarcaID;
            txtStockMax.Text = Inventario.StockMax.ToString();
            txtStockMin.Text = Inventario.StockMin.ToString();
            txtExistencia.Text = Inventario.Existencia.ToString();
            cbUnidadEntrada.SelectedValue = Inventario.UnidadEntradaID;
            cbUnidadSalida.SelectedValue = Inventario.UnidadSalidaID;
            dtpFechaCreacion.Value = Inventario.FechaCreacion;
            dtpFechaModificacion.Value = Inventario.FechaModificacion;
            txtNotas.Text = Inventario.Notas;
            cbProveedor1.SelectedValue = Inventario.ProveedorID1;
            cbProveedor2.SelectedValue = Inventario.ProveedorID2;
            dtpFechaVencimiento.Value = Convert.ToDateTime(Inventario.FechaVencimiento);
            pbArticulo.Image = byteArrayToImage(Inventario.Imagen);
            cbImpuesto.SelectedValue = Inventario.ImpuestoID;
            txtFechaUltVenta.Text = ObtenerFecha(Inventario.FechaUltVenta);
            txtFechaUltCompra.Text = ObtenerFecha(Inventario.FechaUltCompra);
            txtMontoCompras.Text = Inventario.MontoUltCompra.ToString("C2");
            txtMontoVentas.Text = Inventario.MontoUltVenta.ToString("C2");
            txtCantidadCompras.Text = Inventario.CantUltCompra.ToString("N2");
            txtCantidadVentas.Text = Inventario.CantUltVenta.ToString("N2");
            HabilitarCombos(Inventario.TipoArticulo.ToString());
            txtCostoPromedio.Text = Inventario.CostoPromedio.ToString("C2");
            chbNotificarVencimiento.Checked = Inventario.AvisarVencimiento;
            chbFacturarSinExistencia.Checked = Inventario.FacturarSinExistencia;

            MostrarPorcientos();

        }

        private String ObtenerFecha(object Parametro)
        {
            DateTime Fecha;
            if (Parametro != null)
            {
                if (DateTime.TryParse(Parametro.ToString(), out Fecha))
                {
                    Fecha = Convert.ToDateTime(Parametro.ToString());
                    return Fecha.ToShortDateString();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

       private void HabilitarCombos(string TipoArticulo)
        {
           if (TipoArticulo=="C")
           {
               btnAgregar.Enabled = true;
               btnEditar.Enabled = true;
               btnEliminar.Enabled = true;
           }
           else
           {
               btnAgregar.Enabled = false;
               btnEditar.Enabled = false;
               btnEliminar.Enabled = false;
           }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null && byteArrayIn.Length>0)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;

                //MemoryStream mStream = new MemoryStream();
                //byte[] pData = byteArrayIn;
                //mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                //Bitmap bm = new Bitmap(mStream, false);
                //mStream.Dispose();
                //return bm;
            }
            else
            {
                return null;
            }
        }

        //Seleccionamos el tipo de articulo.
        private int SeleccionTipo(string Sexo)
        {
            if (Sexo == "F") { return 0; } else { return 1; }
        }
       
            

        private cInventario ObtenerDatos()
        {
            cInventario Inventario = new cInventario();
            Inventario.ID = Convert.ToInt32(txtID.Text);
            Inventario.CodigoArticulo = txtCodigo.Text;
            Inventario.Descripcion = txtDescripcion.Text;
            Inventario.UltCosto = Convert.ToDecimal(txtCosto.Text);
            Inventario.TipoArticulo = Convert.ToString(cbTipoArticulo.SelectedItem);
            Inventario.PrecioPublico = Convert.ToDecimal(txtPrecioPublico.Text);
            Inventario.Precio2 = Convert.ToDecimal(txtPrecio2.Text);
            Inventario.Precio3 = Convert.ToDecimal(txtPrecio3.Text);
            Inventario.Precio4 = Convert.ToDecimal(txtMinimo.Text);
            Inventario.FamiliaID = cbFamilia.SelectedValue;
            Inventario.MarcaID = cbMarca.SelectedValue;
            Inventario.StockMax = Convert.ToInt32(txtStockMax.Text);
            Inventario.StockMin = Convert.ToInt32(txtStockMin.Text);
            Inventario.Existencia = Convert.ToDecimal(txtExistencia.Text);
            Inventario.UnidadEntradaID = Convert.ToInt32(cbUnidadEntrada.SelectedValue);
            Inventario.UnidadSalidaID = Convert.ToInt32(cbUnidadSalida.SelectedValue);
            Inventario.Notas = txtNotas.Text;
            //Fecha de Vencimiento
            if (IndCambioFechaVencimiento && dtpFechaVencimiento.Value!=DateTime.Now.Date)
            {
                Inventario.FechaVencimiento=dtpFechaVencimiento.Value;
            }
            //Inventario.ImagenURL = pbArticulo.ImageLocation.ToString();
            Inventario.ProveedorID1 = cbProveedor1.SelectedValue;
            Inventario.ProveedorID2 = cbProveedor2.SelectedValue;
            Inventario.AvisarVencimiento = chbNotificarVencimiento.Checked;
            Inventario.FacturarSinExistencia = chbFacturarSinExistencia.Checked;
            Inventario.Imagen = imageToByteArray(pbArticulo.Image);
            Inventario.ImpuestoID =(Int32)cbImpuesto.SelectedValue;
            Inventario.EstatusID = 1; //Articulo activo
   
          return Inventario;
        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            if (imageIn != null)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
            else
            {
                return null;
            }
        }

        

        private void btnBuscarFamilia_Click(object sender, EventArgs e)
        {

            frmListarComponentes Familias = new frmListarComponentes("Familia");
            Familias.ShowDialog(this);
        }

        private void btnBuscarMarca_Click(object sender, EventArgs e)
        {
            frmListarComponentes Marca = new frmListarComponentes("Marca");
            Marca.ShowDialog(this);
        }

        private void btnVerUnidadEntrada_Click(object sender, EventArgs e)
        {
            frmListarComponentes UnidadEntrada = new frmListarComponentes("UnidadEntrada");
            UnidadEntrada.ShowDialog(this);
        }

        private void btnVerUnidadSalida_Click(object sender, EventArgs e)
        {
            frmListarComponentes UnidadSalida = new frmListarComponentes("UnidadSalida");
            UnidadSalida.ShowDialog(this);
        }

        private void txtPrecioPublico_KeyPress(object sender, KeyPressEventArgs e)
       {
         //Evitamos que se entre un caracter que no sea numerico
           if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
           {
               e.Handled = false;
           }
           else
           {
               e.Handled = true;
           }
       }

        private void txtPrecio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtStockMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtStockMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_Validated(object sender, EventArgs e)
        {
            if (InventarioID.HasValue)
            {
                //colocamos el codigo de inventario en mayuscula
                txtCodigo.Text = txtCodigo.Text.ToUpper();
            }
            else
            {
                //colocamos el codigo de inventario en mayuscula
                txtCodigo.Text = txtCodigo.Text.ToUpper();
                InventarioBL Inventario = new InventarioBL();
                if (Inventario.Existe(txtCodigo.Text))
                {
                    MessageBox.Show("El codigo de articulo introducido existe actualmente en el inventario", "Error en codigo de inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(txtCodigo, "Codigo existente en inventario");
                    txtCodigo.Focus();
                }
                else if (txtCodigo.Text.Length < 2)
                {
                    MessageBox.Show("El campo de codigo de articulo no puede estar vacio", "Codigo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(txtCodigo, "Codigo de articulo vacio");
                    txtCodigo.Focus();
                }
                else
                    errorProvider1.Clear();
            }
        }

        private void txtDescripcion_Validated(object sender, EventArgs e)
        {
            //Convertimos la descripcion del articulo a mayuscula
            txtDescripcion.Text = txtDescripcion.Text.ToUpper();
        }

        private void btnVerAlmacenes_Click(object sender, EventArgs e)
        {
            if (InventarioID.HasValue)
            {
                Int32 ID = Convert.ToInt32(InventarioID);
                frmVerExistenciaAlmacenes ExistenciaPorAlmacen = new frmVerExistenciaAlmacenes(ID);
                ExistenciaPorAlmacen.ShowDialog(this);
            }
         
        }

        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            //Indicador de Fecha de Vencimiento
            IndCambioFechaVencimiento=true;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Title = "Abrir imagen";
            Dialog.Filter = "Archivos (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if(Dialog.ShowDialog()==DialogResult.OK)
            {
                pbArticulo.Image = new Bitmap(Dialog.FileName);
            }
        }

        

        private void cbTipoArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTipoArticulo.Text!="Fisico")
            {
                BloquearCampos();
            }

            else
            {
                HabilitarCampos();
            }
        }

       private void BloquearCampos()
        {
           //Bloquea los campos en caso de que no sea un articulo fisico
           //Existencia
           txtExistencia.Text = "0";
           txtExistencia.Enabled = false;
           //Stocks
           txtStockMax.Text = "0";
           txtStockMax.Enabled = false;
           txtStockMin.Text = "0";
           txtStockMin.Enabled = false;
           //Costo
           txtCosto.Text = "0";
           txtCosto.Enabled = false;

           //Fechas y vencimientos
           dtpFechaVencimiento.Enabled = false;
           chbFacturarSinExistencia.Enabled = false;
           chbNotificarVencimiento.Enabled = false;
          


        }

        private void HabilitarCampos()
       {
           txtExistencia.Enabled = true;
           txtStockMax.Enabled = true;
           txtStockMin.Enabled = true;
           txtCosto.Enabled = true;
           dtpFechaVencimiento.Enabled = true;
           chbFacturarSinExistencia.Enabled = true;
           chbNotificarVencimiento.Enabled = true;
       }

        private void x(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmBuscarArticuloCombo BuscarArticulo = new frmBuscarArticuloCombo();
            BuscarArticulo.ShowDialog(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                frmModificarCantidadCombo ModificarCantidad = new frmModificarCantidadCombo(ArticuloID);
                ModificarCantidad.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ArticuloID = Convert.ToInt32(dgvArticulos.Rows[e.RowIndex].Cells[1].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            RelacionCombosBL ObjetoRelacion = new RelacionCombosBL();
            int I = (int)InventarioID;
            ObjetoRelacion.Eliminar(ArticuloID, I);
            Refrescar();
        }

        private void MostrarPorcientos()
        {
            lblPorcientoPublico.Text = PorcientoGanancia(txtPrecioPublico.Text);
            lblPorcientoPrecio2.Text = PorcientoGanancia(txtPrecio2.Text);
            lblPorcientoPrecio3.Text = PorcientoGanancia(txtPrecio3.Text);
            lblPorcientoPrecio4.Text = PorcientoGanancia(txtMinimo.Text);
        }
        private void txtPrecioPublico_Validated(object sender, EventArgs e)
        {
            lblPorcientoPublico.Text=PorcientoGanancia(txtPrecioPublico.Text);
        
        }
        private void txtPrecio2_Validated(object sender, EventArgs e)
        {
            lblPorcientoPrecio2.Text = PorcientoGanancia(txtPrecio2.Text);
        }

        private void txtPrecio3_Validated(object sender, EventArgs e)
        {
            lblPorcientoPrecio3.Text = PorcientoGanancia(txtPrecio3.Text);
        }

        private void txtMinimo_Validated(object sender, EventArgs e)
        {
            lblPorcientoPrecio4.Text = PorcientoGanancia(txtMinimo.Text);
        }

        private string PorcientoGanancia(string Valor)
        {
            try
            {
                Decimal _Valor = Convert.ToDecimal(Valor);
                Decimal _Costo = Convert.ToDecimal(txtCosto.Text);
                Decimal Resultado=0;
                
                //Evitamos la division por 0
                if(_Costo==0)
                {
                    Resultado = 100;
                }
                else if (_Costo > 0)
                {
                    Resultado = Math.Round(((_Valor - _Costo) / _Costo) * 100, 2);
                }

                return Resultado.ToString() + "%";
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error al calcular porcentaje de ganancia " + Ex.Message, "Error al calcular porcentaje de ganancia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }

        private void txtStockMin_Validated(object sender, EventArgs e)
        {
            if (txtStockMax.Text == string.Empty)
            {
                errorProvider1.SetError(txtStockMin, "El campo no puede estar vacio, favor proporcionar un valor valido");
            }
            else
            {
                try
                {
                    Decimal ValorMin = Convert.ToDecimal(txtStockMin.Text);
                    Decimal ValorMax = Convert.ToDecimal(txtStockMax.Text);

                    if (ValorMax < ValorMin)
                    {
                        errorProvider1.SetError(txtStockMin, "Error, el valor minimo de inventario no puede ser mayor al valor maximo");
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }
                }
                catch (Exception Ex)
                {

                }
            }
        }

        private void txtStockMax_Validated(object sender, EventArgs e)
        {
            if (txtStockMax.Text == string.Empty)
            {
                errorProvider1.SetError(txtStockMax, "El campo no puede estar vacio, favor proporcionar un valor valido");
            }
            else
            {
                try
                {

                    Decimal ValorMin = Convert.ToDecimal(txtStockMin.Text);
                    Decimal ValorMax = Convert.ToDecimal(txtStockMax.Text);

                    if (ValorMin > ValorMax)
                    {
                        errorProvider1.SetError(txtStockMax, "Error, el valor maximo de inventario no puede ser menor al valor minimo");
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }
                }
                catch (Exception Ex)
                {

                }
            }
        }

        private void txtCosto_Validated(object sender, EventArgs e)
        {
            if(txtCosto.Text==string.Empty || (Convert.ToDecimal(txtCosto.Text))<=0)
            {
                errorProvider1.SetError(txtCosto, "El campo no puede estar vacio ni ser igual o menor a 0, favor proporcionar un valor valido");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                InventarioBL ObjetoInventario = new InventarioBL();
                ObjetoInventario.GuardarCambios(ObtenerDatos());

                if (GestionInventario != null)
                {
                    //Refresca los cambios realizados en la tabla de Inventarios 
                    GestionInventario.Actualizar();
                }
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al guardar cambios en articulo de inventario. Descripcion: " + Ex.Message, "Error al guardar cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerUnidadEntrada_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBuscarProveedor1_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor(1);
            BuscarProveedor.ShowDialog(this);
        }

        private void btnBuscarProveedor2_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor(2);
            BuscarProveedor.ShowDialog(this);
        }
    }
}
