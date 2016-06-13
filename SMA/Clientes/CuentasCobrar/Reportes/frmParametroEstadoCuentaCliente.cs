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

namespace SMA.Clientes.CuentasCobrar.Reportes
{
    public partial class frmParametroEstadoCuentaCliente : Office2007Form
    {
        Int32? ClienteID;
        String TipoReporte;
        DateTime FechaDesde;
        DateTime FechaHasta;
        DateTime FechaCorte;
        Int16 IndicadorCorte;
        Int32 ClienteDesde;
        Int32 ClienteHasta;

        public frmParametroEstadoCuentaCliente()
        {
            InitializeComponent();
        }

        //CONSTRUCTOR
        public frmParametroEstadoCuentaCliente(Int32 ClienteID, String TipoReporte):this()
        {
            this.ClienteID = ClienteID;
            this.TipoReporte = TipoReporte;
        }

        public frmParametroEstadoCuentaCliente(String TipoReporte):this()
        {
            this.TipoReporte = TipoReporte;
        }

        private void frmParametroEstadoCuentaCliente_Load(object sender, EventArgs e)
        {
            try
            {
                ClienteBL ObjetoCliente = new ClienteBL();
                cbbClienteDesde.DataSource = ObjetoCliente.Listar();
                cbbClienteDesde.ValueMember = "Codigo";
                cbbClienteDesde.DisplayMember = "NombreComercial";

                if (ClienteID.HasValue)
                {
                    //Si el parametro de Proveedor tiene algun valor entonces filtramos al Proveedor seleccionado para que
                    //solo muestre informacion de este
                    Int32 Codigo = Convert.ToInt32(ClienteID);
                    cbbClienteDesde.SelectedValue = Codigo;
                }

                
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ObtenerDatos()
        {
            FechaDesde = dtpFechaDesde.Value;
            FechaHasta = dtpFechaHasta.Value;
            FechaCorte = dtpFechaCorte.Value;
            IndicadorCorte = ObtenerIndicadorCorte();
            ClienteDesde = Convert.ToInt32(cbbClienteDesde.SelectedValue.ToString());
            ClienteHasta = Convert.ToInt32(cbbClienteDesde.SelectedValue.ToString());


        }

        private Int16 ObtenerIndicadorCorte()
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


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (TipoReporte == "General")
            {
                try
                {
                    ObtenerDatos();
                    CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                    List<cReporteEstadoCuenta> Lista = ObjetoCuenta.EstadoCuentaGeneral(FechaDesde, FechaHasta, FechaCorte, IndicadorCorte, ClienteDesde, ClienteHasta);
                    frmrptEstadoCuentaGeneral EstadoCuentaGeneral = new frmrptEstadoCuentaGeneral(Lista);
                    EstadoCuentaGeneral.ShowDialog(this);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (TipoReporte == "Detallado")
            {
                try
                {
                    ObtenerDatos();
                    CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                    List<cReporteEstadoCuenta> Lista = ObjetoCuenta.EstadoCuentaDetallado(FechaDesde, FechaHasta, FechaCorte, IndicadorCorte, ClienteDesde, ClienteHasta);
                    frmrptEstadoCuentaDetalladoCliente EstadoCuentaDetallado = new frmrptEstadoCuentaDetalladoCliente(Lista);
                    EstadoCuentaDetallado.ShowDialog(this);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (TipoReporte == "Cobranza General")
            {
                try
                {
                    ObtenerDatos();
                    CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                    List<cReporteEstadoCuenta> Lista = ObjetoCuenta.CobranzaGeneral(FechaDesde, FechaHasta, FechaCorte, IndicadorCorte, ClienteDesde, ClienteHasta);
                    frmrptCobranzaGeneral EstadoCuentaDetallado = new frmrptCobranzaGeneral(Lista);
                    EstadoCuentaDetallado.ShowDialog(this);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
