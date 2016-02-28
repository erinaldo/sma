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


namespace SMA.Inventario.Reportes
{
    public partial class frmParametrosCostoInventario : Office2007Form,IReportes
    {
        public frmParametrosCostoInventario()
        {
            InitializeComponent();
        }

        #region Implementacion de interfase
        public void SeleccionarCliente(Int64 Codigo, Int32 Indicador)
        {
            //No Implementada
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

        private void frmParametrosCostoInventario_Load(object sender, EventArgs e)
        {

            InventarioBL ObjetoInventario = new InventarioBL();
            cbbCodigoDesde.DataSource = ObjetoInventario.Listar();
            cbbCodigoDesde.ValueMember = "CodigoArticulo";
            cbbCodigoDesde.DisplayMember = "Descripcion";

            cbbCodigoHasta.DataSource = ObjetoInventario.Listar();
            cbbCodigoHasta.ValueMember = "CodigoArticulo";
            cbbCodigoHasta.DisplayMember = "Descripcion";

            FamiliaBL ObjetoFamilia = new FamiliaBL();
            cbFamilia.DataSource = ObjetoFamilia.Listar();
            cbFamilia.ValueMember = "ID";
            cbFamilia.DisplayMember = "Descripcion";
            cbFamilia.SelectedValue = -1;

        }

      

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            InventarioBL ObjetoInventario = new InventarioBL();
            //Codigo Inicio de busqueda
            String CodigoDesde = ObtenerCodigo(cbbCodigoDesde.SelectedValue);
            //Codigo Hasta la busqueda
            String CodigoHasta = ObtenerCodigo(cbbCodigoHasta.SelectedValue);
            //Familia de articulos
            Int32? FamiliaID=ObtenerFamilia();
            //Orden de reporte
            String OrdenarPor = ObtenerOrden();


           

            List<cInventario> ListaInventario = ObjetoInventario.ReporteExistenciaCosto(CodigoDesde, CodigoHasta, FamiliaID,OrdenarPor);

            frmrptCostoInventario ReporteListaProductos = new frmrptCostoInventario(ListaInventario);
            ReporteListaProductos.ShowDialog(this);
        }

        private string ObtenerCodigo(object Codigo)
        {
            //Obtenemos el codigo de articulo
            if (Codigo != null)
            {
                return Codigo.ToString();
            }
            else
            {
                return null;
            }
        }

        private int? ObtenerFamilia()
        {
            if (cbFamilia.SelectedValue != null)
            {
                Int32 Familia;
                if (Int32.TryParse(cbFamilia.SelectedValue.ToString(), out Familia))
                {
                    return Convert.ToInt32(cbFamilia.SelectedValue.ToString());
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

        private string ObtenerOrden()
        {
            if (rbCodigo.Checked)
            {
                return "Clave";
            }
            else if (rbDescripcion.Checked)
            {
                return "Descripcion";
            }
            else if (rbExistencia.Checked)
            {
                return "Existencia";
            }
            else if (rbFamilia.Checked)
            {
                return "Familia";
            }
           
            else
            {
                return "Clave";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarDesde_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulos = new frmListaArticulos(1);
            ListaArticulos.ShowDialog(this);
        }

        private void btnBuscarHasta_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulos = new frmListaArticulos(2);
            ListaArticulos.ShowDialog(this);
        }
    }
}
