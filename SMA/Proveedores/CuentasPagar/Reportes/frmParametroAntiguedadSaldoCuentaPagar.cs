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
    public partial class frmParametroAntiguedadSaldoCuentaPagar : Office2007Form
    {
        private Int32? ProveedorID;

        public frmParametroAntiguedadSaldoCuentaPagar()
        {
            InitializeComponent();
        }

        public frmParametroAntiguedadSaldoCuentaPagar(Int32 ProveedorID):this()
        {
            this.ProveedorID = ProveedorID;
        }

        private void frmParametroAntiguedadSaldo_Load(object sender, EventArgs e)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? FechaCorte = ObtenerFechaCorte();
                String IndicadorFecha = ObtenerIndicadorFecha();
                Int64 ProveedorDesde = Convert.ToInt64(cbbProveedorDesde.SelectedValue.ToString());
                Int64 ProveedorHasta = Convert.ToInt64(cbbProveedorHasta.SelectedValue.ToString());
                DateTime FechaReferencia = dtpFechaReferencia.Value;

                CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();

                if (ckbDetalle.Checked)
                {
                    //Obtenemos la lista de resultados
                    List<cAntiguedadSaldoDetalle> Lista = ObjetoCuenta.AntiguedadSaldoDetalle(IndicadorFecha, FechaReferencia, FechaCorte, ProveedorDesde, ProveedorHasta);
                    //verificamos si existe información
                    if (Lista.Count > 0)
                    {
                        //Formulario de reporte
                        frmrptAntiguedadSaldoCuentaPagarDetalle ReporteAntiguedadSaldo = new frmrptAntiguedadSaldoCuentaPagarDetalle(Lista);
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
                    List<cAntiguedadSaldo> Lista = ObjetoCuenta.AntiguedadSaldo(IndicadorFecha, FechaReferencia, FechaCorte, ProveedorDesde, ProveedorHasta);
                    //verificamos si existe información
                    if (Lista.Count > 0)
                    {
                        //Formulario de reporte
                        frmrptAntiguedadSaldoCuentaPagar ReporteAntiguedadSaldo = new frmrptAntiguedadSaldoCuentaPagar(Lista);
                        ReporteAntiguedadSaldo.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("No existe información para mostrar en el reporte", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private String ObtenerIndicadorFecha()
        {
            //Obtenemos el parametro de la fecha parametro
            if (rbFechaEmision.Checked)
            {
                return "Emision";
            }
            else if (rbFechaVencimiento.Checked)
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
