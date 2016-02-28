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

namespace SMA.Compras.Devoluciones
{
    public partial class frmFiltrarDevolucionCompra : Office2007Form,iGestionDocumentoCompras
    {
        private frmGestionDevolucionCompras GestionDevolucion;
        DateTime? FechaDesde;
        DateTime? FechaHasta;

        public frmFiltrarDevolucionCompra()
        {
            InitializeComponent();
        }

        public frmFiltrarDevolucionCompra(frmGestionDevolucionCompras GestionDevolucion):this()
        {
            this.GestionDevolucion = GestionDevolucion;
        }

        #region Implementacion de Interfase
        public void BusquedaProveedor(Int64 ProveedorID)
        {
            cbProveedor.SelectedValue = ProveedorID;
        }

       public void SeleccionDocumento(string Documento,Int32 Indicador)
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

        private void frmFiltrarDevolucionCompra_Load(object sender, EventArgs e)
        {
            try
            {
                ProveedorBL ObjetoCliente = new ProveedorBL();
                cbProveedor.DataSource = ObjetoCliente.Listar();
                cbProveedor.ValueMember = "ID";
                cbProveedor.DisplayMember = "NombreComercial";
                cbProveedor.SelectedValue = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al listar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ComprasBL ObjetoCompra = new ComprasBL();
            Int32? ProveedorID = ObtenerProveedor();
            Int32? DocumentoDesde = ObtenerDocumento(txtDesde.Text);
            Int32? DocumentoHasta = ObtenerDocumento(txtHasta.Text);
            Boolean IndGenerada = ckbGenerada.Checked;
            Boolean IndCancelada = ckbCancelada.Checked;
            String CriterioCantidad = ObtenerCriterio(cbbCriterio.Text);
            Decimal ValorFactura = ObtenerValor(txtImporte.Text);
            //Boolean IndFacturada = ckbFacturada.Checked;

            List<cCompras> Lista = ObjetoCompra.Filtrar("D",ProveedorID,DocumentoDesde,DocumentoHasta,FechaDesde,FechaHasta,CriterioCantidad,ValorFactura,IndGenerada,IndCancelada);
            GestionDevolucion.BuscarOrdenes(Lista);
        }

        private Decimal ObtenerValor(string p)
        {
            Decimal Valor;
            if(Decimal.TryParse(p,out Valor))
            {
                return Convert.ToDecimal(p);
            }
            else
            {
                return 0;
            }
        }

        private int? ObtenerDocumento(string p)
        {
            Int32 Valor;
            if(Int32.TryParse(p,out Valor))
            {
                return Convert.ToInt32(p);
            }
            else
            {
                return null;
            }
        }

        private string ObtenerCriterio(string p)
        {
            if(p!=null  && p!="")
            {
                return p;
            }
            else
            {
                return "Todos";
            }
        }

        private int? ObtenerProveedor()
        {
            //Obtenemos el codigo de proveedor
            Int32 Codigo;
            if (cbProveedor.Text != String.Empty)
            {
                if (Int32.TryParse(cbProveedor.SelectedValue.ToString(), out Codigo))
                {
                    return Convert.ToInt32(cbProveedor.SelectedValue.ToString());
                }
                else
                {
                    throw new Exception("Error al obtener proveedor");
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

        private void btnVerProveedores_Click(object sender, EventArgs e)
        {
            //Buscamos los proveedores
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor();
            BuscarProveedor.ShowDialog(this);
        }

        private void btnBuscarDocumentoDesde_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaDocumento = new frmListaDocumento("D", 1);
            ListaDocumento.ShowDialog(this);
        }

        private void btnBuscarDocumentoHasta_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaDocumento = new frmListaDocumento("D", 2);
            ListaDocumento.ShowDialog(this);
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpDesde.Value.Date;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpHasta.Value.Date;
        }
    }
}
