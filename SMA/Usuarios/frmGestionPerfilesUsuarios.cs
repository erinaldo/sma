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

namespace SMA.Usuarios
{
    public partial class frmGestionPerfilesUsuarios : Form
    {
        private Int16 CodigoPerfil; //CODIGO DE PERFIL

        #region Constructores
        public frmGestionPerfilesUsuarios()
        {
            InitializeComponent();
        }

        private void frmGestionPerfilesUsuarios_Load(object sender, EventArgs e)
        {
            CargarPerfiles();
        }
        #endregion
        #region Acciones y metodos
        internal void CargarPerfiles()
        {
            //CARGA LA LISTA DE PERFILES DE USUARIO
            try
            {
                PerfilBL ObjetoPerfil = new PerfilBL();
                dgvPerfiles.AutoGenerateColumns = false;
                dgvPerfiles.DataSource = ObjetoPerfil.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion
        #region Acciones y metodos de formulario
        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Buscamos el codigo del perfil seleccionado en la lista de usuarios 
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                CodigoPerfil = Convert.ToInt16(dgvPerfiles.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //EDITAR PERFIL
            frmAgregarEditarPerfil EditarPerfil = new frmAgregarEditarPerfil(CodigoPerfil,this);
            EditarPerfil.Show(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {//ELIMINA UN PERFIL SELECCIONADO
                DialogResult Resultado = MessageBox.Show("Se eliminara el perfil seleccionado, ¿Desea continuar?", "Eliminar perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resultado == DialogResult.Yes)
                {
                    PerfilBL ObjetoPerfil = new PerfilBL();
                    ObjetoPerfil.Eliminar(CodigoPerfil);
                    CargarPerfiles();
                }
                else
                {
                    MessageBox.Show("Operacion cancelada", "Operacion cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //BUSCA UN PERFIL
            ribbonBar4.Visible = true;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarPerfiles();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarPerfil AgregarPerfil = new frmAgregarEditarPerfil(this);
            AgregarPerfil.ShowDialog(this);
        }
        

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            PerfilBL ObjetoPerfil = new PerfilBL();
            List<cPerfil> Lista = ObjetoPerfil.Listar();
            dgvPerfiles.AutoGenerateColumns = false;


            //Busqueda por Telefono
            var Resultado = (from c in Lista
                             where c.Descripcion.StartsWith(txtBusqueda.Text)
                             select c).ToList();
            dgvPerfiles.DataSource = Resultado;
        }
        #endregion
    }
}
