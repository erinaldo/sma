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
        Int32? CodigoUsuario;    //CODIGO DE USUARIO
        Int32 RelacionCodigo;  //CODIGO DE RELACION PERFIL                     
        RelacionUsuarioPerfilesBL ObjetoRelacion = new RelacionUsuarioPerfilesBL(); //OBJETO RELACION USUARIO PERFIL NEGOCIO
        
        #region Constructores
        public frmAgregarEditarUsuario()
        {
            InitializeComponent();
        }
        
        public frmAgregarEditarUsuario(Int32 CodigoUsuario):this()
        {
            this.CodigoUsuario = CodigoUsuario;
        }
        #endregion

        #region Acciones y Metodos
        public void AgregarPerfil(Int16 Codigo)
        {
            try
            {
                if (CodigoUsuario.HasValue)
                {
                    Int32 UsuarioCodigo = Convert.ToInt32(CodigoUsuario);
                    cRelacionUsuarioPerfil Relacion = new cRelacionUsuarioPerfil();
                    Relacion.Codigo = -1;
                    Relacion.PerfilCodigo = Codigo;
                    Relacion.UsuarioCodigo = UsuarioCodigo;

                    RelacionUsuarioPerfilesBL ObjetoRelacion = new RelacionUsuarioPerfilesBL();
                    ObjetoRelacion.Crear(Relacion);
                    VerPerfiles(ObjetoRelacion.Listar(UsuarioCodigo));
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al agregar perfil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AsignarValores(cUsuario Usuario)
        {
            //CARGAMOS LA INFORMACION DEL USUARIO
            lblCodigo.Text = Usuario.Codigo.ToString();
            txtLoginUsuario.Text = Usuario.Login;
            txtPassword.Text = Usuario.Pass;
            ckbEstatus.Checked = Usuario.Estatus;
            txtNombre.Text = Usuario.Nombre;
            txtTelefono.Text = Usuario.Telefono;
            txtFechaCreacion.Text = Usuario.FechaCreacion.ToShortDateString();
            txtFechaModificacion.Text = Usuario.FechaModificacion.ToShortDateString();
            ckbResetOnLogin.Checked = Usuario.ResetPassOnLogin;
        }

        private void VerPerfiles(List<cRelacionUsuarioPerfil> Perfiles)
        {
            //VISUALIZAMOS LA LISTA DE PERFILES RELACIONADOS CON EL USUARIO
            dgvPerfil.AutoGenerateColumns = false;
            dgvPerfil.DataSource = Perfiles;
        }

        private cUsuario ObtenerDatos()
        {
            //OBTENEMOS LA INFORMACION DEL USUARIO A MODIFICAR O AGREGAR
            cUsuario Usuario = new cUsuario();
            Usuario.Codigo = Convert.ToInt32(lblCodigo.Text);
            Usuario.Login = txtLoginUsuario.Text;
            Usuario.Pass = txtPassword.Text;
            Usuario.Estatus = ckbEstatus.Checked;
            Usuario.Nombre = txtNombre.Text;
            Usuario.Telefono = txtTelefono.Text;
            Usuario.ResetPassOnLogin = ckbResetOnLogin.Checked;
            return Usuario;

        }

        #endregion

        #region Acciones de controles formulario
        private void frmAgregarEditarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                if (CodigoUsuario.HasValue)
                {
                    //BUSQUEDA DE USUARIOS Y MUESTRA DE INFORMACION
                    Int32 RelacionCodigo = Convert.ToInt32(CodigoUsuario);
                    UsuarioBL ObjetoUsuario = new UsuarioBL();
                    
                    AsignarValores(ObjetoUsuario.BuscarPorCodigo(RelacionCodigo));
                    VerPerfiles(ObjetoRelacion.Listar(RelacionCodigo));
                }
                else
                {
                    lblCodigo.Text = "-1";
                    txtFechaCreacion.Text = DateTime.Now.Date.ToShortDateString();
                    txtFechaModificacion.Text = DateTime.Now.Date.ToShortDateString();
                
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
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
            //ELIMINA LA RELACION EXISTENTE ENTRE UN USUARIO Y LOS PERFILES
            try
            {
                RelacionUsuarioPerfilesBL ObjetoPerfil = new RelacionUsuarioPerfilesBL();
                ObjetoPerfil.Eliminar(RelacionCodigo);
                //SI LA VARIABLE CONTIENE UN VALOR BUSCAMOS LOS PERFILES RELACIONADOS
                if(CodigoUsuario.HasValue)
                {
                    Int32 Codigo = Convert.ToInt32(CodigoUsuario);
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
                //Codigo de cliente que se obtiene desde el grCodigo
                RelacionCodigo = Convert.ToInt32(dgvPerfil.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        #endregion
    }
}
