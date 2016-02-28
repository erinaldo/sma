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
    public partial class frmFiltrarCotizacion : Office2007Form
    {
        frmGestionCotizaciones GestionCotizaciones;
        DateTime? FechaDesde;
        DateTime? FechaHasta;

        public frmFiltrarCotizacion()
        {
            InitializeComponent();
        }

        public frmFiltrarCotizacion(frmGestionCotizaciones GestionCotizaciones):this()
        {
            this.GestionCotizaciones = GestionCotizaciones;
        }
        private void frmFiltrarCotizacion_Load(object sender, EventArgs e)
        {
            try
            {
                ClienteBL ObjetoCliente = new ClienteBL();
                cbCliente.DataSource = ObjetoCliente.Listar();
                cbCliente.ValueMember = "ID";
                cbCliente.DisplayMember = "NombreComercial";
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al listar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            FacturaBL ObjetoFactura = new FacturaBL();
            Int32? ClienteID=ObtenerCliente();
            
            Int32? DocumentoDesde=Convert.ToInt32(txtDesde.Text);
            Int32? DocumentoHasta=Convert.ToInt32(txtHasta.Text);
            Boolean IndGenerada=ckbGenerada.Checked;
            Boolean IndCancelada=ckbCancelada.Checked;
            Boolean IndFacturada=ckbFacturada.Checked;
            String CriterioValor = ObtenerCriterio(cbbCriterio.Text);
            Decimal ValorFactura = ObtenerValor(txtImporte.Text);

            List<cFactura> Lista = ObjetoFactura.FiltrarFactura("C", ClienteID, DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta, IndGenerada, IndCancelada, IndFacturada,CriterioValor,ValorFactura);
            GestionCotizaciones.BuscarFactura(Lista);
        }

        private Decimal ObtenerValor(string p)
        {
            Decimal Valor;
            if (Decimal.TryParse(p, out Valor))
            {
                return Convert.ToDecimal(p);
            }
            else
            {
                return 0;
            }
        }

        private string ObtenerCriterio(string p)
        {
            if(p!=null)
            {
                return p;
            }
            else
            {
                return null;
            }
        }

        private Int32 ObtenerCliente()
        {
            Int32 Codigo;
            if(Int32.TryParse(cbCliente.SelectedValue.ToString(),out Codigo))
            {
                return Convert.ToInt32(cbCliente.SelectedValue.ToString());
            }
            else
            {
                throw new Exception("Es necesario que indique el cliente");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpDesde.Value;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpHasta.Value;
        }
    }
}
