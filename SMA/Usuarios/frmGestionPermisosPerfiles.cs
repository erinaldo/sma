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
    public partial class frmGestionPermisosPerfiles : Office2007Form
    {
        Int16 PerfilID;

        public frmGestionPermisosPerfiles()
        {
            InitializeComponent();
        }

        private void frmGestionPermisosPerfiles_Load(object sender, EventArgs e)
        {
            CargarPerfiles();
            CargarModulos();
            CargarRoles(ObtenerModulo());

        }

        private void CargarRoles(Int32 CodigoModulo)
        {
            RolesBL ObjetoRoles = new RolesBL();
            lbPermisos.DataSource = ObjetoRoles.Listar(CodigoModulo);
            lbPermisos.DisplayMember = "Descripcion";
            lbPermisos.ValueMember = "Codigo";
        }

        private void CargarModulos()
        {
            ModuloBL ObjetoModulo = new ModuloBL();
            lbModulos.DataSource = ObjetoModulo.Listar();
            lbModulos.DisplayMember = "Descripcion";
            lbModulos.ValueMember = "Codigo";
        }

        private void CargarPerfiles()
        {
         try
         {
             PerfilBL ObjetoPerfil = new PerfilBL();
             cbbPerfiles.DataSource = ObjetoPerfil.Listar();
             cbbPerfiles.DisplayMember = "Descripcion";
             cbbPerfiles.ValueMember = "Codigo";
         }
            catch(Exception Ex)
         {
             MessageBox.Show(Ex.Message);
         }
        }

        private void cbbPerfiles_SelectedValueChanged(object sender, EventArgs e)
        {
            //OBTENEMOS LOS MODULOS ASIGNADOS A UN PERFIL A PARTIR DE SU CODIGO
            try
            {
                Int16 Codigo;
                if (Int16.TryParse(cbbPerfiles.SelectedValue.ToString(), out Codigo))
                {
                   PerfilID = Convert.ToInt16(cbbPerfiles.SelectedValue.ToString());
                    ListarModulosAsignados(PerfilID);
                }
                else
                {
                    lbPermisosAsignados.DataSource = null;
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }

        private void ListarModulosAsignados(Int16 PerfilID)
        {
            //LISTA DE MODULOS ASIGNADOS
            try
            {
                RelacionModuloPerfilBL ObjetoRelacion = new RelacionModuloPerfilBL();
                lbModulosAsignados.DataSource = ObjetoRelacion.ListarRelacionPerfilModulo(PerfilID);
                lbModulosAsignados.DisplayMember = "DescripcionModulo";
                lbModulosAsignados.ValueMember = "Codigo";
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void lbModulosAsignados_Click(object sender, EventArgs e)
        {
            CargarRoles(ObtenerModulo());
        }

        private Int32? ObtenerPerfil()
        {
            try
            {
                Int32 Perfil;
                if(Int32.TryParse(lbModulosAsignados.SelectedValue.ToString(),out Perfil))
                {
                    return Convert.ToInt32(lbModulosAsignados.SelectedValue.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
        private void ListarRolesAsignadosPorModulo(Int32 RelacionID)
        {
            try
            {
                RelacionModuloPerfilRolBL ObjetoRelacion = new RelacionModuloPerfilRolBL();
               lbPermisosAsignados.DataSource=  ObjetoRelacion.ListarRelacionPerfilRol(RelacionID);
               lbPermisosAsignados.DisplayMember = "DescripcionRol";
               lbPermisosAsignados.ValueMember = "Codigo";
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void lbModulosAsignados_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 RelacionID;
                //Int32? PerfilID = ObtenerPerfil();

                if ((lbModulosAsignados.SelectedValue!=null ) && (Int32.TryParse(lbModulosAsignados.SelectedValue.ToString(), out RelacionID)))
                {

                    ListarRolesAsignadosPorModulo(RelacionID);
                    
                }
                else
                {
                    lbModulosAsignados.DataSource = null;
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEliminarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                RelacionModuloPerfilBL ObjetoRelacion = new RelacionModuloPerfilBL();
                ObjetoRelacion.EliminarRelacionModuloPerfil(ObtenerModuloAsignado());
                ListarModulosAsignados(PerfilID);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private int ObtenerModuloAsignado()
        {
            //OBTENEMOS EL MODULO SELECCIONADO
            Int32 Codigo;
            if (Int32.TryParse(lbModulosAsignados.SelectedValue.ToString(), out Codigo))
            {
                return Convert.ToInt32(lbModulosAsignados.SelectedValue.ToString());
            }
            else
            {
                throw new Exception("Es necesario que seleccione un modulo para ser agregado");
            }
        }

        private void btnAgregarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                //AGREGAMOS MODULO AL PERFIL
                RelacionModuloPerfilBL ObjetoRelacion = new RelacionModuloPerfilBL();
                //CREAMOS EL OBJETO DE RELACION
                cRelacionPerfilModulo Relacion = new cRelacionPerfilModulo();
                Relacion.ModuloID = ObtenerModulo();
                Relacion.PerfilID = PerfilID;
                
                //CREAMOS LA RELACION
                ObjetoRelacion.CrearRelacionModuloPerfil(Relacion);
                ListarModulosAsignados(PerfilID);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private Int16 ObtenerModulo()
        {
            //OBTENEMOS EL MODULO SELECCIONADO
            Int16 Codigo;
            if(Int16.TryParse(lbModulos.SelectedValue.ToString(),out Codigo))
            {
                return Convert.ToInt16(lbModulos.SelectedValue.ToString());
            }
            else
            {
                throw new Exception("Es necesario que seleccione un modulo para ser agregado");
            }
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            try
            {
            RelacionModuloPerfilRolBL ObjetoRelacion = new RelacionModuloPerfilRolBL();
            //OBJETO DE RELACION
            cRelacionModuloPerfilRol Relacion=new cRelacionModuloPerfilRol();
            Relacion.ModuloPerfilID=ObtenerModuloAsignado();
            Relacion.CodigoRol=ObtenerRol();

            //AGREGAMOS LA RELACION
            ObjetoRelacion.CrearRelacionModuloPerfilRol(Relacion);
             ListarRolesAsignadosPorModulo(ObtenerModuloAsignado());
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private Int16 ObtenerRol()
        {
            //OBTENEMOS EL PERMISO SELECCIONADO
            try
            {
                Int16 Codigo;
                if (lbPermisos.SelectedValue!=null && Int16.TryParse(lbPermisos.SelectedValue.ToString(), out Codigo))
                {
                    return Convert.ToInt16(lbPermisos.SelectedValue.ToString());
                }
                else
                {
                    throw new Exception("Debe seleccionar un permiso adecuado");
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                RelacionModuloPerfilRolBL ObjetoRelacion = new RelacionModuloPerfilRolBL();
                ObjetoRelacion.EliminarRelacionModuloPerfilRol(ObtenerRolAsignado());
                ListarRolesAsignadosPorModulo(ObtenerModuloAsignado());
            }
            catch(Exception Ex)
            {
                MessageBox.Show("No existen permisos seleccionados","Error al eliminar permiso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private int ObtenerRolAsignado()
        {
            try
            {
                Int32 Codigo;
                if(Int32.TryParse(lbPermisosAsignados.SelectedValue.ToString(),out Codigo))
                {
                    return Convert.ToInt32(lbPermisosAsignados.SelectedValue.ToString());
                }
                else
                {
                    throw new Exception("Debe seleccionar el permiso a ser eliminado");
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private void lbModulos_Click(object sender, EventArgs e)
        {
            CargarRoles(ObtenerModulo());
        }
    }
}
