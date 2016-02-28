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

namespace SMA.Clientes.CuentasCobrar.Reportes
{
    public partial class frmParametroResumenCuentaCobrar : Office2007Form
    {
        private Int64? ClienteID;

        private Int64? CodigoCliente;
        private DateTime? FechaDesde;
        private DateTime? FechaHasta;

        public frmParametroResumenCuentaCobrar()
        {
            InitializeComponent();
        }

        public frmParametroResumenCuentaCobrar(Int64 ClienteID):this()
        {
            this.ClienteID = ClienteID;
        }

        private void frmParametroResumenCuentaCobrar_Load(object sender, EventArgs e)
        {
            ClienteBL ObjetoCliente = new ClienteBL();
            if (ClienteID.HasValue)
            {
                //Si el parametro de Proveedor tiene algun valor entonces filtramos al Proveedor seleccionado para que
                //solo muestre informacion de este
                Int64 Codigo = Convert.ToInt64(ClienteID);
                cbCliente.DataSource = ObjetoCliente.Filtrar(Codigo, Codigo, null, null, null);
            }
            else
            {
                cbCliente.DataSource = ObjetoCliente.Listar();


            }
            cbCliente.ValueMember = "ID";
            cbCliente.DisplayMember = "NombreComercial";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
             
            CuentasCobrarBL ObjetoCuenta=new CuentasCobrarBL();
            //RESUMEN DE CUENTAS
            if(rbResumen.Checked)
            {
            
                List<cReporteResumenCuentaCobrar> Lista=ObjetoCuenta.ReporteResumenCuentaCobrar(CodigoCliente,FechaDesde,FechaHasta);
                frmrptResumenCuentasCobrar ResumenCuentas=new frmrptResumenCuentasCobrar(Lista);
                ResumenCuentas.ShowDialog(this);
            }
            
            //RESUMEN DETALLADO
            if(rbResumenyMov.Checked)
            {
                List<cReporteEstadoCuenta> Lista = ObjetoCuenta.ReporteResumenCuentaCobrarDetalle(CodigoCliente, FechaDesde, FechaHasta);
                frmrptResumenCuentaCobrarDetalle ResumenDetallado = new frmrptResumenCuentaCobrarDetalle(Lista);
                ResumenDetallado.ShowDialog(this);
            }

        }

        private void ObtenerDatos()
        {
            CodigoCliente = ObtenerCodigo();
            
        }

        private Int64? ObtenerCodigo()
        {
            //Obtenemos el codigo de cliente
            if (cbCliente.Text != String.Empty)
            {
                return Convert.ToInt64(cbCliente.SelectedValue.ToString());
            }
            else
            {
                return null;
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpFechaHasta.Value;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        }
    }

