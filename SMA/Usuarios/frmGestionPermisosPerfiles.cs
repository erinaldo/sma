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
        Int32 PerfilID;

        public frmGestionPermisosPerfiles()
        {
            InitializeComponent();
        }

        private void frmGestionPermisosPerfiles_Load(object sender, EventArgs e)
        {
            CargarPerfiles();
            CargarModulos();
            CargarRoles();

        }

        private void CargarRoles()
        {
            RolesBL ObjetoRoles = new RolesBL();
            lbPermisos.DataSource = ObjetoRoles.Listar();
            lbPermisos.DisplayMember = "Descripcion";
            lbPermisos.ValueMember = "ID";
        }

        private void CargarModulos()
        {
            ModuloBL ObjetoModulo = new ModuloBL();
            lbModulos.DataSource = ObjetoModulo.Listar();
            lbModulos.DisplayMember = "Descripcion";
            lbModulos.ValueMember = "ID";
        }

        private void CargarPerfiles()
        {
         try
         {
             PerfilBL ObjetoPerfil = new PerfilBL();
             cbbPerfiles.DataSource = ObjetoPerfil.Listar();
             cbbPerfiles.DisplayMember = "Descripcion";
             cbbPerfiles.ValueMember = "ID";
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
                Int32 Codigo;
                if (Int32.TryParse(cbbPerfiles.SelectedValue.ToString(), out Codigo))
                {
                   PerfilID = Convert.ToInt32(cbbPerfiles.SelectedValue.ToString());
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

        private void ListarModulosAsignados(int PerfilID)
        {
            //LISTA DE MODULOS ASIGNADOS
            try
            {
                RelacionModuloPerfilBL ObjetoRelacion = new RelacionModuloPerfilBL();
                lbModulosAsignados.DataSource = ObjetoRelacion.ListarRelacionPerfilModulo(PerfilID);
                lbModulosAsignados.DisplayMember = "DescripcionModulo";
                lbModulosAsignados.ValueMember = "ID";
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void lbModulosAsignados_Click(object sender, EventArgs e)
        {
            
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
               lbPermisosAsignados.ValueMember = "ID";
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void lbModulosAsignados_SelectedValueChanged(object sender, EventArgs e)
        {
            Int32 RelacionID;
            //Int32? PerfilID = ObtenerPerfil();

            if (Int32.TryParse(lbModulosAsignados.SelectedValue.ToString(), out RelacionID))
            {
                
                ListarRolesAsignadosPorModulo(RelacionID);
            }
            else
            {
                lbModulosAsignados.DataSource = null;
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

        private Int32 ObtenerModulo()
        {
            //OBTENEMOS EL MODULO SELECCIONADO
            Int32 Codigo;
            if(Int32.TryParse(lbModulos.SelectedValue.ToString(),out Codigo))
            {
                return Convert.ToInt32(lbModulos.SelectedValue.ToString());
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
            Relacion.RolID=ObtenerRol();

            //AGREGAMOS LA RELACION
            ObjetoRelacion.CrearRelacionModuloPerfilRol(Relacion);
             ListarRolesAsignadosPorModulo(ObtenerModuloAsignado());
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private int ObtenerRol()
        {
            //OBTENEMOS EL PERMISO SELECCIONADO
            try
            {
                Int32 Codigo;
                if(Int32.TryParse(lbPermisos.SelectedValue.ToString(),out Codigo))
                {
                    return Convert.ToInt32(lbPermisos.SelectedValue.ToString());
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
    }
}
