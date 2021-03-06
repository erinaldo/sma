﻿using System;
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

namespace SMA.Clientes.CuentasPagar
{
    public partial class frmBuscarCxC : Office2007Form
    {
        Int16 IndicadorFechaEmision = -1;
        Int16 IndicadorFechaVencimiento = -1;
        Int16 IndicadorConcepto = -1;
        String CriterioMonto;
        String CriterioBalance;
        Decimal Monto;
        Decimal Balance;
        Int16 CodigoConcepto;
        Int32 CodigoCliente;
        DateTime FechaDesde;
        DateTime FechaHasta;

        #region Constructores
        public frmBuscarCxC()
        {
            InitializeComponent();
        }

        public frmBuscarCxC(Int32 CodigoCliente):this()
        {
            this.CodigoCliente = CodigoCliente;
        }
        #endregion

        private void frmBuscarCxC_Load(object sender, EventArgs e)
        {
            ConceptoCxCBL ObjetoConcepto = new ConceptoCxCBL();
            lbConceptos.DataSource = ObjetoConcepto.Listar();
            lbConceptos.ValueMember = "Codigo";
            lbConceptos.DisplayMember = "Descripcion";
        }

        private void rdbTodosConceptos_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbTodosConceptos.Checked)
            {
                lbConceptos.Enabled = false;
            }
        }

        private void rdbSeleccionarConcepto_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbSeleccionarConcepto.Checked)
            {
                lbConceptos.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Obtenemos los datos necesarios
            ObtenerDatos();

            //Utilizamos la interface para pasar la lista resultado del filtro
            try
            {
                //Provee el documento
                IGestionCuentasCobrar FormInterfaceGestionCuentas = this.Owner as IGestionCuentasCobrar;
                if (FormInterfaceGestionCuentas != null)
                {
                    CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                    //Realizamos la busqueda y guardamos el resultado
                    List<cCuentasCobrar> ListaFiltrada = ObjetoCuenta.FiltrarCuentas(IndicadorFechaEmision, IndicadorFechaVencimiento, IndicadorConcepto, CriterioMonto, CriterioBalance, Monto, Balance, CodigoConcepto, CodigoCliente, FechaDesde, FechaHasta);
                    //Enviamos el resultado utilizando la interface
                    FormInterfaceGestionCuentas.AplicarFiltro(ListaFiltrada);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ObtenerDatos()
        {
            //Indicador de Concepto
            if(rdbSeleccionarConcepto.Checked)
         
            {
                IndicadorConcepto = 1;
            }

            if(rdbTodosConceptos.Checked)
            {
                IndicadorConcepto = -1;
            }

            //Indicador Fecha Emision
            if(rdbFechaAplicacion.Checked)
            {
                IndicadorFechaEmision = 1;
            }
            else
            {
                IndicadorFechaEmision=-1;
            }

            //Indicador Fecha Vencimiento
            if(rdbFechaVencimiento.Checked)
            {
                IndicadorFechaVencimiento = 1;
            }
            else
            {
                IndicadorFechaVencimiento = -1;
            }

            CodigoConcepto = ObtenerConcepto();
            //Criterios de Balance y Monto
            CriterioBalance = cbCriterioBalance.Text;
            CriterioMonto = cbCriterioMonto.Text;
            Monto = ObtenerMonto();
            Balance = ObtenerBalance();

            //Fechas
            FechaDesde = dtpDesde.Value;
            FechaHasta = dtpHasta.Value;
        }

        private Int16 ObtenerConcepto()
        {
            //Obtenemos el codigo del concepto a buscar
            Int16 Codigo;
            if(Int16.TryParse(lbConceptos.SelectedValue.ToString(),out Codigo))
            {
                return Convert.ToInt16(lbConceptos.SelectedValue.ToString());
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
