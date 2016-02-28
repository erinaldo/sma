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
    public partial class frmParametroResumenFacturas : Office2007Form,IBusqueda
    {
        private string TipoDocumento; //DETERMINA EL TIPO DE DOCUMENTO

        private DateTime? FechaDesde; //FECHA DE CREACION DOCUMENTO
        private DateTime? FechaHasta; //FECHA DE CREACION DOCUMENTO

        public frmParametroResumenFacturas()
        {
            InitializeComponent();
        }
        public frmParametroResumenFacturas(String TipoDocumento):this()
        {
            this.TipoDocumento = TipoDocumento;
        }

        #region Implementacion de Interfases
        public void SeleccionarDocumentoDesde(Int32 Documento)
        {
            txtDocumentoDesde.Text = Documento.ToString();
        }

        public void SeleccionarDocumentoHasta(Int32 Documento)
        {
            txtDocumentoHasta.Text = Documento.ToString();
        }

        public void SeleccionarClienteDesde(Int32 Codigo)
        {
            cbbClienteDesde.SelectedValue = Codigo;
        }

        public void SeleccionarClienteHasta(Int32 Codigo)
        {
            cbbClienteHasta.SelectedValue = Codigo;
        }
        #endregion

        private void frmParametroResumenFacturas_Load(object sender, EventArgs e)
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

                //FAMILIA ARTICULOS
                FamiliaBL ObjetoFamilia = new FamiliaBL();
                cbbFamilia.DataSource = ObjetoFamilia.Listar();
                cbbFamilia.ValueMember = "ID";
                cbbFamilia.DisplayMember = "Descripcion";
                cbbFamilia.SelectedValue = -1;

                //VENDEDORES
                VendedorBL ObjetoVendedor=new VendedorBL();
                cbbVendedor.DataSource = ObjetoVendedor.Listar();
                cbbVendedor.ValueMember = "ID";
                cbbVendedor.DisplayMember = "Nombre";
                cbbVendedor.SelectedValue = -1;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                FacturaBL ObjetoFactura = new FacturaBL();
                Int64? DocumentoDesde = ObtenerDocumento(txtDocumentoDesde.Text);
                Int64? DocumentoHasta = ObtenerDocumento(txtDocumentoHasta.Text);
                Int32? FamiliaID = ObtenerFamilia();
                Int64? ClienteDesde = ObtenerCliente(cbbClienteDesde.SelectedValue);
                Int64? ClienteHasta = ObtenerCliente(cbbClienteHasta.SelectedValue);
                String TipoArticulo = ObtenerTipoAticulo();
                Int32? VendedorID = ObtenerVendedor();
                List<cReporteResumenFactura> Lista = ObjetoFactura.ResumenFactura(DocumentoDesde, DocumentoHasta, FamiliaID, TipoArticulo, FechaDesde, FechaHasta, ClienteDesde, ClienteHasta,TipoDocumento, VendedorID);

                if (TipoDocumento == "F")
                {
                    frmrptResumenFactura ResumenFactura = new frmrptResumenFactura(Lista);
                    ResumenFactura.ShowDialog(this);
                }
                else if(TipoDocumento=="D")
                {
                    frmrptResumenDevoluciones ResumenDevoluciones = new frmrptResumenDevoluciones(Lista);
                    ResumenDevoluciones.ShowDialog(this);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
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

        private String ObtenerTipoAticulo()
        {

            //Obtenemos el tipo de articulo relacionado
            try
            {
                String Item;
                StringBuilder strCategory = new StringBuilder();
                String Resultado;


                if (ckbTodos.Checked)
                {
                    return "Todos";
                }
                else
                {
                    if (ckbFisicos.Checked)
                    {
                        //strCategory.Append("'");
                        strCategory.Append("F");
                        //strCategory.Append("'");
                        strCategory.Append(",");
                    }

                    if (ckbServicios.Checked)
                    {
                        //strCategory.Append("'");
                        strCategory.Append('S');
                        //strCategory.Append("'");
                        strCategory.Append(",");
                    }

                    if (ckbCombos.Checked)
                    {
                        //strCategory.Append("'");
                        strCategory.Append('C');
                        //strCategory.Append("'");
                        strCategory.Append(",");
                    }
                }




                if (strCategory.ToString() != String.Empty)
                {
                    //Convertimos en una cadena
                    Resultado = strCategory.ToString();
                    //Eliminamos la ultima coma para evitar errores
                    Resultado = Resultado.TrimEnd(new char[] { ',' });
                }
                else
                {
                    Resultado = null;
                }

                return Resultado;
            }
            catch (Exception Ex)
            {
                throw Ex;
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

        private int? ObtenerFamilia()
        {
            //Obtenemos la familia de articulos
            if (cbbFamilia.Text != String.Empty)
            {
                return Convert.ToInt32(cbbFamilia.SelectedValue.ToString());
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
            if(Int32.TryParse(p,out Codigo))
            {
                return Convert.ToInt32(p);
            }
            else
            {
                return null;
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            //Obtenemos la fecha desde
            FechaDesde = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            //Obtenemos la fecha hasta
            FechaHasta = dtpFechaHasta.Value;
        }

        private void btnBuscarDocumentoDesde_Click(object sender, EventArgs e)
        {
            frmListaDocumentos ListaDocumentos = new frmListaDocumentos(TipoDocumento,1);
            ListaDocumentos.ShowDialog(this);
        }

        private void btnBuscarDocumentoHasta_Click(object sender, EventArgs e)
        {
            frmListaDocumentos ListaDocumentos = new frmListaDocumentos(TipoDocumento, 2);
            ListaDocumentos.ShowDialog(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
