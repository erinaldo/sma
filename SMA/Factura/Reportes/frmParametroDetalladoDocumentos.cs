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

namespace SMA.Factura.Reportes
{
    public partial class frmParametroDetalladoDocumentos : Office2007Form
    {
        private String TipoDocumento;
        private DateTime? FechaCreacionDesde;
        private DateTime? FechaCreacionHasta;
        private DateTime? FechaVencimientoDesde;
        private DateTime? FechaVencimientoHasta;

        public frmParametroDetalladoDocumentos()
        {
            InitializeComponent();
        }

        public frmParametroDetalladoDocumentos(String TipoDocumento):this()
        {
            this.TipoDocumento = TipoDocumento;
        }

        private void frmParametroDetalladoDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                //CLIENTES
                ClienteBL ObjetoCliente = new ClienteBL();
                cbbClienteDesde.DataSource = ObjetoCliente.Listar();
                cbbClienteDesde.ValueMember = "ID";
                cbbClienteDesde.DisplayMember = "NombreComercial";
                cbbClienteDesde.SelectedValue = -1;

                cbbClienteHasta.DataSource = ObjetoCliente.Listar();
                cbbClienteHasta.ValueMember = "ID";
                cbbClienteHasta.DisplayMember = "NombreComercial";
                cbbClienteHasta.SelectedValue = -1;

                //VENDEDORES
                VendedorBL ObjetoVendedor = new VendedorBL();
                cbbVendedor.DataSource = ObjetoVendedor.Listar();
                cbbVendedor.ValueMember = "ID";
                cbbVendedor.DisplayMember = "Nombre";
                cbbVendedor.SelectedValue = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                FacturaBL ObjetoFactura = new FacturaBL();
                Int32? DocumentoDesde = ObtenerDocumento(txtDocumentoDesde.Text);
                Int32? DocumentoHasta = ObtenerDocumento(txtDocumentoHasta.Text);
                Int32? ClienteDesde = ObtenerCliente(cbbClienteDesde.SelectedValue);
                Int32? ClienteHasta = ObtenerCliente(cbbClienteHasta.SelectedValue);
                Int32? VendedorID = ObtenerVendedor();
                List<cReporteDetalladoDocumento> Lista = ObjetoFactura.ReporteDetalladoDocumentos(DocumentoDesde, DocumentoHasta, FechaCreacionDesde, FechaCreacionHasta, FechaVencimientoDesde, FechaVencimientoHasta, ClienteDesde, ClienteHasta, TipoDocumento, VendedorID);

                if (TipoDocumento == "F")
                {
                    frmrptDetalladoFactura ResumenFactura = new frmrptDetalladoFactura(Lista);
                    ResumenFactura.ShowDialog(this);
                }
                //else if (TipoDocumento == "D")
                //{
                //    frmrptResumenDevoluciones ResumenDevoluciones = new frmrptResumenDevoluciones(Lista);
                //    ResumenDevoluciones.ShowDialog(this);
                //}
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

        private int? ObtenerVendedor()
        {
            //Obtenemos la familia de articulos
            if (cbbVendedor.Text != String.Empty)
            {
                return Convert.ToInt32(cbbVendedor.SelectedValue.ToString());
            }
            else
            {
                return null;
            }
        }

        private int? ObtenerCliente(object p)
        {
            //Obtenemos el codigo de articulo
            if (p != null)
            {
                return Convert.ToInt32(p.ToString());
            }
            else
            {
                return null;
            }
        }

        private int? ObtenerDocumento(string p)
        {
            //Obtenemos el codigo a partir de un text
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

        private void dtpFechaCreacionDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaCreacionDesde = dtpFechaCreacionDesde.Value;
        }

        private void dtpFechaCreacionHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaCreacionHasta = dtpFechaCreacionHasta.Value;
        }

        private void dtpFechaVencimientoDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaVencimientoDesde = dtpFechaVencimientoDesde.Value;
        }

        private void dtpFechaVencimientoHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaVencimientoHasta = dtpFechaVencimientoHasta.Value;
        }
    }
}
