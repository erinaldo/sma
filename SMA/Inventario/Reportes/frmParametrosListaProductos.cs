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

namespace SMA.Inventario.Reportes
{
    public partial class frmParametrosListaProductos : Office2007Form
    {
        public frmParametrosListaProductos()
        {
            InitializeComponent();
        }

        private void frmParametrosListaProductos_Load(object sender, EventArgs e)
        {
            InventarioBL ObjetoInventario = new InventarioBL();
            cbDesde.DataSource = ObjetoInventario.Listar();
            cbDesde.ValueMember = "ID";
            cbDesde.DisplayMember = "Descripcion";

            cbHasta.DataSource = ObjetoInventario.Listar();
            cbHasta.ValueMember = "ID";
            cbHasta.DisplayMember = "Descripcion";

            FamiliaBL ObjetoFamilia = new FamiliaBL();
            cbFamilia.DataSource = ObjetoFamilia.Listar();
            cbFamilia.ValueMember = "ID";
            cbFamilia.DisplayMember = "Descripcion";
            cbFamilia.SelectedValue = -1;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            InventarioBL ObjetoInventario = new InventarioBL();
            //Codigo Inicio de busqueda
            Int32 CodigoDesde = Convert.ToInt32(cbDesde.SelectedValue.ToString());
            //Codigo Hasta la busqueda
            Int32 CodigoHasta = Convert.ToInt32(cbHasta.SelectedValue.ToString());
            //Familia de articulos
            Int32 FamiliaID=-1;

           
            if(cbFamilia.SelectedValue!=null)
            {
                Int32 Familia;
                if(Int32.TryParse(cbFamilia.SelectedValue.ToString(),out Familia))
                {
                    FamiliaID=Convert.ToInt32(cbFamilia.SelectedValue.ToString());
                }
            }
            else
            {
                FamiliaID = -1;
            }

            List<cInventario> ListaInventario = ObjetoInventario.ReporteExistenciaCosto(CodigoDesde, CodigoHasta, FamiliaID);

            frmrptListaProductos ReporteListaProductos = new frmrptListaProductos(ListaInventario);
            ReporteListaProductos.ShowDialog(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
