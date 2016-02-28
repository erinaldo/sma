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
    public partial class frmGestionUsuarios : Office2007Form
    {
        Int32 UsuarioID;

        public frmGestionUsuarios()
        {
            InitializeComponent();
        }

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnPerfiles.Enabled = false;
            btnPermisos.Enabled = false;

            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Usuarios")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR USUARIO
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            break;
                        //EDITAR USUARIO
                        case "Editar":
                            btnEditar.Enabled = true;
                            break;
                        //ELIMINAR USUARIO
                        case "Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                        //CONSULTAR USUARIOS
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

            //DETERMINAMOS SI TIENE ACCESO AL MODULO DE COMPROBANTES FISCALES
            foreach (cRolesModulosUsuarios m in cGlobal.ListaModulosPermisos)
            {
                switch (m.Modulo.ToString())
                {
                    case "Perfiles usuarios":
                        btnPerfiles.Enabled = true;
                        break;
                }
            }
            //DETERMINAMOS SI TIENE ACCESO AL MODULO DE COMPROBANTES FISCALES
            foreach (cRolesModulosUsuarios m in cGlobal.ListaModulosPermisos)
            {
                switch (m.Modulo.ToString())
                {
                    case "Permisos usuarios":
                        btnPermisos.Enabled = true;
                        break;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarUsuario AgregarUsuario = new frmAgregarEditarUsuario();
            AgregarUsuario.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                UsuarioID = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarUsuario();
        }

        private void EditarUsuario()
        {
            frmAgregarEditarUsuario EditarUsuario = new frmAgregarEditarUsuario(UsuarioID);
            EditarUsuario.ShowDialog(this);
        }

        private void frmGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarInformacion();
            GestionAccesos();
        }

        private void CargarInformacion()
        {
            try
            {
                UsuarioBL ObjetoUsuario = new UsuarioBL();
                dgvUsuarios.AutoGenerateColumns = false;
                dgvUsuarios.DataSource = ObjetoUsuario.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarUsuario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //ELIMINA INFORMACION DEL USUARIO
            //PENDIENTE VALIDAR QUE EL USUARIO ACTUAL NO SE ESTE TRATANDO DE ELIMINAR
            DialogResult Resultado = MessageBox.Show("Esta seguro que desea eliminar el usuario seleccionado", "Eliminar usuario", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                UsuarioBL ObjetoUsuario = new UsuarioBL();
                ObjetoUsuario.Eliminar(UsuarioID);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = true;
            btnBuscar.Visible = true;
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            frmGestionPefiles GestionPerfiles = new frmGestionPefiles();
            GestionPerfiles.ShowDialog(this);
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            frmGestionPermisosPerfiles GestionPermisos = new frmGestionPermisosPerfiles();
            GestionPermisos.ShowDialog();
        }
    }
}
