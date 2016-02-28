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
using SMA.Inventario.Movimientos_Inventario.Conceptos_Movimiento;
using DevComponents.DotNetBar;

namespace SMA.Inventario.Movimientos_Inventario
{
    public partial class frmGestionMovimientoInventario : Office2007Form
    {
        private Int64 InventarioID; //Variable para la busqueda de movimientos
        private Int64 MovimientoID;

        public frmGestionMovimientoInventario()
        {
            InitializeComponent();
        }

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnRefrescar.Enabled = false;
            btnEntrada.Enabled = false;
            btnSalida.Enabled = false;
            btnConceptos.Enabled = false;

            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Movimientos de Inventario")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR ARTICULO
                        case "Entrada de Inventario":
                            btnEntrada.Enabled = true;
                            break;
                        //EDITAR ARTICULO
                        case "Salida de Inventario":
                            btnSalida.Enabled = true;
                            break;
                        //CONSULTAR ARTICULO
                        case "Consultar":
                            btnRefrescar.Enabled = true;
                            btnFiltrar.Enabled = true;
                            break;
                        
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            //DETERMINAMOS SI TIENE ACCESO AL MODULO DE CUENTAS POR COBRAR
            foreach (cRolesModulosUsuarios m in cGlobal.ListaModulosPermisos)
            {
                switch (m.Modulo.ToString())
                {
                    case "Conceptos Mov Inventario":
                        btnConceptos.Enabled = true;
                        break;
                }
            }
        }
    

        public frmGestionMovimientoInventario(Int64 InventarioID): this()
        {
            //Constructor
            this.InventarioID = InventarioID;
        }
        private void frmGestionMovimientoInventario_Load(object sender, EventArgs e)
        {
            //Si existe un valor para la variable entonces mostramos los movimientos
            if(InventarioID!=0)
            {
                try
                {
                    Int64 ID = Convert.ToInt64(InventarioID);
                    CargarMovimientos(ID);
                    CargarDetalleArticulo(ID);
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                GestionAccesos();
                
            }
        }

        private void CargarMovimientos(Int64 ID)
        {
            MovInventarioBL ObjetoMovimiento = new MovInventarioBL();
            dgvMovimientos.AutoGenerateColumns = false;
            dgvMovimientos.DataSource = ObjetoMovimiento.Listar(ID);
        }

        private void CargarDetalleArticulo(Int64 ID)
        {
            InventarioBL ObjetoInventario = new InventarioBL();
            //Articulo seleccionado
            cInventario Articulo = ObjetoInventario.BuscarPorID(ID);
            txtCodigoArticulo.Text = Articulo.CodigoArticulo;
            txtDescripcion.Text = Articulo.Descripcion;
            txtCosto.Text = Articulo.UltCosto.ToString("C2");
            txtPrecio.Text = Articulo.PrecioPublico.ToString("C2");
            lblStockMin.Text = Articulo.StockMin.ToString("N2");
            //Unidades de inventario
            //UnidadInventarioBL ObjetoUnidadInventario = new UnidadInventarioBL();
            //cbUnidadEntrada.DataSource = ObjetoUnidadInventario.Listar();
            //cbUnidadSalida.DataSource = ObjetoUnidadInventario.Listar();
            //cbUnidadEntrada.ValueMember = "ID";
            //cbUnidadSalida.ValueMember = "ID";
            //cbUnidadEntrada.DisplayMember = "Descripcion";
            //cbUnidadSalida.DisplayMember = "Descripcion";
            //cbUnidadEntrada.SelectedValue = Articulo.UnidadEntradaID;
            //cbUnidadSalida.SelectedValue = Articulo.UnidadSalidaID;
            ////Stock y existencia
            //txtStockMaximo.Text = Articulo.StockMax.ToString("N");
            //txtStockMin.Text = Articulo.StockMin.ToString("N");
            txtExistencia.Text = Articulo.Existencia.ToString("N");
            //Titulo de formulario
            this.Text = "Movimiento de inventario para: " + Articulo.Descripcion;
        }

        

    

     

       

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            frmAgregarEditarMovInventario CrearEntrada = new frmAgregarEditarMovInventario(InventarioID, "Entrada");
            CrearEntrada.Text = "Entrada de articulos";
            CrearEntrada.ShowDialog();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            frmAgregarEditarMovInventario CrearSalida = new frmAgregarEditarMovInventario(InventarioID, "Salida");
            CrearSalida.Text = "Salida de Articulo";
            CrearSalida.ShowDialog();
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
        }

        private void btnVer_Click(object sender, EventArgs e)
        {

        }

        private void btnConceptos_Click(object sender, EventArgs e)
        {

            frmGestionConceptosMov GestionConcepto = new frmGestionConceptosMov();
            GestionConcepto.ShowDialog(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                MovimientoID = Convert.ToInt32(dgvMovimientos.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoArticulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {

        }
    }
}
