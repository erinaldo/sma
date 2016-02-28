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

namespace SMA.Inventario.Movimientos_Inventario.Conceptos_Movimiento
{
    public partial class frmGestionConceptosMov : Office2007Form
    {
        private int ConceptoID;

        public frmGestionConceptosMov()
        {
            InitializeComponent();
        }

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            Nuevo.Enabled = false;
            tsbEditar.Enabled = false;
            tsRefrescar.Enabled = false;

            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Conceptos Mov Inventario")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR ARTICULO
                        case "Agregar":
                            Nuevo.Enabled = true;
                            break;
                        //EDITAR ARTICULO
                        case "Editar":
                            tsbEditar.Enabled = true;
                            break;
                        //CONSULTAR ARTICULO
                        case "Consultar":
                            tsRefrescar.Enabled = true;
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

           
        }

        private void frmGestionConceptosMov_Load(object sender, EventArgs e)
        {
            ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();
            dgvConcepto.AutoGenerateColumns = false;
            dgvConcepto.DataSource = ObjetoConcepto.Listar();
            GestionAccesos();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarConcepto AgregarConcepto = new frmAgregarEditarConcepto();
            AgregarConcepto.ShowDialog(this);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarConcepto EditarConcepto = new frmAgregarEditarConcepto(ConceptoID);
            EditarConcepto.ShowDialog(this);
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void tsRefrescar_Click(object sender, EventArgs e)
        {
            ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();
            dgvConcepto.AutoGenerateColumns = false;
            dgvConcepto.DataSource = ObjetoConcepto.Listar();
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvConcepto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ConceptoID = Convert.ToInt32(dgvConcepto.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();
            //BindingSource BDInventario = new BindingSource();
            //BDInventario.DataSource = ObjetoConcepto.Listar();

            ////Realizamos la busqueda deendiendo del critrio
            //dgvConcepto.AutoGenerateColumns = false;
            //dgvConcepto.DataSource = BDInventario;

            ////Busqueda por codigo
            //if (cbCriterio.Text == "Codigo")
            //{
            //    int Codigo = Convert.ToInt32(txtBusqueda.Text);
            //    var obj = BDInventario.List.OfType<cInventario>().ToList().Find(f => f.ID == Codigo);
            //    var pos = BDInventario.IndexOf(obj);
            //    BDInventario.Position = pos;
            //}

            ////Busqueda por Descripcion
            //if (cbCriterio.Text == "Descripcion")
            //{
            //    string Descripcion = txtBusqueda.Text;
            //    var obj = BDInventario.List.OfType<cInventario>().ToList().Find(f => f.Descripcion == Descripcion);
            //    var pos = BDInventario.IndexOf(obj);
            //    BDInventario.Position = pos;
            //}
        }
    }
}
