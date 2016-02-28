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


namespace SMA.Inventario.Movimientos_Inventario
{
    public partial class frmCrearMovimientoInventario : Office2007Form
    {
        private int? InventarioID = null; //Codigo de articulo
        private string TipoMovimiento;  //Tipo de movimiento

        public frmCrearMovimientoInventario()
        {
            InitializeComponent();
        }

        public frmCrearMovimientoInventario(int InventarioID,string TipoMovimiento): this()
        {
            this.InventarioID = InventarioID;
            this.TipoMovimiento = TipoMovimiento;
        }
        private void frmCrearMovimientoInventario_Load(object sender, EventArgs e)
        {
            CargarDependencias();

        }

 
        private void CargarDependencias()
        {
            try
            {
                 ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();

                 if (TipoMovimiento == "Entrada")
                 {
                     //Concepto Entrada
                     cbConcepto.DataSource = ObjetoConcepto.ListarConceptoEntrada();
                 }
                 else if (TipoMovimiento == "Salida")
                 {
                     //Concepto Salida
                     cbConcepto.DataSource = ObjetoConcepto.ListarConceptoSalida();

                     //Costo y precio prublico
                     InventarioBL ObjetoInventario = new InventarioBL();
                     int I = Convert.ToInt32(InventarioID);
                     cInventario Articulo = ObjetoInventario.BuscarPorID(I);
                     txtCosto.Text = Articulo.UltCosto.ToString();
                     txtPrecio.Text = Articulo.PrecioPublico.ToString();

                 }

                //Valores para el control
                cbConcepto.ValueMember = "ID";
                cbConcepto.DisplayMember = "Descripcion";

                //Lista de Almacenes
                AlmacenBL ObjetoAlmacen = new AlmacenBL();
                cbAlmacen.DataSource = ObjetoAlmacen.Listar();
                cbAlmacen.ValueMember = "ID";
                cbAlmacen.DisplayMember = "Nombre";

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private Decimal CantidadSalida(Int64 InventarioID, int AlmacenID)
        {
            //Arroja la cantidad disponible en el almacen en el cuadro de texto
            return ExistenciaAlmacen(InventarioID, AlmacenID);
        }

        private Decimal ExistenciaAlmacen(Int64 InventarioID, int AlmacenID)
        {
            //Extrae la existencia del articulo en el almacen seleccionado
            try
            {
                RelacionAlmacenBL ObjetoRelacionAlmacen = new RelacionAlmacenBL();
                Decimal I=ObjetoRelacionAlmacen.ExistenciaAlmacen(InventarioID, AlmacenID);

                if(I>0)
                {
                    return I;
                }
                else
                {
                  throw new Exception("El almacen seleccionado no contiene el articulo de inventario");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return 0;
            }
        }
    private void cbConcepto_SelectedValueChanged(object sender, EventArgs e)
    {
        //int ID = Convert.ToInt32(cbConcepto.SelectedValue);
       //txtTipoConcepto.Text = TipoMovimiento(ID);
    }



    //    private cMovInventario ObtenerDatos()
    //{
    //    //try
    //    //{
    //    //    //Obtenemos la informacion del movimiento
    //    //    cMovInventario Movimiento = new cMovInventario();

    //    //    Movimiento.Cantidad = Convert.ToDouble(txtCantidad.Text);
    //    //    Movimiento.ConceptoID = cbConcepto.SelectedValue;
    //    //    //Si el movimiento es de entrada entonces guardamos el almacen de destino a donde va dirigido
    //    //    if (TipoMovimiento == "Entrada")
    //    //    {
    //    //        Movimiento.AlmacenDestinoID = cbAlmacen.SelectedValue;
    //    //    }
    //    //    else
    //    //    //Si el movimiento es de salida entonces determinamos el almacen de origen
    //    //    {
    //    //        Movimiento.AlmacenOrigenID = cbAlmacen.SelectedValue;
    //    //    }
    //    //    Movimiento.Costo = Convert.ToDouble(txtCosto.Text);
    //    //    Movimiento.Precio = Convert.ToDouble(txtPrecio.Text);
    //    //    Movimiento.Notas = txtNotas.Text;
    //    //    Movimiento.Fecha = dtpFecha.Value.Date;
    //    //    //Codigo de inventario a realizar el movimiento
    //    //    int I = Convert.ToInt32(InventarioID);
    //    //    Movimiento.InventarioID = I;
    //    //    Movimiento.DocumentoID = txtDocumento.Text;

    //    //    return Movimiento;
    //    //}
    //    //    catch(Exception Ex)
    //    //{
            
    //    //    MessageBox.Show(Ex.Message);
    //    //    return null;
    //    //}
    //}

 

    private void cbAlmacen_SelectedValueChanged(object sender, EventArgs e)
    {
        //Si el movimiento es de salida, entonces seleccionamos la existencia disponible en el almacen seleccionado
        if  (TipoMovimiento == "Salida")

        {
            //Codigo de Almacen
            int AlmacenID;                                     
            string Almacen=cbAlmacen.SelectedValue.ToString();

            if (int.TryParse(Almacen, out AlmacenID)) //Validacion numerica
            {
                AlmacenID = Convert.ToInt32(Almacen);
                Int64 _InventarioID = (Int64)InventarioID;
                Decimal Cantidad=CantidadSalida(_InventarioID, AlmacenID);

                //Si la cantidad es mayor a 0 entonces mostramos la cantidad y habilitamos 
                if (Cantidad>0) 

                {
                    txtCantidad.Text = Cantidad.ToString();
                    btnAceptar.Enabled=true;
                }
                else
                {
                    //En caso de que sea mejor a 0 ó menor entonces indicamos el error y deshabilitamos el boton de aceptar para evitar errores
                    MessageBox.Show("Error no posee la cantidad seleccionada en el almacen","Error en seleccion de almacen",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtCantidad.Text="0";
                    btnAceptar.Enabled = false;
                }
            }         
           
        }
        else
        {
            txtCantidad.Text = "";
        }
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    //Insertamos el movimiento de inventario
        //    MovInventarioBL ObjetoMovimiento = new MovInventarioBL();
        //    ObjetoMovimiento.GuardarCambios(ObtenerDatos());
        //    this.Close();
        //}
        //catch (Exception Ex)
        //{
        //    MessageBox.Show(Ex.Message);
        //}
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    }


}
