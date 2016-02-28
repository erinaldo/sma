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
using SMA.Compras.Reportes;
using DevComponents.DotNetBar;

namespace SMA.Compras.Devoluciones
{
    public partial class frmGestionDevolucionCompras : Office2007Form
    {
        private Int64 CompraID;

        public frmGestionDevolucionCompras()
        {
            InitializeComponent();
        }

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
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Devoluciones Compras")
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
        private void frmGestionDevolucionCompras_Load(object sender, EventArgs e)
        {
            CargarCompras();
            GestionAccesos();
        }

        public void BuscarOrdenes(List<cCompras> Resultado)
        {
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.DataSource = Resultado;
        }


        private void CargarCompras()
        {
            ComprasBL ObjetoCompras = new ComprasBL();
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.DataSource = ObjetoCompras.Listar("D");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarDevolucionCompra AgregarDevolucion = new frmAgregarDevolucionCompra();
            AgregarDevolucion.ShowDialog(this);
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            frmrptDevolucionCompra ReporteCompra = new frmrptDevolucionCompra(CompraID);
            ReporteCompra.ShowDialog(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ComprasBL ObjetoCompras = new ComprasBL();
                ObjetoCompras.Cancelar(CompraID);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al tratar de cancelar la recepcion de compras", "Error de cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmFiltrarDevolucionCompra BuscarDevolucion = new frmFiltrarDevolucionCompra(this);
            BuscarDevolucion.ShowDialog(this);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarCompras();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                CompraID = Convert.ToInt64(dgvCompras.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            frmFiltrarDevolucionCompra FiltrarDevolucion = new frmFiltrarDevolucionCompra(this);
            FiltrarDevolucion.ShowDialog(this);
        }

        private void btnResumenDocumentos_Click(object sender, EventArgs e)
        {
            frmParametroResumenCompras ResumenDevoluciones = new frmParametroResumenCompras("D");
            ResumenDevoluciones.ShowDialog(this);
        }

    }
}
