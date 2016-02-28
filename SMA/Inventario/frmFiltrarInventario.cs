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

namespace SMA.Inventario
{
                                              
    public partial class frmFiltrarInventario : Office2007Form, IGeneral
    {
        private frmGestionInventario GestionInventario;
        DateTime? FechaDesde;
        DateTime? FechaHasta;
        


        public frmFiltrarInventario()
        {
            InitializeComponent();
        }
        public frmFiltrarInventario(frmGestionInventario GestionInventario): this()
        {
            this.GestionInventario = GestionInventario;
        }

        #region Implementacion de Interfase
        //SELECCION DE RANGO DE ARTICULOS
        public void SeleccionarArticulo(String Codigo, Int16 Indicador)
        {
            if (Indicador == 1)
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

        private void frmFiltrarInventario_Load(object sender, EventArgs e)
        {
            CargarDependencias();
        }

        private void CargarDependencias()
        {
            //Cargar Familia
            FamiliaBL ObjetoFamilia = new FamiliaBL();
            cbFamilia.DataSource = ObjetoFamilia.Listar();
            cbFamilia.ValueMember = "ID";
            cbFamilia.DisplayMember = "Descripcion";
            //Inicializamos el control
            cbFamilia.SelectedValue = -1;


            //Cargar Marca
            MarcaBL ObjetoMarca = new MarcaBL();
            cbMarca.DataSource = ObjetoMarca.Listar();
            cbMarca.ValueMember = "ID";
            cbMarca.DisplayMember = "Descripcion";
            //Inicializamos el control
            cbMarca.SelectedValue = -1;

            //Carga articulos
            InventarioBL ObjetoInventario = new InventarioBL();
            cbbArticuloDesde.DataSource = ObjetoInventario.Listar();
            cbbArticuloDesde.DisplayMember = "Descripcion";
            cbbArticuloDesde.ValueMember = "CodigoArticulo";
            cbbArticuloDesde.SelectedValue = -1;

            cbbArticuloHasta.DataSource = ObjetoInventario.Listar();
            cbbArticuloHasta.DisplayMember = "Descripcion";
            cbbArticuloHasta.ValueMember = "CodigoArticulo";
            cbbArticuloHasta.SelectedValue = -1;

            ////Cargar estatus
            //EstatusBL ObjetoEstatus = new EstatusBL();
            //cbEstatus.DataSource = ObjetoEstatus.Listar();
            //cbEstatus.ValueMember = "ID";
            //cbEstatus.DisplayMember="Descripcion";

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void txtExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            try
            {
            string CodigoDesde=ObtenerCodigo(cbbArticuloDesde.SelectedValue);
            string CodigoHasta=ObtenerCodigo(cbbArticuloHasta.SelectedValue);
            Int32? FamiliaID=ObtenerComponente(cbFamilia.SelectedValue);
            Int32? MarcaID=ObtenerComponente(cbMarca.SelectedValue);
            String TipoArticulo=ObtenerTipo(cbTipo.SelectedItem);
            Int32? IndicadorCreacion=ObtenerIndicador(rbFechaCreacion.Checked);
            Int32? IndicadorModificacion=ObtenerIndicador(rbFechaModificacion.Checked);
            
            String CriterioCantidad=ObtenerCriterio(cbCriterio.Text);
            Decimal Cantidad=ObtenerMonto(txtExistencia.Text);
            String Descripcion = ObtenerDescripcion(txtDescripcion.Text);

           
                
                InventarioBL ObjetoInventario = new InventarioBL();
                //Llama al procedimiento en la interfase que adiciona un articulo a un combo

                List<cInventario> Resultado = ObjetoInventario.Filtrar(CodigoDesde,
                                                                         CodigoHasta,
                                                                         FamiliaID,
                                                                         MarcaID,
                                                                         TipoArticulo,
                                                                         IndicadorCreacion,
                                                                         IndicadorModificacion,
                                                                         FechaDesde,
                                                                         FechaHasta,
                                                                         CriterioCantidad,
                                                                         Cantidad,
                                                                         Descripcion);

               GestionInventario.Filtrar(Resultado);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private string ObtenerDescripcion(string p)
        {
            if(p!=String.Empty)
            {
                return p;
            }
            else
            {
                return null;
            }
        }

        private string ObtenerTipo(object p)
        {
            if(p!=null)
            {
                return p.ToString();
            }
            else
            {
                return "F";
            }
        }

        private string ObtenerCriterio(string p)
        {
            //Obtenemos el criterio a aplicarse a la existencia
            if(p!=String.Empty)
            {
                return p;
            }
            else
            {
                return "Todos";
            }
        }

        private Decimal ObtenerMonto(string p)
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

        private int? ObtenerIndicador(bool p)
        {
            if(p==true)
            {
                return 1;
            }
            else
            {
                return null;
            }
        }

        private int? ObtenerComponente(object p)
        {
            Int32 Codigo;
            if (p != null)
            {
                if (Int32.TryParse(p.ToString(), out Codigo))
                {
                    return Convert.ToInt32(p.ToString());
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

        private string ObtenerCodigo(object p)
        {
            //Obtenemos el codigo del articulo
            if(p!=null)
            {
                return Convert.ToString(p);
            }
            else
            {
                return null;
            }
        }
        
        

        //private void ObtenerDatos()
        //{
        //    //CODIGOS DE ARTICULOS
        //    CodigoDesde = txtCodigoDesde.Text;
        //    CodigoHasta = txtCodigoHasta.Text;

        //    //FAMILIA DE ARTICULOS
        //    if (cbFamilia.SelectedValue != null)
        //    {
        //        FamiliaID = (Int32)cbFamilia.SelectedValue;
        //    }
        //    else
        //    {
        //        FamiliaID = -1;
        //    }

        //    //MARCA DE ARTICULOS
        //    if (cbMarca.SelectedValue != null)
        //    {
        //        MarcaID = (Int32)cbMarca.SelectedValue;
        //    }
        //    else
        //    {
        //        MarcaID = -1;
        //    }

        //    //TIPO DE ARTICULO
        //    if (cbTipo.Text !="")
        //    {
        //        TipoArticulo = cbTipo.SelectedItem.ToString().Substring(0, 1);
        //    }
        //    else
        //    {
        //        TipoArticulo = "";
        //    }
            
        //    //INDICADOR FECHA DE CREACION
        //    if(rbFechaCreacion.Checked)
        //    {
        //        IndicadorCreacion = 1;
        //    }
        //    else
        //    {
        //        IndicadorCreacion = -1;
        //    }

        //    //INDICADOR FECHA MODIFICACION
        //    if(rbFechaModificacion.Checked)
        //    {
        //        IndicadorModificacion = 1;
        //    }
        //    else
        //    {
        //        IndicadorModificacion = -1;
        //    }

        //    //FECHAS 
        //    FechaDesde = dtpFechaDesde.Value.Date;
        //    FechaHasta = dtpFechaHasta.Value.Date;

        //    //CRITERIOS DE CANTIDAD
        //    CriterioCantidad = cbCriterio.Text;

        //    //CANTIDAD EN EXISTENCIA
        //    if (txtExistencia.Text != string.Empty)
        //    {
        //        Cantidad = Convert.ToDouble(txtExistencia.Text);
        //    }

        //    //DESCRIPCION DE ARTICULOS
        //    Descripcion = txtDescripcion.Text;
        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnArticulosDesde_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulos = new frmListaArticulos(1);
            ListaArticulos.ShowDialog(this);
        }

        private void btnArticulosHasta_Click(object sender, EventArgs e)
        {
            frmListaArticulos ListaArticulos = new frmListaArticulos(2);
            ListaArticulos.ShowDialog(this);
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpFechaDesde.Value.Date;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpFechaHasta.Value.Date;
        }
    }
}
