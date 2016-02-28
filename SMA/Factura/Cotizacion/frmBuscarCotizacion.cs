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

namespace SMA.Factura.Cotizacion
{
    public partial class frmBuscarCotizacion : Office2007Form
    {

        frmGestionCotizaciones GestionCotizaciones;

        public frmBuscarCotizacion()
        {
            InitializeComponent();
        }

        public frmBuscarCotizacion(frmGestionCotizaciones GestionCotizaciones):this()
        {
            this.GestionCotizaciones = GestionCotizaciones;
        }

        private void frmBuscarCotizacion_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now.Date;
            Decimal Monto = 0;
            Int64 FacturaID=0;
            String NombreComercial = "";
            String CriterioValor = "Todos";

            if (cbbBusqueda.Text == "Nombre de Cliente")
            {
                NombreComercial = txtStringFind.Text;
            }
            else if (cbbBusqueda.Text == "Fecha Elaboración" && DateTime.TryParse(txtStringFind.Text, out Fecha))
            {
                Fecha = Convert.ToDateTime(txtStringFind.Text);

            }
            else if (cbbBusqueda.Text == "Perido")
            {
                FacturaID = Convert.ToInt64(txtStringFind.Text);
            }
            else
            {
                MessageBox.Show("Los datos proporcionados no coinciden con las opciones seleccionadas, revise y vuelva a internarlo", "Error en busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cbbCriterio.Text == "Todos" && Decimal.TryParse(txtImporte.Text, out Monto))
            {
                Monto = Convert.ToDecimal(txtImporte.Text);
            }
            Buscar(NombreComercial, Fecha, Monto, FacturaID, CriterioValor);
        }

        private void Buscar(string NombreComercial_, DateTime Fecha_, Decimal Monto_, Int64 FacturaID_, String CriterioValor)
        {
            //try
            //{
            //    //Obtenemos la lista de cotizaciones con los parametros proporcionados
            //    FacturaBL ObjetoFactura = new FacturaBL();
            //    GestionCotizaciones.BuscarFactura(ObjetoFactura.Filtrar("C", cbbBusqueda.Text, CriterioValor, Monto_, NombreComercial_, Fecha_, FacturaID_));
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
