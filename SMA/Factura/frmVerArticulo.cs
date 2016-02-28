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
using System.IO;

namespace SMA.Factura
{
    public partial class frmVerArticulo : Office2007Form
    {
        private Int64? ArticuloID;

        public frmVerArticulo()
        {
            InitializeComponent();
        }

        public frmVerArticulo(Int64 ArticuloID):this()
        {
            this.ArticuloID = ArticuloID;
        }

        private void frmVerArticulo_Load(object sender, EventArgs e)
        {
            if (ArticuloID.HasValue)
            {
                Int64 I = Convert.ToInt64(ArticuloID);
                InventarioBL ObjetoInventario = new InventarioBL();
                MostrarDatos(ObjetoInventario.BuscarPorID(I));
            }

        }

        private void MostrarDatos(cInventario Articulo)
        {
            //Muestra la informacion del articulo
            lblDescripcion.Text = Articulo.Descripcion;
            lblPrecio.Text = Articulo.PrecioPublico.ToString("C2");
            lblExistencia.Text = Articulo.Existencia.ToString("N2");
            lblLinea.Text = ObtenerFamilia(Articulo.FamiliaID.ToString());
            lblMarca.Text = ObtenerMarca(Articulo.MarcaID.ToString());
            pcbImagenArticulo.Image = byteArrayToImage(Articulo.Imagen);
        }

        private String ObtenerFamilia(String ID)
        {
            //Obtenemos la descripcion de la familia de articulo
            FamiliaBL ObjetoFamilia = new FamiliaBL();
            Int32 Codigo;
            if (Int32.TryParse(ID, out Codigo))
            {
                Codigo = Convert.ToInt32(ID);
                return ObjetoFamilia.BuscarPorID(Codigo).Descripcion.ToString();
            }
            else
            {
                return null;
            }
        }

        private String ObtenerMarca(String ID)
        {
            //Obtenemos la descripcion de la marca de articulo
            MarcaBL ObjetoMarca = new MarcaBL();
            Int32 Codigo;
            if (Int32.TryParse(ID, out Codigo))
            {
                Codigo = Convert.ToInt32(ID);
                return ObjetoMarca.BuscarPorID(Codigo).Descripcion.ToString();
            }
            else
            {
                return null;
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null && byteArrayIn.Length > 0)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            else
            {
                return null;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
