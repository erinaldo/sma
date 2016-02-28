using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.Entity;
using SMA.BL;
using DevComponents.DotNetBar;

namespace SMA.Inventario.Reportes
{
    public partial class frmParametroMovimientoInventarios : Office2007Form,IReportes
    {
        DateTime? FechaDesde;
        DateTime? FechaHasta;

        public frmParametroMovimientoInventarios()
        {
            InitializeComponent();
        }

        #region Implementacion de interfase
        public void SeleccionarCliente(Int64 Codigo, Int32 Indicador)
        {
            //No Implementada
        }

        public void SeleccionarCodigoDesde(String Codigo)
        {
            cbbCodigoDesde.SelectedValue = Codigo;
        }

        public void SeleccionarCodigoHasta(String Codigo)
        {
            cbbCodigoHasta.SelectedValue = Codigo;
        }
        #endregion

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpFechaHasta.Value;
        }

        private void frmParametroMovimientoInventarios_Load(object sender, EventArgs e)
        {
            //LISTA DE PRODUCTOS
            InventarioBL ObjetoInventario = new InventarioBL();
            cbbCodigoDesde.DataSource = ObjetoInventario.Listar();
            cbbCodigoHasta.DataSource = ObjetoInventario.Listar();
            cbbCodigoDesde.DisplayMember = "Descripcion";
            cbbCodigoHasta.DisplayMember = "Descripcion";
            cbbCodigoDesde.ValueMember = "CodigoArticulo";
            cbbCodigoHasta.ValueMember = "CodigoArticulo";

            //LISTA DE FAMILIAS
            FamiliaBL ObjetoFamilia = new FamiliaBL();
            cbbFamilia.DataSource = ObjetoFamilia.Listar();
            cbbFamilia.ValueMember = "ID";
            cbbFamilia.DisplayMember = "Descripcion";
            //Valor Inicial
            cbbFamilia.SelectedValue = -1;

            //LISTA DE CLIENTES
            ClienteBL ObjetoCliente = new ClienteBL();
            cbbCliente.DataSource = ObjetoCliente.Listar();
            cbbCliente.ValueMember = "ID";
            cbbCliente.DisplayMember = "NombreComercial";
            //Valor inicial
            cbbCliente.SelectedValue = -1;

            //LISTA DE PROVEEDORES
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            cbbProveedor.DataSource = ObjetoProveedor.Listar();
            cbbProveedor.ValueMember = "ID";
            cbbProveedor.DisplayMember = "NombreComercial";
            //Valor Inicial
            cbbProveedor.SelectedValue = -1;

            //LISTA DE CONCEPTOS
            //Conceptos
            ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();
            lbConceptos.DataSource = ObjetoConcepto.Listar();
            lbConceptos.DisplayMember = "Descripcion";
            lbConceptos.ValueMember = "ID";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Captura de Datos
                String CodigoDesde = ObtenerCodigoDesde();
                String CodigoHasta = ObtenerCodigoHasta();
                Int64? DocumentoDesde = ObtenerDocumentoDesde();
                Int64? DocumentoHasta = ObtenerDocumentoHasta();
                Int32? Familia = ObtenerFamilia();
                String Cliente = ObtenerCliente();
                String Proveedor = ObtenerProveedor();
                String Movimiento = ObtenerConceptos();


                MovInventarioBL ObjetoMovimiento=new MovInventarioBL();
                List<cReporteMovimientoInventario> Lista = ObjetoMovimiento.ReporteMovimientoInventario(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento, Cliente, Proveedor);

                //LLAMAMOS EL REPORTE
                frmrptMovimientosInventarios ReporteMovimiento = new frmrptMovimientosInventarios(Lista);
                ReporteMovimiento.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerConceptos()
        {


            try
            {
                String Item;
                StringBuilder strCategory = new StringBuilder();
                String Resultado;

                //Recorremos los elementos seleccionados
                foreach (int Ind in lbConceptos.SelectedIndices)
                {
                    Item = (lbConceptos.Items[Ind] as cConcMovInvent).Descripcion.ToString();

                    //strCategory.Append("'");
                    strCategory.Append(Item);
                    //strCategory.Append("'");
                    strCategory.Append(",");

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

        private string ObtenerProveedor()
        {
            if(cbbProveedor.Text!=String.Empty)
            {
                return cbbProveedor.Text;
            }
            else
            {
                return null;
            }
        }

        private string ObtenerCliente()
        {
            if(cbbCliente.Text!=String.Empty)
            {
                return cbbCliente.Text;
            }
            else
            {
                return null;
            }
        }

        private int? ObtenerFamilia()
        {
            if(cbbFamilia.Text!=String.Empty)
            {
                return Convert.ToInt32(cbbFamilia.SelectedValue.ToString());
            }
            else
            {
                return null;
            }
        }

        private Nullable<Int64> ObtenerDocumentoHasta()
        {
            Int32 Codigo;
            if (txtDocumentoHasta.Text != String.Empty || Int32.TryParse(txtDocumentoHasta.Text, out Codigo))
            {
                return Convert.ToInt64(txtDocumentoHasta.Text);
            }
            else
            {
                return null;
            }
        }

        private Nullable<Int64> ObtenerDocumentoDesde()
        {
            Int32 Codigo;
            if (txtDocumentoDesde.Text != String.Empty || Int32.TryParse(txtDocumentoDesde.Text,out Codigo) )
            {
                return Convert.ToInt64(txtDocumentoDesde.Text);
            }
            else
            {
                return null;
            }
        }

        private string ObtenerCodigoHasta()
        {
            if(cbbCodigoHasta.Text!=String.Empty)
            {
                return cbbCodigoHasta.SelectedValue.ToString();
            }
            else
            {
                return null;
            }
        }

        private string ObtenerCodigoDesde()
        {
            if(cbbCodigoDesde.Text!=String.Empty)
            {
                return cbbCodigoDesde.SelectedValue.ToString();
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

        private void dtpFechaDesde_Validated(object sender, EventArgs e)
        {
            //ASIGNACION DE FECHA
            FechaDesde = dtpFechaDesde.Value;
        }

        private void btnBuscarDesde_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulos = new frmListaArticulos(1);
            ListaArticulos.ShowDialog(this);
        }

        private void btnBuscarHasta_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulos = new frmListaArticulos(2);
            ListaArticulos.ShowDialog(this);
        }
    }
}
