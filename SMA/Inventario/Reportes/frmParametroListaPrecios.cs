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
    public partial class frmParametroListaPrecios : Office2007Form,IReportes
    {
        public frmParametroListaPrecios()
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


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            InventarioBL ObjetoInventario=new InventarioBL();
            String CodigoDesde = ObtenerCodigoDesde();
            String CodigoHasta = ObtenerCodigoHasta();
            Int32? Familia = ObtenerFamilia();
            String TipoArticulo = ObtenerTipoArticulo();
            String IndicadorPrecio1 = ObtenerPrecio1();
            String IndicadorPrecio2 = ObtenerPrecio2();
            String OrdenarPor = ObtenerOrdenarPor();
            Int32? ConExistencia = ObtenerIndicadorExistencia();

            List<cInventario> Lista = ObjetoInventario.ReporteListaPrecios(CodigoDesde, CodigoHasta, Familia, IndicadorPrecio1, IndicadorPrecio2, ConExistencia, TipoArticulo, OrdenarPor);
            frmrptListaPrecios ListaPrecios = new frmrptListaPrecios(Lista);
            ListaPrecios.ShowDialog(this);
        }

        private Int32? ObtenerIndicadorExistencia()
        {
            if(ckbConExistencia.Checked)
            {
                return 1;
            }
            else
            {
                return null;
            }
        }

        private string ObtenerOrdenarPor()
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

        private string ObtenerPrecio2()
        {
            if(cbbPrecio2.Text!="Ninguno" || cbbPrecio2.Text!=String.Empty)
            {
                return cbbPrecio2.Text;
            }
            else
            {
                return null;
            }
        }

        private string ObtenerPrecio1()
        {
            if (cbbPrecio1.Text != "Ninguno" || cbbPrecio1.Text!=String.Empty)
            {
                return cbbPrecio1.Text;
            }
            else
            {
                return null;
            }
        }

        private string ObtenerTipoArticulo()
        {

            try
            {
                String Item;
                StringBuilder strCategory = new StringBuilder();
                String Resultado;


                if (ckbFisico.Checked)
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

                if (ckbCombos.Checked)
                {
                    //strCategory.Append("'");
                    strCategory.Append('C');
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
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private int? ObtenerFamilia()
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

        private string ObtenerCodigoHasta()
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

        private string ObtenerCodigoDesde()
        {
            try
            {
                if (cbbCodigoDesde.Text != String.Empty)
                {
                    return cbbCodigoDesde.SelectedValue.ToString();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmParametroListaPrecios_Load(object sender, EventArgs e)
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
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
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
