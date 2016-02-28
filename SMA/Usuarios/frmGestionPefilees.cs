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

namespace SMA.Usuarios
{
    public partial class frmGestionPefiles : Office2007Form
    {
        Int32 PerfilID;
        PerfilBL ObjetoPerfil = new PerfilBL();

        public frmGestionPefiles()
        {
            InitializeComponent();
        }

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            //btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;

            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Perfiles usuarios")
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
                            //btnBuscar.Enabled = true;
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


        private void frmGestionPefiles_Load(object sender, EventArgs e)
        {
            CargarPerfiles();
            GestionAccesos();
        }

        private void CargarPerfiles()
        {
            //CARGAMOS LA LISTA DE PERFILES
            try
            {
                dgvPerfil.AutoGenerateColumns = false;
                dgvPerfil.DataSource = ObjetoPerfil.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //GUARDAR CAMBIOS
            try
            {
                ObjetoPerfil.GuardarCambios(ObtenerDatos());
                CargarPerfiles();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtID.Text = "-1";
            txtCodigo.Text = null;
            txtDescripcion.Text = null;
            txtNotas.Text = null;
            //COLOCAMOS EL CURSOR EN EL PRIMER CAMPO
            txtCodigo.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ObjetoPerfil.Eliminar(PerfilID);
                CargarPerfiles();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void dgvPerfil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo de cliente que se obtiene desde el grid
                PerfilID = Convert.ToInt32(dgvPerfil.Rows[e.RowIndex].Cells[0].Value);

                MostrarDatos(ObjetoPerfil.BuscarPorID(PerfilID));
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void MostrarDatos(cPerfiles Perfil)
        {
            //CARGAMOS LA INFORMACION DEL PERFIL EN LOS CONTROLES
            txtID.Text = Perfil.ID.ToString();
            txtCodigo.Text = Perfil.CodigoPerfil;
            txtDescripcion.Text = Perfil.Descripcion;
            txtNotas.Text = Perfil.Notas;
        }

        private cPerfiles ObtenerDatos()
        {
            try
            {
                cPerfiles Perfil = new cPerfiles();
                Perfil.ID = Convert.ToInt32(txtID.Text);
                Perfil.CodigoPerfil = txtCodigo.Text;
                Perfil.Descripcion = txtDescripcion.Text;
                Perfil.Notas = txtNotas.Text;

                return Perfil;
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            CargarPerfiles();
        }
    }
}
