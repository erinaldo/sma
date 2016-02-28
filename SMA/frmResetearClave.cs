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
    public partial class frmResetearClave : Office2007Form
    {
        private cUsuario Usuario;

        public frmResetearClave()
        {
            InitializeComponent();
        }

        public frmResetearClave(cUsuario Usuario):this()
        {
            //TRAEMOS EL USUARIO QUE SE VA A MODIFICAR LA CLAVE
            this.Usuario = Usuario;
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(txtNuevaContrasena.Text==txtRepetirContrasena.Text)
            {
                try
                {
                    UsuarioBL ObjetoUsuario = new UsuarioBL();
                    //ACTUALIZAMOS LA CLAVE Y RESETEAMOS EL INDICADOR
                    Usuario.PassUsuario = txtNuevaContrasena.Text;
                    Usuario.ResetPassOnLogin = false;
                    //GUARDAMOS LOS CAMBIOS
                    ObjetoUsuario.GuardarCambios(Usuario);
                    MessageBox.Show("La contraseña fue actualizada exitosamente,intente ingresar nuevamente", "Actualizacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("La contraseña digitada no coincide, favor revisar y volver a intentar","Error en contraseña",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
