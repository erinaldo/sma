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
    public partial class frmParametroCatalogoProductos : Office2007Form, IReportes
    {
        public frmParametroCatalogoProductos()
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
            if (Codigo != null)
            {
                cbbCodigoDesde.SelectedValue = Codigo;
            }
        }

        public void SeleccionarCodigoHasta(String Codigo)
        {
            if (Codigo != String.Empty)
            {
                cbbCodigoHasta.SelectedValue = Codigo;
            }
        }
        #endregion

        private void frmParametroCatalogoProductos_Load(object sender, EventArgs e)
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
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                InventarioBL ObjetoInventario = new InventarioBL();
                String CodigoDesde = ObtenerCodigoDesde();
                String CodigoHasta = ObtenerCodigoHasta();
                Int32? FamiliaID = ObtenerFamilia();
                Int32? MarcaID = ObtenerMarca();
                String OrdenarPor = ObtenerOrden();
                String TipoArticulo = ObtenerTipoAticulo();

                List<cInventario> Listado = ObjetoInventario.ReporteCatalogoProductos(CodigoDesde, CodigoHasta, FamiliaID, MarcaID, TipoArticulo, OrdenarPor);
                frmrptCatalogoProductos CatalogoProductos = new frmrptCatalogoProductos(Listado);
                CatalogoProductos.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private String ObtenerTipoAticulo()
        {



            try
            {
                String Item;
                StringBuilder strCategory = new StringBuilder();
                String Resultado;

               
                if(ckbTodos.Checked)
                {
                    return "Todos";
                }
                else
                {
                    if(ckbFisicos.Checked)
                    {
                        //strCategory.Append("'");
                        strCategory.Append("F");
                        //strCategory.Append("'");
                        strCategory.Append(",");
                    }
                    
                    if (ckbServicios.Checked)
                    {
                        //strCategory.Append("'");
                        strCategory.Append('S');
                        //strCategory.Append("'");
                        strCategory.Append(",");
                    }
                   
                    if(ckbCombos.Checked)
                    {
                        //strCategory.Append("'");
                        strCategory.Append('C');
                        //strCategory.Append("'");
                        strCategory.Append(",");
                    }
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

        private string ObtenerOrden()
        {
            if(rbCodigo.Checked)
            {
                return "Clave";
            }
            else if(rbDescripcion.Checked)
            {
                return "Descripcion";
            }
            else if(rbExistencia.Checked)
            {
                return "Existencia";
            }
            else if(rbFamilia.Checked)
            {
                return "Familia";
            }
            else if(rbUltimaCompra.Checked)
            {
                return "Fecha Compra";
            }
            else if(rbUltimaVenta.Checked)
            {
                return "Fecha Venta";
            }
            else
            {
                return "Clave";
            }
        }

        private String ObtenerCodigoDesde()
        {
            try
            {
                if(cbbCodigoDesde.Text!=String.Empty)
                {
                    return cbbCodigoDesde.SelectedValue.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private String ObtenerCodigoHasta()
        {
            try
            {
                if (cbbCodigoHasta.Text != String.Empty)
                {
                    return cbbCodigoHasta.SelectedValue.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private Nullable<int> ObtenerMarca()
        {
            try
            {
                if(cbbMarca.Text!=String.Empty)
                {
                    return Convert.ToInt32(cbbMarca.SelectedValue.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private Nullable<int> ObtenerFamilia()
        {
            try
            {
                if (cbbFamilia.Text != String.Empty)
                {
                    return Convert.ToInt32(cbbFamilia.SelectedValue.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnBuscarDesde_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulo = new frmListaArticulos(1);
            ListaArticulo.ShowDialog(this);
        }

        private void btnBuscarHasta_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulo = new frmListaArticulos(2);
            ListaArticulo.ShowDialog(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
