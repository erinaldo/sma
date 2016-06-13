using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.BL;
using SMA.Entity;
using SMA.Factura;
using SMA.Inventario;
using SMA.Compras.Reportes;

namespace SMA.Compras.Ordenes
{
    public partial class frmAgregarOrdenCompra : Office2007Form, IagregarEditarRecepcion
    {
        InventarioBL ObjetoInventario = new InventarioBL();
        //Informacion del detalle de articulo
        private Int64 _Codigo;                        //Codigo de articulo DB
        private string _CodigoArticulo;             //Codigo de Articulo Inventario
        private string _Descripcion;                //Descripcion de articulo
        private Decimal _Cantidad;                   //Cantidad de Articulo Factura
        private Decimal _PrecioUnitario;             //Precio de Articulo Factura
        private Decimal _CostoUnitario;
        //private Decimal _TotalDescuentoArticulo;     //Descuento Articulo Factura
        //private Decimal _TotalImporteArticulo;       //Total Importe de Articulo
        private Decimal _TotalImpuestoArticulo;      //Total Impuesto Articulo
        private Decimal _ImporteImpuestos;           //% De impuesto aplicado a articulo
        //private Decimal _ImporteDescuento;           //% De descuento aplicado a articulo
        private Decimal _ImporteTotalArticulo;        //Importe total del articulo
        private Decimal _SubTotalArticulo;           //Subtotal articulo cantidad por Precio Unitario
        private Int32 _UnidadVentaID;                //Unidad de venta de articulo
        private String _TipoArticulo;                //Tipo de articulo segun inventario
        //Informacion de totales
        private Decimal _SubTotal;                    //Subtotal general
        private Decimal _TotalImpuestos;              //Total de Impuestos
        private Decimal _TotalDescuentos;             //Total de descuentos sobre precio de articulo 
        private Decimal _TotalGeneral; 

        public frmAgregarOrdenCompra()
        {
            InitializeComponent();
        }


        #region Implementacion de Interfaces

        public void BuscarReferencia(Int64 DocumentoID)
        {
           //NO IMPLEMENTADA
        }

        public void BusquedaProveedor(Int32 Codigo)
        {
            try
            {
                ProveedorBL ObjetoProveedor = new ProveedorBL();
                //Buscamos la direccion del cliente y el RNC mediante su codigo unico
                cProveedor Proveedor = ObjetoProveedor.BuscarPorID(Codigo);
                lblDireccion.Text = Proveedor.Direccion.ToString();
                lblRNC.Text = Proveedor.RNC.ToString();
                cbProveedor.SelectedValue = Proveedor.Codigo;
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public void BuscarArticulo(Int64 Codigo)
        {
            //Buscamos el articulo en el inventario por su codigo
            cInventario Articulo = ObjetoInventario.BuscarPorID(Codigo);
            //Asignamos los valores del resultado a los controles indicador en el formulario
            MostrarResultados(Articulo);
            //Nos posicionamos en la cantidad
            txtCantidad.Focus();
        }
        #endregion

        private void IniciarBusquedaArticulo()
        {
            try
            {
                //Formulario de Busqueda de articulos
                frmBuscarArticulos BuscarArticulo = new frmBuscarArticulos();
                BuscarArticulo.ShowDialog(this);
                txtCodigo.Focus();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private Decimal ObtenerValorImpuestos(Int32 Codigo)
        {
            //Obtenemos el valor del impuesto relacionado al producto
            try
            {
                ImpuestosBL ObjetoImpuesto = new ImpuestosBL();
                Decimal Valor = ObjetoImpuesto.BuscarPorID(Codigo).Valor;

                return Valor;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        private void MostrarResultados(cInventario Articulo)
        {

            if (Articulo.ID > 0)
            {
                try
                {
                    //Asigna el resultado de la busqueda a los controles indicados

                    txtCodigo.Text = Articulo.CodigoArticulo.ToString();
                    lblDescripcion.Text = Articulo.Descripcion;
                    txtCantidad.Text = "1";
                    txtPrecio.Text = Articulo.UltCosto.ToString();

                    //Obtenemos el valor del impuesto asignado al articulo
                    Decimal ValorImpuesto = ObtenerValorImpuestos(Convert.ToInt32(Articulo.ImpuestoID.ToString()));
                    txtImpuesto.Text = ValorImpuesto.ToString();
                    //Calculamos el importe total del articulo mas los impuestos siempre por el valor unitario.
                    txtImporteTotal.Text = ((Articulo.PrecioPublico * ((ValorImpuesto / 100) + 1)) * 1).ToString();
                    //Nos posicionamos en la cantidad
                    txtCantidad.Focus();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("La busqueda del articulo no ha arrojado ningun resultado, favor vuelva a intentarlo", "Error busqueda de articulos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Ponemos el foco en el control
                txtCodigo.Focus();
                //Limpiamos el campo
                txtCodigo.Clear();
            }
        }
        private void frmAgregarOrdenCompra_Load(object sender, EventArgs e)
        {
            CargarDependencias();
            txtImpuesto.Text = "0";
            txtCantidad.Text = "1";
        }

        private void CargarDependencias()
        {
            //Clientes
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            cbProveedor.DataSource = ObjetoProveedor.Listar();
            cbProveedor.ValueMember = "ID";
            cbProveedor.DisplayMember = "NombreComercial";
        }

        private void IniciarBusquedaProveedor()
        {
            //Formulario de Busqueda de Cliente
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor();
            BuscarProveedor.ShowDialog(this);
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            IniciarBusquedaProveedor();
        }

        private void cbProveedor_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 C;
                if (Int32.TryParse(cbProveedor.SelectedValue.ToString(), out C))
                {
                    C = Convert.ToInt32(cbProveedor.SelectedValue.ToString());
                    BuscarProveedor(C);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "Error al mostrar informacion de proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscarProveedor(int Codigo)
        {
            try
            {
                ProveedorBL ObjetoProveedor = new ProveedorBL();
                //Buscamos la direccion del cliente y el RNC mediante su codigo unico
                cProveedor Proveedor = ObjetoProveedor.BuscarPorID(Codigo);
                lblDireccion.Text = Proveedor.Direccion.ToString();
                lblRNC.Text = Proveedor.RNC.ToString();
                cbProveedor.SelectedValue = Proveedor.Codigo;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            IniciarBusquedaArticulo();
        }

        private void txtCodigo_Validated(object sender, EventArgs e)
        {
            //Buscamos el articulo por el codigo digitado por el usuario
            if (txtCodigo.Text.Length > 0)
            {
                BuscarArticulo(txtCodigo.Text);
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void BuscarArticulo(String CodigoArticulo)
        {
            //Buscamos el articulo en el inventario por su codigo de articulo
            cInventario Articulo = ObjetoInventario.BuscarPorID(CodigoArticulo);
            //Verificamos el resultado de la busqueda
            Int32 IX;
            if (Int32.TryParse(Articulo.ID.ToString(), out IX))
            {
                //Mostramos los valores del resultado a los controles indicador en el formulario
                MostrarResultados(Articulo);
            }
            else
            {
                //Si el resultado es nulo entonces arrojamos el mensaje de error y limpiamos los campos
                MessageBox.Show("El articulo digitado no puedo se encontrado, vuelva a intentarlo", "Error en busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                txtCodigo.Focus();
            }

        }

        private void LimpiarCampos()
        {
            //Limpia todos los controles 
            txtCodigo.Clear();
            lblDescripcion.Text = "";
            txtCantidad.Text = "1.00";
            txtPrecio.Text = "0.00";
            txtImpuesto.Text = "0.00";
            txtImporteTotal.Text = "0.00";
        }

        private void txtCantidad_Validated(object sender, EventArgs e)
        {
            CalcularImportes(txtImpuesto.Text, txtPrecio.Text);
        }

        private void CalcularImportes(String _Impuesto, String _Precio)
        {

            //Double Descuento = Convert.ToDouble(_Descuento);
            Decimal Precio = Convert.ToDecimal(_Precio);
            Decimal Impuesto = Convert.ToDecimal(_Impuesto);
            Decimal Cantidad = Convert.ToDecimal(txtCantidad.Text);
            //Calculamos los importes relacionados al articulo.
            txtImpuesto.Text = Impuesto.ToString();
            //Calculamos el importe total del articulo mas los impuestos siempre por el valor unitario.
            Decimal Subtotal = (Precio * Cantidad);
            //double Descontar = (Subtotal * (Descuento / 100));
            Decimal ImpuestoTotal = Subtotal * (Impuesto / 100);
            txtImporteTotal.Text = ((Subtotal) + (ImpuestoTotal)).ToString();
        }

        private void txtPrecio_Validated(object sender, EventArgs e)
        {
            CalcularImportes(txtImpuesto.Text, txtPrecio.Text);
        }

        private void txtImpuesto_Validated(object sender, EventArgs e)
        {
            CalcularImportes(txtImpuesto.Text, txtPrecio.Text);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AsignarValores(ObjetoInventario.BuscarPorID(txtCodigo.Text));
            if (_Codigo > 0)
            {
                dgvDetalleFactura.Rows.Add(_Codigo, _CodigoArticulo, _Descripcion, _Cantidad, _PrecioUnitario, _ImporteImpuestos, _TotalImpuestoArticulo, _ImporteTotalArticulo, _CostoUnitario, _UnidadVentaID, _TipoArticulo);
                ActualizarMontos();
                LimpiarCampos();
                txtCodigo.Focus();
            }
            else
            {
                MessageBox.Show("Error, debe proporcionar un articulo para ser incluido en la factura", "Error insertando articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private void AsignarValores(cInventario Articulo)
        {
            try
            {
                //Guardamos los resultados del articulo a facturar
                _Codigo = Articulo.ID;
                _CodigoArticulo = Articulo.CodigoArticulo;
                _Descripcion = Articulo.Descripcion;
                _Cantidad = Convert.ToDecimal(txtCantidad.Text);
                _PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                _CostoUnitario = Articulo.UltCosto;
                //_ImporteDescuento = Convert.ToDouble(txtDescuento.Text);
                //_TotalDescuentoArticulo = _PrecioUnitario * (_ImporteDescuento / 100); //Total de valor a descontarse
                _ImporteImpuestos = Convert.ToDecimal(txtImpuesto.Text);                 //Importe de Impuestos
                _TotalImpuestoArticulo = (_PrecioUnitario * _Cantidad) * (_ImporteImpuestos / 100); //Total de valor a cobrarse de impuesto
                _SubTotalArticulo = _Cantidad * _PrecioUnitario;                        //Subtotal de articulo
                _ImporteTotalArticulo = _SubTotalArticulo + _TotalImpuestoArticulo;
                _TipoArticulo = Articulo.TipoArticulo;
                _UnidadVentaID = Convert.ToInt32(Articulo.UnidadEntradaID.ToString());
            }
            catch (Exception Ex)
            {

            }

        }

        private void ActualizarMontos()
        {
            //Actualizaciones de montos
            Decimal SubtotalAcumulado = 0;   //Variable acumulativa para los subtotales para articulos
            Decimal ImpuestoAcumulado = 0;  //Variable acumulativa para el impuesto de los articulos
            Decimal DescuentoAcumulado = 0;  //Variable acumulativa para el descuento de los articulo

            //-----------------------------------------------------------------------
            Decimal SubTotal = 0;             //Variable final para el valor de subtotal
            Decimal TotalImpuesto = 0;       //Variable final para el valor total del impuesto
            Decimal TotalDescuento = 0;      //Variable final para el valor total de descuentos
            Decimal TotalTransaccion = 0;    //Variable final de total de transaccion de la factura



            foreach (DataGridViewRow row in dgvDetalleFactura.Rows)
            {
                Decimal ImpuestoArticulo = Convert.ToDecimal(row.Cells[5].Value) / 100;
                //Double DescuentoArticulo = Convert.ToDecimal(row.Cells[7].Value) / 100;
                //-----------------------------------------------------------------------------------------------------------
                Decimal SubtotalArticulo = Convert.ToDecimal(row.Cells[3].Value) * Convert.ToDecimal(row.Cells[4].Value);
                //Double SubtotalDescuento = SubtotalArticulo * DescuentoArticulo;
                //-----------------------------------------------------------------------------------------------------------
                SubtotalAcumulado = SubtotalAcumulado + SubtotalArticulo;
                ImpuestoAcumulado = ((SubtotalAcumulado) * (ImpuestoArticulo));
                //DescuentoAcumulado = (SubtotalAcumulado * (1 + DescuentoArticulo)) - SubtotalAcumulado;
                //-----------------------------------------------------------------------------------------------------------
                SubTotal = SubtotalAcumulado;
                TotalImpuesto = ImpuestoAcumulado;
                //TotalDescuento = DescuentoAcumulado;
                TotalTransaccion = TotalImpuesto + (SubTotal - TotalDescuento);
            }

            //Mostramos los resultados de las transacciones
            lblSubTotal.Text = SubTotal.ToString("C2");
            lblImpuesto.Text = TotalImpuesto.ToString("C2");
            //lblDescuento.Text = TotalDescuento.ToString("C2");
            lblTotalTrasaccion.Text = TotalTransaccion.ToString("C2");

            //Guardamos los valores acumulados 
            _SubTotal = SubTotal;
            _TotalImpuestos = ImpuestoAcumulado;
            _TotalDescuentos = DescuentoAcumulado;
            _TotalGeneral = TotalTransaccion;
        }

        private void btnEliminarLinea_Click(object sender, EventArgs e)
        {
            if (dgvDetalleFactura.RowCount > 0)
            {
                Int32 i = dgvDetalleFactura.CurrentRow.Index;
                dgvDetalleFactura.Rows.RemoveAt(i);
                ActualizarMontos();
            }
        }

        private void btnVerProducto_Click(object sender, EventArgs e)
        {
            frmVerArticulo VerArticulo = new frmVerArticulo(ArticuloSeleccionado());
            VerArticulo.ShowDialog(this);
        }

        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            //Agrega un nuevo articulo.
            frmAgregarEditarInventario AgregarArticulo = new frmAgregarEditarInventario();
            AgregarArticulo.ShowDialog();
        }

        private Int32 ArticuloSeleccionado()
        {
            //Buscamos el codigo de articulo que es seleccionado
            Int32 ArticuloID;

            if (Int32.TryParse(dgvDetalleFactura.CurrentRow.Cells[0].Value.ToString(), out ArticuloID))
            {
                ArticuloID = Convert.ToInt32(dgvDetalleFactura.CurrentRow.Cells[0].Value.ToString());
                return ArticuloID;
            }
            else
            {
                return -1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //Verificamos que la factura tenga elementos en el detalle
                if (dgvDetalleFactura.RowCount > 0)
                {

                    ComprasBL ObjetoCompra = new ComprasBL();
                    //Numero de Factura Generada
                    Int32 FacturaID = Convert.ToInt32(ObjetoCompra.Crear(ObtenerOrden()));

                    //Insertamos el detalle de factura
                    if (FacturaID != -1)
                    {
                        try
                        {
                            //Insertamos el detalle de la factura
                            InsertarDetalle(FacturaID);
                            //Mostramos el modulo de pagos
                            frmRptOrdenCompra ImpresionOrden = new frmRptOrdenCompra(FacturaID);
                            ImpresionOrden.ShowDialog(this);
                            //frmPagoFactura PagarFactura = new frmPagoFactura(FacturaID, _TotalGeneral);
                            //PagarFactura.ShowDialog(this);
                            //Inhabilitamos el boton de guardar para evitar que se guarde nuevamente la factura;
                            btnGuardar.Enabled = false;
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message, "Error en facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error en la recepcion", "Error al crear recepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                else
                {
                    MessageBox.Show("Debe agregar elementos a la presente recepcion", "Error en Recepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarBusquedaArticulo();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error en Recepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private cCompras ObtenerOrden()
        {
            cCompras Compra = new cCompras();
            Compra.ProveedorID = cbProveedor.SelectedValue;
            Compra.EstatusID = "O";
            Compra.TipoDocumento = "O";
            Compra.FechaEnvio = dtpFechaFactura.Value;
            Compra.FechaCreacion = dtpFechaFactura.Value;
            Compra.FechaVencimiento = dtpFechaVencimiento.Value;
            Compra.CondicionVenta = ObtenerCondiciones();
            Compra.DireccionEnvio = txtEnviar.Text;
            Compra.ImpuestosTotal = _TotalImpuestos;
            Compra.Observacion = txtObservaciones.Text;
            Compra.SubTotal = _SubTotal;
            Compra.TotalGeneral = _TotalGeneral;
            Compra.NCF = String.Empty;

            return Compra;
        }

        private object ObtenerCondiciones()
        {
            //Obtenemos las condiciones de venta del documento
            if (rbCredito.Checked)
            {
                //Credito
                return "CE";
            }
            else
            {
                //Contado
                return "CO";
            }

        }

        private void InsertarDetalle(Int32 CompraID)
        {
            //Obtenemos el detalle de las facturas creadas.       

            List<cDetalleCompra> ListaDetalleCompra = new List<cDetalleCompra>();
            foreach (DataGridViewRow row in dgvDetalleFactura.Rows)
            {
                cDetalleCompra Detalle = new cDetalleCompra();
                Detalle.CompraID = CompraID;
                Detalle.TipoDocumento = "O";
                Detalle.ArticuloID = Convert.ToInt32(row.Cells[0].Value);
                Detalle.Precio = Convert.ToDecimal(row.Cells[4].Value);
                Detalle.Cantidad = Convert.ToDecimal(row.Cells[3].Value);
                Detalle.ImpuestoValor = Convert.ToDecimal(row.Cells[5].Value);
                Detalle.UnidadCompraID = Convert.ToInt32(row.Cells[9].Value);
                Detalle.TipoProducto = row.Cells[10].Value.ToString();

                ListaDetalleCompra.Add(Detalle);
            }
            DetalleCompraBL ObjetoDetalleCompra = new DetalleCompraBL();
            ObjetoDetalleCompra.Crear(ListaDetalleCompra);

        }

    }
}
