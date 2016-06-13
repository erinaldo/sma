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
    public partial class frmListaPerfiles : Office2007Form
    {
        frmAgregarEditarUsuario EditarUsuario;
        Int16 PerfilCodigo;
        List<cPerfil> ListaPerfiles;

        public frmListaPerfiles()
        {
            InitializeComponent();
        }

        public frmListaPerfiles(frmAgregarEditarUsuario EditarUsuario):this()
        {
            this.EditarUsuario = EditarUsuario;
        }

        private void frmListaPerfiles_Load(object sender, EventArgs e)
        {
            try
            {
                PerfilBL ObjetoPerfil = new PerfilBL();
                dgvComponente.AutoGenerateColumns = false;
                ListaPerfiles=ObjetoPerfil.Listar();
                ActualizarGrid(ListaPerfiles);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                //AGREGA EL PERFIL AL USUARIO CONSULTADO
                EditarUsuario.AgregarPerfil(PerfilCodigo);
                this.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvComponente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                PerfilCodigo = Convert.ToInt16(dgvComponente.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            //REALIZAMOS UNA BUSQUEDA POR LA DESCRIPCION DEL PERFIL Y MOSTRAMOS LOS RESULTADOS
            List<cPerfil> Resultado = (from C in ListaPerfiles
                                          where C.Descripcion.StartsWith(txtBusqueda.Text)
                                          select C).ToList();
            ActualizarGrid(Resultado);
        }

        private void ActualizarGrid(List<cPerfil> Resultado)
        {
            //ACTUALIZA EL GRID CON LA LISTA QUE SE ENVIA COMO PARAMETRO
            dgvComponente.DataSource = Resultado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
