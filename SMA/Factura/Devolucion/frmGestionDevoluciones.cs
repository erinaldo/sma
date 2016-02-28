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
using SMA.Factura.Reportes;

namespace SMA.Factura.Devolucion
{
    public partial class frmGestionDevoluciones : Office2007Form
    {
        FacturaBL ObjetoFactura = new FacturaBL();
        Int32 FacturaID;

        public frmGestionDevoluciones()
        {
            InitializeComponent();
        }
        #region procedimientos y funciones
        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnVisualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnReportes.Enabled = false;
            try
            {
                //SELECCIONAMOS EL MODULO DE DEVOLUCIONES EN VENTA
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Devoluciones Ventas")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR DEVOLUCIONES
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            break;
                        //CANCELAR DEVOLUCIONES
                        case "Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                         //CONSULTAR DEVOLUCIONES
                        case "Consultar":
                            btnBuscar.Enabled = true;
                            btnRefrescar.Enabled = true;
                            break;
                        case "Imprimir reportes":
                            btnVisualizar.Enabled = true;
                            btnReportes.Enabled = true;
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
            dgvDevoluciones.AutoGenerateColumns = false;
            dgvDevoluciones.DataSource = Resultado;
        }

        private void CargarFacturas()
        {
            try
            {
                FacturaBL ObjetoFactura = new FacturaBL();
                dgvDevoluciones.AutoGenerateColumns = false;
                dgvDevoluciones.DataSource = ObjetoFactura.Listar("D");
                GestionAccesos();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion


        private void frmGestionDevoluciones_Load(object sender, EventArgs e)
        {
            try
            {
                dgvDevoluciones.AutoGenerateColumns = false;
                dgvDevoluciones.DataSource = ObjetoFactura.Listar("D");
                GestionAccesos();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarDevolucion AgregarDevolucion = new frmAgregarDevolucion();
            AgregarDevolucion.ShowDialog(this);
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            //Ver Cotizacion Existente
            frmrptDevolucion ReporteDevolucion = new frmrptDevolucion(FacturaID);
            ReporteDevolucion.ShowDialog(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           //LA CANCELACION DE LA DEVOLUCION SACARA DEL INVENTARIO TODOS LOS ARTICULOS DEVUELTOS
            DialogResult Resultado;

            Resultado = MessageBox.Show("Se cancelara la devolucion, esta sacara de inventario los articulos devueltos, ¿Esta seguro que desea continuar?", "Cancelacion de Devolucion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    FacturaBL ObjetoFactura = new FacturaBL();
                    ObjetoFactura.Cancelar(FacturaID);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error en cancelacion de devolucion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmFiltrarDevolucion FiltrarDevolucion = new frmFiltrarDevolucion(this);
            FiltrarDevolucion.ShowDialog(this);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            //Refrescar grid
            try
            {
                CargarFacturas();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDevoluciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                FacturaID = Convert.ToInt32(dgvDevoluciones.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            
        }

        private void btnResumenDocumentos_Click(object sender, EventArgs e)
        {
            frmParametroResumenFacturas ResumenDevoluciones = new frmParametroResumenFacturas("D");
            ResumenDevoluciones.ShowDialog(this);
        }
    }
}
