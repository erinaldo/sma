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

namespace SMA.Compras.Ordenes
{
    public partial class frmFiltrarOrdenCompra : Office2007Form,iGestionDocumentoCompras
    {
        private frmGestionOrdenesCompra GestionOrdenes;
        DateTime? FechaDesde;
        DateTime? FechaHasta;

        #region Constructores
        public frmFiltrarOrdenCompra()
        {
            InitializeComponent();
        }
        #endregion

        #region Implementacion de Interfase
        public void BusquedaProveedor(Int64 ProveedorID)
        {
           //BUSQUEDA DE PROVEEDORES
            cbProveedor.SelectedValue = ProveedorID;
        }

        public void SeleccionDocumento(string Documento, Int32 Indicador)
        {
            //SELECCION DE DOCUMENTO
            if (Indicador == 1)
            {
                txtDesde.Text = Documento;
            }
            else
            {
                txtHasta.Text = Documento;
            }
        }

        public void SeleccionProveedor(Int64 Codigo, Int32 Indicador)
        {
            //NO IMPLEMENTADA
        }

        public void BusquedaArticulo(Int64 Codigo)
        {
            //NO IMPLEMENTADA
        }

        public void SeleccionFamilia(Int32 Codigo)
        {

        }

        #endregion

        public frmFiltrarOrdenCompra(frmGestionOrdenesCompra GestionOrdenes):this()
        {
            this.GestionOrdenes = GestionOrdenes;
        }

        private void frmFiltrarOrdenCompra_Load(object sender, EventArgs e)
        {
            try
            {
                ProveedorBL ObjetoProveedor = new ProveedorBL();
                cbProveedor.DataSource = ObjetoProveedor.Listar();
                cbProveedor.DisplayMember = "NombreComercial";
                cbProveedor.ValueMember = "ID";
                cbProveedor.SelectedValue = -1;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ComprasBL ObjetoCompra = new ComprasBL();
            Int32? ProveedorID = ObtenerProveedor();
            
            Int32? DocumentoDesde =  ObtenerDocumento(txtDesde.Text);
            Int32? DocumentoHasta = ObtenerDocumento(txtHasta.Text);
            Boolean IndGenerada = ckbGenerada.Checked;
            Boolean IndCancelada = ckbCancelada.Checked;
            Boolean IndFacturada = ckbFacturada.Checked;
            String CriterioCantidad = ObtenerCriterio(cbbCriterio.Text);
            Decimal ValorFactura = ObtenerValor(txtImporte.Text);

            List<cCompras> Lista =ObjetoCompra.Filtrar("O", ProveedorID, DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta,CriterioCantidad,ValorFactura,IndGenerada, IndCancelada, IndFacturada);
            GestionOrdenes.BuscarOrdenes(Lista);
        }
        private Decimal ObtenerValor(string p)
        {
            Decimal Valor;
            if (Decimal.TryParse(p, out Valor))
            {
                return Convert.ToDecimal(p);
            }
            else
            {
                return 0;
            }
        }

        private string ObtenerCriterio(string p)
        {
            if (p != null && p!="")
            {
                return p;
            }
            else
            {
                return "Todos";
            }
        }

        private int? ObtenerDocumento(string p)
        {
            Int32 Valor;
            if (Int32.TryParse(p, out Valor))
            {
                return Convert.ToInt32(p);
            }
            else
            {
                return null;
            }
        }
        private int? ObtenerProveedor()
        {
            //Obtenemos el codigo de proveedor
            Int32 Codigo;
            if(cbProveedor.Text!=String.Empty)
            {
                if(Int32.TryParse(cbProveedor.SelectedValue.ToString(),out Codigo))
                {
                    return Convert.ToInt32(cbProveedor.SelectedValue.ToString());
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

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpDesde.Value.Date;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpHasta.Value.Date;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarDocumentoDesde_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaDocumentos = new frmListaDocumento("O", 1);
            ListaDocumentos.ShowDialog(this);
        }

        private void btnBuscarDocumentoHasta_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaDocumentos = new frmListaDocumento("O", 2);
            ListaDocumentos.ShowDialog(this);
        }

        private void btnVerProveedores_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor ListaProveedores = new frmBuscarProveedor();
            ListaProveedores.ShowDialog(this);
        }
    }
}
