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

namespace SMA.Factura.Devolucion
{
    public partial class frmFiltrarDevolucion : Office2007Form
    {
        frmGestionDevoluciones GestionDevoluciones;
        DateTime? FechaDesde;
        DateTime? FechaHasta; 

        public frmFiltrarDevolucion()
        {
            InitializeComponent();
        }

        public frmFiltrarDevolucion (frmGestionDevoluciones GestionDevoluciones):this()
        {
            this.GestionDevoluciones = GestionDevoluciones;
        }

        private void frmFiltrarDevolucion_Load(object sender, EventArgs e)
        {
            try
            {
                ClienteBL ObjetoCliente = new ClienteBL();
                cbCliente.DataSource = ObjetoCliente.Listar();
                cbCliente.ValueMember = "ID";
                cbCliente.DisplayMember = "NombreComercial";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al listar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                FacturaBL ObjetoFactura = new FacturaBL();
                Int32? ClienteID = ObtenerCliente(cbCliente.SelectedValue);
               
                Int32? DocumentoDesde = ObtenerDocumento(txtDesde.Text);
                Int32? DocumentoHasta = ObtenerDocumento(txtHasta.Text);
                Boolean IndGenerada = ckbGenerada.Checked;
                Boolean IndCancelada = ckbCancelada.Checked;
                String CriterioCantidad = ObtenerCriterio(cbbCriterio.Text);
                Decimal ValorFactura = ObtenerValor(txtImporte.Text);

                List<cFactura> Lista = ObjetoFactura.FiltrarFactura("D", ClienteID, DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta,IndGenerada,IndCancelada,false,CriterioCantidad,ValorFactura);
                GestionDevoluciones.BuscarFactura(Lista);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private int? ObtenerDocumento(string p)
        {
            Int32 Codigo;
            if (Int32.TryParse(p, out Codigo))
            {
                return Convert.ToInt32(p);
            }
            else
            {
                return null;
            }
        }


        private Decimal  ObtenerValor(string p)
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
            if (p != null && p!="")
            {
                return p;
            }
            else
            {
                return "Todos";
            }
        }


        private Int32? ObtenerCliente(Object P)
        {
            Int32 Codigo;
            if (P != null)
            {
                if (Int32.TryParse(cbCliente.SelectedValue.ToString(), out Codigo))
                {
                    return Convert.ToInt32(cbCliente.SelectedValue.ToString());
                }
                else
                {
                    throw new Exception("Es necesario que indique el cliente");
                }
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
