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

namespace SMA.Inventario
{
    public partial class frmListaArticulos : Office2007Form
    {
        private String ArticuloID;

        InventarioBL ObjetoInventario = new InventarioBL();
        List<cInventario> ListaInventario;
        String Criterio;
        Int16 Seleccion;

        public frmListaArticulos()
        {
            InitializeComponent();
        }

        public frmListaArticulos(Int16 Seleccion):this()
        {
            this.Seleccion = Seleccion;
        }
        private void frmListaArticulos_Load(object sender, EventArgs e)
        {

            try
            {
                dgvArticulos.AutoGenerateColumns = false;
                ListaInventario = ObjetoInventario.Listar();
                dgvArticulos.DataSource = ListaInventario;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (Criterio == "Codigo")
            {
                List<cInventario> Resultado = (from C in ListaInventario
                                               where C.CodigoArticulo.StartsWith(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);

            }
            else if (Criterio == "Descripcion")
            {
                List<cInventario> Resultado = (from C in ListaInventario
                                               where C.Descripcion.StartsWith(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);
            }
            else if (Criterio == "Familia")
            {
                List<cInventario> Resultado = (from C in ListaInventario
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

            ArticuloID = Convert.ToString(dgvArticulos.CurrentRow.Cells[1].Value);
            SeleccionarArticulo(ArticuloID);

        }
             private void SeleccionarArticulo(String ArticuloID)
        {
            //Provee el codigo del articulo a ser buscado
            IGeneral FormInterfaceFactura = this.Owner as IGeneral;
            if (FormInterfaceFactura != null)
            {
                FormInterfaceFactura.SeleccionarArticulo(ArticuloID, Seleccion);
            }

           
            

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaArticulos_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == (char)13 )
            {
                if (dgvArticulos.Rows.Count > 0)
                {
                    Int32 i = dgvArticulos.CurrentRow.Index-1;
                    if (i != -1)
                    {
                        SeleccionarArticulo(Convert.ToString(dgvArticulos.Rows[i].Cells[1].Value));
                    }
                }
                else
                {
                    MessageBox.Show("Error al seleccionar articulo, la busqueda no arrojo ninguna resultado", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
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
