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
    public partial class frmParametroProductosVencidos : Office2007Form, IReportes
    {
        public frmParametroProductosVencidos()
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

        private void frmParametroProductosVencidos_Load(object sender, EventArgs e)
        {
            try
            {
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
                cbbFamilia.SelectedValue = -1;

                //LISTA DE MARCA
                MarcaBL ObjetoMarca = new MarcaBL();
                cbbMarca.DataSource = ObjetoMarca.Listar();
                cbbMarca.ValueMember = "ID";
                cbbMarca.DisplayMember = "Descripcion";
                cbbMarca.SelectedValue = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                InventarioBL ObjetoInventario = new InventarioBL();
                String CodigoDesde = ObtenerCodigo(cbbCodigoDesde.SelectedValue);
                String CodigoHasta = ObtenerCodigo(cbbCodigoHasta.SelectedValue);
                Int32? Familia = ObtenerFamilia(cbbFamilia.SelectedValue);
                Int32? Marca = ObtenerMarca(cbbMarca.SelectedValue);
                String OrdenarPor = ObtenerOrden();

                if (ckbProximosVencimientos.Checked)
                {
                    List<cInventario> Lista = ObjetoInventario.ReporteProductosVencidos(CodigoDesde, CodigoHasta, Familia, Marca, OrdenarPor, null);

                    frmrptProductosVencidos ProductosVencidos = new frmrptProductosVencidos(Lista);
                    ProductosVencidos.ShowDialog(this);
                }
                else
                {
                    List<cInventario> Lista = ObjetoInventario.ReporteProductosVencidos(CodigoDesde, CodigoHasta, Familia, Marca, "Fecha Vencimiento", 1);

                    frmrptProductosVencidos ProductosVencidos = new frmrptProductosVencidos(Lista);
                    ProductosVencidos.ShowDialog(this);
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
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
            else if (rbUltimaCompra.Checked)
            {
                return "Fecha Compra";
            }
            else if (rbUltimaVenta.Checked)
            {
                return "Fecha Venta";
            }
            else
            {
                return "Clave";
            }
        }

        private int? ObtenerMarca(Object p)
        {
            //Obtenemos el codigo de familia de articulos
            if (p != null)
            {
                return Convert.ToInt32(p.ToString());
            }
            else
            {
                return null;
            }
        }

        private int? ObtenerFamilia(Object p)
        {
            //Obtenemos el codigo de familia de articulos
            if (p != null)
            {
                return Convert.ToInt32(p.ToString());
            }
            else
            {
                return null;
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
