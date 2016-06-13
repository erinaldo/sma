using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.BL;
using SMA.Entity;
using DevComponents.DotNetBar;
using SMA.Factura.Reportes;

namespace SMA.Factura.Cotizacion
{
    public partial class frmAgregarCotizacion : Office2007Form, IagregarEditarFacturas
    {
        InventarioBL ObjetoInventario = new InventarioBL();
        FacturaBL ObjetoFactura = new FacturaBL();
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


        #region Constructores
        public frmAgregarCotizacion()
        {
            InitializeComponent();
        }
        #endregion

        #region Procedimiento y funciones

       
        private cFactura ObtenerFactura()
        {
            FacturaBL ObjetoFactura = new FacturaBL();
            cFactura Factura = new cFactura();

            Factura.ClienteID = cbbCliente.SelectedValue;
            Factura.TipoDocumento = "C";
            Factura.CondicionVenta = ObtenerCondiciones();
            //Obtenemos el ultimo documento del tipo Factura
            //Factura.DocumentoID = ObtenerNumeroDocumento();
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
            

            return Factura;
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
            catch(Exception Ex)
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
                Detalle.TipoDocumento = "C";
                Detalle.ArticuloID = Convert.ToInt32(row.Cells[0].Value);
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
                _ImporteDescuento = Convert.ToDecimal(txtDescuento.Text);
                _TotalDescuentoArticulo = _PrecioUnitario * (_ImporteDescuento / 100); //Total de valor a descontarse
                _ImporteImpuestos = Convert.ToDecimal(txtImpuesto.Text);                 //Importe de Impuestos
                _TotalImpuestoArticulo = (_PrecioUnitario * _Cantidad) * (_ImporteImpuestos / 100); //Total de valor a cobrarse de impuesto
                _SubTotalArticulo = _Cantidad * _PrecioUnitario;                        //Subtotal de articulo
                _ImporteTotalArticulo = (_SubTotalArticulo - _TotalDescuentoArticulo) + _TotalImpuestoArticulo;
                _TipoArticulo = Articulo.TipoArticulo;
                _UnidadVentaID = Convert.ToInt32(Articulo.UnidadSalidaID.ToString());
            }
            catch (Exception Ex)
            {

            }

        }

        private void ValidacionDescuento(Decimal Descuento)
        {
            //Validamos que el precio digitado este entre los paramentros permitidos en el inventario
            Decimal PrecioPublico;                               //Precio publico en inventario
            Decimal PrecioMinimo;                                //Precio Minimo en Inventario
            Decimal PrecioDigitado;                              //Precio Digitado por el usuario
            Decimal DescuentoAplicado;                           //Precio luego de aplicado el descuento

            InventarioBL ObjetoInventario = new InventarioBL();
            cInventario Articulo = ObjetoInventario.BuscarPorID(txtCodigo.Text); //Articulo

            PrecioPublico = Articulo.PrecioPublico;
            PrecioMinimo = Articulo.Precio4;
            PrecioDigitado = Convert.ToDecimal(txtPrecio.Text);
            if (Descuento > 0)
            {
                DescuentoAplicado = ((Descuento / 100) * PrecioDigitado);

                //Si el Descuento aplicado es mayor o igual al minimo y menor o igual al maximo calculamos el importe
                if (DescuentoAplicado >= PrecioMinimo && DescuentoAplicado <= PrecioPublico)
                {
                    CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);
                    btnInsertar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("El descuento aplicado esta por debajo del precio minimo permitido, revise e intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescuento.Focus();
                    btnInsertar.Enabled = false;
                }
            }
            else
            {
                CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);
                btnInsertar.Enabled = true;
            }
        }

        private void ValidacionPrecio()
        {
            //Validamos que el precio digitado este entre los paramentros permitidos en el inventario
            Decimal PrecioPublico;                               //Precio publico en inventario
            Decimal PrecioMinimo;                                //Precio Minimo en Inventario
            Decimal PrecioDigitado;                              //Precio Digitado por el usuario

            InventarioBL ObjetoInventario = new InventarioBL();
            cInventario Articulo = ObjetoInventario.BuscarPorID(txtCodigo.Text); //Articulo

            PrecioPublico = Articulo.PrecioPublico;
            PrecioMinimo = Articulo.Precio4;
            PrecioDigitado = Convert.ToDecimal(txtPrecio.Text);

            //Si el precio digitado es mayor o igual al minimo y menos o igual al maximo calculamos el importe
            if (PrecioDigitado >= PrecioMinimo && PrecioPublico <= PrecioDigitado)
            {
                CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);
                btnInsertar.Enabled = true;
            }
            else
            {
                MessageBox.Show("El precio digitado esta por debajo del precio minimo permitido, revise e intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                btnInsertar.Enabled = false;
            }
        }


        private void CalcularImportes(String _Impuesto, String _Precio, String _Descuento)
        {

            Decimal Descuento = Convert.ToDecimal(_Descuento);
            Decimal Precio = Convert.ToDecimal(_Precio);
            Decimal Impuesto = Convert.ToDecimal(_Impuesto);
            Decimal Cantidad = Convert.ToDecimal(txtCantidad.Text);
            //Calculamos los importes relacionados al articulo.
            txtImpuesto.Text = Impuesto.ToString();
            //Calculamos el importe total del articulo mas los impuestos siempre por el valor unitario.
            Decimal Subtotal = (Precio * Cantidad);
            Decimal Descontar = (Subtotal * (Descuento / 100));
            Decimal ImpuestoTotal = Subtotal * (Impuesto / 100);
            txtImporteTotal.Text = ((Subtotal - Descontar) + (ImpuestoTotal)).ToString();
        }

        //private void ValidacionExistencia()
        //{
        //    if (txtCodigo.Text != string.Empty)
        //    {
        //        InventarioBL ObjetoInventario = new InventarioBL();
        //        //Buscamos el articulo por su codigo de inventario
        //        cInventario Articulo = ObjetoInventario.BuscarPorID(txtCodigo.Text);
        //        //Indicador de facturacion aun si existencia
        //        Boolean FacturarSinExistencia = Articulo.FacturarSinExistencia;
        //        //Cantidad de articulo en inventario
        //        Double Cantidad = Articulo.Existencia;

        //        //Esta validacion solo se realiza para los articulos fisicos, los combos no aplican
        //        if (Articulo.TipoArticulo == "F")
        //        {
        //            //Validamos que la cantidad facturada no sea mayor a la existente siempre que el indicador de facturar sin existencia no este marcado
        //            //Validamos que el campo tenga el tipo de datos correcto
        //            Double X;
        //            if (Double.TryParse(txtCantidad.Text, out X))
        //            {
        //                //Si la cantidad digitada es menor a la cantidad en existencia calculamos el importe
        //                if (Convert.ToDouble(txtCantidad.Text) <= Cantidad)
        //                {
        //                    CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);

        //                    btnInsertar.Enabled = true;
        //                }
        //                //Si la cantidad es mayor a la cantidad existente y tiene el indicador hacemos la pregunta al usuario
        //                else if (Convert.ToDouble(txtCantidad.Text) >= Cantidad && FacturarSinExistencia == true)
        //                {
        //                    DialogResult Resultado = MessageBox.Show("El valor proporcionado excede la cantidad en inventario,¿Desea proseguir con la facturacion?", "Cantidad excede existencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (Resultado == DialogResult.Yes)
        //                    {
        //                        CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);

        //                        btnInsertar.Enabled = true;
        //                    }
        //                    else
        //                    {
        //                        LimpiarCampos();
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("La cantidad digitada excede la existencia del articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    txtCantidad.Focus();
        //                    btnInsertar.Enabled = false;
        //                }

        //            }
        //        }
        //        else if (Articulo.TipoArticulo == "C")
        //        {
        //            //Validamos las cantidades de los elementos contenidos en un combo

        //            Boolean FacturarSinExistenciaComponente;                //Indicador de componente
        //            RelacionCombosBL ObjetoCombo = new RelacionCombosBL();    //Objeto de combo
        //            List<cRelacionCombos> ListaComponentes = new List<cRelacionCombos>();

        //            ListaComponentes = ObjetoCombo.Listar(Articulo.ID);

        //            foreach (cRelacionCombos I in ListaComponentes)
        //            {
        //                Double CantidadInventario;                              //Cantidad existente en inventario
        //                cInventario Componente;                                  //Articulo que compone el combo
        //                Double CantidadComponente;                              //Cantidad de componentes
        //                Int32 CodigoComponente = Convert.ToInt32(I.InventarioID); //Codigo del componente pertenenciente al combo
        //                //Datos del componente
        //                Componente = ObjetoInventario.BuscarPorID(CodigoComponente);
        //                CantidadInventario = Componente.Existencia;                         //Cantidad de componente en inventario
        //                FacturarSinExistenciaComponente = Componente.FacturarSinExistencia; //Indicador facturar sin existencia de inventario

        //                //Cantidad del componente 
        //                CantidadComponente = Convert.ToDouble(I.Cantidad);

        //                //Validamos que la cantidad existente no sobre pase la cantidad 
        //                if (CantidadComponente <= CantidadInventario)
        //                {
        //                    CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);
        //                }
        //                else if (CantidadComponente > CantidadInventario && FacturarSinExistenciaComponente)
        //                {
        //                    DialogResult Resultado = MessageBox.Show("La cantidad disponible de uno de los componentes excede la cantidad en inventario, revise e intentelo nuevamente", "Cantidad excede existencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (Resultado == DialogResult.Yes)
        //                    {
        //                        CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);
        //                    }
        //                    else
        //                    {
        //                        LimpiarCampos();
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No existe disponibilidad de uno de los componentes del combo, revise e intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    LimpiarCampos();
        //                }
        //            }
        //        }
        //    }
        //}

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
                    txtPrecio.Text = Articulo.PrecioPublico.ToString();

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

        private void IniciarBusquedaCliente()
        {
            //Formulario de Busqueda de Cliente
            frmBuscarCliente BuscarCliente = new frmBuscarCliente();
            BuscarCliente.ShowDialog(this);
        }

        #endregion

        #region Implementacion de Interface

        public void BuscarReferencia(Int64 DocumentoID)
        {
            //No Implementado
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

        public void BusquedaCliente(Int32 Codigo)
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

        private void AsignarDatosCliente(cCliente Cliente)
        {
            lblDireccion.Text = Cliente.Direccion.ToString();
            lblRNC.Text = Cliente.RNC.ToString();
            cbbCliente.SelectedValue = Cliente.Codigo;


            AsignarFechaVencimiento(Cliente);
        }

        private void AsignarFechaVencimiento(cCliente Cliente)
        {
            //Determinamos la fecha de vencimiento del documento
            dtpFechaVencimiento.Value = dtpFechaFactura.Value.AddDays(Cliente.DiasCredito);
        }


        #endregion


        private void frmAgregarCotizacion_Load(object sender, EventArgs e)
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

                        //Mostramos el modulo de pagos
                        frmrptCotizacion PagarFactura = new frmrptCotizacion(FacturaID);
                        PagarFactura.ShowDialog(this);
                        //Inhabilitamos el boton de guardar para evitar que se guarde nuevamente la factura;
                        btnGuardar.Enabled = false;
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Error en facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al Crear Cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AsignarValores(ObjetoInventario.BuscarPorID(txtCodigo.Text));
            if (_Codigo > 0)
            {
                dgvDetalleFactura.Rows.Add(_Codigo, _CodigoArticulo, _Descripcion, _Cantidad, _PrecioUnitario, _ImporteImpuestos, _TotalImpuestoArticulo, _ImporteDescuento, _TotalDescuentoArticulo, _ImporteTotalArticulo, _CostoUnitario, _UnidadVentaID, _TipoArticulo);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cierra el formulario
            this.Close();
        }

        private void cbbCliente_SelectedValueChanged(object sender, EventArgs e)
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

        private void txtCodigo_Validated(object sender, EventArgs e)
        {
            //La busqueda de articulos debe estar suscrita solo a los articulos que contiene la factura.
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

        private void txtPrecio_Validated(object sender, EventArgs e)
        {
            ValidacionPrecio();
        }

        private void txtDescuento_Validated(object sender, EventArgs e)
        {
            Decimal Descuento;
            if (Decimal.TryParse(txtDescuento.Text, out Descuento))
            {
                Descuento = Convert.ToDecimal(txtDescuento.Text);
                ValidacionDescuento(Descuento);
            }
            else
            {
                MessageBox.Show("Error al aplicar descuento, revise e intentelo nuevamente", "Error al aplicar descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_Validated(object sender, EventArgs e)
        {
            //Se debe validar que la cantidad devuelta no sea mayor a la facturada
        }

        private void dtpFechaFactura_ValueChanged(object sender, EventArgs e)
        {
            //Asignamos una fecha de vencimiento de acuerdo a la fecha de creacion
            dtpFechaVencimiento.Value = dtpFechaFactura.Value.AddDays(30);
        }
        
    }
}
