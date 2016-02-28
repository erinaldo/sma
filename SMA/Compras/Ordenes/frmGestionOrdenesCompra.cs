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
using SMA.Compras.Reportes;

namespace SMA.Compras.Ordenes
{
    public partial class frmGestionOrdenesCompra : Office2007Form
    {
        private Int64 CompraID;

        public frmGestionOrdenesCompra()
        {
            InitializeComponent();
        }

        private void frmGestionOrdenesCompra_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCompras();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CargarCompras()
        {
            try
            {
                ComprasBL ObjetoCompras = new ComprasBL();
                dgvCompras.AutoGenerateColumns = false;
                dgvCompras.DataSource = ObjetoCompras.Listar("O");
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarOrdenCompra AgregarOrden = new frmAgregarOrdenCompra();
            AgregarOrden.ShowDialog();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            frmRptOrdenCompra VerOrden = new frmRptOrdenCompra(CompraID);
            VerOrden.ShowDialog(this);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ComprasBL ObjetoCompras = new ComprasBL();
                ObjetoCompras.Cancelar(CompraID);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al tratar de cancelar la recepcion de compras", "Error de cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmFiltrarOrdenCompra BuscarOrden = new frmFiltrarOrdenCompra(this);
            BuscarOrden.ShowDialog(this);
        }

        public void BuscarOrdenes(List<cCompras> Resultado)
        {
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.DataSource = Resultado;
        }


        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarCompras();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
            frmFiltrarOrdenCompra FiltrarOrdenes = new frmFiltrarOrdenCompra(this);
            FiltrarOrdenes.ShowDialog(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                CompraID = Convert.ToInt32(dgvCompras.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
