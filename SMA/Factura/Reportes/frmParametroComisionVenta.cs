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

namespace SMA.Factura.Reportes
{
    public partial class frmParametroComisionVenta : Office2007Form
    {
        public frmParametroComisionVenta()
        {
            InitializeComponent();
        }

        private void frmParametroComisionVenta_Load(object sender, EventArgs e)
        {
            try
            {
                VendedorBL ObjetoVendedor = new VendedorBL();
                //LISTA DE VENDEDORES
                cbbVendedorDesde.DataSource = ObjetoVendedor.Listar();
                cbbVendedorDesde.ValueMember = "ID";
                cbbVendedorDesde.DisplayMember = "Nombre";

                cbbVendedorHasta.DataSource = ObjetoVendedor.Listar();
                cbbVendedorHasta.ValueMember = "ID";
                cbbVendedorHasta.DisplayMember = "Nombre";
                
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                FacturaBL ObjetoFactura = new FacturaBL();

                DateTime FechaDesde = dtpFechaDesde.Value;
                DateTime FechaHasta = dtpFechaHasta.Value;

                Int32? VendedorDesde = ObtenerCodigo(cbbVendedorDesde.SelectedValue);
                Int32? VendedorHasta = ObtenerCodigo(cbbVendedorHasta.SelectedValue);

                //REPORTE DETALLADO DE COMISION DE VENTA
                if (ckbDetalle.Checked)
                {
                    List<cReporteComisionVentaDetalle> Lista = ObjetoFactura.ReporteComisionVentaDetalle(VendedorDesde, VendedorHasta, FechaDesde, FechaHasta);

                    frmrptComisionVentasDetalles ComisionVentas = new frmrptComisionVentasDetalles(Lista);
                    ComisionVentas.ShowDialog(this);
                }
                else
                {
                    List<cReporteResumenComisionVenta> Lista = ObjetoFactura.ReporteComisionVenta(VendedorDesde, VendedorHasta, FechaDesde, FechaHasta);

                    frmrptComisionVenta ComisionVenta = new frmrptComisionVenta(Lista);
                    ComisionVenta.ShowDialog(this);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? ObtenerCodigo(object p)
        {
            if(p!=null)
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

        }
    }
}
