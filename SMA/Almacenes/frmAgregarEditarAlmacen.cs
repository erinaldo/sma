using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.Entity;
using SMA.BL;
namespace SMA.Almacenes
{
    public partial class frmAgregarEditarAlmacen : Form
    {
        private int? AlmacenID=null;

        public frmAgregarEditarAlmacen()
        {
            InitializeComponent();
        }

        //Sobrecargamos el formulario para obtener el parametro
        public frmAgregarEditarAlmacen(int AlmacenID):this()
        {
            this.AlmacenID = AlmacenID;

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Guardamos los cambios realizados al almacen
                AlmacenBL ObjetoAlmacen = new AlmacenBL();
                ObjetoAlmacen.GuardarCambios(ObtenerDatos());

                //Refresca los cambios realizados en la tabla de clientes en el formulario de muestra
                IfrmGestionAlmacen FormInterface = this.Owner as IfrmGestionAlmacen;

                if (FormInterface != null)
                {
                    FormInterface.RefrescarAlmacenes();
                }
                
                this.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        //Obtenemos los datos para actualizaciones
        private cAlmacen ObtenerDatos()
        {
            cAlmacen Almacen=new cAlmacen();

            Almacen.ID =Convert.ToInt32( txtCodigo.Text);
            Almacen.Nombre = txtNombre.Text;
            Almacen.Direccion = txtDireccion.Text;
            Almacen.Ciudad = txtCiudad.Text;
            Almacen.Provincia = txtProvincia.Text;
            Almacen.Telefono = txtTelefono.Text;
            Almacen.Fax = txtFax.Text;
            Almacen.Email = txtCorreo.Text;
            Almacen.Web = txtWeb.Text;
            Almacen.Observacion = txtObservaciones.Text;

            return Almacen;

        }

        private void frmAgregarEditarAlmacen_Load(object sender, EventArgs e)
        {
            if (AlmacenID.HasValue)
            {
                int ID = Convert.ToInt32(AlmacenID);
                //Instanciamos la capa de negocios
                AlmacenBL ObjetoAlmacen = new AlmacenBL();
                //Mostramos el resultado
                try
                {
                    MostrarDatos(ObjetoAlmacen.BuscarPorID(ID));
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                //Ponemos el indicador en -1
            txtCodigo.Text = "-1";
            }

        }

        private void MostrarDatos(cAlmacen Almacen)
        {
            
            txtCodigo.Text = Convert.ToString(Almacen.ID);
            txtNombre.Text = Almacen.Nombre;
            txtDireccion.Text = Almacen.Direccion;
            txtCiudad.Text = Almacen.Ciudad;
            txtProvincia.Text = Almacen.Provincia;
            txtTelefono.Text = Almacen.Telefono;
            txtFax.Text = Almacen.Fax;
            txtCorreo.Text = Almacen.Email;
            txtWeb.Text = Almacen.Web;
            txtObservaciones.Text = Almacen.Observacion;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
