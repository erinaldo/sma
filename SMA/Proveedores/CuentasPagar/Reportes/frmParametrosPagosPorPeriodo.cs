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
    public partial class frmParametrosPagosPorPeriodo : Office2007Form
    {
        private Int32? ProveedorID;
        DateTime FechaDesde;
        DateTime FechaHasta;

        public frmParametrosPagosPorPeriodo()
        {
            InitializeComponent();
        }

        public frmParametrosPagosPorPeriodo(Int32 ProveedorID):this()
        {
            this.ProveedorID = ProveedorID;
        }

        private void frmParametrosPagosPorPeriodo_Load(object sender, EventArgs e)
        {
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            if (ProveedorID.HasValue)
            {
                //Si el parametro de Proveedor tiene algun valor entonces filtramos al Proveedor seleccionado para que
                //solo muestre informacion de este
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                cbbClienteDesde.DataSource = ObjetoProveedor.Filtrar(Codigo, Codigo, null, null);
                cbbClienteHasta.DataSource = ObjetoProveedor.Filtrar(Codigo, Codigo, null, null);
            }
            else
            {
                cbbClienteDesde.DataSource = ObjetoProveedor.Listar();
                cbbClienteHasta.DataSource = ObjetoProveedor.Listar();

            }
            cbbClienteDesde.ValueMember = "ID";
            cbbClienteHasta.ValueMember = "ID";
            cbbClienteDesde.DisplayMember = "NombreComercial";
            cbbClienteHasta.DisplayMember = "NombreComercial";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Int32 ClienteDesde = Convert.ToInt32(cbbClienteDesde.SelectedValue.ToString());
            Int32 ClienteHasta = Convert.ToInt32(cbbClienteHasta.SelectedValue.ToString());

            FechaDesde = dtpFechaDesde.Value;
            FechaHasta = dtpFechaHasta.Value;

            DateTime? FechaCorte = ObtenerFechaCorte();

            CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
            List<cReporteEstadoCuentaPagar> Lista = ObjetoCuenta.ReportePagosPorPeriodo(FechaDesde, FechaHasta, FechaCorte, ClienteDesde, ClienteHasta);

            frmrptPagosPorPeriodo ReporteAbonos = new frmrptPagosPorPeriodo(Lista);
            ReporteAbonos.ShowDialog(this);
        }


        private DateTime? ObtenerFechaCorte()
        {
            if (rbFechaCorte.Checked)
            {
                return dtpFechaCorte.Value;
            }
            else
            {
                return null;
            }
        }
    }
}
