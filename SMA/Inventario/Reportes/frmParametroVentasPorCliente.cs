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

namespace SMA.Inventario.Reportes
{
    public partial class frmParametroVentasPorCliente : Office2007Form,IReportes
    {
        private String ClienteProveedor;

        public frmParametroVentasPorCliente()
        {
            InitializeComponent();
        }

        public frmParametroVentasPorCliente(String ClienteProveedor):this()
        {
            this.ClienteProveedor = ClienteProveedor;
        }

        #region Implementacion de interfase

        public void SeleccionarCliente(Int64 Codigo, Int32 Indicador)
        {
            //SELECCION DE CLIENTES
            if(Indicador==1)
            {
                cbbClienteDesde.SelectedValue = Codigo;
            }
            else
            {
                cbbClienteHasta.SelectedValue = Codigo;
            }
        }
        public void SeleccionarCodigoDesde(String Codigo)
        {
            cbbCodigoDesde.SelectedValue = Codigo;
        }

        public void SeleccionarCodigoHasta(String Codigo)
        {
            cbbCodigoHasta.SelectedValue = Codigo;
        }
        #endregion

        DateTime? FechaDesde;
        DateTime? FechaHasta;

        private void frmParametroVentasPorCliente_Load(object sender, EventArgs e)
        {
            try
            {
                //LISTA DE CONCEPTOS
                //Conceptos
                ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();
                lbConceptos.DataSource = ObjetoConcepto.Listar();
                lbConceptos.DisplayMember = "Descripcion";
                lbConceptos.ValueMember = "ID";

                //LISTA DE PRODUCTOS
                InventarioBL ObjetoInventario = new InventarioBL();
                cbbCodigoDesde.DataSource = ObjetoInventario.Listar();
                cbbCodigoHasta.DataSource = ObjetoInventario.Listar();
                cbbCodigoDesde.DisplayMember = "Descripcion";
                cbbCodigoHasta.DisplayMember = "Descripcion";
                cbbCodigoDesde.ValueMember = "CodigoArticulo";
                cbbCodigoHasta.ValueMember = "CodigoArticulo";

                //LISTA DE FAMILIAS
                FamiliaBL ObjetoFamilia = new FamiliaBL();
                cbbFamilia.DataSource = ObjetoFamilia.Listar();
                cbbFamilia.ValueMember = "ID";
                cbbFamilia.DisplayMember = "Descripcion";
                //Valor Inicial
                cbbFamilia.SelectedValue = -1;
                if (ClienteProveedor == "Cliente")
                {
                    //LISTA DE CLIENTES
                    ClienteBL ObjetoCliente = new ClienteBL();
                    cbbClienteDesde.DataSource = ObjetoCliente.Listar();
                    cbbClienteHasta.DataSource = ObjetoCliente.Listar();
                    cbbClienteHasta.DisplayMember = "NombreComercial";
                    cbbClienteDesde.DisplayMember = "NombreComercial";
                    cbbClienteDesde.ValueMember = "ID";
                    cbbClienteHasta.ValueMember = "ID";
                    //Valor Inicial
                    cbbClienteHasta.SelectedValue = -1;
                    cbbClienteDesde.SelectedValue = -1;


                    //SELECCIONAMOS LOS MOVIMIENTOS CLIENTES Y VENTAS
                    lbConceptos.SetSelected(0, false);
                    lbConceptos.SetSelected(2, true);
                    lbConceptos.SetSelected(5, true);
                    lbConceptos.SetSelected(10, true);
                }
                else
                {
                    //LISTA DE PROVEEDORES
                    ProveedorBL ObjetoProveedor = new ProveedorBL();
                    cbbClienteDesde.DataSource = ObjetoProveedor.Listar();
                    cbbClienteHasta.DataSource = ObjetoProveedor.Listar();
                    cbbClienteHasta.DisplayMember = "NombreComercial";
                    cbbClienteDesde.DisplayMember = "NombreComercial";
                    cbbClienteDesde.ValueMember = "ID";
                    cbbClienteHasta.ValueMember = "ID";
                    //Valor Inicial
                    cbbClienteHasta.SelectedValue = -1;
                    cbbClienteDesde.SelectedValue = -1;

                    gbClienteProveedor.Text = "Rango de proveedores";
                    

                    //SELECCIONAMOS LOS MOVIMIENTOS PROVEEDORES Y COMPRAS
                    lbConceptos.SetSelected(0, false);
                    lbConceptos.SetSelected(6, true);
                    lbConceptos.SetSelected(7, true);
                    lbConceptos.SetSelected(8, true);
                    
                }
                

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String CodigoDesde = ObtenerCodigoArticulo(cbbCodigoDesde.SelectedValue);
            String CodigoHasta = ObtenerCodigoArticulo(cbbCodigoHasta.SelectedValue);
            Int32? ClienteDesde = ObtenerCodigoCliente(cbbClienteDesde.SelectedValue);
            Int32? ClienteHasta = ObtenerCodigoCliente(cbbClienteHasta.SelectedValue);
            Int32? DocumentoDesde = ObtenerDocumento(txtDocumentoDesde.Text);
            Int32? DocumentoHasta = ObtenerDocumento(txtDocumentoHasta.Text);
            Int32? Familia = ObtenerFamilia(cbbFamilia.SelectedValue);
            String Movimiento = ObtenerConceptos();

            MovInventarioBL ObjetoMovimiento = new MovInventarioBL();

            try
            {
                //VENTAS POR CLIENTE
                if (ClienteProveedor == "Cliente")
                {
                    //Reporte Detallado
                    if (ckbDetalle.Checked)
                    {
                        List<cReporteVentasPorClienteDetalle> Lista = ObjetoMovimiento.ReporteVentasporClienteDetalle(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento, ClienteDesde, ClienteHasta);
                        frmrptVentasPorClienteDetallado VentasPorClienteDetalle = new frmrptVentasPorClienteDetallado(Lista);
                        VentasPorClienteDetalle.ShowDialog(this);
                    }
                    //Reporte Resumido
                    else
                    {

                        List<cReporteVentasPorCliente> Lista = ObjetoMovimiento.ReporteVentasporCliente(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento, ClienteDesde, ClienteHasta);

                        frmrptVentasPorCliente VentasPorCliente = new frmrptVentasPorCliente(Lista);
                        VentasPorCliente.ShowDialog(this);
                    }
                }
                //COMPRAS POR PROVEEDOR
                else
                {
                    if (ckbDetalle.Checked)
                    {
                        List<cReporteVentasPorClienteDetalle> Lista = ObjetoMovimiento.ReporteComprasPorProveedorDetalle(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento, ClienteDesde, ClienteHasta);
                        frmrptComprasPorProveedorDetalle ComprasPorProveedor = new frmrptComprasPorProveedorDetalle(Lista);
                        ComprasPorProveedor.ShowDialog(this);
                    }
                    else
                    {

                        List<cReporteVentasPorCliente> Lista = ObjetoMovimiento.ReporteComprasPorProveedor(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento, ClienteDesde, ClienteHasta);

                        frmrptComprasPorProveedor ComprasProveedor = new frmrptComprasPorProveedor(Lista);
                        ComprasProveedor.ShowDialog(this);
                    }
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private string ObtenerConceptos()
        {

            //Obtenemos los conceptos seleccionados
            try
            {
                String Item;
                StringBuilder strCategory = new StringBuilder();
                String Resultado;

                //Recorremos los elementos seleccionados
                foreach (int Ind in lbConceptos.SelectedIndices)
                {
                    Item = (lbConceptos.Items[Ind] as cConcMovInvent).Descripcion.ToString();

                    //strCategory.Append("'");
                    strCategory.Append(Item);
                    //strCategory.Append("'");
                    strCategory.Append(",");

                }

                if (strCategory.ToString() != String.Empty)
                {
                    //Convertimos en una cadena
                    Resultado = strCategory.ToString();
                    //Eliminamos la ultima coma para evitar errores
                    Resultado = Resultado.TrimEnd(new char[] { ',' });
                }
                else
                {
                    Resultado = null;
                }

                return Resultado;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private Int32? ObtenerFamilia(object p)
        {
            //Obtenemos el codigo de familia de articulos
            if(p!=null)
            {
                return Convert.ToInt32(p.ToString());
            }
            else
            {
                return null;
            }
        }

        private int? ObtenerDocumento(string Documento)
        {
            //Obtenemos el documento de movimiento
            Int32 D;
            if(Int32.TryParse(Documento,out D))
            {
                return Convert.ToInt32(Documento.ToString());
            }
            else
            {
                return null;
            }
        }

        private Int32? ObtenerCodigoCliente(object p)
        {
            //Obtenemos el codigo de articulo
            if(p!=null)
            {
                return Convert.ToInt32(p.ToString());
            }
            else
            {
                return null;
            }
        }

        private string ObtenerCodigoArticulo(object Codigo)
        {
            //Obtenemos el codigo de articulo
            if(Codigo!=null)
            {
                return Codigo.ToString();
            }
            else
            {
                return null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            //Fecha movimiento desde
            FechaDesde = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            //Fecha movimiento hasta
            FechaHasta = dtpFechaHasta.Value;
        }

        private void btnBuscarDesde_Click(object sender, EventArgs e)
        {
            //Codigo Desde
            frmListaArticulos ListaArticulos = new frmListaArticulos(1);
            ListaArticulos.ShowDialog(this);
        }

        private void btnBuscarHasta_Click(object sender, EventArgs e)
        {
            //Codigo Hasta
            frmListaArticulos ListaArticulos = new frmListaArticulos(2);
            ListaArticulos.ShowDialog(this);
        }

        private void btnBuscarClienteDesde_Click(object sender, EventArgs e)
        {
            if (ClienteProveedor == "Cliente")
            {
                Factura.frmBuscarCliente BuscarCliente = new Factura.frmBuscarCliente(1);
                BuscarCliente.ShowDialog(this);
            }
            else
            {
                Compras.frmBuscarProveedor BuscarProveedor = new Compras.frmBuscarProveedor(1);
                BuscarProveedor.ShowDialog(this);
            }
        }

        private void btnBuscarClienteHasta_Click(object sender, EventArgs e)
        {

            if (ClienteProveedor == "Cliente")
            {
                Factura.frmBuscarCliente BuscarCliente = new Factura.frmBuscarCliente(2);
                BuscarCliente.ShowDialog(this);
            }
            else
            {
                Compras.frmBuscarProveedor BuscarProveedor = new Compras.frmBuscarProveedor(2);
                BuscarProveedor.ShowDialog(this);
            }
        }
    }
}
