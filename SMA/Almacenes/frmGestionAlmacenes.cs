using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMA.BL;
using SMA.Entity;
using DevComponents.DotNetBar;

namespace SMA.Almacenes
{
    public partial class frmGestionAlmacenes : Office2007Form, IfrmGestionAlmacen
    {
        private int AlmacenID;

        public frmGestionAlmacenes()
        {
            InitializeComponent();
        }

        #region Implementacion de Interfaces
        public void RefrescarAlmacenes()
        {
            try
            {
                
                //Cargamos la lista de almacenes para mostrarla
                AlmacenBL ObjetoAlmacen = new AlmacenBL();
                dgvAlmacen.AutoGenerateColumns = false;
                dgvAlmacen.DataSource = ObjetoAlmacen.Listar();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        

        private void frmGestionAlmacenes_Load(object sender, EventArgs e)
        {
            try
            {

                CargarAlmacenes();
                
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CargarAlmacenes()
        {
            //Cargamos la lista de almacenes para mostrarla
            AlmacenBL ObjetoAlmacen = new AlmacenBL();
            dgvAlmacen.AutoGenerateColumns = false;
            dgvAlmacen.DataSource = ObjetoAlmacen.Listar();
        }

        private void dgvAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo de cliente que se obtiene desde el grid
                AlmacenID = Convert.ToInt32(dgvAlmacen.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (AlmacenID > 0)
            {

                frmAgregarEditarAlmacen EditarAlmacen = new frmAgregarEditarAlmacen(AlmacenID);
                EditarAlmacen.Text = "Modificar almacen";
                EditarAlmacen.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Almacen!!!");
            } 
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Nuevo_Click(object sender, EventArgs e)
        {

            frmAgregarEditarAlmacen AgregarAlmacen = new frmAgregarEditarAlmacen();
            AgregarAlmacen.ShowDialog(this);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            //Marca un almacen como eliminado
            try
            {
            AlmacenBL ObjetoAlmacen = new AlmacenBL();
            ObjetoAlmacen.Eliminar(AlmacenID);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            cbCriterio.Visible = true;
            txtBusqueda.Visible = true;
            btnBuscar.Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            AlmacenBL ObjetoAlmacen = new AlmacenBL();
            BindingSource BDAlmacen = new BindingSource();
            BDAlmacen.DataSource = ObjetoAlmacen.Listar();

            //Realizamos la busqueda deendiendo del critrio
            dgvAlmacen.DataSource = BDAlmacen;

            //Busqueda por codigo
            if (cbCriterio.Text == "Codigo")
            {
                int Codigo = Convert.ToInt32(txtBusqueda.Text);
                var obj = BDAlmacen.List.OfType<cAlmacen>().ToList().Find(f => f.ID == Codigo);
                var pos = BDAlmacen.IndexOf(obj);
                BDAlmacen.Position = pos;
            }

            //Busqueda por Telefono
            if (cbCriterio.Text == "Telefono")
            {
                string Telefono = txtBusqueda.Text;
                var obj = BDAlmacen.List.OfType<cAlmacen>().ToList().Find(f => f.Telefono == Telefono);
                var pos = BDAlmacen.IndexOf(obj);
                BDAlmacen.Position = pos;
            }

            //Busqueda por Telefono
            if (cbCriterio.Text == "Fax")
            {
                string Fax = txtBusqueda.Text;
                var obj = BDAlmacen.List.OfType<cAlmacen>().ToList().Find(f => f.Fax == Fax);
                var pos = BDAlmacen.IndexOf(obj);
                BDAlmacen.Position = pos;
            }
        }

        private void tsFiltrar_Click(object sender, EventArgs e)
        {
            frmFiltrarAlmacen Filtrar = new frmFiltrarAlmacen();
            Filtrar.Show(this);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                CargarAlmacenes();
            }
            catch(Exception Ex)
            {
                MessageBox.Show("A ocurrido un error." + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
