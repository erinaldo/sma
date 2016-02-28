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

namespace SMA.Clientes.CuentasPagar
{
    public partial class frmBuscarCxP : Office2007Form
    {
        Nullable<Int32> IndicadorFechaEmision;
        Nullable<Int32> IndicadorFechaVencimiento;
        Nullable<Int32> IndicadorConcepto;
        String CriterioMonto;
        String CriterioBalance;
        Decimal Monto;
        Decimal Balance;
        Nullable<Int32> ConceptoID;
        Int64 ProveedorID;
        DateTime FechaDesde;
        DateTime FechaHasta;

        public frmBuscarCxP()
        {
            InitializeComponent();
        }

        public frmBuscarCxP(Int32 ProveedorID):this()
        {
            this.ProveedorID = ProveedorID;
        }
        private void frmBuscarCxP_Load(object sender, EventArgs e)
        {
            ConceptoCxPBL ObjetoConcepto = new ConceptoCxPBL();
            lbConceptos.DataSource = ObjetoConcepto.Listar();
            lbConceptos.ValueMember = "ID";
            lbConceptos.DisplayMember = "Descripcion";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos necesarios
            ObtenerDatos();

            //Utilizamos la interface para pasar la lista resultado del filtro
            try
            {
                //Provee el documento
                IGestionCuentasPagar FormInterfaceGestionCuentas = this.Owner as IGestionCuentasPagar;
                if (FormInterfaceGestionCuentas != null)
                {
                    CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
                    //Realizamos la busqueda y guardamos el resultado
                    List<cCuentasPagar> ListaFiltrada = ObjetoCuenta.FiltrarCuentas(IndicadorFechaEmision, IndicadorFechaVencimiento, IndicadorConcepto, CriterioMonto, CriterioBalance, Monto, Balance, ConceptoID, ProveedorID, FechaDesde, FechaHasta);
                    //Enviamos el resultado utilizando la interface
                    FormInterfaceGestionCuentas.AplicarFiltro(ListaFiltrada);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ObtenerDatos()
        {
            //Indicador de Concepto
            if (rbSeleccionarConcepto.Checked)
            {
                IndicadorConcepto = 1;
            }

            if (rbTodosConceptos.Checked)
            {
                IndicadorConcepto = -1;
            }

            //Indicador Fecha Emision
            if (rdbFechaAplicacion.Checked)
            {
                IndicadorFechaEmision = 1;
            }
            else
            {
                IndicadorFechaEmision = -1;
            }

            //Indicador Fecha Vencimiento
            if (rdbFechaVencimiento.Checked)
            {
                IndicadorFechaVencimiento = 1;
            }
            else
            {
                IndicadorFechaVencimiento = -1;
            }

            ConceptoID = ObtenerConcepto();
            //Criterios de Balance y Monto
            CriterioBalance = cbCriterioBalance.Text;
            CriterioMonto = cbCriterioMonto.Text;
            Monto = ObtenerMonto();
            Balance = ObtenerBalance();

            //Fechas
            FechaDesde = dtpDesde.Value;
            FechaHasta = dtpHasta.Value;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbTodosConceptos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodosConceptos.Checked)
            {
                lbConceptos.Enabled = false;
            }
        }

        private void rbSeleccionarConcepto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSeleccionarConcepto.Checked)
            {
                lbConceptos.Enabled = true;
            }
        }

        private Int32 ObtenerConcepto()
        {
            //Obtenemos el codigo del concepto a buscar
            Int32 Codigo;
            if (Int32.TryParse(lbConceptos.SelectedValue.ToString(), out Codigo))
            {
                return Convert.ToInt32(lbConceptos.SelectedValue.ToString());
            }
            else
            {
                return -1;
            }
        }
        private Decimal ObtenerBalance()
        {
            //Obtenemos el balance introducido
            Decimal Balance;
            if (Decimal.TryParse(txtBalance.Text, out Balance))
            {
                return Convert.ToDecimal(txtBalance.Text);
            }
            else
            {
                return 0;
            }
        }

        private Decimal ObtenerMonto()
        {
            //Introducimos el Monto del Documento
            Decimal Monto;
            if (Decimal.TryParse(txtMonto.Text, out Monto))
            {
                return Convert.ToDecimal(txtMonto.Text);
            }
            else
            {
                return 0;
            }
        }
    }
}
