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


namespace SMA.Familia
{
    public partial class frmGestionFamilia : Office2007Form
    {
        private int FamiliaID;

        public frmGestionFamilia()
        {
            InitializeComponent();
        }
        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;
            
            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Familia Inventario")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR FACTURA
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            btnGuardar.Enabled = true;
                            break;
                        //CANCELAR FACTURA
                        case "Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                        case "Consultar":
                            btnBuscar.Enabled = true;
                            btnRefrescar.Enabled = true;
                            break;
                        
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void frmGestionFamilia_Load(object sender, EventArgs e)
        {
            try
            {
                FamiliaBL ObjetoFamilia = new FamiliaBL();
                dgvFamilia.AutoGenerateColumns = false;
                dgvFamilia.DataSource = ObjetoFamilia.Listar();
                GestionAccesos();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvFamilia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo de cliente que se obtiene desde el grid
                FamiliaID = Convert.ToInt32(dgvFamilia.Rows[e.RowIndex].Cells[0].Value);
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            //Mostramos la informacion de la familia de articulos
            try
            {
                FamiliaBL Familia = new FamiliaBL();
                MostarDatos(Familia.BuscarPorID(FamiliaID));
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void MostarDatos(cFamilia Familia)
        {
            //Mostramos los datos seleccionados en el grid
            txtCodigo.Text = Familia.Codigo.ToString();
            txtDescripcion.Text = Familia.Descripcion;
            txtNotas.Text = Familia.Notas;
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private cFamilia ObtenerDatos()
        {
            try
            {
                //Obtenemos los datos referentes a la familia de articulos
                cFamilia Familia = new cFamilia();
                Familia.Codigo = Convert.ToInt32(txtCodigo.Text);
                Familia.Descripcion = txtDescripcion.Text;
                Familia.Notas = txtNotas.Text;

                return Familia;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al obtener informacion");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtDescripcion_Validated(object sender, EventArgs e)
        {
            //Convertimos la descripcion de la familia a mayuscula
            txtDescripcion.Text = txtDescripcion.Text.ToUpper();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtDescripcion.Enabled = true;
            txtNotas.Enabled = true;
            //Reniciamos todos los campos
            txtCodigo.Text = "-1";
            txtDescripcion.Text = "";
            txtNotas.Text = "";
            txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Enviamos los datos recolectados a guardar los cambios
            try
            {
                FamiliaBL ObjetoFamilia = new FamiliaBL();

                ObjetoFamilia.GuardarCambios(ObtenerDatos());
                LimpiarCampos();
                Refrescar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al guardar cambios, " + Ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FamiliaBL ObjetoFamilia = new FamiliaBL();
            ObjetoFamilia.Eliminar(FamiliaID);
            LimpiarCampos();
            Refrescar();

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            rbCriterio.Visible = true;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void Refrescar()
        {
            FamiliaBL ObjetoFamilia = new FamiliaBL();
            dgvFamilia.AutoGenerateColumns = false;
            dgvFamilia.DataSource = ObjetoFamilia.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {

            FamiliaBL ObjetoFamilia = new FamiliaBL();
            BindingSource BDMarca = new BindingSource();
            BDMarca.DataSource = ObjetoFamilia.Listar();

            //Realizamos la busqueda deendiendo del critrio
            dgvFamilia.AutoGenerateColumns = false;
            dgvFamilia.DataSource = BDMarca;

            //Busqueda por codigo
            if (cbCriterio.SelectedItem.ToString() == "Codigo")
            {
                int Codigo = Convert.ToInt32(txtBusqueda.Text);
                var obj = BDMarca.List.OfType<cFamilia>().ToList().Find(f => f.Codigo == Codigo);
                var pos = BDMarca.IndexOf(obj);
                BDMarca.Position = pos;
            }

            //Busqueda por Descripcion
            if (cbCriterio.SelectedItem.ToString() == "Descripcion")
            {
                string Descripcion = txtBusqueda.Text;
                var obj = BDMarca.List.OfType<cFamilia>().ToList().Find(f => f.Descripcion == Descripcion);
                var pos = BDMarca.IndexOf(obj);
                BDMarca.Position = pos;
            }
        }
    }
}
