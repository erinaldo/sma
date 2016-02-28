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

namespace SMA.Factura.Devolucion
{
    public partial class frmAgregarDevolucion : Office2007Form,IagregarEditarFacturas
    {
        InventarioBL ObjetoInventario = new InventarioBL();
        ClienteBL ObjetoCliente = new ClienteBL();
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


        public frmAgregarDevolucion()
        {
            InitializeComponent();
        }

        #region Implementacion de Interface
        public void BuscarReferencia(Int64 DocumentoID)
        {
            try
            {
                //Buscamos y mostramos la informacion referente a un documento tipo Factura
                txtReferencia.Text = DocumentoID.ToString();
                BuscarFactura();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error en busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscarArticulo(Int64 Codigo)
        {
            //Buscamos el articulo en inventario
            cInventario Articulo = ObjetoInventario.BuscarPorID(Codigo);

            //Detalle de Factura
            DetalleFacturaBL ObjetoDetalle = new DetalleFacturaBL();

            //Buscamos el articulo en la factura seleccionada
            List<cDetalleFactura> ListaArticulos = ObjetoDetalle.ListarDetalleDevolucion(Articulo.CodigoArticulo, ObtenerDocumentoReferencia());
            //Verificamos el resultado de la busqueda
            Int32 IX;
            if (ListaArticulos.Count > 0)
            {
                //Mostramos los valores del resultado a los controles indicador en el formulario
                MostrarResultados(ListaArticulos);
                txtCantidad.Focus();
            }
            
            
        }

        public void BusquedaCliente(Int64 Codigo)
        {
            try
            {
                ClienteBL ObjetoCliente = new ClienteBL();
                //Buscamos la direccion del cliente y el RNC mediante su codigo unico
                cCliente Cliente = ObjetoCliente.BuscarPorID(Codigo);
                AsignarDatosCliente(Cliente);
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        


        #endregion


        #region Procedimientos y Funciones

        private int ObtenerReferencia()
        {
            //Obtenemos el codigo de referencia de nuestra factura
            int Codigo;
            if (txtReferencia.Text != String.Empty)
            {
                if (int.TryParse(txtReferencia.Text, out Codigo))
                {
                    return Convert.ToInt32(txtReferencia.Text);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        private cFactura ObtenerFactura()
        {
            //Obtenemos los datos de la factura a ser agregada
            FacturaBL ObjetoFactura = new FacturaBL();
            cFactura Factura = new cFactura();
            Factura.ClienteID = cbbCliente.SelectedValue;
            Factura.TipoDocumento = "D";
            Factura.CondicionVenta = "NA";
            //Obtenemos el ultimo documento del tipo Factura
            //Factura.DocumentoID = ObjetoFactura.ControlDocumento("F");
            Factura.DescuentoTotal = _TotalDescuentos;
            Factura.DireccionEnvio = txtEnviarA.Text;
            Factura.EstatusID = "O";
            Factura.FechaCreacion = DateTime.Now.Date;
            Factura.FechaEnvio = dtpFechaEnvio.Value.Date;
            Factura.ImpuestosTotal = _TotalImpuestos;
            Factura.Observacion = txtObservaciones.Text;
            Factura.SubTotal = _SubTotal;
            Factura.TotalGeneral = _TotalGeneral;
            Factura.FechaVencimiento = dtpFechaVencimiento.Value.Date;
            Factura.VendedorID = ObtenerVendedor();
            Factura.Referencia = ObtenerReferencia();
            return Factura;
        }

        private void AsignarNCF(Int32 FacturaID)
        {
            if (chbGenerarComprobante.Checked)
            {
                AsignacionNCFBL ObjetoAsignacion = new AsignacionNCFBL();
                cAsigancionNCF Asignacion = new cAsigancionNCF();
                Asignacion.FacturaID = FacturaID;
                Asignacion.ComprobanteID = ObtenerTipoComprobante();
                Asignacion.FechaAsignacion = DateTime.Now.Date;

                //Agregamos los datos del comprobante
                ObjetoAsignacion.Crear(Asignacion);
            }
        }

        private Int32 ObtenerVendedor()
        {
            try
            {
                //Obtenemos el codigo del vendedor
                Int32 Codigo;
                if (Int32.TryParse(cbVendedor.SelectedValue.ToString(), out Codigo))
                {
                    return Convert.ToInt32(cbVendedor.SelectedValue.ToString());
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }


        private void InsertarDetalle(Int32 FacturaID)
        {
            //Obtenemos el % de Comision del vendedor
            VendedorBL ObjetoVendedor = new VendedorBL();
            Decimal Comision = ObjetoVendedor.BuscarPorID(ObtenerVendedor()).Comision;

            //Obtenemos el detalle de las facturas creadas.       

            List<cDetalleFactura> ListaDetalleFactura = new List<cDetalleFactura>();
            foreach (DataGridViewRow row in dgvDetalleFactura.Rows)
            {
                cDetalleFactura Detalle = new cDetalleFactura();
                Detalle.FacturaID = FacturaID;
                Detalle.TipoDocumento = "D";
                Detalle.ArticuloID = Convert.ToInt64(row.Cells[0].Value);
                Detalle.Precio = Convert.ToDecimal(row.Cells[4].Value);
                Detalle.Cantidad = Convert.ToDecimal(row.Cells[3].Value);
                Detalle.Costo = Convert.ToDecimal(row.Cells[10].Value);
                Detalle.ImpuestoValor = Convert.ToDecimal(row.Cells[5].Value);
                Detalle.DescuentoValor = Convert.ToDecimal(row.Cells[7].Value);
                Detalle.UnidadVentaID = Convert.ToInt32(row.Cells[11].Value);
                Detalle.TipoProducto = row.Cells[12].Value.ToString();
                Detalle.ValorComision = (Convert.ToDecimal(Comision) * (Convert.ToDecimal(row.Cells[4].Value)));
                Detalle.ComisionVenta = Comision;

                ListaDetalleFactura.Add(Detalle);
            }
            DetalleFacturaBL ObjetoDetalleFactura = new DetalleFacturaBL();
            ObjetoDetalleFactura.Crear(ListaDetalleFactura);

        }


        private Int32 ObtenerTipoComprobante()
        {
            if (chbGenerarComprobante.Checked)
            {
                //El tipo de comprobante para notas de credito
                return 5;
            }
            else
            {
                return -1;
            }
        }

        private void InsertarDetalle()
        {
            InsertarLineaGrid(_Codigo,
                              _CodigoArticulo,
                              _Descripcion,
                              _Cantidad,
                              _PrecioUnitario,
                              _ImporteImpuestos,
                              _TotalImpuestoArticulo,
                              _ImporteDescuento,
                              _TotalDescuentoArticulo,
                              _ImporteTotalArticulo,
                              _CostoUnitario,
                              _UnidadVentaID,
                              _TipoArticulo);

        }


        private void AsignarValores(cDetalleFactura Detalle)
        {
            cInventario Articulo = ObjetoInventario.BuscarPorID(Detalle.ArticuloID);
            try
            {
                //Guardamos los resultados del articulo a facturar
                _Codigo = Articulo.ID;
                _CodigoArticulo = Articulo.CodigoArticulo;
                _Descripcion = Articulo.Descripcion;
                _Cantidad = Convert.ToDecimal(txtCantidad.Text);
                _PrecioUnitario = Detalle.Precio;
                _CostoUnitario = Detalle.Costo;
                _ImporteDescuento = Detalle.DescuentoValor;
                _TotalDescuentoArticulo = _PrecioUnitario * (_ImporteDescuento / 100); //Total de valor a descontarse
                _ImporteImpuestos = Detalle.ImpuestoValor;                 //Importe de Impuestos
                _TotalImpuestoArticulo = (_PrecioUnitario * _Cantidad) * (_ImporteImpuestos / 100); //Total de valor a cobrarse de impuesto
                _SubTotalArticulo = _Cantidad * _PrecioUnitario;                        //Subtotal de articulo
                _ImporteTotalArticulo = (_SubTotalArticulo - _TotalDescuentoArticulo) + _TotalImpuestoArticulo;
                _TipoArticulo = Detalle.TipoProducto;
                _UnidadVentaID = Detalle.UnidadVentaID;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }


        private Boolean ValidacionCantidad()
        {
            //Valida si la cantidad introducida es mayor a la cantidad disponible para devolucion
            cDetalleFactura DetalleFactura;
            DetalleFacturaBL ObjetoDetalle = new DetalleFacturaBL();

            //Lista de Articulos Asociados a la factura
            DetalleFactura = ObjetoDetalle.ListarDetalleDevolucion(txtCodigo.Text, ObtenerDocumentoReferencia()).FirstOrDefault();

            //Cantidad de Articulos a devolver
            Int32 CantidadDevuelta = ObtenerCantidad();

            if(CantidadDevuelta>DetalleFactura.Cantidad)
            {
                return false;
            }
            else
            {
                return true;
            }

            

        }

        private int ObtenerCantidad()
        {
            Int32 Cantidad;
            if(Int32.TryParse(txtCantidad.Text, out Cantidad))
            {
                return Convert.ToInt32(txtCantidad.Text);
            }
            else
            {
                throw new Exception("Error al obtener cantidad de articulos a devolver");
            }
        }

       

        private void BuscarFactura()
        {
            DetalleFacturaBL ObjetoDetalle = new DetalleFacturaBL();
            FacturaBL ObjetoFactura = new FacturaBL();
            Int64 ID;
            if (txtReferencia.Text != String.Empty)
            {
                //Obtenemos el ID del Documento por medio del numero de documento
                ID = Convert.ToInt64(txtReferencia.Text);

                //Buscamos la cotizacion que tiene este numero de documento
                cFactura Factura = ObjetoFactura.BuscarPorID(ID, "F");
                //Verificamos que obtuvimos algun resultado
                if (Int64.TryParse(Factura.ID.ToString(), out ID))
                {
                    //Verificamos que la factura no este cancelada ni se encuentre devuelta
                    if (Factura.EstatusID.ToString() != "C" && Factura.EstatusID.ToString()!="D")
                    {
                        //Guardamos el ID de la FacturA
                        Int64 FacturaID = Factura.ID;
                        Int64 ClienteID = Convert.ToInt64(Factura.ClienteID);

                        //Asignamos los datos del cliente que se encuentra en la cotizacion
                        AsignarDatosCliente(ObjetoCliente.BuscarPorID(ClienteID));

                        //Buscamos la lista de Articulos que se encuentran en la cotizacion
                        List<cDetalleFactura> ListaDetalle = ObjetoDetalle.ListarDetalle(FacturaID, "F");

                        //Objeto Inventario para realizar operaciones
                        InventarioBL ObjetoInventario = new InventarioBL();
                        foreach (cDetalleFactura Detalle in ListaDetalle)
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
                                              Detalle.DescuentoValor,
                                              (Detalle.DescuentoValor / 100) * Detalle.Precio,
                                              (((Detalle.Cantidad * Detalle.Precio) - ((Detalle.DescuentoValor / 100) * Detalle.Precio)) + ((Detalle.ImpuestoValor / 100) * Detalle.Precio)),
                                              Detalle.Costo,
                                              Detalle.UnidadVentaID,
                                              Detalle.TipoProducto);

                        }

                    }
                    else
                    {
                        throw new Exception("La factura se encuentra cancelada o devuelta y no puede ser procesada");
                    }
                }
                else
                {
                    throw new Exception("La factura solicitada no se encuentra en la lista");
                }
                
            }
            
        }

        private void InsertarLineaGrid(Int64 Codigo,
                                       String CodigoArticulo,
                                       String Descripcion,
                                       Decimal Cantidad,
                                       Decimal PrecioUnitario,
                                       Decimal ImporteImpuestos,
                                       Decimal TotalImpuestoArticulo,
                                       Decimal ImporteDescuento,
                                       Decimal TotalDescuentoArticulo,
                                       Decimal ImporteTotalArticulo,
                                       Decimal CostoUnitario,
                                       int UnidadVentaID,
                                       String TipoArticulo)
        {
            //Insertar nueva linea en el DataGridView
            dgvDetalleFactura.Rows.Add(Codigo, CodigoArticulo, Descripcion, Cantidad, PrecioUnitario, ImporteImpuestos, TotalImpuestoArticulo, ImporteDescuento, TotalDescuentoArticulo, ImporteTotalArticulo, CostoUnitario, UnidadVentaID, TipoArticulo);
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
                Decimal DescuentoArticulo = Convert.ToDecimal(row.Cells[7].Value) / 100;
                //-----------------------------------------------------------------------------------------------------------
                Decimal SubtotalArticulo = Convert.ToDecimal(row.Cells[3].Value) * Convert.ToDecimal(row.Cells[4].Value);
                Decimal SubtotalDescuento = SubtotalArticulo * DescuentoArticulo;
                //-----------------------------------------------------------------------------------------------------------
                SubtotalAcumulado = SubtotalAcumulado + SubtotalArticulo;
                ImpuestoAcumulado = ((SubtotalAcumulado - (SubtotalAcumulado * (1 + DescuentoArticulo)) + (SubtotalAcumulado)) * (ImpuestoArticulo));
                DescuentoAcumulado = (SubtotalAcumulado * (1 + DescuentoArticulo)) - SubtotalAcumulado;
                //-----------------------------------------------------------------------------------------------------------
                SubTotal = SubtotalAcumulado;
                TotalImpuesto = ImpuestoAcumulado;
                TotalDescuento = DescuentoAcumulado;
                TotalTransaccion = TotalImpuesto + (SubTotal - TotalDescuento);
            }

            //Mostramos los resultados de las transacciones
            lblSubTotal.Text = SubTotal.ToString("C2");
            lblImpuesto.Text = TotalImpuesto.ToString("C2");
            lblDescuento.Text = TotalDescuento.ToString("C2");
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
            txtDescuento.Text = "0.00";
            txtImpuesto.Text = "0.00";
            txtImporteTotal.Text = "0.00";
        }


        private void BuscarArticulo(String CodigoArticulo)
        {
            DetalleFacturaBL ObjetoDetalle = new DetalleFacturaBL();
            
            //Buscamos el articulo en el inventario por su codigo de articulo
           List<cDetalleFactura> ListaArticulos = ObjetoDetalle.ListarDetalleDevolucion(CodigoArticulo,ObtenerDocumentoReferencia());
            //Verificamos el resultado de la busqueda
            Int32 IX;
            if (ListaArticulos.Count>0)
            {
                //Mostramos los valores del resultado a los controles indicador en el formulario
                MostrarResultados(ListaArticulos);
            }
            else
            {
                //Si el resultado es nulo entonces arrojamos el mensaje de error y limpiamos los campos
                MessageBox.Show("El articulo digitado no puedo se encontrado, vuelva a intentarlo", "Error en busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                txtCodigo.Focus();
            }

        }

        private int ObtenerDocumentoReferencia()
        {
            if(txtReferencia.Text!=String.Empty || txtReferencia.Text!="")
            {
                Int32 Codigo;
                if(Int32.TryParse(txtReferencia.Text,out Codigo))
                {
                    return Convert.ToInt32(txtReferencia.Text);
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
                return 0;
                MessageBox.Show(Ex.Message);
            }
        }

        private void MostrarResultados(List<cDetalleFactura> ListaArticulos)
        {
            //Ajustamos la lista para el primer articulo
            cDetalleFactura Articulo=ListaArticulos.FirstOrDefault();
                try
                {
                    cInventario InformacionArticulo=ObjetoInventario.BuscarPorID(Articulo.ArticuloID);
                    //Asigna el resultado de la busqueda a los controles indicados

                    txtCodigo.Text =InformacionArticulo.CodigoArticulo;
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
           

        private void AsignarFechaVencimiento(cCliente Cliente)
        {
            //Determinamos la fecha de vencimiento del documento
            dtpFechaVencimiento.Value = dtpFechaFactura.Value.AddDays(Cliente.DiasCredito);
        }

        private void AsignarDatosCliente(cCliente Cliente)
        {
            try
            { 
            lblDireccion.Text = Cliente.Direccion.ToString();
            lblRNC.Text = Cliente.RNC.ToString();
            cbbCliente.SelectedValue = Cliente.ID;


            AsignarFechaVencimiento(Cliente);
                }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private void CargarDependencias()
        {
            //Clientes
            ClienteBL ObjetoCliente = new ClienteBL();
            cbbCliente.DataSource = ObjetoCliente.Listar();
            cbbCliente.ValueMember = "ID";
            cbbCliente.DisplayMember = "NombreComercial";

            VendedorBL ObjetoVendedor = new VendedorBL();
            cbVendedor.DataSource = ObjetoVendedor.Listar();
            cbVendedor.ValueMember = "ID";
            cbVendedor.DisplayMember = "Nombre";

        }
        #endregion


        private void frmAgregarDevolucion_Load(object sender, EventArgs e)
        {
            CargarDependencias();
            //Valores iniciales para crear documento
            txtFactura_ID.Text = "-1";
            txtDescuento.Text = "0";
            btnInsertar.Enabled = false;
            //Las cotizaciones tendran una fecha de vencimiento igual a 30 dias
            dtpFechaVencimiento.Value = DateTime.Now.AddDays(30);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             try
            {
                ParametroNCFBL ObjetoParametro = new ParametroNCFBL(); //Parametro de comprobantes fiscales
                //Verificamos que la factura tenga elementos en el detalle
                if (dgvDetalleFactura.RowCount > 0)
                {
                    //Verificamos si existe disponibilidad del comprobante y el cliente posee RNC para el mismo.
                    if (ObjetoParametro.Disponibilidad(ObtenerTipoComprobante()))
                    {
                        FacturaBL ObjetoFactura = new FacturaBL();
                        //Numero de Factura Generada
                        Int32 FacturaID = Convert.ToInt32(ObjetoFactura.Crear(ObtenerFactura()));

                        //Insertamos el detalle de factura
                        if (FacturaID != -1)
                        {
                            try
                            {
                                //Insertamos el detalle de la factura
                                InsertarDetalle(FacturaID);
                                //Generamos un # de comprobante fiscal dependiendo del tipo de comprobante seleccionado
                                AsignarNCF(FacturaID);
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

                    }
                    else
                    {
                        MessageBox.Show("El tipo de comprobante seleccionado esta agotado o no existe, favor verificar", "Error en Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                else
                {
                    MessageBox.Show("Debe agregar elementos a la presente factura", "Error en facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarBusquedaArticulo();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error en facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        

        private void cbbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 C;
                if (Int32.TryParse(cbbCliente.SelectedValue.ToString(), out C))
                {
                    ClienteBL ObjetoCliente = new ClienteBL();
                    C = Convert.ToInt32(cbbCliente.SelectedValue.ToString());
                    AsignarDatosCliente(ObjetoCliente.BuscarPorID(C));
                }
            }
            catch (Exception Ex)
            {

            }
}
        

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente BuscarCliente = new frmBuscarCliente();
            BuscarCliente.ShowDialog(this);
        }

        private void btnBuscarArticulos_Click(object sender, EventArgs e)
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

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Realizamos una busqueda de los elementos que componen el documento de referencia
            if (e.KeyChar == (char)Keys.Enter)
            {
                dgvDetalleFactura.Rows.Clear();
                //Procedimiento que buscar la cotizacion 
                BuscarFactura();
            }
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            //Visualizamos la lista de Facturas no Devueltas o con Devolucion Parcial
            frmListaCotizacion ListaFacturas = new frmListaCotizacion("F");
            ListaFacturas.Text = "Listado de Facturas";
            ListaFacturas.ShowDialog(this);
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

        private void txtCantidad_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ValidacionCantidad())
                {
                    btnInsertar.Enabled = true;
                }
                else
                {
                    txtCantidad.Focus();
                    MessageBox.Show("La cantidad digitada excede la facturada, no se puede procesar la devolucion", "Error en cantidad de articulos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            DetalleFacturaBL ObjetoDetalle = new DetalleFacturaBL();

            List<cDetalleFactura> ListaDetalle = ObjetoDetalle.ListarDetalleDevolucion(txtCodigo.Text, ObtenerDocumentoReferencia());

            //Asignamos los valores a partir del codigo del articulo proporcionado
            AsignarValores(ListaDetalle.FirstOrDefault());
            if (_Codigo > 0)
            {
                //Insertamos el articulo seleccionado, cantidad, precio, costo y demas en el DataGrid
                InsertarDetalle();
            }
            else
            {
                MessageBox.Show("Error, debe proporcionar un articulo para ser incluido en la factura", "Error insertando articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private void chbGenerarComprobante_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnVerProducto_Click(object sender, EventArgs e)
        {
            frmVerArticulo VerArticulo = new frmVerArticulo(ArticuloSeleccionado());
            VerArticulo.ShowDialog(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Int32 ArticuloSeleccionado()
        {
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

        private void txtReferencia_Validated(object sender, EventArgs e)
        {
            try
            {
                //Procedimiento que buscar la cotizacion 
                BuscarFactura();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error en busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

