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
    public partial class frmParametroAbonosCuentaCobrar : Office2007Form
    {
        private Int32? ClienteID;
        DateTime FechaDesde;
        DateTime FechaHasta;

        public frmParametroAbonosCuentaCobrar()
        {
            InitializeComponent();
        }

        public frmParametroAbonosCuentaCobrar(Int32 ClienteID):this()
        {
            this.ClienteID = ClienteID;
        }

        private void frmParametroAbonosCuentaCobrar_Load(object sender, EventArgs e)
        {
            ClienteBL ObjetoCliente = new ClienteBL();
            
            Int32 Codigo = Convert.ToInt32(ClienteID);
            cbbClienteDesde.DataSource = ObjetoCliente.Listar();
            cbbClienteHasta.DataSource = ObjetoCliente.Listar();

            cbbClienteDesde.ValueMember = "Codigo";
            cbbClienteHasta.ValueMember = "Codigo";
            cbbClienteDesde.DisplayMember = "NombreComercial";
            cbbClienteHasta.DisplayMember = "NombreComercial";

            //Colocamos en seleccion al cliente 
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
                Int32 ClienteDesde = ObtenerCodigoCliente(cbbClienteDesde.SelectedValue.ToString());
                Int32 ClienteHasta = ObtenerCodigoCliente(cbbClienteHasta.SelectedValue.ToString());

                FechaDesde = dtpFechaDesde.Value;
                FechaHasta = dtpFechaHasta.Value;

                DateTime FechaCorte = ObtenerFechaCorte();
                Int16 IndicadorCorte = ObtenerIndicadorCorte();

                CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                List<cReporteEstadoCuenta> Lista = ObjetoCuenta.ReporteAbonoPorPeriodo(FechaDesde, FechaHasta, FechaCorte, ClienteDesde, ClienteHasta,IndicadorCorte);

                frmrptAbonosPorPeriodoCuentaCobrar ReporteAbonos = new frmrptAbonosPorPeriodoCuentaCobrar(Lista);
                ReporteAbonos.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error en consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Obtenemos 
        private short ObtenerIndicadorCorte()
        {
           if(rbFechaCorte.Checked)
           {
               return 1;
           }
           else
           {
               return -1;
           }
        }

        private Int32 ObtenerCodigoCliente(String Valor)
        {
            //Obtenemos el codigo del cliente seleccionado
            if(Valor!=null)
            {
                return Convert.ToInt32(Valor);
            }
            else
            {
                throw new Exception("Es necesario que especifique el o los clientes a consultar");
            }
            
        }

        private DateTime ObtenerFechaCorte()
        {
            
                return dtpFechaCorte.Value;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
