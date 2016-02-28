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

namespace SMA.Clientes.Reportes
{
    public partial class frmParametroCatalogoCliente : Office2007Form
    {
        public frmParametroCatalogoCliente()
        {
            InitializeComponent();
        }

        private void frmParametroCatalogoCliente_Load(object sender, EventArgs e)
        {
            CargarDependencias();
        }

        private void CargarDependencias()
        {
            //Clientes
            ClienteBL ObjetoCliente = new ClienteBL();
            cbClienteDesde.DataSource = ObjetoCliente.Listar();
            cbClienteDesde.DisplayMember = "NombreComercial";
            cbClienteDesde.ValueMember = "ID";

            cbClienteHasta.DataSource = ObjetoCliente.Listar();
            cbClienteHasta.DisplayMember = "NombreComercial";
            cbClienteHasta.ValueMember = "ID";

            //Vendedores
            VendedorBL ObjetoVendedor = new VendedorBL();
            cbVendedor.DataSource = ObjetoVendedor.Listar();
            cbVendedor.DisplayMember = "Nombre";
            cbVendedor.ValueMember = "ID";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBL ObjetoCliente = new ClienteBL();
                List<cCliente> Listado = ObjetoCliente.Catalogo(ObtenerClienteDesde(), ObtenerClienteHasta(), ObtenerVendedor(), ObtenerEstatus());
                frmrptCatalogoCliente CatalogoCliente = new frmrptCatalogoCliente(Listado);
                CatalogoCliente.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Int32 ObtenerClienteDesde()
        {
            Int32 Codigo;
            try
            {
                if (Int32.TryParse(cbClienteDesde.SelectedValue.ToString(), out Codigo))
                {
                    return Convert.ToInt32(cbClienteDesde.SelectedValue.ToString());
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

        private Int32 ObtenerClienteHasta()
        {
            Int32 Codigo;
            try
            {
                if (Int32.TryParse(cbClienteHasta.SelectedValue.ToString(), out Codigo))
                {
                    return Convert.ToInt32(cbClienteHasta.SelectedValue.ToString());
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

        private Nullable<Int32> ObtenerVendedor()
        {
            Int32 Codigo;
            try
            {
                if (cbVendedor.Text != String.Empty)
                {
                    if (Int32.TryParse(cbVendedor.SelectedValue.ToString(), out Codigo))
                    {
                        return Convert.ToInt32(cbVendedor.SelectedValue.ToString());
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private Nullable<bool>  ObtenerEstatus()
        {
            if(cbEstatus.Text=="Suspendidos")
            {
                return false;
            }
            else if(cbEstatus.Text=="Activos")
            {
                return true;
            }
            else
            {
                return null;
            }
    
        }
    }
}
