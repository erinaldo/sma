using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.Entity;
using SMA.BL;


namespace SMA.Vendedor
{
    public partial class frmListaVendedor : Office2007Form
    {
        private Int32 VendedorID;

        public frmListaVendedor()
        {
            InitializeComponent();
        }

        VendedorBL ObjetoInventario = new VendedorBL();
        List<cVendedor> ListaVendores;
        String Criterio;

        private void frmListaVendedor_Load(object sender, EventArgs e)
        {
            VendedorBL ObjetoVendedor = new VendedorBL();
            dgvVendedor.AutoGenerateColumns = false;
            ListaVendores = ObjetoVendedor.Listar();
            dgvVendedor.DataSource = ListaVendores;
            
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            VendedorID = Convert.ToInt32(dgvVendedor.CurrentRow.Cells[0].Value);
            SeleccionVedendor(VendedorID);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (Criterio == "Codigo")
            {
                List<cVendedor> Resultado = (from C in ListaVendores
                                               where C.ID==Convert.ToInt32(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);

            }
            else if (Criterio == "Nombre")
            {
                List<cVendedor> Resultado = (from C in ListaVendores
                                               where C.Nombre.StartsWith(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);
            }
            else if (Criterio == "Telefono")
            {
                List<cVendedor> Resultado = (from C in ListaVendores
                                               where C.Telefono.StartsWith(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);
            }

        }

        private void ActualizarGrid(List<cVendedor> Listado)
        {
            dgvVendedor.DataSource = Listado;
        }

        private void cbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbCriterio.Text)
            {
                case "Codigo":
                    Criterio = "Codigo";
                    break;
                case "Nombre":
                    Criterio = "Nombre";
                    break;
                case "Telefono":
                    Criterio = "Telefono";
                    break;
            }
        }

        private void dgvVendedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmListaVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (dgvVendedor.Rows.Count > 0)
                {
                    Int32 i = dgvVendedor.CurrentRow.Index - 1;
                    if (i != -1)
                    {
                        SeleccionVedendor(Convert.ToInt32(dgvVendedor.Rows[i].Cells[0].Value));
                    }
                }
                else
                {
                    MessageBox.Show("Error al seleccionar articulo, la busqueda no arrojo ninguna resultado", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SeleccionVedendor(Int32 ID)
        {
            //Provee el codigo del articulo a ser buscado
            SMA.Clientes.iAgregarEditarCliente FormInterfaceFactura = this.Owner as SMA.Clientes.iAgregarEditarCliente;
            if (FormInterfaceFactura != null)
            {
                FormInterfaceFactura.SeleccionarVendedor(ID);
            }

            this.Close();
        }

        private void dgvVendedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                VendedorID = Convert.ToInt32(dgvVendedor.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
