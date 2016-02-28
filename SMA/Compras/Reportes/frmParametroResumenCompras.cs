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


namespace SMA.Compras.Reportes
{
    public partial class frmParametroResumenCompras : Office2007Form,iGestionDocumentoCompras
    {
        private String TipoDocumento;
        private DateTime? FechaDesde;
        private DateTime? FechaHasta;

        #region Contructores
        public frmParametroResumenCompras()
        {
            InitializeComponent();
        }

        public frmParametroResumenCompras(String TipoDocumento):this()
        {
            this.TipoDocumento = TipoDocumento;
        }
        #endregion

        #region Implementacion de Interfase

        public void BusquedaProveedor(Int64 Codigo)
        {
            //No Implemetada
        }
        public void SeleccionDocumento(string Documento, Int32 Indicador)
        {
            //Procedimiento para poblar los campos de documentos
            if(Indicador==1)
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
            //Procedimiento para seleccionar rango de proveedores
            if(Indicador==1)
            {
                cbbProveedorDesde.SelectedValue = Codigo;
            }
            else
            {
                cbbProveedorHasta.SelectedValue = Codigo;
            }
        }

        public void BusquedaArticulo(Int64 Codigo)
        {
            //NO IMPLEMENTADA
        }

        public void SeleccionFamilia(Int32 Codigo)
        {
            //NO IMPLEMENTADA
        }
        #endregion

        private void frmParametroResumenCompras_Load(object sender, EventArgs e)
        {
            //INFORMACION DE PROVEEDORES
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            cbbProveedorDesde.DataSource = ObjetoProveedor.Listar();
            cbbProveedorDesde.DisplayMember = "NombreComercial";
            cbbProveedorDesde.ValueMember = "ID";
            cbbProveedorDesde.SelectedValue = -1;

            cbbProveedorHasta.DataSource = ObjetoProveedor.Listar();
            cbbProveedorHasta.DisplayMember = "NombreComercial";
            cbbProveedorHasta.ValueMember = "ID";
            cbbProveedorHasta.SelectedValue = -1;

            //INFORMACION FAMILIA DE ARTICULOS
            FamiliaBL ObjetoFamilia = new FamiliaBL();
            cbbFamilia.DataSource = ObjetoFamilia.Listar();
            cbbFamilia.ValueMember = "ID";
            cbbFamilia.DisplayMember = "Descripcion";
            cbbFamilia.SelectedValue = -1;

        }

        private void btnBuscarDocumentoDesde_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaDocumentos = new frmListaDocumento("R",1);
            ListaDocumentos.ShowDialog(this);
        }

        private void btnBuscarDocumentoHasta_Click(object sender, EventArgs e)
        {
            frmListaDocumento ListaDocumentos = new frmListaDocumento("R",2);
            ListaDocumentos.ShowDialog(this);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ComprasBL ObjetoCompras = new ComprasBL();
                Int32? DocumentoDesde = ObtenerDocumento(txtDocumentoDesde.Text);
                Int32? DocumentoHasta = ObtenerDocumento(txtDocumentoHasta.Text);
                Int32? FamiliaID = ObtenerFamilia();
                Int32? ProveedorDesde = ObtenerProveedor(cbbProveedorDesde.SelectedValue);
                Int32? ProveedorHasta = ObtenerProveedor(cbbProveedorHasta.SelectedValue);

                List<cReporteResumenFactura> Lista = ObjetoCompras.ResumenCompras(DocumentoDesde, DocumentoHasta, FamiliaID, FechaDesde, FechaHasta, ProveedorDesde, ProveedorHasta, TipoDocumento);
                if (Lista.Count > 0)
                {
                    if (TipoDocumento == "R")
                    {
                        //RESUMEN DE RECEPCIONES
                        frmrptResumenRecepciones ResumenRecepciones = new frmrptResumenRecepciones(Lista);
                        ResumenRecepciones.ShowDialog(this);
                    }
                    else if (TipoDocumento == "D")
                    {
                        //RESUMEN DE DEVOLUCIONES
                        frmrptResumenDevoluciones ResumenDevoluciones = new frmrptResumenDevoluciones(Lista);
                        ResumenDevoluciones.ShowDialog(this);
                    }
                }
                else
                {
                    MessageBox.Show("La busqueda no arrojado ningun resultado", "Busqueda sin resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            //Fecha Inicial
            FechaDesde = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            //Fecha Final
            FechaHasta = dtpFechaHasta.Value;
        }

        private void btnBuscarProveedorDesde_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor(1);
            BuscarProveedor.ShowDialog(this);
        }

        private void btnBuscarProveedorHasta_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor(2);
            BuscarProveedor.ShowDialog(this);
        }
    }
}
