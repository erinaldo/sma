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


namespace SMA.Compras.Reportes
{
    public partial class rptParametrosResumenNCF : Office2007Form
    {
        private Int32 ProveedorID=-1;

        public rptParametrosResumenNCF()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rptParametrosResumenNCF_Load(object sender, EventArgs e)
        {
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            cbCliente.DataSource = ObjetoProveedor.Listar();
            cbCliente.ValueMember = "ID";
            cbCliente.DisplayMember = "NombreComercial";
            cbCliente.SelectedValue = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime FechaDesde = dtpFechaDesde.Value;
                DateTime FechaHasta = dtpFechaHasta.Value;

                ComprasBL ObjetoCompra = new ComprasBL();

                Int32 Codigo;
                if (cbCliente.SelectedValue != null)
                {
                    if (Int32.TryParse(cbCliente.SelectedValue.ToString(), out Codigo))
                    {
                        ProveedorID = Convert.ToInt32(cbCliente.SelectedValue.ToString());
                    }
                }

                List<cReporteFactura> Listado = ObjetoCompra.ResumenNCF(FechaDesde, FechaHasta, ProveedorID);
                if (Listado.Count > 0)
                {
                    frmrptResumenNCF ResumenFactura = new frmrptResumenNCF(Listado);
                    ResumenFactura.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("La busqueda no ha arrojado ningun resultado", "Busqueda sin resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception Ex)
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
