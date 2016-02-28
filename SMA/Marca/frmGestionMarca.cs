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

namespace SMA.Marca
{
    public partial class frmGestionMarca : Office2007Form
    {
        MarcaBL ObjetoMarca = new MarcaBL();
        private int MarcaID;

        public frmGestionMarca()
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
                                                                where C.Modulo.Contains("Marcas Inventario")
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

        
        private void frmGestionMarca_Load(object sender, EventArgs e)
        {
            try
            {
                dgvMarca.AutoGenerateColumns = false;
                dgvMarca.DataSource = ObjetoMarca.Listar();
                GestionAccesos();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo de cliente que se obtiene desde el grid
                MarcaID = Convert.ToInt32(dgvMarca.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            //Mostramos la informacion de la familia de articulos
            try
            {
                MarcaBL Marca = new MarcaBL();
                MostarDatos(Marca.BuscarPorID(MarcaID));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void MostarDatos(cMarca Marca)
        {
            //Mostramos los datos seleccionados en el grid
            txtCodigo.Text = Marca.ID.ToString();
            txtDescripcion.Text = Marca.Descripcion;
            txtNotas.Text = Marca.Notas;
        }

        private cMarca ObtenerDatos()
        {
            try
            {
                //Obtenemos los datos referentes a la familia de articulos
                cMarca Marca = new cMarca();
                Marca.ID = Convert.ToInt32(txtCodigo.Text);
                Marca.Descripcion = txtDescripcion.Text;
                Marca.Notas = txtNotas.Text;

                return Marca;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al obtener informacion");
            }
        }

     

        
     
        

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void txtDescripcion_Validated(object sender, EventArgs e)
        {
            //Convertimos la descripcion de la marca a mayuscula
            txtDescripcion.Text = txtDescripcion.Text.ToUpper();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Enviamos los datos recolectados a guardar los cambios
            try
            {

                ObjetoMarca.GuardarCambios(ObtenerDatos());
                LimpiarCampos();
                Refrescar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al guardar cambios, " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ObjetoMarca.Eliminar(MarcaID);
                LimpiarCampos();
                Refrescar();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            

        }

        private void tsRefrescar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {

            BindingSource BDMarca = new BindingSource();
            BDMarca.DataSource = ObjetoMarca.Listar();

            //Realizamos la busqueda deendiendo del critrio
            dgvMarca.AutoGenerateColumns = false;
            dgvMarca.DataSource = BDMarca;

            //Busqueda por codigo
            if (cbCriterio.SelectedItem.ToString()== "Codigo")
            {
                int Codigo = Convert.ToInt32(txtBusqueda.Text);
                var obj = BDMarca.List.OfType<cMarca>().ToList().Find(f => f.ID == Codigo);
                var pos = BDMarca.IndexOf(obj);
                BDMarca.Position = pos;
            }

            //Busqueda por Descripcion
            if (cbCriterio.SelectedItem.ToString() == "Descripcion")
            {
                string Descripcion = txtBusqueda.Text;
                var obj = BDMarca.List.OfType<cMarca>().ToList().Find(f => f.Descripcion == Descripcion);
                var pos = BDMarca.IndexOf(obj);
                BDMarca.Position = pos;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            rbCriterio.Visible = true;
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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void Refrescar()
        {
            dgvMarca.AutoGenerateColumns = false;
            dgvMarca.DataSource = ObjetoMarca.Listar();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
