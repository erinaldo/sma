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
    public partial class frmParametroAntiguedadSaldo : Office2007Form
    {
        private Int64? ClienteID;

        public frmParametroAntiguedadSaldo()
        {
            InitializeComponent();
        }

        public frmParametroAntiguedadSaldo(Int64 ClienteID):this()
        {
            this.ClienteID = ClienteID;
        }

        private void frmParametroAntiguedadSaldo_Load(object sender, EventArgs e)
        {
            ClienteBL ObjetoCliente = new ClienteBL();
            //Si el parametro de Proveedor tiene algun valor entonces filtramos al Proveedor seleccionado para que
            //solo muestre informacion de este
            Int64 Codigo = Convert.ToInt64(ClienteID);
            cbbClienteDesde.DataSource = ObjetoCliente.Listar();
            cbbClienteHasta.DataSource = ObjetoCliente.Listar();
         
            cbbClienteDesde.ValueMember = "ID";
            cbbClienteHasta.ValueMember = "ID";
            cbbClienteDesde.DisplayMember = "NombreComercial";
            cbbClienteHasta.DisplayMember = "NombreComercial";

            if (ClienteID.HasValue)
            {
                cbbClienteDesde.SelectedValue = ClienteID;
                cbbClienteHasta.SelectedValue = ClienteID;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? FechaCorte = ObtenerFechaCorte();
                String IndicadorFecha = ObtenerIndicadorFecha();
                Int64 ClienteDesde = Convert.ToInt64(cbbClienteDesde.SelectedValue.ToString());
                Int64 ClienteHasta = Convert.ToInt64(cbbClienteHasta.SelectedValue.ToString());
                DateTime FechaReferencia = dtpFechaReferencia.Value;

                CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();

                if (ckbDetalle.Checked)
                {
                    //Obtenemos la lista de resultados
                    List<cAntiguedadSaldoDetalle> Lista = ObjetoCuenta.AntiguedadSaldoDetalle(IndicadorFecha, FechaReferencia, FechaCorte, ClienteDesde, ClienteHasta);
                   //verificamos si existe información
                    if (Lista.Count > 0)
                    {
                        //Formulario de reporte
                        frmrptAntiguedadSaldoDetalleCliente ReporteAntiguedadSaldo = new frmrptAntiguedadSaldoDetalleCliente(Lista);
                        ReporteAntiguedadSaldo.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("No existe información para mostrar en el reporte", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    //Obtenemos la lista de resultados
                    List<cAntiguedadSaldo> Lista = ObjetoCuenta.AntiguedadSaldo(IndicadorFecha, FechaReferencia, FechaCorte, ClienteDesde, ClienteHasta);
                    //verificamos si existe información
                    if (Lista.Count > 0)
                    {
                        //Formulario de reporte
                        frmrptAntiguedadSaldoCuentasCobras ReporteAntiguedadSaldo = new frmrptAntiguedadSaldoCuentasCobras(Lista);
                        ReporteAntiguedadSaldo.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("No existe información para mostrar en el reporte", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private String ObtenerIndicadorFecha()
        {
            //Obtenemos el parametro de la fecha parametro
            if(rbFechaEmision.Checked)
            {
                return "Emision";
            }
            else if(rbFechaVencimiento.Checked)
            {
                return "Vencimiento";
            }
            else
            {
                return "Vencimiento";
            }

        }

        private Nullable<DateTime> ObtenerFechaCorte()
        {
            //Obtenemos la fecha de corte
            if(rbFechaCorte.Checked)
            {
                return dtpFechaCorte.Value;
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

        private void rbFechaEmision_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFechaEmision.Checked)
            {
                if (rbFechaCorte.Checked)
                {
                    rbFechaCorte.Checked = false;
                }
            }
        }

        private void rbFechaVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFechaVencimiento.Checked)
            {
                if (rbFechaCorte.Checked)
                {
                    rbFechaCorte.Checked = false;
                }
            }
        }

        private void rbFechaCorte_CheckedChanged(object sender, EventArgs e)
        {

            if (rbFechaCorte.Checked)
            {
                rbFechaVencimiento.Checked = false;
                rbFechaEmision.Checked = false;
            }
        }
    }
}
