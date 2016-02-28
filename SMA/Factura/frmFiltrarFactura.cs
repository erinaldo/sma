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

namespace SMA.Factura
{
    public partial class frmFiltrarFactura : Office2007Form
    {
        private DateTime? FechaDesde;
        private DateTime? FechaHasta;
        private frmGestionFactura GestionFacturas;

        public frmFiltrarFactura()
        {
            InitializeComponent();
        }

        public frmFiltrarFactura(frmGestionFactura GestionFacturas):this()
        {
            this.GestionFacturas = GestionFacturas;
        }

        private void frmFiltrarFactura_Load(object sender, EventArgs e)
        {
            ClienteBL ObjetoCliente = new ClienteBL();
            cbbCliente.DataSource = ObjetoCliente.Listar();
            cbbCliente.ValueMember = "ID";
            cbbCliente.DisplayMember = "NombreComercial";
            cbbCliente.SelectedValue = -1;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            FacturaBL ObjetoFactura=new FacturaBL();
            Int32? ClienteID = ObtenerCliente(cbbCliente.SelectedValue);
            Int32? DocumentoDesde = ObtenerDocumento(txtDocumentoDesde.Text);
            Int32? DocumentoHasta = ObtenerDocumento(txtDocumentoHasta.Text);
            Boolean IndGenerada = ckbGenerada.Checked;
            Boolean IndCancelada = ckbCancelada.Checked;
            Boolean IndDevuelta = ckbDevueltas.Checked;
            String CriterioCantidad = ObtenerCriterio(cbbCriterio.Text);
            Decimal ValorFactura = ObtenerValor(txtImporte.Text);

            List<cFactura> Lista = ObjetoFactura.FiltrarFactura("F", ClienteID, DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta, IndGenerada, IndCancelada, IndDevuelta,CriterioCantidad,ValorFactura);
            GestionFacturas.BuscarFactura(Lista);
        }

        private Decimal ObtenerValor(string p)
        {
            Decimal Valor;
            if(Decimal.TryParse(p,out Valor))
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
            if(p!=null && p!="")
            {
                return p;
            }
            else
            {
                return "Todos";
            }
        }

        private int? ObtenerCliente(object p)
        {
           if(p!=null)
           {
               return Convert.ToInt32(p);
           }
           else
           {
               return null;
           }
        }

        private int? ObtenerDocumento(string p)
        {
            Int32 Codigo;
            if(Int32.TryParse(p,out Codigo))
            {
                return Convert.ToInt32(p);
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

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpFechaHasta.Value;
        }

       
    }
}
