using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.Entity;
using SMA.BL;

namespace SMA.Inventario
{
    public partial class frmCambioPrecioInventario : Office2007Form,IGeneral
    {
        private frmGestionInventario GestionInventario=new frmGestionInventario();
        DateTime? FechaDesde;
        DateTime? FechaHasta;

        public  frmCambioPrecioInventario()
        {
            InitializeComponent();
        }

        #region Implementacion de Interfase
        //SELECCION DE RANGO DE ARTICULOS
        public void SeleccionarArticulo(String Codigo, Int16 Indicador)
        {
            if(Indicador==1)
            {
                //Codigo desde
                cbbArticuloDesde.SelectedValue = Codigo;
            }
            else
            {
                //Codigo Hasta
                cbbArticuloHasta.SelectedValue = Codigo;
            }
        }

        //SELECCION DE FAMILIA
        public void SeleccionarFamilia(Int32 Codigo)
        {
            cbFamilia.SelectedValue = Codigo;
        }


        //SELECCION DE MARCA
        public void SeleccionarMarca(Int32 Codigo)
        {
            cbMarca.SelectedValue = Codigo;
        }
        #endregion
        public frmCambioPrecioInventario(frmGestionInventario GestionInventario): this()
        {
            this.GestionInventario = GestionInventario;
        }

        private void frmCambioPrecioInventario_Load(object sender, EventArgs e)
        {
            CargarDependencias();
        }

        private void CargarDependencias()
        {
            try
            {
                //ARTICULOS
                InventarioBL ObjetoInventario = new InventarioBL();
                cbbArticuloDesde.DataSource = ObjetoInventario.Listar();
                cbbArticuloDesde.ValueMember = "CodigoArticulo";
                cbbArticuloDesde.DisplayMember = "Descripcion";

                cbbArticuloHasta.DataSource = ObjetoInventario.Listar();
                cbbArticuloHasta.ValueMember = "CodigoArticulo";
                cbbArticuloHasta.DisplayMember = "Descripcion";

                //FAMILIA
                FamiliaBL ObjetoFamilia = new FamiliaBL();
                cbFamilia.DataSource = ObjetoFamilia.Listar();
                cbFamilia.ValueMember = "ID";
                cbFamilia.DisplayMember = "Descripcion";
                cbFamilia.SelectedValue = -1;

                //MARCA
                MarcaBL ObjetoMarca = new MarcaBL();
                cbMarca.DataSource = ObjetoMarca.Listar();
                cbMarca.ValueMember = "ID";
                cbMarca.DisplayMember = "Descripcion";
                cbMarca.SelectedValue = -1;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void rbPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            try
            {
                Int32 IndPrecioPublico = ObtenerIndicador(ckbPrecio1.Checked);
                Int32 IndPrecio2 = ObtenerIndicador(ckbPrecio2.Checked);
                Int32 IndPrecio3 = ObtenerIndicador(ckbPrecio3.Checked);
                Int32 IndPrecio4 = ObtenerIndicador(ckbPrecio4.Checked);
                Int32 IndPorcentaje = ObtenerIndicador(rdbPorcentaje.Checked);
                Int32 IndPorCosto = ObtenerIndicador(ckbPrecioPartirCosto.Checked);
                Int32 IndPorUltimoCosto = ObtenerIndicador(rdbUltimoCosto.Checked);
                Int32 IndCostoPromedio = ObtenerIndicador(rdbCostoPromedio.Checked);
                Int32 IndMonto = ObtenerIndicador(rdbMonto.Checked);
                // Double Porcentaje;
                Decimal Monto = ObtenerMonto(txtPorcentajeMonto.Text);
                Int32? FamiliaID = ObtenerDependencia(cbFamilia.SelectedValue);
                Int32? MarcaID = ObtenerDependencia(cbMarca.SelectedValue);
                String TipoProducto = ObtenerTipoAticulo();
                String CodigoArticuloDesde = ObtenerCodigo(cbbArticuloDesde.SelectedValue);
                String CodigoArticuloHasta = ObtenerCodigo(cbbArticuloHasta.SelectedValue);

                InventarioBL ObjetoInventario = new InventarioBL();
                ObjetoInventario.ActualizarPrecios(IndPrecioPublico, IndPrecio2, IndPrecio3, IndPrecio4, IndPorcentaje, IndPorCosto, IndPorUltimoCosto, IndCostoPromedio, IndMonto, Monto, FamiliaID, MarcaID, TipoProducto, FechaDesde, FechaHasta, CodigoArticuloDesde, CodigoArticuloHasta);
                GestionInventario.Actualizar();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error en actualizacion de precios", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //SELECCIONAMOS EL INDICADOR DE ERROR
                if(Ex.Message=="Debe Seleccionar al menos un precio a actualizar")
                {
                    errorProvider1.SetError(gbPrecios, "Debe Especificar que precio va a ser actualizado");
                }
                else if(Ex.Message=="Debe seleccionar al menos un costo como parametro")
                {
                    errorProvider1.SetError(gpbApartirDelCosto, "Debe especificar a partir de cual costo ser hara la actualizacion");
                }
                else if(Ex.Message=="Debe indicador un metodo de actualizacion de precio" || Ex.Message=="Debe especificar un monto")
                {
                    errorProvider1.SetError(gpbPorcentajeMonto, "Debe indicador un metodo de actualizacion de precio");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
            
        }

        private string ObtenerCodigo(object p)
        {
            //Obtenemos el codigo de articulo
            if(p!=null)
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
        
                //String Item;
                StringBuilder strCategory = new StringBuilder();
                String Resultado;


                if (ckbFisico.Checked)
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
          

        private int? ObtenerDependencia(object p)
        {
            //Obtenemos la dependencia en valores numericos
         if(p!=null)
         {
             return Convert.ToInt32(p.ToString());
         }
         else
         {
             return null;
         }
        }

        private Decimal ObtenerMonto(string p)
        {
            //Obtenemos el monto o porcentaje solicitado para el cambio de precio
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

        private int ObtenerIndicador(bool p)
        {
            //Obtenemos el indicador dependiendo del valor enviado
            if(p==true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
            
        

        private Boolean ValidacionCampos()
        {
            //Validamos campos necesarios
            if(ValidacionPrecios() && ValidacionCostos() && ValidacionTipoArticulos() && ValidacionMontosPorcentajes())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean ValidacionPrecios()
        {
            //Validacion de precios
            if (ckbPrecio1.Checked == false && ckbPrecio2.Checked == false && ckbPrecio3.Checked == false && ckbPrecio4.Checked == false)
            {
                errorProvider1.SetError(gbPrecios, "Debe Especificar que precio va a ser actualizado");
                return false;
            }
            else
            {
                errorProvider1.Clear();
                return true;
            }
        }

        private Boolean ValidacionCostos()
        {
            //Validacion de Campos de costos
            if (ckbPrecioPartirCosto.Checked && (rdbCostoPromedio.Checked == false && rdbUltimoCosto.Checked == false))
            {
                errorProvider1.SetError(gpbApartirDelCosto, "Debe especificar a partir de cual costo ser hara la actualizacion");
                return false;
            }
            else
            {
                errorProvider1.Clear();
                return true;
            }
        }

        private Boolean ValidacionTipoArticulos()
        {
            //Validacion de tipo de productos
            if (ckbFisico.Checked == false && ckbServicios.Checked == false && ckbCombos.Checked == false)
            {
                errorProvider1.SetError(gbTipoArticulo, "Debe especificar cuales productos seran actualizados");
                return false;
            }
            else
            {
                errorProvider1.Clear();
                return true;
            }
        }

        private Boolean ValidacionMontosPorcentajes()
        {
            //Validacion de opciones de costos
            if ((rdbPorcentaje.Checked || rdbMonto.Checked) && (txtPorcentajeMonto.Text == "" || txtPorcentajeMonto.Text == String.Empty))
            {
                errorProvider1.SetError(gpbPorcentajeMonto, "Debe especificar un valor de monto o porcentaje");
                return false;
            }
            else
            {
                errorProvider1.Clear();
                return true;
            }
        }
        private void ObtenerDatos()
        {

        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpDesde.Value;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpHasta.Value;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulos = new frmListaArticulos(1);
            ListaArticulos.ShowDialog(this);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            frmListaArticulos ListaArticulos = new frmListaArticulos(2);
            ListaArticulos.ShowDialog(this);
        }

        private void btnSeleccionLinea_Click(object sender, EventArgs e)
        {
            frmListarComponentes ListaFamilia = new frmListarComponentes("Familia");
            ListaFamilia.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmListarComponentes ListaMarcas = new frmListarComponentes("Marca");
            ListaMarcas.ShowDialog(this);
        }

        private void ckbPrecioPartirCosto_CheckedChanged(object sender, EventArgs e)
        {
            //Activa y desactiva los indicadores de costos
            if(ckbPrecioPartirCosto.Checked)
            {
                rdbCostoPromedio.Enabled = true;
                rdbUltimoCosto.Enabled = true;
            }
            else
            {
                rdbUltimoCosto.Enabled = false;
                rdbCostoPromedio.Enabled = false;
            }
        }
    }
}
