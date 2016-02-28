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
    public partial class frmParametroCuentaGeneralProveedor : Office2007Form
    {
        Int32? ProveedorID;
        String TipoReporte;
        DateTime FechaDesde;
        DateTime FechaHasta;
        DateTime FechaCorte;
        Int32 IndicadorCorte;
        Int32 ProveedorDesde;
        Int32 ProveedorHasta;


        public frmParametroCuentaGeneralProveedor()
        {
            InitializeComponent();
        }

        public frmParametroCuentaGeneralProveedor(Int32 ProveedorID, String TipoReporte):this()
        {
            this.ProveedorID = ProveedorID;
            this.TipoReporte = TipoReporte;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (TipoReporte == "General")
            {
                try
                {
                    ObtenerDatos();
                    CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
                    List<cReporteEstadoCuenta> Lista = ObjetoCuenta.EstadoCuentaGeneral(FechaDesde, FechaHasta, FechaCorte, IndicadorCorte, ProveedorDesde, ProveedorHasta);
                    frmrptEstadoCuentaGeneralProveedor EstadoCuentaGeneral = new frmrptEstadoCuentaGeneralProveedor(Lista);
                    EstadoCuentaGeneral.ShowDialog(this);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error al general reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    ObtenerDatos();
                    CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
                    List<cReporteEstadoCuenta> Lista = ObjetoCuenta.EstadoCuentaDetallado(FechaDesde, FechaHasta, FechaCorte, IndicadorCorte, ProveedorDesde, ProveedorHasta);
                    frmrptEstadoCuentaDetalladoProveedor EstadoCuentaDetallado = new frmrptEstadoCuentaDetalladoProveedor(Lista);
                    EstadoCuentaDetallado.ShowDialog(this);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error al general reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmEstadoCuentaGeneralProveedor_Load(object sender, EventArgs e)
        {
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            if (ProveedorID.HasValue)
            {
                //Si el parametro de Proveedor tiene algun valor entonces filtramos al Proveedor seleccionado para que
                //solo muestre informacion de este
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                cbbProveedorDesde.DataSource = ObjetoProveedor.Filtrar(Codigo, Codigo, null, null);
                cbbProveedorHasta.DataSource = ObjetoProveedor.Filtrar(Codigo, Codigo, null, null);
            }
            else
            {
                cbbProveedorDesde.DataSource = ObjetoProveedor.Listar();
                cbbProveedorHasta.DataSource = ObjetoProveedor.Listar();

            }
            cbbProveedorDesde.ValueMember = "ID";
            cbbProveedorHasta.ValueMember = "ID";
            cbbProveedorDesde.DisplayMember = "NombreComercial";
            cbbProveedorHasta.DisplayMember = "NombreComercial";

        }

        private void ObtenerDatos()
        {
            FechaDesde = dtpFechaDesde.Value;
            FechaHasta = dtpFechaHasta.Value;
            FechaCorte = dtpFechaCorte.Value;
            IndicadorCorte = ObtenerIndicadorCorte();
            ProveedorDesde = Convert.ToInt32(cbbProveedorDesde.SelectedValue.ToString());
            ProveedorHasta = Convert.ToInt32(cbbProveedorHasta.SelectedValue.ToString());


        }

        private int ObtenerIndicadorCorte()
        {
            //Indicador de Fecha de Corte
            if (rbFechaCorte.Checked)
            {
                return 1;
            }
            else
            {
                return -1;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
