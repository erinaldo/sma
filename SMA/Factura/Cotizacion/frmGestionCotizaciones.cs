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
using SMA.Factura.Reportes;

namespace SMA.Factura.Cotizacion
{
    public partial class frmGestionCotizaciones : Form
    {
        FacturaBL ObjetoFactura = new FacturaBL();
        Int32 FacturaID;

        #region Constructores
        public frmGestionCotizaciones()
        {
            InitializeComponent();
        }
        #endregion

        #region Funciones y procedimientos

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnVisualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;
         
            try
            {
                //SELECCIONAMOS EL MODULO DE COTIZACIONES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Cotizaciones")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR FACTURA
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            break;
                        //CANCELAR FACTURA
                        case "Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                        case "Consultar":
                            btnBuscar.Enabled = true;
                            btnRefrescar.Enabled = true;
                            break;
                        case "Imprimir reportes":
                            btnVisualizar.Enabled = true;
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        
        }

        public void BuscarFactura(List<cFactura> Resultado)
        {
            FacturaBL ObjetoFactura = new FacturaBL();
            dgvCotizaciones.AutoGenerateColumns = false;
            dgvCotizaciones.DataSource = Resultado;
        }

        private void CargarFacturas()
        {
            try
            {
                FacturaBL ObjetoFactura = new FacturaBL();
                dgvCotizaciones.AutoGenerateColumns = false;
                dgvCotizaciones.DataSource = ObjetoFactura.Listar("C");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Nueva Cotizacion
            frmAgregarCotizacion CrearCotizacion = new frmAgregarCotizacion();
            CrearCotizacion.ShowDialog();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            //Ver Cotizacion Existente
            frmrptCotizacion ReporteCotizacion = new frmrptCotizacion(FacturaID);
            ReporteCotizacion.ShowDialog(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //LA CANCELACION DE LA COTIZACION NO TIENE EFECTO SOBRE EL INVENTARIO
            DialogResult Resultado;

            Resultado = MessageBox.Show("Se cancelara la cotizacion, ¿Esta seguro que desea continuar?", "Cancelacion de Cotizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    FacturaBL ObjetoFactura = new FacturaBL();
                    ObjetoFactura.Cancelar(FacturaID);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error en cancelacion de cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Buscar documento
            frmFiltrarCotizacion BusquedaFacturas = new frmFiltrarCotizacion(this);
            BusquedaFacturas.ShowDialog(this);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            //Refrescar grid
            try
            {
                CargarFacturas();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Cerrar
            this.Close();
        }

        private void frmGestionCotizaciones_Load(object sender, EventArgs e)
        {
            try
            {
                dgvCotizaciones.AutoGenerateColumns = false;
                dgvCotizaciones.DataSource = ObjetoFactura.Listar("C");
                GestionAccesos();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvCotizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                FacturaID = Convert.ToInt32(dgvCotizaciones.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            frmFiltrarCotizacion FiltrarCotizacion = new frmFiltrarCotizacion(this);
            FiltrarCotizacion.ShowDialog(this);
        }

        private void btnDevolucionesPorCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnResumenDocumentos_Click(object sender, EventArgs e)
        {

        }
    }
}
