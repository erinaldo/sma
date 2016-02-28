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

namespace SMA.Inventario.Reportes
{
    public partial class frmParametroHistoricoExistencia : Office2007Form
    {
        public frmParametroHistoricoExistencia()
        {
            InitializeComponent();
        }

        DateTime? FechaDesde;
        DateTime? FechaHasta;

        private void frmParametroHistoricoExistencia_Load(object sender, EventArgs e)
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
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
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

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpFechaHasta.Value;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                MovInventarioBL ObjetoMovimiento = new MovInventarioBL();
                String CodigoDesde = ObtenerCodigoArticulo(cbbCodigoDesde.SelectedValue);
                String CodigoHasta = ObtenerCodigoArticulo(cbbCodigoHasta.SelectedValue);
                Int32? Familia = ObtenerFamilia(cbbFamilia.SelectedValue);
                String Movimiento = ObtenerConceptos();

                List<cReporteHistoricoExistencia> Lista = ObjetoMovimiento.ReporteHistoricoExistencias(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, Familia, Movimiento);
                frmrptHistoricoExistencia HistoricoExistencia = new frmrptHistoricoExistencia(Lista);
                HistoricoExistencia.ShowDialog(this);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Int32? ObtenerFamilia(object p)
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

        private string ObtenerCodigoArticulo(object Codigo)
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

    }
}
