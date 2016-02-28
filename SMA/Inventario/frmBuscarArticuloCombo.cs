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

namespace SMA.Inventario
{
    public partial class frmBuscarArticuloCombo : Office2007Form
    {
        public frmBuscarArticuloCombo()
        {
            InitializeComponent();
        }

        BindingSource BDInventario = new BindingSource();
        InventarioBL ObjetoInventario = new InventarioBL();
        //------------------------------------------------------------
        Int64 InventarioID;
        Decimal Precio;
        //Double Cantidad;
        //int AlmacenID;

        private void frmAgregarEditarArticuloCombo_Load(object sender, EventArgs e)
        {

            BDInventario.DataSource = ObjetoInventario.Listar();

            //Realizamos la busqueda deendiendo del critrio
            dgvArticulos.AutoGenerateColumns = false;
            dgvArticulos.DataSource = BDInventario;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string Criterio=cbCriterio.Text;
            string Busqueda=txtBusqueda.Text;

            //Busqueda por codigo
            if (Criterio == "Codigo")
            {
                string Codigo = Busqueda;
                var obj = BDInventario.List.OfType<cInventario>().ToList().Find(f => f.CodigoArticulo == Codigo);
                var pos = BDInventario.IndexOf(obj);
                BDInventario.Position = pos;
            }

            //Busqueda por Descripcion
            if (Criterio == "Descripcion")
            {
                string Descripcion = Busqueda;
                var obj = BDInventario.List.OfType<cInventario>().ToList().Find(f => f.Descripcion.StartsWith(Descripcion));
                var pos = BDInventario.IndexOf(obj);
                BDInventario.Position = pos;
            }


            //Busqueda por Tipo Familia
            if (Criterio == "Familia")
            {
                string Familia = Busqueda;
                var obj = BDInventario.List.OfType<cInventario>().ToList().Find(f => f.FamiliaID == Familia);
                var pos = BDInventario.IndexOf(obj);
                BDInventario.Position = pos;
            }

            //Busqueda por Tipo Marca
            if (Criterio == "Marca")
            {
                string Marca = Busqueda;
                var obj = BDInventario.List.OfType<cInventario>().ToList().Find(f => f.MarcaID == Marca);
                var pos = BDInventario.IndexOf(obj);
                BDInventario.Position = pos;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //Llama al procedimiento en la interfase que adiciona un articulo a un combo
            IfrmAgregarEditarInventario FormInterface = this.Owner as IfrmAgregarEditarInventario;

                if (FormInterface != null)
                {
                    FormInterface.AgregarArticulo(InventarioID);
                    FormInterface.Refrescar();
                }
            //Pregunta si desea agregar algun otro articulo al combo
                if (MessageBox.Show("Desea agregar otro articulo al combo", "Agregar otro articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Close();
                }
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
                InventarioID = Convert.ToInt64(dgvArticulos.Rows[e.RowIndex].Cells[0].Value);
                Precio = Convert.ToDecimal(dgvArticulos.Rows[e.RowIndex].Cells[4].Value);
               
                ////Cargar almacenes donde existe el producto
                //CargarAlmacenes(InventarioID);
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

        //private void CargarAlmacenes(int InventarioID)
        //{
        //    //Carga los almacenes donde se encuentra el articulo
        //    RelacionAlmacenBL ObjetoAlmacen = new RelacionAlmacenBL();
        //    dgvAlmacen.AutoGenerateColumns = false;
        //    dgvAlmacen.DataSource = ObjetoAlmacen.Listar(InventarioID);
        //}

        //private void dgvAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        //evita el error al tratar de reordenar la lista
        //        if (e.RowIndex == -1)
        //        {
        //            return;
        //        }

        //        //Idenfiticamos la linea en donde se encuentra la relacion del articulo identificandolo por el ID
        //        AlmacenID = Convert.ToInt32(dgvAlmacen.Rows[e.RowIndex].Cells[0].Value);
                
            
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //}
    }
}
