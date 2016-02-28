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
using SMA.Inventario.Movimientos_Inventario;
using DevComponents.DotNetBar;
using SMA.Inventario.Reportes;

namespace SMA.Inventario
{
    public partial class frmGestionInventario : Office2007Form
    {
        private Int64 InventarioID;
        InventarioBL ObjetoInventario = new InventarioBL();
        private frmGestionInventario Instancia;


        public frmGestionInventario()
        {
            InitializeComponent();
            Instancia = this;
        }

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnBuscar.Enabled = false;
            btnCambioPrecio.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;
            btnFiltrar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnKardex.Enabled = false;
            btnReportes.Enabled = false;

            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Inventarios")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR ARTICULO
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            break;
                        //EDITAR ARTICULO
                        case "Editar":
                            btnEditar.Enabled = true;
                            break;
                        //CONSULTAR ARTICULO
                        case "Consultar":
                            btnRefrescar.Enabled = true;
                            btnBuscar.Enabled = true;
                            btnFiltrar.Enabled = true;
                            break;
                        //ELIMINAR ARTICULO
                        case"Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                        //CAMBIO DE PRECIOS ARTICULOS
                        case"Cambio de Precios":
                            btnCambioPrecio.Enabled = true;
                            break;
                        //CONSULTA IMPRESION DE REPORTES
                        case "Imprimir reportes":
                            btnReportes.Enabled = true;
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
                    case "Movimientos de Inventario":
                        btnKardex.Enabled = true;
                        break;
                }
            }
        }
    
        public void Filtrar(List<cInventario> ListaFiltrada)
        {
            BindingSource BDInventario = new BindingSource();
            BDInventario.DataSource = ListaFiltrada;

            //Realizamos la busqueda deendiendo del critrio
            dgvInventario.AutoGenerateColumns = false;
            dgvInventario.DataSource = BDInventario;
        }
        

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            //Cerrar formulario
            this.Close();
        }

     
     

        private void frmGestionInventario_Load(object sender, EventArgs e)
        {

            
            try
            {
                InventarioBL ObjetoInventario = new InventarioBL();
                dgvInventario.AutoGenerateColumns = false;
                dgvInventario.DataSource = ObjetoInventario.Listar();
                GestionAccesos();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }

      

        private void tsbKardex_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvInventario_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void Buscar(string Busqueda)
        {
            InventarioBL ObjetoInventario = new InventarioBL();
            BindingSource BDInventario = new BindingSource();
            BDInventario.DataSource = ObjetoInventario.Listar();

            //Realizamos la busqueda deendiendo del critrio
            dgvInventario.AutoGenerateColumns = false;
            dgvInventario.DataSource = BDInventario;

            //Busqueda por codigo
                string Codigo = Busqueda;
                var obj = BDInventario.List.OfType<cInventario>().ToList().Find(f => f.CodigoArticulo == Codigo);
                var pos = BDInventario.IndexOf(obj);
                BDInventario.Position = pos;
        }
       

        public void Actualizar()
        {
            //Actualiza los cambios realizados en el inventario
            dgvInventario.DataSource = ObjetoInventario.Listar();
        }

        private void tsRefrescar_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

           
        }

        private void ribbonBar3_ItemClick(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAgregarEditarInventario AgregarInventario = new frmAgregarEditarInventario(this);
                AgregarInventario.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarArticulo();
        }

        private void EditarArticulo()
        {
            frmAgregarEditarInventario EditarInventario = new frmAgregarEditarInventario(InventarioID, this);
            EditarInventario.ShowDialog(this);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            try
            {
                InventarioBL ObjetoInventario = new InventarioBL();
                DialogResult Resultado = (MessageBox.Show("Se va a eliminar el articulo del registro de inventario, ¿Desea continuar?", "Eliminar articulo de inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (Resultado == DialogResult.Yes)
                {
                    ObjetoInventario.Eliminar(InventarioID);
                    Actualizar();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al eliminar articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            frmFiltrarInventario FiltrarInventario = new frmFiltrarInventario(this);
            FiltrarInventario.ShowDialog(this);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            frmGestionMovimientoInventario GestionInventario = new frmGestionMovimientoInventario(InventarioID);
            GestionInventario.ShowDialog(this);
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                InventarioID = Convert.ToInt64(dgvInventario.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvInventario_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                InventarioID = Convert.ToInt32(dgvInventario.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            txtBusqueda.Visible = true;
            btnEjecutarBusqueda.Visible = true;
        }

        private void btnEjecutarBusqueda_Click(object sender, EventArgs e)
        {
           Buscar(txtBusqueda.Text);
        }

        private void btnCambioPrecio_Click(object sender, EventArgs e)
        {
            frmCambioPrecioInventario CambioDePrecio = new frmCambioPrecioInventario();
            CambioDePrecio.Show(this);
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
           

        private void btnCosto_Click(object sender, EventArgs e)
        {
            frmParametrosCostoInventario ParametrosLista = new frmParametrosCostoInventario();
            ParametrosLista.ShowDialog();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            frmParametroCatalogoProductos CatalogoProductos = new frmParametroCatalogoProductos();
            CatalogoProductos.ShowDialog(this);
        }

        private void btnListaPrecios_Click(object sender, EventArgs e)
        {
            frmParametroListaPrecios ListaPrecio = new frmParametroListaPrecios();
            ListaPrecio.ShowDialog(this);
        }

        private void btnCostoInventario_Click(object sender, EventArgs e)
        {
            frmParametrosCostoInventario CostoInventario = new frmParametrosCostoInventario();
            CostoInventario.ShowDialog(this);
        }

        private void btnInventarioFisico_Click(object sender, EventArgs e)
        {
            frmParametroInventarioFisico InventarioFisico = new frmParametroInventarioFisico();
            InventarioFisico.ShowDialog(this);
        }

        private void btnMovInventario_Click(object sender, EventArgs e)
        {
            frmParametroMovimientoInventarios ParametroMovimiento = new frmParametroMovimientoInventarios();
            ParametroMovimiento.ShowDialog(this);
        }

        private void btnReporteKardex_Click(object sender, EventArgs e)
        {
            frmParametroKardex KardexInventario = new frmParametroKardex();
            KardexInventario.ShowDialog(this);
        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarArticulo();
        }

        private void btnRotacionInventario_Click(object sender, EventArgs e)
        {
            frmParametroRotacionInventario RotacionInventario = new frmParametroRotacionInventario("Rotacion");
            RotacionInventario.ShowDialog(this);
        }

        private void btnVentasUtilidades_Click(object sender, EventArgs e)
        {
            frmParametroRotacionInventario RotacionInventario = new frmParametroRotacionInventario("UtilidadVentas");
            RotacionInventario.Text = "Utilidad y Ventas Inventario";
            RotacionInventario.ShowDialog(this);
        }

        private void btnVentasPorCliente_Click(object sender, EventArgs e)
        {
            frmParametroVentasPorCliente VentasPorCliente = new frmParametroVentasPorCliente("Cliente");
            VentasPorCliente.ShowDialog(this);
        }

        private void btnComprasPorProveedor_Click(object sender, EventArgs e)
        {
            frmParametroVentasPorCliente ComprasPorProveedor = new frmParametroVentasPorCliente("Proveedor");
            ComprasPorProveedor.Text = "Compras por proveedor";
            ComprasPorProveedor.ShowDialog(this);
        }

        private void btnHistoricoExistencia_Click(object sender, EventArgs e)
        {
            frmParametroHistoricoExistencia HistoricoExistencia = new frmParametroHistoricoExistencia();
            HistoricoExistencia.ShowDialog(this);
        }

        private void btnProductoObsoletos_Click(object sender, EventArgs e)
        {
            frmParametroProductosObsoletos ProductoObsoleto = new frmParametroProductosObsoletos();
            ProductoObsoleto.ShowDialog(this);
        }

        private void btnProductosVencidos_Click(object sender, EventArgs e)
        {
            frmParametroProductosVencidos ProductosVencidos = new frmParametroProductosVencidos();
            ProductosVencidos.ShowDialog(this);
        }


        
    }
}
