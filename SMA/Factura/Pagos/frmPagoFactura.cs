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
using SMA.Factura.Reportes;

namespace SMA.Factura.Pagos
{
    
    public partial class frmPagoFactura : Office2007Form
    {
        private Int64 FacturaID;
        private Decimal MontoFactura;
        Decimal MontoPagado;

        public frmPagoFactura()
        {
            InitializeComponent();
        }

        public frmPagoFactura(Int64 FacturaID, Decimal MontoFactura):this()
        {
            this.FacturaID = FacturaID;
            this.MontoFactura = MontoFactura;
        }
        private void frmPagoFactura_Load(object sender, EventArgs e)
        {
            CargarDependencias();
            lblMontoFactura.Text = MontoFactura.ToString("C2");
            lblNumeroFactura.Text = FacturaID.ToString();
            btnImprimir.Enabled = false;
        }

        private void CargarDependencias()
        {
            //Carga los combo box con informacion completementaria
            TipoTarjetaBL ObjetoTipoTarjeta = new TipoTarjetaBL();
            cbTipoTarjeta.DataSource = ObjetoTipoTarjeta.Listar();
            cbTipoTarjeta.ValueMember = "ID";
            cbTipoTarjeta.DisplayMember = "Descripcion";
            cbTipoTarjeta.SelectedValue=-1;

            EmisorTarjetaBL ObjetoEmisorTarjeta = new EmisorTarjetaBL();
            cbEntidad.DataSource=ObjetoEmisorTarjeta.Listar();
            cbEntidad.ValueMember="ID";
            cbEntidad.DisplayMember="Descripcion";
            cbEntidad.SelectedValue=-1;
        }
        

        private void txtMontoEfectivo_Validated(object sender, EventArgs e)
        {
            try
            {
                //Total Pago en Efectivo
               SumarPago(Convert.ToDecimal(txtMontoEfectivo.Text),0);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void txtMontoTarjeta_Validated(object sender, EventArgs e)
        {
            try
            {
                //Total Pago en efectivo mas Tarjeta
               SumarPago(Convert.ToDecimal(txtMontoEfectivo.Text), Convert.ToDecimal(txtMontoTarjeta.Text));
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void SumarPago(Decimal ValorEfectivo, Decimal ValorTarjeta)
        {
            MontoPagado = ValorEfectivo + ValorTarjeta;
            lblSuPago.Text = MontoPagado.ToString("C2");


        }

        private void lblSuPago_TextChanged(object sender, EventArgs e)
        {
            CalcularDevolucion();
        }

        private void CalcularDevolucion()
        {
            Decimal Devolucion = MontoPagado - MontoFactura;
            lblDevolucion.Text = Devolucion.ToString("C2");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MontoPagado >= MontoFactura)
                {
                    frmrptFactura Reporte = new frmrptFactura(FacturaID);
                    Reporte.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("El monto pagado no alcanza el monto de total de factura, favor verificar", "Error en pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Error en pago",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void GuardarCambios()
        {
            try
            {
                MovCajaCobroBL ObjetoMovCajaCobro = new MovCajaCobroBL();
                ObjetoMovCajaCobro.Crear(ObtenerDatos());
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error en pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
        private cMovCajaCobro ObtenerDatos()
        {
            //Obtenemos los datos del pago
            try
            {
                cMovCajaCobro Movimiento = new cMovCajaCobro();
                Movimiento.FacturaID = FacturaID;
                Movimiento.Fecha = DateTime.Now;
                Movimiento.FechaExpiracion = txtExpiracionTarjeta.Text;
                Movimiento.NumeroTarjeta = ObtenerNumeroTarjeta();
                Movimiento.MontoEfectivo = Convert.ToDecimal(txtMontoEfectivo.Text);
                Movimiento.MontoTarjeta = Convert.ToDecimal(txtMontoTarjeta.Text);
                Movimiento.TipoTarjetaID = ObtenerTipoTarjeta();
                Movimiento.EmisorID = ObtenerEmisor();
                Movimiento.NumeroAprobacion = ObtenerNumeroAprobacion(txtNumeroAprobacion.Text);

                return Movimiento;
            }
            catch(Exception Ex)
            {
                throw Ex;
               
            }
        }

        private int ObtenerNumeroAprobacion(string p)
        {
            Int32 Codigo;
            if(Int32.TryParse(p.ToString(),out Codigo))
            {
                return Convert.ToInt32(p);
            }
            else 
            {
                return -1;
            }
        }

        public Int32 ObtenerEmisor()
        {
            //Obtenemos el emisor de la tarjeta
            String Emisor = cbEntidad.Text;
            if(Emisor!=string.Empty)
            {
                return Convert.ToInt32(cbEntidad.SelectedValue.ToString());
            }
            else
            {
                return -1;
            }
        }
        public Int32 ObtenerTipoTarjeta()
        {
            //Obtenemos el tipo de tarjeta
            String TipoTarjeta = cbTipoTarjeta.Text;

            if(TipoTarjeta!=string.Empty)
            {
                return Convert.ToInt32(cbTipoTarjeta.SelectedValue.ToString());
            }
            else
            {
                return -1;
            }

        }
        public Int32 ObtenerNumeroTarjeta()
        {
            Int32 Numero;
            

            if(Int32.TryParse(txtNumeroTarjeta.Text,out Numero) && (txtNumeroTarjeta.Text.Length==4))
            {
                return Convert.ToInt32(txtNumeroTarjeta.Text);
            }
            else
            {
                return 0;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarCambios();
                btnGuardar.Enabled = false;
                btnImprimir.Enabled = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error en pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
