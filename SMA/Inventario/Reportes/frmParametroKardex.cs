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
    public partial class frmParametroKardex : Office2007Form, IReportes
    {
        public frmParametroKardex()
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

        private void frmParametroKardex_Load(object sender, EventArgs e)
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
                //VALOR INICIAL
                cbbFamilia.SelectedValue = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String CodigoDesde = ObtenerCodigoDesde();
            String CodigoHasta = ObtenerCodigoHasta();
            Int32? Familia = ObtenerFamilia();

            MovInventarioBL ObjetoMovimiento=new MovInventarioBL();
            List<cReporteKardexInventario> Lista = ObjetoMovimiento.ReporteKardexInventario(CodigoDesde, CodigoHasta, Familia);

            frmrptKardexInventario KardexInventario = new frmrptKardexInventario(Lista);
            KardexInventario.ShowDialog(this);
        }

        private string ObtenerCodigoDesde()
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

        private string ObtenerCodigoHasta()
        {
            if(cbbCodigoHasta.Text!=String.Empty)
            {
                return cbbCodigoHasta.SelectedValue.ToString();
            }
            else
            {
                return null;
            }
        }

        private int? ObtenerFamilia()
        {
            Int32 Codigo;
            if(cbbFamilia.Text!=String.Empty)
            {
                if (Int32.TryParse(cbbFamilia.SelectedValue.ToString(), out Codigo))
                {
                    return Convert.ToInt32(cbbFamilia.SelectedValue.ToString());
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
