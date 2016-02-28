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

namespace SMA.Clientes.CuentasPagar.Reportes
{
    public partial class frmParametroCatalogoProveedores : Office2007Form
    {
       
        public frmParametroCatalogoProveedores()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ProveedorBL ObjetoProveedor = new ProveedorBL();
                List<cProveedor> Listado = ObjetoProveedor.Catalogo(ObtenerProveedorDesde(), ObtenerProveedorHasta(),  ObtenerEstatus());
                frmrptCatalogoProveedores CatalogoCliente = new frmrptCatalogoProveedores(Listado);
                CatalogoCliente.ShowDialog(this);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }


        private Int32 ObtenerProveedorDesde()
        {
            Int32 Codigo;
            try
            {
                if (Int32.TryParse(cbbProveedorDesde.SelectedValue.ToString(), out Codigo))
                {
                    return Convert.ToInt32(cbbProveedorDesde.SelectedValue.ToString());
                }
                else
                {
                    throw new Exception("Error al obtener codigo de cliente");
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }



        }

        private Int32 ObtenerProveedorHasta()
        {
            Int32 Codigo;
            try
            {
                if (Int32.TryParse(cbbProveedorHasta.SelectedValue.ToString(), out Codigo))
                {
                    return Convert.ToInt32(cbbProveedorHasta.SelectedValue.ToString());
                }
                else
                {
                    throw new Exception("Error al obtener codigo de cliente");
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

       

        private Nullable<bool> ObtenerEstatus()
        {
            if (cbEstatus.Text == "Suspendidos")
            {
                return false;
            }
            else if (cbEstatus.Text == "Activos")
            {
                return true;
            }
            else
            {
                return null;
            }

        }

        private void frmParametroCatalogoProveedores_Load(object sender, EventArgs e)
        {
            ProveedorBL ObjetoProveedor = new ProveedorBL();

            cbbProveedorDesde.DataSource = ObjetoProveedor.Listar();
            cbbProveedorHasta.DataSource = ObjetoProveedor.Listar();


            cbbProveedorDesde.ValueMember = "ID";
            cbbProveedorHasta.ValueMember = "ID";
            cbbProveedorDesde.DisplayMember = "NombreComercial";
            cbbProveedorHasta.DisplayMember = "NombreComercial";
        }
    }
}
