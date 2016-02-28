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

namespace SMA.Inventario.Reportes
{
    public partial class frmParametroProductosObsoletos : Office2007Form
    {
        public frmParametroProductosObsoletos()
        {
            InitializeComponent();
        }

        private void frmParametroProductosObsoletos_Load(object sender, EventArgs e)
        {
            FamiliaBL ObjetoFamilia = new FamiliaBL();
            cbbFamilia.DataSource = ObjetoFamilia.Listar();
            cbbFamilia.DisplayMember = "Descripcion";
            cbbFamilia.ValueMember = "ID";

            MarcaBL ObjetoMarca = new MarcaBL();
            cbbMarca.DataSource = ObjetoMarca.Listar();
            cbbMarca.DisplayMember = "Descripcion";
            cbbMarca.ValueMember = "ID";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32? Familia = ObtenerValor(cbbFamilia.SelectedValue);
                Int32? Marca = ObtenerValor(cbbMarca.SelectedValue);
                DateTime Fecha = dtpFecha.Value;

                MovInventarioBL ObjetoMovimiento = new MovInventarioBL();
                List<cInventario> Lista = ObjetoMovimiento.ReporteProductosObsoletos(Familia, Marca, Fecha);

                frmrptProductosObsoletos ProductosObsoletos = new frmrptProductosObsoletos(Lista);
                ProductosObsoletos.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private int? ObtenerValor(object p)
        {
            //Obtenemos el codigo de familia de articulos
            if (p != null)
            {
                return Convert.ToInt32(p.ToString());
            }
            else
            {
                return null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
