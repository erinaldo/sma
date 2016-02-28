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

namespace SMA.Usuarios
{
    public partial class frmAgregarEditarUsuario : Office2007Form
    {
        int? ID;
        Int32 RelacionID;
        RelacionUsuarioPerfilesBL ObjetoRelacion = new RelacionUsuarioPerfilesBL();

        public frmAgregarEditarUsuario()
        {
            InitializeComponent();
        }

        public frmAgregarEditarUsuario(int ID):this()
        {
            this.ID = ID;
        }

        public void AgregarPerfil(Int32 Codigo)
        {
            try
            {
                if (ID.HasValue)
                {
                    Int32 UsuarioID = Convert.ToInt32(ID);
                    cRelacionUsuarioPerfil Relacion = new cRelacionUsuarioPerfil();
                    Relacion.ID = -1;
                    Relacion.PerfilID = Codigo;
                    Relacion.UsuarioID = UsuarioID;

                    RelacionUsuarioPerfilesBL ObjetoRelacion = new RelacionUsuarioPerfilesBL();
                    ObjetoRelacion.Crear(Relacion);
                    VerPerfiles(ObjetoRelacion.Listar(UsuarioID));
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al agregar perfil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmAgregarEditarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                if (ID.HasValue)
                {
                    //BUSQUEDA DE USUARIOS Y MUESTRA DE INFORMACION
                    Int32 Codigo = Convert.ToInt32(ID);
                    UsuarioBL ObjetoUsuario = new UsuarioBL();
                    
                    AsignarValores(ObjetoUsuario.BuscarPorID(Codigo));
                    VerPerfiles(ObjetoRelacion.Listar(Codigo));
                }
                else
                {
                    lblID.Text = "-1";
                    txtFechaCreacion.Text = DateTime.Now.Date.ToShortDateString();
                    txtFechaModificacion.Text = DateTime.Now.Date.ToShortDateString();
                
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void AsignarValores(cUsuario Usuario)
        {
            //CARGAMOS LA INFORMACION DEL USUARIO
            lblID.Text = Usuario.ID.ToString();
            txtLoginUsuario.Text = Usuario.LoginUsuario;
            txtPassword.Text = Usuario.PassUsuario;
            ckbEstatus.Checked = Usuario.Estatus;
            txtNombre.Text = Usuario.Nombre;
            txtTelefono.Text = Usuario.Telefono;
            txtFechaCreacion.Text = Usuario.FechaCreacion.ToShortDateString();
            txtFechaModificacion.Text = Usuario.FechaModificacion.ToShortDateString();
            ckbResetOnLogin.Checked = Usuario.ResetPassOnLogin;
        }

        private void VerPerfiles(List<cRelacionUsuarioPerfil> Perfiles)
        {
            dgvPerfil.AutoGenerateColumns = false;
            dgvPerfil.DataSource = Perfiles;   
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBL ObjetoUsuario = new UsuarioBL();
                ObjetoUsuario.GuardarCambios(ObtenerDatos());
                this.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private cUsuario ObtenerDatos()
        {
            cUsuario Usuario = new cUsuario();
            Usuario.ID = Convert.ToInt32(lblID.Text);
            Usuario.LoginUsuario = txtLoginUsuario.Text;
            Usuario.PassUsuario = txtPassword.Text;
            Usuario.Estatus = ckbEstatus.Checked;
            Usuario.Nombre = txtNombre.Text;
            Usuario.Telefono = txtTelefono.Text;
            Usuario.ResetPassOnLogin = ckbResetOnLogin.Checked;
            return Usuario;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmListaPerfiles ListaPerfiles = new frmListaPerfiles(this);
            ListaPerfiles.ShowDialog(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                PerfilBL ObjetoPerfil = new PerfilBL();
                ObjetoPerfil.Eliminar(RelacionID);
                if(ID.HasValue)
                {
                    Int32 Codigo = Convert.ToInt32(ID);
                    VerPerfiles(ObjetoRelacion.Listar(Codigo));
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message +". Error al intentar eliminar perfil de usuario","Error eliminando perfil",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
                RelacionID = Convert.ToInt32(dgvPerfil.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
    }
}
