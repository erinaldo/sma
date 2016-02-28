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


namespace SMA.Factura.Reportes
{
    public partial class frmParametroArticulosDevueltos : Office2007Form
    {
        DateTime? FechaDesde;
        DateTime? FechaHasta;

        public frmParametroArticulosDevueltos()
        {
            InitializeComponent();
        }

        private void frmParametroArticulosDevueltos_Load(object sender, EventArgs e)
        {
            try
            {
                //CLIENTES
                ClienteBL ObjetoCliente = new ClienteBL();
                cbbCliente.DataSource = ObjetoCliente.Listar();
                cbbCliente.ValueMember = "ID";
                cbbCliente.DisplayMember = "NombreComercial";
                cbbCliente.SelectedValue = -1;

                //INVENTARIO
                InventarioBL ObjetoInventario = new InventarioBL();
                cbbProducto.DataSource = ObjetoInventario.Listar();
                cbbProducto.ValueMember = "CodigoArticulo";
                cbbProducto.DisplayMember = "Descripcion";
                cbbProducto.SelectedValue = -1;

                //FAMILIA
                FamiliaBL ObjetoFamilia = new FamiliaBL();
                cbbFamilia.DataSource = ObjetoFamilia.Listar();
                cbbFamilia.ValueMember = "ID";
                cbbFamilia.DisplayMember = "Descripcion";
                cbbFamilia.SelectedValue = -1;


            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Error al cargar informacion", "Error en carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Int64? CodigoCliente = ObtenerCliente(cbbCliente.SelectedValue);
                String TipoArticulo = ObtenerTipoAticulo();
                Int32? VendedorID = ObtenerVendedor();
                String CodigoArticulo = ObtenerArticulo(cbbProducto.SelectedValue);

                List<cReporteArticulosDevueltos> Lista = ObjetoFactura.ReporteArticulosDevueltos(DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta, CodigoCliente, VendedorID, CodigoArticulo, FamiliaID, TipoArticulo);
                frmrptArticulosDevueltos ArticulosDevueltos = new frmrptArticulosDevueltos(Lista);
                ArticulosDevueltos.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Error al generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private string ObtenerArticulo(object p)
        {
            //Obtenemos el codigo de articulo
            if (p != null)
            {
                return p.ToString();
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
        private Int64? ObtenerCliente(object p)
        {
            //Obtenemos el codigo de articulo
            if (p != null)
            {
                return Convert.ToInt64(p.ToString());
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
        private Int64? ObtenerDocumento(string p)
        {
            //Obtenemos el codigo a partir de un text
            Int64 Codigo;
            if (Int64.TryParse(p, out Codigo))
            {
                return Convert.ToInt64(p);
            }
            else
            {
                return null;
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

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpFechaHasta.Value;
        }

        private void btnBuscarDocumentoDesde_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarDocumentoHasta_Click(object sender, EventArgs e)
        {

        }

    }
}
