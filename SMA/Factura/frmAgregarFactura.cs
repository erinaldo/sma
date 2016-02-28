using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.Entity;
using SMA.BL;
using SMA.Factura.Pagos;
using SMA.Factura.Reportes;

namespace SMA.Factura
{
    public partial class frmAgregarFactura : Office2007Form, IagregarEditarFacturas
    {
        private Int64? NumeroFactura;
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


        #region Construtores
        public frmAgregarFactura()
        {
            InitializeComponent();
        }

        public frmAgregarFactura(int NumeroFactura)
        {
            this.NumeroFactura = NumeroFactura;
        }

        #endregion

        #region Implementacion de Interface

        public void BuscarReferencia(Int64 DocumentoID)
        {
            //Buscamos y mostramos la informacion referente a un documento tipo cotizacion
            txtReferencia.Text = DocumentoID.ToString();
            BuscarCotizacion();

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

        private void AsignarDatosCliente(cCliente Cliente)
        {
            lblDireccion.Text = Cliente.Direccion.ToString();
            lblRNC.Text = Cliente.RNC.ToString();
            cbbCliente.SelectedValue = Cliente.ID;
            cbbTipoComprobante.SelectedValue = Cliente.TipoComprobanteID;
            cbVendedor.SelectedValue = Cliente.VendedorID;


            AsignarFechaVencimiento(Cliente);
        }

        private void AsignarFechaVencimiento(cCliente Cliente)
        {
            //Determinamos la fecha de vencimiento del documento
            dtpFechaVencimiento.Value = dtpFechaFactura.Value.AddDays(Cliente.DiasCredito);
        }


        #endregion

        #region Operaciones de Busqueda y calculos
        private void BuscarCotizacion()
        {
            DetalleFacturaBL ObjetoDetalle = new DetalleFacturaBL();
            FacturaBL ObjetoFactura = new FacturaBL();
            Int32 ID;
            if (txtReferencia.Text != String.Empty)
            {
                //Obtenemos el ID del Documento por medio del numero de documento
                ID = Convert.ToInt32(txtReferencia.Text);

                //Buscamos la cotizacion que tiene este numero de documento
                cFactura Factura = ObjetoFactura.BuscarPorID(ID, "C");
                //Verificamos que obtuvimos algun resultado
                if (Int32.TryParse(Factura.ID.ToString(), out ID))
                {
                    //Guardamos el ID de la FacturA
                    Int64 FacturaID = Factura.ID;
                    Int64 ClienteID = Convert.ToInt32(Factura.ClienteID);

                    //Asignamos los datos del cliente que se encuentra en la cotizacion
                    AsignarDatosCliente(ObjetoCliente.BuscarPorID(ClienteID));

                    //Buscamos la lista de Articulos que se encuentran en la cotizacion
                    List<cDetalleFactura> ListaDetalle = ObjetoDetalle.ListarDetalle(FacturaID, "C");

                    //Objeto Inventario para realizar operaciones
                    InventarioBL ObjetoInventario = new InventarioBL();
                    foreach (cDetalleFactura Detalle in ListaDetalle)
                    {



                        cInventario Articulo = ObjetoInventario.BuscarPorID(Detalle.ArticuloID);
                        if (ValidacionExistencia(Articulo, Detalle.Cantidad))
                        {
                            if (ValidacionPrecio(Articulo, Detalle.Precio) && ValidacionDescuento(Articulo, Detalle.DescuentoValor, Detalle.Precio))
                            {
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
                            else
                            {
                                MessageBox.Show("El Articulo  " + Articulo.Descripcion + " tiene un precio que esta por debajo del permitido, y no será agregado a esta factura", "Precio de articulo muy inferior", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Articulo " + Articulo.Descripcion + " no posee la cantidad solicitada en el almacen", "Cantidad no disponible para articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
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
        private Boolean ValidacionDescuento(cInventario Articulo, Decimal Descuento, Decimal PrecioDigitado)
        {
            //Validamos que el precio digitado este entre los paramentros permitidos en el inventario
            Decimal PrecioPublico;                               //Precio publico en inventario
            Decimal PrecioMinimo;                                //Precio Minimo en Inventario
            Decimal DescuentoAplicado;                           //Precio luego de aplicado el descuento

            PrecioPublico = Articulo.PrecioPublico;
            PrecioMinimo = Articulo.Precio4;

            if (Descuento > 0)
            {
                DescuentoAplicado = ((Descuento / 100) * PrecioDigitado);

                //Si el Descuento aplicado es mayor o igual al minimo y menor o igual al maximo calculamos el importe
                if (DescuentoAplicado >= PrecioMinimo && DescuentoAplicado <= PrecioPublico)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
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

        private void IniciarBusquedaCliente()
        {
            //Formulario de Busqueda de Cliente
            frmBuscarCliente BuscarCliente = new frmBuscarCliente();
            BuscarCliente.ShowDialog(this);
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

        private void BuscarArticulo(String CodigoArticulo)
        {
            try
            {
                //Buscamos el articulo en el inventario por su codigo de articulo
                cInventario Articulo = ObjetoInventario.BuscarPorID(CodigoArticulo);
                //Verificamos el resultado de la busqueda
                Int32 IX;
                if (Int32.TryParse(Articulo.ID.ToString(), out IX))
                {
                    //SI EL ARTICULO ESTA VENCIDO Y TIENE EL INDICADOR AVISAR EN VENCIMIENTO REALIZAMOS LA COMPARACION
                    if (ValidarVencimiento(Articulo.FechaVencimiento) && Articulo.AvisarVencimiento)
                    {
                        //PREGUNTAMOS EL SI CONTINUAMOS EL PROCESO O SELECCIONAMOS OTRO ARTICULO
                        DialogResult Resultado=MessageBox.Show("El articulo seleccionado se encuentra vencido, ¿desea continuar?", "Articulo vencido", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (Resultado == DialogResult.Yes)
                        {
                            //Mostramos los valores del resultado a los controles indicador en el formulario
                            MostrarResultados(Articulo);
                        }
                        else
                        {
                            LimpiarCampos();
                        }
                    }
                    else
                    {
                        //Mostramos los valores del resultado a los controles indicador en el formulario
                        MostrarResultados(Articulo);
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
                MessageBox.Show(Ex.Message);
            }
        }
        private Boolean ValidarVencimiento(Object FechaVencimiento)
        {
            //VALIDAMOS SI EL ARTICULO SE ENCUENTRA VENCIDO
            DateTime Fecha;
            if (DateTime.TryParse(FechaVencimiento.ToString(),out Fecha))
            {
                Fecha = Convert.ToDateTime(FechaVencimiento);
                if(Fecha<=DateTime.Now.Date)
                {
                    //ARTICULO VENCIDO
                    return true;
                }
                else
                {
                    //ARTICULO NO VENCIDO
                    return false;
                }
            }
            else
            {
                //FECHA NO APLICA
                return false;
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

            TipoComprobanteFiscalBL ObjetoTipoComprobante = new TipoComprobanteFiscalBL();
            cbbTipoComprobante.DataSource = ObjetoTipoComprobante.Listar();
            cbbTipoComprobante.ValueMember = "ID";
            cbbTipoComprobante.DisplayMember = "Descripcion";

            VendedorBL ObjetoVendedor = new VendedorBL();
            cbVendedor.DataSource = ObjetoVendedor.Listar();
            cbVendedor.ValueMember = "ID";
            cbVendedor.DisplayMember = "Nombre";
        }

        private void ValidacionExistencia()
        {
            try
            {
                if (txtCodigo.Text != string.Empty)
                {
                    InventarioBL ObjetoInventario = new InventarioBL();
                    //Buscamos el articulo por su codigo de inventario
                    cInventario Articulo = ObjetoInventario.BuscarPorID(txtCodigo.Text);
                    //Indicador de facturacion aun si existencia

                    Boolean FacturarSinExistencia = Articulo.FacturarSinExistencia;
                    //Cantidad de articulo en inventario
                    Decimal Cantidad = Articulo.Existencia;

                    //Esta validacion solo se realiza para los articulos fisicos, los combos no aplican
                    if (Articulo.TipoArticulo == "F")
                    {
                        //Validamos que la cantidad facturada no sea mayor a la existente siempre que el indicador de facturar sin existencia no este marcado
                        //Validamos que el campo tenga el tipo de datos correcto
                        Decimal X;
                        if (Decimal.TryParse(txtCantidad.Text, out X))
                        {
                            //Si la cantidad digitada es menor a la cantidad en existencia calculamos el importe
                            if (Convert.ToDecimal(txtCantidad.Text) <= Cantidad)
                            {
                                CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);

                                btnInsertar.Enabled = true;
                            }
                            //Si la cantidad es mayor a la cantidad existente y tiene el indicador hacemos la pregunta al usuario
                            else if (Convert.ToDecimal(txtCantidad.Text) >= Cantidad && FacturarSinExistencia == true)
                            {
                                DialogResult Resultado = MessageBox.Show("El valor proporcionado excede la cantidad en inventario,¿Desea proseguir con la facturacion?", "Cantidad excede existencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (Resultado == DialogResult.Yes)
                                {
                                    CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);

                                    btnInsertar.Enabled = true;
                                }
                                else
                                {
                                    LimpiarCampos();
                                }
                            }
                            else
                            {
                                MessageBox.Show("La cantidad digitada excede la existencia del articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtCantidad.Focus();
                                btnInsertar.Enabled = false;
                            }

                        }
                    }
                    else if (Articulo.TipoArticulo == "C")
                    {
                        //Validamos las cantidades de los elementos contenidos en un combo

                        Boolean FacturarSinExistenciaComponente;                //Indicador de componente
                        RelacionCombosBL ObjetoCombo = new RelacionCombosBL();    //Objeto de combo
                        List<cRelacionCombos> ListaComponentes = new List<cRelacionCombos>();

                        ListaComponentes = ObjetoCombo.Listar(Articulo.ID);

                        foreach (cRelacionCombos I in ListaComponentes)
                        {
                            Decimal CantidadInventario;                              //Cantidad existente en inventario
                            cInventario Componente;                                  //Articulo que compone el combo
                            Decimal CantidadComponente;                              //Cantidad de componentes
                            Int32 CodigoComponente = Convert.ToInt32(I.InventarioID); //Codigo del componente pertenenciente al combo
                            //Datos del componente
                            Componente = ObjetoInventario.BuscarPorID(CodigoComponente);
                            CantidadInventario = Componente.Existencia;                         //Cantidad de componente en inventario
                            FacturarSinExistenciaComponente = Componente.FacturarSinExistencia; //Indicador facturar sin existencia de inventario

                            //Cantidad del componente 
                            CantidadComponente = Convert.ToDecimal(I.Cantidad);

                            //Validamos que la cantidad existente no sobre pase la cantidad 
                            if (CantidadComponente <= CantidadInventario)
                            {
                                CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);
                            }
                            else if (CantidadComponente > CantidadInventario && FacturarSinExistenciaComponente)
                            {
                                DialogResult Resultado = MessageBox.Show("La cantidad disponible de uno de los componentes excede la cantidad en inventario, revise e intentelo nuevamente", "Cantidad excede existencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (Resultado == DialogResult.Yes)
                                {
                                    CalcularImportes(txtImpuesto.Text, txtPrecio.Text, txtDescuento.Text);
                                }
                                else
                                {
                                    LimpiarCampos();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No existe disponibilidad de uno de los componentes del combo, revise e intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarCampos();
                            }
                        }
                    }
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private Boolean ValidacionExistencia(cInventario Articulo, Decimal Cantidad)
        {

            //Indicador de facturacion aun si existencia
            Boolean FacturarSinExistencia = Articulo.FacturarSinExistencia;
            //Cantidad de articulo en inventario
            Decimal CantidadExistente = Articulo.Existencia;

            if (Articulo.TipoArticulo == "F")
            {
                //Validamos que la cantidad proporcionada no sea mayor a la cantidad en existencia 

                //Si la cantidad digitada es menor a la cantidad en existencia devolvemos un valor afirmativo
                if (Cantidad <= CantidadExistente)
                {
                    return true;
                }
                //En el caso que la cantidad sea superior y el indicador de Facturar sin existencia este encendido entonces devolvemos un valor afirmativo
                else if (Cantidad >= CantidadExistente && FacturarSinExistencia == true)
                {
                    return true;
                }
                else
                {
                    //En caso contrario devolvemos un valor negativo
                    return false;
                }
            }

            else if (Articulo.TipoArticulo == "C")
            {
                //Validamos las cantidades de los elementos contenidos en un combo

                Boolean FacturarSinExistenciaComponente;                //Indicador de componente
                RelacionCombosBL ObjetoCombo = new RelacionCombosBL();    //Objeto de combo
                List<cRelacionCombos> ListaComponentes = new List<cRelacionCombos>();

                ListaComponentes = ObjetoCombo.Listar(Articulo.ID);
                Int32 Indicador = 0; //Utilizamos este indicador para determinar si existe un elemento sin la suficiente disponibilidad para ser facturado
                foreach (cRelacionCombos I in ListaComponentes)
                {
                    Decimal CantidadInventario;                              //Cantidad existente en inventario
                    cInventario Componente;                                  //Articulo que compone el combo
                    Decimal CantidadComponente;                              //Cantidad de componentes
                    Int64 CodigoComponente = Convert.ToInt64(I.InventarioID); //Codigo del componente pertenenciente al combo
                    //Datos del componente
                    Componente = ObjetoInventario.BuscarPorID(CodigoComponente);
                    CantidadInventario = Componente.Existencia;                         //Cantidad de componente en inventario
                    FacturarSinExistenciaComponente = Componente.FacturarSinExistencia; //Indicador facturar sin existencia de inventario

                    //Cantidad del componente 
                    CantidadComponente = Convert.ToDecimal(I.Cantidad);

                    //Validamos que la cantidad existente no sobre pase la cantidad 
                    if (CantidadInventario < CantidadComponente && FacturarSinExistenciaComponente == false)
                    {
                        Indicador = +1;

                    }

                }
                if (Indicador > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return false;
            }

        }

        private void ValidacionPrecio()
        {
            try
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
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Error en precio de articulo", "Error en precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean ValidacionPrecio(cInventario Articulo, Decimal Precio)
        {
            //Validamos que el precio digitado este entre los paramentros permitidos en el inventario
            Decimal PrecioPublico;                               //Precio publico en inventario
            Decimal PrecioMinimo;                                //Precio Minimo en Inventario
            Decimal PrecioDigitado;                              //Precio Digitado por el usuario



            PrecioPublico = Articulo.PrecioPublico;
            PrecioMinimo = Articulo.Precio4;
            PrecioDigitado = Precio;

            //Si el precio digitado es mayor o igual al minimo y menos o igual al maximo calculamos el importe
            if (PrecioDigitado >= PrecioMinimo && PrecioPublico <= PrecioDigitado)
            {
                return true;
            }
            else
            {
                return false;
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

        private void InsertarDetalle(Int64 FacturaID)
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
                Detalle.TipoDocumento = "F";
                Detalle.ArticuloID = Convert.ToInt64(row.Cells[0].Value);
                Detalle.Precio = Convert.ToDecimal(row.Cells[4].Value);
                Detalle.Cantidad = Convert.ToDecimal(row.Cells[3].Value);
                Detalle.Costo = Convert.ToDecimal(row.Cells[10].Value);
                Detalle.ImpuestoValor = Convert.ToDecimal(row.Cells[5].Value);
                Detalle.DescuentoValor = Convert.ToDecimal(row.Cells[7].Value);
                Detalle.UnidadVentaID = Convert.ToInt32(row.Cells[11].Value);
                Detalle.TipoProducto = row.Cells[12].Value.ToString();
                Detalle.ValorComision = (Convert.ToDecimal(Comision/100) * (Convert.ToDecimal(row.Cells[4].Value)));
                Detalle.ComisionVenta = Comision;

                ListaDetalleFactura.Add(Detalle);
            }
            DetalleFacturaBL ObjetoDetalleFactura = new DetalleFacturaBL();
            ObjetoDetalleFactura.Crear(ListaDetalleFactura);

        }

        private cFactura ObtenerFactura()
        {
            //Obtenemos los datos de la factura a ser agregada
            FacturaBL ObjetoFactura = new FacturaBL();
            cFactura Factura = new cFactura();
            Factura.ClienteID = cbbCliente.SelectedValue;
            Factura.TipoDocumento = "F";
            Factura.CondicionVenta = ObtenerCondiciones();
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

        private Int32 ObtenerVendedor()
        {
            try
            {
                //Obtenemos el codigo del vendedor
                Int32 Codigo;
                if (cbVendedor.SelectedValue != null)
                {
                    if (Int32.TryParse(cbVendedor.SelectedValue.ToString(), out Codigo))
                    {
                        return Convert.ToInt32(cbVendedor.SelectedValue.ToString());
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
            catch (Exception Ex)
            {
                throw Ex;
            }

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

        private void AsignarNCF(Int64 FacturaID)
        {
            AsignacionNCFBL ObjetoAsignacion = new AsignacionNCFBL();
            cAsigancionNCF Asignacion = new cAsigancionNCF();
            Asignacion.FacturaID = FacturaID;
            Asignacion.ComprobanteID = ObtenerTipoComprobante();
            Asignacion.FechaAsignacion = DateTime.Now.Date;

            //Agregamos los datos del comprobante
            ObjetoAsignacion.Crear(Asignacion);
        }

        private Int32 ObtenerTipoComprobante()
        {
            Int32 Tipo;
            if (cbbTipoComprobante.Text != string.Empty)
            {
                if (Int32.TryParse(cbbTipoComprobante.SelectedValue.ToString(), out Tipo))
                {
                    return Convert.ToInt32(cbbTipoComprobante.SelectedValue.ToString());
                }
                else
                {
                    throw new Exception("Existe un error en la creacion de la factura, debe elegir un tipo de comprobante");
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) )
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            //Al pulsar la tecla de ENTER entonces pasa al campo de descuento.
            if (e.KeyChar == (char)13)
            {
                txtDescuento.Focus();
            }
        }
        private void frmAgregarFactura_Load(object sender, EventArgs e)
        {
            CargarDependencias();

            //Iniciamos los controles
            txtFactura_ID.Text = "-1";
            txtDescuento.Text = "0";
            btnInsertar.Enabled = false;
            cbVendedor.SelectedValue = -1;

        }

        private void cbbCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 C;
                //VALIDAMOS QUE EL VALOR SELECCIONADO CORRESPONDA CON UN VALOR NUMERICO ENTERO
                if (Int32.TryParse(cbbCliente.SelectedValue.ToString(), out C))
                {
                    C = Convert.ToInt32(cbbCliente.SelectedValue.ToString());
                    //BUSCAMOS LOS DATOS DEL CLIENTE Y LO MOSTRAMOS EN EL FORMULARIO
                    AsignarDatosCliente(ObjetoCliente.BuscarPorID(C));
                }
            }
            catch (Exception Ex)
            {

            }
        }

        private void cbbCliente_Validated(object sender, EventArgs e)
        {


        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //Al pulsar la tecla de enter buscamos el articulo por el codigo digitado por el usuario
                BuscarArticulo(txtCodigo.Text);
            }

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

            //Pulsacion de tecla enter
            if (e.KeyChar == (char)13)
            {
                txtPrecio.Focus();
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            //Al pulsar la tecla ENTER entonces pasa al boton de insertar
            if (e.KeyChar == (char)13)
            {
                btnInsertar.Focus();
            }
        }

        private void txtCantidad_Validated(object sender, EventArgs e)
        {
            ValidacionExistencia();
        }

        private void btnBuscarArticulo_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregarFactura_KeyDown(object sender, KeyEventArgs e)
        {
            //Pulsciones de teclas funcion para llamar a las diferentes busquedas
            switch (e.KeyValue)
            {
                case (char)Keys.F4: // Busqueda de Clientes
                    IniciarBusquedaCliente();
                    break;
                case (char)Keys.F7: //Busqueda de Articulos
                    IniciarBusquedaArticulo();
                    break;

            }
        }

        private void btnBuscarCliente_Click_1(object sender, EventArgs e)
        {
            IniciarBusquedaCliente();
        }

        private void btnBuscarArticulos_Click(object sender, EventArgs e)
        {
            IniciarBusquedaArticulo();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //Asignamos los valores a partir del codigo del articulo proporcionado
            AsignarValores(ObjetoInventario.BuscarPorID(txtCodigo.Text));
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
            //VISUALIZAMOS LOS PRODUCTOS SELECCIONADOS 
            frmVerArticulo VerArticulo = new frmVerArticulo(ArticuloSeleccionado());
            VerArticulo.ShowDialog(this);
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
                        Int64 FacturaID = Convert.ToInt64(ObjetoFactura.Crear(ObtenerFactura()));

                        //Insertamos el detalle de factura
                        if (FacturaID != -1)
                        {
                            try
                            {
                                //Insertamos el detalle de la factura
                                InsertarDetalle(FacturaID);
                                //Generamos un # de comprobante fiscal dependiendo del tipo de comprobante seleccionado
                                AsignarNCF(FacturaID);

                                //frmrptFactura Reporte = new frmrptFactura(FacturaID);
                                //Reporte.ShowDialog(this);

                                if (rbCredito.Checked)
                                {

                                }
                                else
                                {
                                    //Mostramos el modulo de pagos
                                    frmPagoFactura PagarFactura = new frmPagoFactura(FacturaID, _TotalGeneral);
                                    PagarFactura.ShowDialog(this);
                                    //Inhabilitamos el boton de guardar para evitar que se guarde nuevamente la factura;
                                }
                                this.Close();
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



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dtpFechaFactura_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 ID = Convert.ToInt32(cbbCliente.SelectedValue.ToString());
                AsignarDatosCliente(ObjetoCliente.BuscarPorID(ID));
            }
            catch (Exception Ex)
            {

            }
        }

        private void lblDireccion_Click(object sender, EventArgs e)
        {

        }

        private void cbbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }


            //Realizamos una busqueda de los elementos que componen el documento de referencia
            if (e.KeyChar == (char)Keys.Enter)
            {
                //Procedimiento que buscar la cotizacion 
                BuscarCotizacion();
            }
        }

        private void btnVerReferencia_Click(object sender, EventArgs e)
        {
            frmListaCotizacion ListaCotizacion = new frmListaCotizacion("C");
            ListaCotizacion.ShowDialog(this);
        }

        private void txtReferencia_Validated(object sender, EventArgs e)
        {
            dgvDetalleFactura.Rows.Clear();
            //Procedimiento que buscar la cotizacion 
            BuscarCotizacion();
        }

        
    }
}
