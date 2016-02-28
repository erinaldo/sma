﻿using System;
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

namespace SMA.Compras.Devoluciones
{
    public partial class frmAgregarDevolucionCompra : Office2007Form, IagregarEditarRecepcion
    {
        //Informacion del detalle de articulo
        private Int64 _Codigo;                        //Codigo de articulo DB
        private string _CodigoArticulo;             //Codigo de Articulo Inventario
        private string _Descripcion;                //Descripcion de articulo
        private Decimal _Cantidad;                   //Cantidad de Articulo Factura
        private Decimal _PrecioUnitario;             //Precio de Articulo Factura
        private Decimal _CostoUnitario;
        private Decimal _TotalDescuentoArticulo;     //Descuento Articulo Factura
        private Decimal _TotalImporteArticulo;       //Total Importe de Articulo
        private Decimal _TotalImpuestoArticulo;      //Total Impuesto Articulo
        private Decimal _ImporteImpuestos;           //% De impuesto aplicado a articulo
        private Decimal _ImporteDescuento;           //% De descuento aplicado a articulo
        private Decimal _ImporteTotalArticulo;        //Importe total del articulo
        private Decimal _SubTotalArticulo;           //Subtotal articulo cantidad por Precio Unitario
        private Int32 _UnidadVentaID;                //Unidad de venta de articulo
        private String _TipoArticulo;                //Tipo de articulo segun inventario
        //Informacion de totales
        private Decimal _SubTotal;                    //Subtotal general
        private Decimal _TotalImpuestos;              //Total de Impuestos
        private Decimal _TotalDescuentos;             //Total de descuentos sobre precio de articulo 
        private Decimal _TotalGeneral;                //Total General Factura
        InventarioBL ObjetoInventario = new InventarioBL();

        public frmAgregarDevolucionCompra()
        {
            InitializeComponent();
        }
        #region Implementacion de Interfaces

        public void BuscarReferencia(Int64 DocumentoID)
        {
            //Buscamos y mostramos la informacion referente a un documento tipo cotizacion
            txtReferencia.Text = DocumentoID.ToString();
            BuscarRecepcion();

        }

        public void BusquedaProveedor(Int64 Codigo)
        {
            try
            {
                ProveedorBL ObjetoProveedor = new ProveedorBL();
                //Buscamos la direccion del cliente y el RNC mediante su codigo unico
                cProveedor Proveedor = ObjetoProveedor.BuscarPorID(Codigo);
                lblDireccion.Text = Proveedor.Direccion.ToString();
                lblRNC.Text = Proveedor.RNC.ToString();
                cbProveedor.SelectedValue = Proveedor.ID;
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
        #region Procedimientos y funciones

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
                    //Double ValorImpuesto = Convert.ToDouble();
                    //Calculamos el importe total del articulo mas los impuestos siempre por el valor unitario.
                    //txtImporteTotal.Text = ((Articulo.PrecioPublico * ((ValorImpuesto / 100) + 1)) * 1).ToString();
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

        private void InsertarDetalle(Int64 CompraID)
        {
            //Obtenemos el detalle de las facturas creadas.       

            List<cDetalleCompra> ListaDetalleCompra = new List<cDetalleCompra>();
            foreach (DataGridViewRow row in dgvDetalleFactura.Rows)
            {
                cDetalleCompra Detalle = new cDetalleCompra();
                Detalle.CompraID = CompraID;
                Detalle.TipoDocumento = "D";
                Detalle.ArticuloID = Convert.ToInt64(row.Cells[0].Value);
                Detalle.Precio = Convert.ToDecimal(row.Cells[4].Value);
                Detalle.Cantidad = Convert.ToDecimal(row.Cells[3].Value);
                Detalle.ImpuestoValor = Convert.ToDecimal(row.Cells[5].Value);
                Detalle.UnidadCompraID = Convert.ToInt32(row.Cells[8].Value);
                Detalle.TipoProducto = row.Cells[9].Value.ToString();

                ListaDetalleCompra.Add(Detalle);
            }
            DetalleCompraBL ObjetoDetalleCompra = new DetalleCompraBL();
            ObjetoDetalleCompra.Crear(ListaDetalleCompra);

        }


        private cCompras ObtenerDevolucion()
        {
            try
            {
                cCompras Compra = new cCompras();
                Compra.ProveedorID = cbProveedor.SelectedValue;
                Compra.EstatusID = "O";
                Compra.TipoDocumento = "D";
                Compra.FechaEnvio = dtpFechaFactura.Value;
                Compra.FechaCreacion = dtpFechaFactura.Value;
                Compra.FechaVencimiento = dtpFechaFactura.Value;
                Compra.CondicionVenta = "NA";
                Compra.DireccionEnvio = "NA";
                Compra.Referencia = ObtenerReferencia();
                Compra.ImpuestosTotal = _TotalImpuestos;
                Compra.Observacion = txtObservaciones.Text;
                Compra.SubTotal = _SubTotal;
                Compra.TotalGeneral = _TotalGeneral;
                Compra.NCF = String.Empty;

                return Compra;
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private int ObtenerReferencia()
        {
            if (txtReferencia.Text != String.Empty)
            {
                Int32 Codigo;
                if (Int32.TryParse(txtReferencia.Text, out Codigo))
                {
                    return Convert.ToInt32(txtReferencia.Text);
                }
                else
                {
                    throw new Exception("Error al obtener referencia");
                }
            }
            else
            {
                return -1;
            }
        }

        private void MostrarResultados(List<cDetalleCompra> ListaArticulos)
        {
            InventarioBL ObjetoInventario = new InventarioBL();

            //Ajustamos la lista para el primer articulo
            cDetalleCompra Articulo = ListaArticulos.FirstOrDefault();
            try
            {
                cInventario InformacionArticulo = ObjetoInventario.BuscarPorID(Articulo.ArticuloID);
                //Asigna el resultado de la busqueda a los controles indicados

                txtCodigo.Text = InformacionArticulo.CodigoArticulo;
                lblDescripcion.Text = InformacionArticulo.Descripcion;
                txtCantidad.Text = Articulo.Cantidad.ToString();
                txtPrecio.Text = Articulo.Precio.ToString();

                //Obtenemos el valor del impuesto asignado al articulo
                Decimal ValorImpuesto = Articulo.ImpuestoValor;
                txtImpuesto.Text = ValorImpuesto.ToString();
                //Calculamos el importe total del articulo mas los impuestos siempre por el valor unitario.
                txtImporteTotal.Text = ((Articulo.Precio * ((ValorImpuesto / 100) + 1)) * 1).ToString();
                //Nos posicionamos en la cantidad
                txtCantidad.Focus();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
           

        private Int64 ObtenerDocumentoReferencia()
        {
            if (txtReferencia.Text != String.Empty || txtReferencia.Text != "")
            {
                Int64 Codigo;
                if (Int64.TryParse(txtReferencia.Text, out Codigo))
                {
                    return Convert.ToInt64(txtReferencia.Text);
                }
                else
                {
                    throw new Exception("Se requiere un numero de Factura para poder realizar devolucion");
                }
            }
            else
            {
                throw new Exception("Se requiere un numero de Factura para poder realizar devolucion");
            }
        }

        private Boolean ValidacionArticuloAgregado(String CodigoArticulo)
        {
            //VALIDA QUE EL ARTICULO DIGITADO NO EXISTE EN EL GRID
            Int32 Conteo=0;

            //Verificamos que el articulo no existe actualmente en el grid
            foreach (DataGridViewRow row in dgvDetalleFactura.Rows)
            {
                String ArticuloEnGrid=row.Cells[1].Value.ToString();
                if(CodigoArticulo.ToUpper()==ArticuloEnGrid.ToUpper())
                {
                    //Incrimentamos el contador en uno cada vez que encuentre un articulo igual al digitado
                    Conteo=Conteo+1;
                }
                
            }

            //Si el codigo del articulo existe devolvemos un valor positivo
            if(Conteo>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void BuscarArticulo(String CodigoArticulo)
        {
            try
            {
                DetalleCompraBL ObjetoDetalle = new DetalleCompraBL();

                //Buscamos el articulo en el inventario por su codigo de articulo
                List<cDetalleCompra> ListaArticulos = ObjetoDetalle.ListarDetalleDevolucion(CodigoArticulo, ObtenerDocumentoReferencia());
                //Verificamos el resultado de la busqueda
                //Int32 IX;
                if (ListaArticulos.Count > 0)
                {
                    if (ValidacionArticuloAgregado(CodigoArticulo))
                    {
                        LimpiarCampos();
                        throw new Exception("El articulo ya existe en la factura, favor revisar y volver a intentarlo");
                    }
                    else
                    {
                        //Mostramos los valores del resultado a los controles indicador en el formulario
                        MostrarResultados(ListaArticulos);
                    }
                }
                else
                {
                    //Si el resultado es nulo entonces arrojamos el mensaje de error y limpiamos los campos
                    MessageBox.Show("El articulo digitado no puedo se encontrado, vuelva a intentarlo", "Error en busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                    txtCodigo.Focus();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Error en la busqueda",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void InsertarLineaGrid(Int64 Codigo,
                                       String CodigoArticulo,
                                       String Descripcion,
                                       Decimal Cantidad,
                                       Decimal PrecioUnitario,
                                       Decimal ImporteImpuestos,
                                       Decimal TotalImpuestoArticulo,
                                       Decimal ImporteTotalArticulo,
                                       int UnidadCompraID,
                                       String TipoArticulo)
        {

            //Insertar nueva linea en el DataGridView
            dgvDetalleFactura.Rows.Add(Codigo, CodigoArticulo, Descripcion, Cantidad, PrecioUnitario, ImporteImpuestos, TotalImpuestoArticulo, ImporteTotalArticulo, UnidadCompraID, TipoArticulo);
            ActualizarMontos();
            LimpiarCampos();
            txtCodigo.Focus();

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
                //Decimal DescuentoArticulo = Convert.ToDecimal(row.Cells[7].Value) / 100;
                //-----------------------------------------------------------------------------------------------------------
                Decimal SubtotalArticulo = Convert.ToDecimal(row.Cells[3].Value) * Convert.ToDecimal(row.Cells[4].Value);
               // Double SubtotalDescuento = SubtotalArticulo * DescuentoArticulo;
                //-----------------------------------------------------------------------------------------------------------
                SubtotalAcumulado = SubtotalAcumulado + SubtotalArticulo;
                ImpuestoAcumulado = (SubtotalAcumulado) * (ImpuestoArticulo);
                
                //-----------------------------------------------------------------------------------------------------------
                SubTotal = SubtotalAcumulado;
                TotalImpuesto = ImpuestoAcumulado;
                TotalDescuento = DescuentoAcumulado;
                TotalTransaccion = TotalImpuesto + (SubTotal);
            }

            //Mostramos los resultados de las transacciones
            lblSubTotal.Text = SubTotal.ToString("C2");
            lblImpuesto.Text = TotalImpuesto.ToString("C2");
            
            lblTotalTrasaccion.Text = TotalTransaccion.ToString("C2");

            //Guardamos los valores acumulados 
            _SubTotal = SubTotal;
            _TotalImpuestos = ImpuestoAcumulado;
            _TotalDescuentos = DescuentoAcumulado;
            _TotalGeneral = TotalTransaccion;
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

        private void AsignarDatosProveedor(cProveedor Proveedor)
        {
            try
            {
                lblDireccion.Text = Proveedor.Direccion.ToString();
                lblRNC.Text = Proveedor.RNC.ToString();
                cbProveedor.SelectedValue = Proveedor.ID;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CargarDependencias()
        {
            //Clientes
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            cbProveedor.DataSource = ObjetoProveedor.Listar();
            cbProveedor.ValueMember = "ID";
            cbProveedor.DisplayMember = "NombreComercial";
        }

        private void BuscarRecepcion()
        {
            DetalleCompraBL ObjetoDetalle = new DetalleCompraBL();
            ComprasBL ObjetoFactura = new ComprasBL();
            ProveedorBL ObjetoProveedor = new ProveedorBL();

            Int64 ID;
            if (txtReferencia.Text != String.Empty)
            {
                //Obtenemos el ID del Documento por medio del numero de documento
                ID = Convert.ToInt64(txtReferencia.Text);

                //Buscamos la cotizacion que tiene este numero de documento
                cCompras Factura = ObjetoFactura.BuscarPorID(ID, "R");
                //Verificamos que obtuvimos algun resultado
                if (Int64.TryParse(Factura.ID.ToString(), out ID))
                {
                    //Validamos que la recepcion no tenga el estatus de devuelta
                    if (Factura.EstatusID.ToString() == "O")
                    {
                        //Guardamos el ID de la FacturA
                        Int64 FacturaID = Factura.ID;
                        Int64 ProveedorID = Convert.ToInt64(Factura.ProveedorID);

                        //Asignamos los datos del cliente que se encuentra en la cotizacion
                        AsignarDatosProveedor(ObjetoProveedor.BuscarPorID(ProveedorID));

                        //Buscamos la lista de Articulos que se encuentran en la cotizacion
                        List<cDetalleCompra> ListaDetalle = ObjetoDetalle.ListarDetalle(FacturaID, "R");

                        //Objeto Inventario para realizar operaciones
                        InventarioBL ObjetoInventario = new InventarioBL();
                        foreach (cDetalleCompra Detalle in ListaDetalle)
                        {
                            cInventario Articulo = ObjetoInventario.BuscarPorID(Detalle.ArticuloID);

                            //Insertamos los articulos en el DataGrid
                            InsertarLineaGrid(Detalle.ArticuloID,
                                                     Articulo.CodigoArticulo,
                                                     Articulo.Descripcion,
                                                     Detalle.Cantidad,
                                                     Detalle.Precio,
                                                     Detalle.ImpuestoValor,
                                                     (Detalle.ImpuestoValor / 100) * Detalle.Precio,
                                                     ((Detalle.Cantidad * Detalle.Precio) + ((Detalle.ImpuestoValor / 100) * Detalle.Precio)),
                                                     Detalle.UnidadCompraID,
                                                     Detalle.TipoProducto);

                        }

                    }
                    else
                    {
                        //Documento Cancelado
                        if (Factura.EstatusID.ToString() == "C")
                        {
                            MessageBox.Show("El documento se encuentra Cancelado, Operacion invalida", "Error en busqueda de recepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //Documento Devuelto
                        else if (Factura.EstatusID.ToString() == "D")
                        {
                            MessageBox.Show("El documento ya fue devuelto, Operacion Invalida", "Error en busqueda de recepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
               
            }
     
    
        }

        #endregion

        

        private void frmAgregarDevolucionCompra_Load(object sender, EventArgs e)
        {
            CargarDependencias();
        }

        private void txtReferencia_Validated(object sender, EventArgs e)
        {
            dgvDetalleFactura.Rows.Clear();
            BuscarRecepcion();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //Verificamos que la factura tenga elementos en el detalle
                if (dgvDetalleFactura.RowCount > 0)
                {

                    ComprasBL ObjetoCompra = new ComprasBL();
                    //Numero de Factura Generada
                    Int64 FacturaID = Convert.ToInt64(ObjetoCompra.Crear(ObtenerDevolucion()));

                    //Insertamos el detalle de factura
                    if (FacturaID != -1)
                    {
                        try
                        {
                            //Insertamos el detalle de la factura
                            InsertarDetalle(FacturaID);
                            //Mostramos el modulo de pagos
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

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaRecepciones = new frmListaDocumento("R");
            ListaRecepciones.ShowDialog(this);

        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            IniciarBusquedaArticulo();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            IniciarBusquedaProveedor();
        }

        
        private void IniciarBusquedaProveedor()
        {
            //Formulario de Busqueda de Cliente
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor();
            BuscarProveedor.ShowDialog(this);
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
                //_CostoUnitario = Articulo.UltCosto;
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
                MessageBox.Show(Ex.Message);
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AsignarValores(ObjetoInventario.BuscarPorID(txtCodigo.Text));
            if (_Codigo > 0)
            {
                dgvDetalleFactura.Rows.Add(_Codigo, _CodigoArticulo, _Descripcion, _Cantidad, _PrecioUnitario, _ImporteImpuestos, _TotalImpuestoArticulo, _ImporteTotalArticulo, _UnidadVentaID, _TipoArticulo);
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

        private void txtCantidad_Validated(object sender, EventArgs e)
        {

        }
    }
}
