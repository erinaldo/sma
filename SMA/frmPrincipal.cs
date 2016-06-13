using SMA.Almacenes;
using SMA.Familia;
using SMA.Inventario;
using SMA.Marca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.Factura;
using SMA.Clientes;
using SMA.Compras;
using SMA.Vendedor;
using SMA.BL;
using SMA.Factura.Cotizacion;
using SMA.Factura.Devolucion;
using SMA.Empresa;
using SMA.Compras.Ordenes;
using SMA.Compras.Devoluciones;
using SMA.Usuarios;
using SMA.Entity;

namespace SMA
{
    public partial class frmPrincipal : Office2007Form
    {
        private List<cRolesModulosUsuarios> Permisos;

        #region Constructores
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public frmPrincipal(List<cRolesModulosUsuarios> Permisos):this()
        {
            this.Permisos = Permisos;
        }

        #endregion

        private void GestionAccesos()
        {
            btnFacturacion.Enabled = false;
            btnProveedores.Enabled = false;
            btnCotizacion.Enabled = false;
            btnDevolucionVentas.Enabled = false;
            btnClientes.Enabled = false;
            btnInventario.Enabled = false;
            btnOrden.Enabled = false;
            btnRecepcion.Enabled = false;
            btnDevolucionCompras.Enabled = false;
            btnFamilia.Enabled = false;
            btnMarcas.Enabled = false;
            btnEmpresa.Enabled = false;
            btnVendedores.Enabled = false;
            btnUsuarios.Enabled = false;
            //Gestiona los permisos a los modulos de usuarios 

            //Recorremos la lista de modulos para permitir o no el acceso
            foreach (cRolesModulosUsuarios p in cGlobal.ListaModulosPermisos)
            {
                switch (p.Modulo.ToString())
                {
                    //CLIENTES
                    case "Clientes":
                        btnClientes.Enabled = true;
                        break;
                    //FACTURACION
                    case "Facturas":
                        btnFacturacion.Enabled = true;
                        break;
                    //COTIZACIONES
                    case "Cotizaciones":
                        btnCotizacion.Enabled = true;
                        break;
                    //DEVOLUCIONES EN VENTAS
                    case "Devoluciones Ventas":
                        btnDevolucionVentas.Enabled = true;
                        break;
                    //INVENTARIOS
                    case "Inventarios":
                        btnInventario.Enabled = true;
                        break;
                    //RECEPCION EN COMPRAS
                    case "Recepcion Compras":
                        btnRecepcion.Enabled = true;
                        break;
                    //ORDENES DE COMPRA
                    case "Ordenes Compras":
                        btnOrden.Enabled = true;
                        break;
                    //DEVOLUCIONES EN COMPRAS
                    case "Devoluciones Compras":
                        btnDevolucionCompras.Enabled = true;
                        break;
                    //PROVEEDORES
                    case "Proveedores":
                        btnProveedores.Enabled = true;
                        break;
                    //FAMILIA DE INVENTARIOS
                    case "Familia Inventario":
                        btnFamilia.Enabled = true;
                        break;
                    //MARCA DE INVENTARIOS
                    case "Marcas Inventario":
                        btnMarcas.Enabled = true;
                        break;
                    //VENDEDORES
                    case "Vendedores":
                        btnVendedores.Enabled = true;
                        break;
                    //USUARIOS
                    case "Usuarios":
                        btnUsuarios.Enabled = true;
                        break;
                    //EMPRESA
                    case "Empresa":
                        btnEmpresa.Enabled = true;
                        break;
                }

                //ASIGNAMOS NOMBRE DE USUARIO Y FECHA DE LOGIN
                tssUsuario.Text = p.NombreUsuario.ToString();
                tssFecha.Text = DateTime.Now.ToShortDateString();
                tssHora.Text = DateTime.Now.ToShortTimeString();


            }
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            //SALIR
            this.Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //COMPROBAMOS LA EXISTENCIA DE LA DB, EN CASO QUE NO EXISTA ENTONCES LA CREAMOS
            try
            {
                //ComprobacionDBBL ObjetoComprobacion = new ComprobacionDBBL();
                //ObjetoComprobacion.CrearDB();
                GestionAccesos();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            //MOSTRAMOS LA GESTION DE INVENTARIOS
            frmGestionInventario GestionInventario = new frmGestionInventario();
            GestionInventario.MdiParent = this;
            GestionInventario.Show();
        }

        private void tsbHerramientas_ButtonClick(object sender, EventArgs e)
        {

        }

        //private void btnAlmacenes_Click(object sender, EventArgs e)
        //{
        //    //ALMACENES
        //    frmGestionAlmacenes GestionAlmacenes = new frmGestionAlmacenes();
        //    GestionAlmacenes.MdiParent = this;
        //    GestionAlmacenes.Show();
        //}

        private void btnFamilia_Click(object sender, EventArgs e)
        {
            //FAMILIA DE ARTICULOS
            frmGestionFamilia GestionFamilia = new frmGestionFamilia();
            GestionFamilia.MdiParent = this;
            GestionFamilia.Show();
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            //MARCA DE INVENTARIO
            frmGestionMarca GestionMarca = new frmGestionMarca();
            GestionMarca.MdiParent = this;
            GestionMarca.Show();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            //SALIMOS DE LA APLICACION
            Application.Exit();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            //frmGestionFactura GestionFacturas = new frmGestionFactura();
            //GestionFacturas.MdiParent = this;
            //GestionFacturas.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //GESTION DE CLIENTES
            try
            {
                frmGestionClientes GestionClientes = new frmGestionClientes();
                GestionClientes.MdiParent = this;
                GestionClientes.Show();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message + " No se pudo acceder a la lista de clientes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }
        
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            //GESTION DE PROVEEDORES
            frmGestionProveedores GestionProveedores = new frmGestionProveedores();
            GestionProveedores.MdiParent = this;
            GestionProveedores.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
        //    frmGestionRecepciones GestionRecepcion = new frmGestionRecepciones();
        //    GestionRecepcion.MdiParent = this;
        //    GestionRecepcion.Show();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            //GESTION DE EMPRESAS
            frmGestiomEmpresa GestionEmpresa = new frmGestiomEmpresa();
            GestionEmpresa.ShowDialog();
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            //GESTION DE VENDEDORES
            frmGestionVendedor GestionVendedores = new frmGestionVendedor();
            GestionVendedores.ShowDialog();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            //GESTIOND DE COTIZACIONES
            frmGestionCotizaciones GestionCotizaciones = new frmGestionCotizaciones();
            GestionCotizaciones.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            //GESTION DE FACTURAS
            frmGestionFactura GestionFacturacion = new frmGestionFactura();
            GestionFacturacion.ShowDialog();
        }

        private void btnDevolucionVentas_Click(object sender, EventArgs e)
        {
            //GESTION DE DEVOLUCIONES
            frmGestionDevoluciones GestionDevolucion = new frmGestionDevoluciones();
            GestionDevolucion.ShowDialog();
        }

        private void btnRecepcion_Click(object sender, EventArgs e)
        {
            //GESTION DE RECEPCIONES EN COMPRA
            frmGestionRecepciones GestionRecepciones = new frmGestionRecepciones();
            GestionRecepciones.ShowDialog();
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            //GESTION DE ORDENES DE COMPRA
            frmGestionOrdenesCompra GestionOrdenCompra = new frmGestionOrdenesCompra();
            GestionOrdenCompra.ShowDialog();
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            //GESTION DE DEVOLUCIONES EN COMPRA
            frmGestionDevolucionCompras GestionDevolucion = new frmGestionDevolucionCompras();
            GestionDevolucion.ShowDialog();

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //GESTION DE USUARIOS 
            frmGestionUsuarios GestionUsuarios = new frmGestionUsuarios();
            GestionUsuarios.ShowDialog();
        }
    }
}
 