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
    public partial class frmListaArticulos : Office2007Form
    {
        private String ArticuloID;
        private Int32 Seleccion;
        InventarioBL ObjetoInventario = new InventarioBL();
        List<cInventario> ListaInventario;
        String Criterio;

        public frmListaArticulos()
        {
            InitializeComponent();

        }
        
        public frmListaArticulos(Int32 Seleccion):this()
        {
            //Indica cual de los combobox fue el seleccionado
            //1-Codigo Desde
            //2-Codigo Hasta
            this.Seleccion = Seleccion;
        }

        private void frmListaArticulos_Load(object sender, EventArgs e)
        {
            dgvArticulos.AutoGenerateColumns = false;
            ListaInventario = ObjetoInventario.Listar();
            dgvArticulos.DataSource = ListaInventario;

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            
            if(Criterio=="Codigo")
            {
              List<cInventario> Resultado=(from C in ListaInventario
                                   where C.CodigoArticulo.StartsWith(txtBusqueda.Text)
                                           select C).ToList();
              ActualizarGrid(Resultado);

            }
            else if(Criterio=="Descripcion")
            {
                List<cInventario> Resultado=(from C in ListaInventario
                                   where C.Descripcion.StartsWith(txtBusqueda.Text)
                                             select C).ToList();
                ActualizarGrid(Resultado);
            }
            else if(Criterio=="Familia")
            {
                List<cInventario> Resultado=(from C in ListaInventario
                                             where Convert.ToString(C.FamiliaID).StartsWith(txtBusqueda.Text)
                                             select C).ToList();
                ActualizarGrid(Resultado);
            }
            else
            {
                ActualizarGrid(ListaInventario);
            }
          
        }

        private void ActualizarGrid(List<cInventario> Listado)
        {
            dgvArticulos.DataSource = Listado;
        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ArticuloID = Convert.ToString(dgvArticulos.Rows[e.RowIndex].Cells[1].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //Provee el codigo del articulo a ser buscado
            IReportes FormInterfaceReporte = this.Owner as IReportes;
            if (FormInterfaceReporte != null && ArticuloID != null)
            {
                if (Seleccion == 1)
                {
                    FormInterfaceReporte.SeleccionarCodigoDesde(ArticuloID);
                }
                else if(Seleccion==2)
                {
                    FormInterfaceReporte.SeleccionarCodigoHasta(ArticuloID);
                }

            this.Close();
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbCriterio.Text)
            {
                case "Codigo":
                    Criterio = "Codigo";
                    break;
                case "Descripcion":
                    Criterio = "Descripcion";
                    break;
                case "Familia":
                    Criterio = "Familia";
                    break;
            }
        }

        


    }
}
