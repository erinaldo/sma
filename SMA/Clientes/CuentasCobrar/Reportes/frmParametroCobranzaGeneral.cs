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
    public partial class frmParametroCobranzaGeneral : Office2007Form
    {
        private Int32? CodigoCliente;

        public frmParametroCobranzaGeneral()
        {
            InitializeComponent();
        }

        public frmParametroCobranzaGeneral(Int32 CodigoCliente):this()
        {
            this.CodigoCliente = CodigoCliente;
        }

        private void frmParametroCobranzaGeneral_Load(object sender, EventArgs e)
        {

            ClienteBL ObjetoCliente = new ClienteBL();
            //Si el parametro de Proveedor tiene algun valor entonces filtramos al Proveedor seleccionado para que
            //solo muestre informacion de este
            Int32 Codigo = Convert.ToInt32(CodigoCliente);
            cbbClienteDesde.DataSource = ObjetoCliente.Listar();
            cbbClienteHasta.DataSource = ObjetoCliente.Listar();

            cbbClienteDesde.ValueMember = "Codigo";
            cbbClienteHasta.ValueMember = "Codigo";
            cbbClienteDesde.DisplayMember = "NombreComercial";
            cbbClienteHasta.DisplayMember = "NombreComercial";

            if (CodigoCliente.HasValue)
            {
                cbbClienteDesde.SelectedValue = CodigoCliente;
                cbbClienteHasta.SelectedValue = CodigoCliente;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 ClienteDesde = ObtenerCliente(cbbClienteDesde.SelectedValue);
                Int32 ClienteHasta = ObtenerCliente(cbbClienteHasta.SelectedValue);
                DateTime FechaCorte = dtpFechaCorte.Value;

                CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                List<cReporteEstadoCuenta> Lista = ObjetoCuenta.ReporteDocumentosPorCobrar(ClienteDesde, ClienteHasta, FechaCorte);
                frmrptCobranzaGeneral DocumentosPorCobrar = new frmrptCobranzaGeneral(Lista);
                DocumentosPorCobrar.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
           
        }

        //Obtenemos el codigo de cliente
        private int ObtenerCliente(Object p)
        {
            Int32 Valor;
            if(p!=null && Int32.TryParse(p.ToString(),out Valor))
            {
                return Convert.ToInt32(p.ToString());
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
