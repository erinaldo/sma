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
using SMA.Compras;

namespace SMA.Factura
{
    public partial class frmBuscarArticulos : Office2007Form
    {
        private int ArticuloID;
        
        public frmBuscarArticulos()
        {
            InitializeComponent();
        }


        InventarioBL ObjetoInventario = new InventarioBL();
        List<cInventario> ListaInventario;
        String Criterio;

        private void frmBuscarArticulos_Load(object sender, EventArgs e)
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ArticuloID = Convert.ToInt32(dgvArticulos.CurrentRow.Cells[0].Value);
            SeleccionarArticulo(ArticuloID);
        }

        private void rbCodigo_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void rbDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbFamilia_CheckedChanged(object sender, EventArgs e)
        {
            
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
                ArticuloID = Convert.ToInt32(dgvArticulos.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionarArticulo(int ArticuloID)
        {
            //Provee el codigo del articulo a ser buscado
            IagregarEditarFacturas FormInterfaceFactura = this.Owner as IagregarEditarFacturas;
            if (FormInterfaceFactura != null)
            {
                FormInterfaceFactura.BuscarArticulo(ArticuloID);
            }

            IagregarEditarRecepcion FormInterfaceCompras = this.Owner as IagregarEditarRecepcion;
            if (FormInterfaceCompras!=null)
            {
                FormInterfaceCompras.BuscarArticulo(ArticuloID);
            }

            iGestionDocumentoCompras FormInterfaseGestionCompras = this.Owner as iGestionDocumentoCompras;
            if(FormInterfaseGestionCompras!=null)
            {
                FormInterfaseGestionCompras.BusquedaArticulo(ArticuloID);
            }
               
            this.Close();
        }

        private void frmBuscarArticulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 )
            {
                if (dgvArticulos.Rows.Count > 0)
                {
                    Int32 i = dgvArticulos.CurrentRow.Index-1;
                    if (i != -1)
                    {
                        SeleccionarArticulo(Convert.ToInt32(dgvArticulos.Rows[i].Cells[0].Value));
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
