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

namespace SMA.Compras
{
    public partial class frmFiltroRecepcion : Office2007Form,iGestionDocumentoCompras
    {
        frmGestionRecepciones GestionRecepciones;
        DateTime? FechaDesde;
        DateTime? FechaHasta;

        public frmFiltroRecepcion()
        {
            InitializeComponent();
        }

        public frmFiltroRecepcion(frmGestionRecepciones GestionRecepciones):this()
        {
            this.GestionRecepciones = GestionRecepciones;
        }

        #region Implementacion de Interfase
        public void BusquedaProveedor(Int64 ProveedorID)
        {
            cbProveedor.SelectedValue = ProveedorID;
        }

        public void SeleccionDocumento(string Documento, Int32 Indicador)
        {
            //NO IMPLEMENTADA
        }

        public void SeleccionProveedor(Int64 Codigo, Int32 Indicador)
        {
            //NO IMPLEMENTADA
        }

        public void BusquedaArticulo(Int64 Codigo)
        {

        }

        public void SeleccionFamilia(Int32 Codigo)
        {

        }
        #endregion

        private void frmFiltroRecepcion_Load(object sender, EventArgs e)
        {
            try
            {
                ProveedorBL ObjetoProveedor = new ProveedorBL();
                cbProveedor.DataSource = ObjetoProveedor.Listar();
                cbProveedor.ValueMember = "ID";
                cbProveedor.DisplayMember = "NombreComercial";
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
            Int32? ProveedorID = ObtenerProveedor(cbProveedor.SelectedValue);

            Int32? DocumentoDesde = ObtenerDocumento(txtDesde.Text);
            Int32? DocumentoHasta = ObtenerDocumento(txtHasta.Text);
            Boolean IndGenerada = ckbGenerada.Checked;
            Boolean IndCancelada = ckbCancelada.Checked;
            Boolean IndDevuelta = ckbRecibida.Checked;
            String CriterioCantidad = ObtenerCriterio(cbbCriterio.Text);
            Decimal ValorFactura = ObtenerValor(txtImporte.Text);

            List<cCompras> Lista = ObjetoCompra.FiltrarRecepcion("R", ProveedorID, DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta, CriterioCantidad, ValorFactura, IndGenerada, IndCancelada,IndDevuelta);
            GestionRecepciones.BuscarRecepcion(Lista);
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
            if (p != null && p != "")
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
        private int? ObtenerProveedor(Object p)
        {
            //Obtenemos el codigo de proveedor
            Int32 Codigo;
            if (p!=null)
            {
                if (Int32.TryParse(p.ToString(), out Codigo))
                {
                    return Convert.ToInt32(p.ToString());
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpDesde.Value.Date;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpHasta.Value.Date;
        }

        private void btnVerProveedores_Click(object sender, EventArgs e)
        {
            //Buscamos los proveedores
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor();
            BuscarProveedor.ShowDialog(this);
        }

        private void btnBuscarDocumentoDesde_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaDocumento = new frmListaDocumento("R", 1);
            ListaDocumento.ShowDialog(this);
        }

        private void btnBuscarDocumentoHasta_Click(object sender, EventArgs e)
        {

            frmListaDocumento ListaDocumento = new frmListaDocumento("R", 2);
            ListaDocumento.ShowDialog(this);
        }
    }
}
