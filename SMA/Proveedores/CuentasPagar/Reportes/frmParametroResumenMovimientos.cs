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
    public partial class frmParametroResumenMovimientos : Office2007Form
    {
        private Int32? ProveedorID;
        private Int32? CodigoCliente;
        private DateTime? FechaDesde;
        private DateTime? FechaHasta;

        public frmParametroResumenMovimientos()
        {
            InitializeComponent();
        }

        public frmParametroResumenMovimientos(Int32 ProveedorID):this()
        {
            this.ProveedorID = ProveedorID;
        }

        private void frmParametroResumenMovimientos_Load(object sender, EventArgs e)
        {
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            if (ProveedorID.HasValue)
            {
                //Si el parametro de Proveedor tiene algun valor entonces filtramos al Proveedor seleccionado para que
                //solo muestre informacion de este
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                cbCliente.DataSource = ObjetoProveedor.Filtrar(Codigo, Codigo, null, null);
            }
            else
            {
                cbCliente.DataSource = ObjetoProveedor.Listar();


            }
            cbCliente.ValueMember = "ID";
            cbCliente.DisplayMember = "NombreComercial";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            ObtenerDatos();

            CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
            //RESUMEN DE CUENTAS
            if (rbResumen.Checked)
            {

                List<cReporteResumenCuentaPagar> Lista = ObjetoCuenta.ResumenCuentaPagar(CodigoCliente, FechaDesde, FechaHasta);
                frmrptResumenCuentaPagar ResumenCuentas = new frmrptResumenCuentaPagar(Lista);
                ResumenCuentas.ShowDialog(this);
            }

            //RESUMEN DETALLADO
            if (rbResumenyMov.Checked)
            {
                List<cReporteEstadoCuentaPagar> Lista = ObjetoCuenta.ReporteResumenCuentaPagarDetalle(CodigoCliente, FechaDesde, FechaHasta);
                frmrptResumenCuentaPagarDetalle ResumenDetallado = new frmrptResumenCuentaPagarDetalle(Lista);
                ResumenDetallado.ShowDialog(this);
            }
        }

        private void ObtenerDatos()
        {
            CodigoCliente = ObtenerCodigo();

        }

        private int? ObtenerCodigo()
        {
            //Obtenemos el codigo de cliente
            if (cbCliente.Text != String.Empty)
            {
                return Convert.ToInt32(cbCliente.SelectedValue.ToString());
            }
            else
            {
                return null;
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpFechaDesde.Value.Date;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpFechaHasta.Value.Date;
        }
    }
}
