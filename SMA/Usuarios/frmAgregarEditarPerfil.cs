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
    public partial class frmAgregarEditarPerfil : Office2007Form
    {
        private short? CodigoPerfil; //CODIGO DE PERFIL
        private frmGestionPerfilesUsuarios GestionPerfilesUsuarios;
        
       
        #region Constructores
        public frmAgregarEditarPerfil()
        {
            InitializeComponent();
        }

        public frmAgregarEditarPerfil(frmGestionPerfilesUsuarios GestionPerfilesUsuarios):this()
        {
            // TODO: Complete member initialization
            this.GestionPerfilesUsuarios = GestionPerfilesUsuarios;
        }

        public frmAgregarEditarPerfil(short CodigoPerfil, frmGestionPerfilesUsuarios GestionPerfilesUsuarios):this()
        {
            // TODO: Complete member initialization
            this.CodigoPerfil = CodigoPerfil;
            this.GestionPerfilesUsuarios = GestionPerfilesUsuarios;
        }
        #endregion

        #region Acciones y Metodos
        private cPerfil ObtenerInformacion()
        {
            //OBTENEMOS LA INFORMACION DE LOS CONTROLES
            try
            {
                cPerfil Perfil = new cPerfil();
                Perfil.Codigo = Convert.ToInt16(txtCodigo.Text);
                Perfil.Descripcion = txtDescripcion.Text;
                Perfil.Notas = txtObservaciones.Text;

                return Perfil;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void MostrarInformacion(cPerfil Perfil)
        {
            //MUESTRA LA INFORMACION DEL PERFIL
            try
            {
                txtCodigo.Text = Perfil.Codigo.ToString();
                txtDescripcion.Text = Perfil.Descripcion;
                txtObservaciones.Text = Perfil.Notas;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion

        #region Acciones y metodos de controles
        private void frmAgregarEditarPerfil_Load(object sender, EventArgs e)
        {
            //CARGAMOS LA INFORMACION DEL PERFIL CON ESTE CODIGO
            if (CodigoPerfil.HasValue)
            {
                try
                {
                    PerfilBL ObjetoPerfil = new PerfilBL();
                    Int32 Codigo = Convert.ToInt32(CodigoPerfil);
                    MostrarInformacion(ObjetoPerfil.BuscarPorID(Codigo));
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                txtCodigo.Text = "-1";
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //GUARDAMOS LOS CAMBIOS APLICADOS
            try
            {
                PerfilBL ObjetoPerfil = new PerfilBL();
                ObjetoPerfil.GuardarCambios(ObtenerInformacion());
                if(GestionPerfilesUsuarios!=null)
                {
                    GestionPerfilesUsuarios.CargarPerfiles();
                }
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
