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

namespace SMA.Inventario
{
    public partial class frmAgregarEditarMovInventario : Office2007Form
    {
        private String TipoMovimiento;
        private Int64 InventarioID;

        public frmAgregarEditarMovInventario()
        {
            InitializeComponent();
        }

        public frmAgregarEditarMovInventario(Int64 InventarioID, String TipoMovimiento):this()
        {
            this.TipoMovimiento = TipoMovimiento;
            this.InventarioID = InventarioID;
        }
        private void frmAgregarEditarMovInventario_Load(object sender, EventArgs e)
        {
            CargarDependencias();
            AsignarValores();
        }

        private void AsignarValores()
        {
            //ASIGNAMOS LOS VALORES DEL ARTICULO SELECCIONADO
            try
            {
                InventarioBL ObjetoInventario = new InventarioBL();
                cInventario Articulo;

                Articulo = ObjetoInventario.BuscarPorID(InventarioID);

                //ASIGNACION
                lblCodigoArticulo.Text = Articulo.CodigoArticulo.ToString();
                lblDescripcionArticulo.Text = Articulo.Descripcion.ToString();
                lblPrecioPublico.Text = Articulo.PrecioPublico.ToString();
                txtCosto.Text = Articulo.UltCosto.ToString();

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CargarDependencias()
        {
            //Objeto Concepto
            ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();

            //Cargamos los controles dependientes para la informacion del movimiento
            try
            {
                

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
                    lblPrecioPublico.Text = Articulo.PrecioPublico.ToString();

                }

                //Valores para el control
                cbConcepto.ValueMember = "ID";
                cbConcepto.DisplayMember = "Descripcion";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            //Determinamos la relacion a partir del concepto
            DeterminarRelacion();
           
        }

       private void DeterminarRelacion()
        {
           
           //Objeto Concepto
            ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();

            //Obtenemos la relacion para determinar si mostramos clientes o proveedores
            Int32 Codigo;
            if (Int32.TryParse(cbConcepto.SelectedValue.ToString(), out Codigo))
            {
                //Buscamos la relacion del concepto
                Codigo = Convert.ToInt32(cbConcepto.SelectedValue.ToString());
                String Relacion = ObjetoConcepto.BuscarPorID(Codigo).Relacion.ToString();

                //Cargamos clientes
                if (Relacion == "C")
                {
                    CargarClientes();
                }
                //Cargamos proveedores
                else if (Relacion == "P")
                {
                    CargarProveedores();
                }

            }
        }

        private void CargarClientes()
        {
            ClienteBL ObjetoCliente = new ClienteBL();
            cbbProveedor.DataSource = ObjetoCliente.Listar();
            cbbProveedor.ValueMember = "ID";
            cbbProveedor.DisplayMember = "NombreComercial";
        }

        private void CargarProveedores()
        {

            ProveedorBL ObjetoProveedor = new ProveedorBL();
            cbbProveedor.DataSource = ObjetoProveedor.Listar();
            cbbProveedor.ValueMember = "ID";
            cbbProveedor.DisplayMember = "NombreComercial";
        }
        private cMovInventario ObtenerDatos()
        {
            try
            {
                //Obtenemos la informacion del movimiento
                cMovInventario Movimiento = new cMovInventario();

                Movimiento.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                Movimiento.ConceptoID = cbConcepto.SelectedValue;
                Movimiento.CliPv = ObtenerClienteProveedor(cbbProveedor.SelectedValue);
                Movimiento.Costo = Convert.ToDecimal(txtCosto.Text);
                Movimiento.Precio = Convert.ToDecimal(lblPrecioPublico.Text);
                Movimiento.Notas = txtNotas.Text;
                Movimiento.Fecha = dtpFecha.Value.Date;
                //Codigo de inventario a realizar el movimiento
                int I = Convert.ToInt32(InventarioID);
                Movimiento.InventarioID = I;
                Movimiento.DocumentoID = txtDocumento.Text;
                Movimiento.ModificarPrecio = ObtenerIndicadorModificarPrecio(ckbModificarPrecio.Checked);
                return Movimiento;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
                return null;
            }
        }

        private object ObtenerClienteProveedor(object p)
        {
            //Obtenemos el codigo del proveedor o cliente segun aplique
            if(p!=null)
            {
                Int32 Codigo;
                if(Int32.TryParse(p.ToString(),out Codigo))
                {
                    return p;
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

        private bool ObtenerIndicadorModificarPrecio(bool p)
        {
            //Retornando el indicador modificar precio
            return p;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Insertamos el movimiento de inventario
                MovInventarioBL ObjetoMovimiento = new MovInventarioBL();
                ObjetoMovimiento.GuardarCambios(ObtenerDatos());
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbConcepto_SelectedValueChanged(object sender, EventArgs e)
        {
            //Determinamos la relacion a partir del concepto seleccionado
            DeterminarRelacion();
        }
    }
}
