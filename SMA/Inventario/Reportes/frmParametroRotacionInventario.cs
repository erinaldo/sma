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

namespace SMA.Inventario.Reportes
{
    public partial class frmParametroRotacionInventario : Office2007Form,IReportes
    {
        DateTime? FechaDesde;
        DateTime? FechaHasta;
        String Reporte;

        public frmParametroRotacionInventario()
        {
            InitializeComponent();
        }

        //Seleccion de reporte 
        public frmParametroRotacionInventario(String Reporte):this()
        {
            this.Reporte = Reporte;
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

        private void frmParametroRotacionInventario_Load(object sender, EventArgs e)
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


            //LISTA DE CONCEPTOS
            //Conceptos
            ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();
            lbConceptos.DataSource = ObjetoConcepto.Listar();
            lbConceptos.DisplayMember = "Descripcion";
            lbConceptos.ValueMember = "ID";

            //SELECCIONAMOS LOS MOVIMIENTOS POR DEFECTO PARA ROTACION
            lbConceptos.SetSelected(0, false);
            lbConceptos.SetSelected(2, true); 
            lbConceptos.SetSelected(5, true);
            lbConceptos.SetSelected(10, true);
            
        }

        private void btnBuscarFamilia_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                String CodigoDesde = ObtenerCodigoDesde();
                String CodigoHasta = ObtenerCodigoHasta();
                Int32? DocumentoDesde = ObtenerDocumento(txtDocumentoDesde.Text);
                Int32? DocumentoHasta = ObtenerDocumento(txtDocumentoHasta.Text);
                Int32? Familia = ObtenerFamilia();
                String Movimiento = ObtenerConceptos();
                MovInventarioBL ObjetoMovimiento = new MovInventarioBL();

                if (Reporte == "Rotacion")
                {
                    
                    List<cReporteRotacionInventario> Lista = ObjetoMovimiento.ReporteRotacionInventario(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento);

                    frmrptRotacionInventario RotacionInventario = new frmrptRotacionInventario(Lista);
                    RotacionInventario.ShowDialog(this);
                }
                else if(Reporte=="UtilidadVentas")
                {
                    List<cReporteUtilidadVentas> Lista = ObjetoMovimiento.ReporteUtilidadVentas(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento);

                    frmrptUtilidadVenta UtilidadVentas = new frmrptUtilidadVenta(Lista);
                    UtilidadVentas.ShowDialog(this);

                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
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


        private Int32? ObtenerDocumento(String Codigo)
        {
            //Obtenemos el resultado de codigo
            if(Codigo!=String.Empty)
            {

                Int32 ID;
                if (Int32.TryParse(Codigo, out ID))
                {
                    return Convert.ToInt32(Codigo);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private string ObtenerCodigoDesde()
        {
            //OBTENEMOS EL CODIGO DE ARTICULO DESDE
            if(cbbCodigoDesde.Text!=String.Empty)
            {
                return cbbCodigoDesde.SelectedValue.ToString();
            }
            else
            {
                return null;
            }
        }

        private string ObtenerCodigoHasta()
        {
            //OBTENEMOS EL CODIGO DE ARTICULO DESDE
            if (cbbCodigoHasta.Text != String.Empty)
            {
                return cbbCodigoHasta.SelectedValue.ToString();
            }
            else
            {
                return null;
            }
        }


        private String ObtenerConceptos()
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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCodigoDesde_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulos = new frmListaArticulos(1);
            ListaArticulos.ShowDialog(this);
        }

        private void btnCodigoHasta_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulos = new frmListaArticulos(2);
            ListaArticulos.ShowDialog(this);
        }

        private void rbEntrada_CheckedChanged(object sender, EventArgs e)
        {                                
            //SELECCIONAMOS LOS MOVIMIENTOS DE ENTRADA
            lbConceptos.ClearSelected();
            if (rbEntrada.Checked)
            {
                Int32 I = lbConceptos.Items.Count;               //Determinamos la cantidad de registros a guardarse en la variable
                Int32 R = 1;                                     //Indicador para almacenar los registros
                Int32[] CatalogoItem = new Int32[I];             //Variable que almacena los item a seleccionar

                //IDENTIFICAMOS LOS ELEMENTOS QUE QUEREMOS SELECCIONAR
                foreach (cConcMovInvent Row in lbConceptos.Items)
                {
                    //Seleccionamos todos los conceptos de Entrada Excepto Inventario Inicial
                    if (Row.Entrada.ToString() == "Entrada" && Row.ID.ToString()!="1")
                    {
                        CatalogoItem[R] = lbConceptos.Items.IndexOf(Row);

                        R = R + 1;
                    }
                }

                for (int E = 1; E < R; E++)
                {
                    lbConceptos.SetSelected(CatalogoItem[E], true);
                }
            }
            

        }

        private void rbSalida_CheckedChanged(object sender, EventArgs e)
        {
            //SELECCIONAMOS TODOS LOS MOVIMIENTOS DE SALIDA
            lbConceptos.ClearSelected();
            if (rbSalida.Checked)
            {
                Int32 I = lbConceptos.Items.Count;               //Determinamos la cantidad de registros a guardarse en la variable
                Int32 R = 1;                                     //Indicador para almacenar los registros
                Int32[] CatalogoItem = new Int32[I];             //Variable que almacena los item a seleccionar

                //IDENTIFICAMOS LOS ELEMENTOS QUE QUEREMOS SELECCIONAR
                foreach (cConcMovInvent Row in lbConceptos.Items)
                {
                    if (Row.Entrada.ToString() == "Salida")
                    {
                        CatalogoItem[R] = lbConceptos.Items.IndexOf(Row);

                        R = R + 1;
                    }
                }

                for (int E = 1; E < R; E++)
                {
                    lbConceptos.SetSelected(CatalogoItem[E], true);
                }
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

      
    }
}
