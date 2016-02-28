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


namespace SMA.Compras.Reportes
{
    public partial class frmParametroArticulosDevueltos : Office2007Form,iGestionDocumentoCompras
    {
        private DateTime? FechaDesde;
        private DateTime? FechaHasta;

        #region Contructores
        public frmParametroArticulosDevueltos()
        {
            InitializeComponent();
        }
        #endregion

        #region Implementacion de Interfases
        public void BusquedaProveedor(Int64 Codigo)
        {
            //Seleccionamos el proveedor
            cbbProveedor.SelectedValue = Codigo;
        }
        public void SeleccionDocumento(string Documento, Int32 Indicador)
        {
            //Procedimiento para poblar los campos de documentos
            if (Indicador == 1)
            {
                txtDocumentoDesde.Text = Documento;
            }
            else
            {
                txtDocumentoHasta.Text = Documento;
            }
        }

        public void SeleccionProveedor(Int64 Codigo, Int32 Indicador)
        {
        //NO IMPLEMENTADA
        }

        public void BusquedaArticulo(Int64 Codigo)
        {
            cbbProducto.SelectedValue = Codigo;
        }

        public void SeleccionFamilia(Int32 Codigo)
        {
            //SELECCIONAMOS LA FAMILIA DE ARTICULOS
            cbbFamilia.SelectedValue = Codigo;
        }
        #endregion
        private void frmParametroArticulosDevueltos_Load(object sender, EventArgs e)
        {
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            cbbProveedor.DataSource = ObjetoProveedor.Listar();
            cbbProveedor.ValueMember = "ID";
            cbbProveedor.DisplayMember = "NombreComercial";
            cbbProveedor.SelectedValue = -1;

            InventarioBL ObjetoInventario = new InventarioBL();
            cbbProducto.DataSource = ObjetoInventario.Listar();
            cbbProducto.DisplayMember = "Descripcion";
            cbbProducto.ValueMember = "ID";
            cbbProducto.SelectedValue = -1;

            FamiliaBL ObjetoFamilia = new FamiliaBL();
            cbbFamilia.DataSource = ObjetoFamilia.Listar();
            cbbFamilia.DisplayMember = "Descripcion";
            cbbFamilia.ValueMember = "ID";
            cbbFamilia.SelectedValue = -1;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ComprasBL ObjetoCompra = new ComprasBL();
            Int32? DocumentoDesde = ObtenerDocumento(txtDocumentoDesde.Text);
            Int32? DocumentoHasta = ObtenerDocumento(txtDocumentoHasta.Text);
            Int32? FamiliaID = ObtenerFamilia();
            Int32? CodigoProveedor = ObtenerProveedor(cbbProveedor.SelectedValue);
            String CodigoArticulo = ObtenerArticulo(cbbProducto.SelectedValue);

            List<cReporteArticulosDevueltos> Lista = ObjetoCompra.ReporteArticulosDevueltos(DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta, CodigoProveedor,CodigoArticulo, FamiliaID);
            frmrptArticulosDevueltos ArticulosDevueltos = new frmrptArticulosDevueltos(Lista);
            ArticulosDevueltos.ShowDialog(this);
        }

        private string ObtenerArticulo(object p)
        {
            //Obtenemos el codigo de articulo
            if (p != null)
            {
                return p.ToString();
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

        private int? ObtenerProveedor(object p)
        {
            //Obtenemos el codigo de articulo
            if (p != null)
            {
                return Convert.ToInt32(p.ToString());
            }
            else
            {
                return null;
            }
        }
        private int? ObtenerFamilia()
        {
            //Obtenemos la familia de articulos
            if (cbbFamilia.Text != String.Empty)
            {
                return Convert.ToInt32(cbbFamilia.SelectedValue.ToString());
            }
            else
            {
                return null;
            }
        }
        private int? ObtenerDocumento(string p)
        {
            //Obtenemos el codigo a partir de un text
            Int32 Codigo;
            if (Int32.TryParse(p, out Codigo))
            {
                return Convert.ToInt32(p);
            }
            else
            {
                return null;
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpFechaHasta.Value;
        }

        private void btnBuscarDocumentoDesde_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaDocumento=new frmListaDocumento("R",1);
            ListaDocumento.ShowDialog(this);
        }

        private void btnBuscarDocumentoHasta_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaDocumento = new frmListaDocumento("R", 2);
            ListaDocumento.ShowDialog(this);
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor();
            BuscarProveedor.ShowDialog(this);
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            Factura.frmBuscarArticulos BuscarArticulo = new Factura.frmBuscarArticulos();
            BuscarArticulo.ShowDialog(this);


        }

        private void btnBuscarFamilia_Click(object sender, EventArgs e)
        {
            Inventario.frmListarComponentes ListaComponentes = new Inventario.frmListarComponentes("Familia");
            ListaComponentes.ShowDialog(this);
        }
    }
}
