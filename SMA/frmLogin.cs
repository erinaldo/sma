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

namespace SMA
{
    public partial class frmLogin : Office2007Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //OBTENEMOS EL USUARIO MEDIANTE SU USERNAME Y PASSWORD
                UsuarioBL ObjetoUsuario = new UsuarioBL();
                cUsuario Usuario = ObjetoUsuario.ObtenerUsuario(txtUsuario.Text, txtContrasena.Text);

                //VALIDAMOS SI EXISTE ALGUN RESULTADO
                if(Usuario!=null && Usuario.ResetPassOnLogin!=true)
                {
                    //CARGAMOS LA LISTA DE PERSMISOS DEL USUARIO
                    cGlobal.ListaModulosPermisos = ObjetoUsuario.ListarPermisos(Usuario.ID);
                    //ACTUALIZAMOS SU ULTIMO LOGIN
                    ObjetoUsuario.ActualizarUltimoLogin(Usuario.ID);

                    frmPrincipal Principal = new frmPrincipal();
                    Principal.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Los datos proporcionados no son validos, revise y vuelva a intentarlo", "Error en acceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                if(Usuario!=null && Usuario.ResetPassOnLogin==true)
                {
                    //MOSTRAMOS EL FORMULARIO PARA RESETEAR LA CLAVE
                    frmResetearClave ResetarClave = new frmResetearClave(Usuario);
                    ResetarClave.ShowDialog(this);
                }

                
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
