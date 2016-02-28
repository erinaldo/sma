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
using SMA.Compras.Reportes;

namespace SMA.Compras
{
    public partial class frmGestionRecepciones : Form
    {
        private Int64 CompraID;

        public frmGestionRecepciones()
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
                                                                where C.Modulo.Contains("Recepcion Compras")
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

        private void frmGestionRecepciones_Load(object sender, EventArgs e)
        {
            CargarCompras();
            GestionAccesos();
        }

        private void CargarCompras()
        {
            //Cargamos todas las recepciones
            ComprasBL ObjetoCompras = new ComprasBL();
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.DataSource = ObjetoCompras.Listar("R");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Agregamos una nueva recepcion de articulos
            frmRecepcionArticulos AgregarRecepcion = new frmRecepcionArticulos();
            AgregarRecepcion.ShowDialog();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            frmrptCompra ReporteCompra = new frmrptCompra(CompraID);
            ReporteCompra.ShowDialog(this);
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ComprasBL ObjetoCompras = new ComprasBL();
                ObjetoCompras.Cancelar(CompraID);
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error al tratar de cancelar la recepcion de compras", "Error de cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmFiltroRecepcion BuscarRecepcion = new frmFiltroRecepcion(this);
            BuscarRecepcion.ShowDialog(this);
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

        public void BuscarRecepcion(List<cCompras>Resultado)
        {
           
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.DataSource = Resultado;
        }

        private void btnResumenCompras_Click(object sender, EventArgs e)
        {
            
        }

    

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnResumenDocumentos_Click(object sender, EventArgs e)
        {
            frmParametroResumenCompras ResumenRecepciones = new frmParametroResumenCompras("R");
            ResumenRecepciones.ShowDialog(this);
        }

        private void btnRelacionNCF_Click(object sender, EventArgs e)
        {
            rptParametrosResumenNCF ParametroResumenNCF = new rptParametrosResumenNCF();
            ParametroResumenNCF.ShowDialog(this);
        }

        private void btnResumenProductosDevueltos_Click(object sender, EventArgs e)
        {
            frmParametroArticulosDevueltos ResumenDevueltos = new frmParametroArticulosDevueltos();
            ResumenDevueltos.ShowDialog();
        }

        private void btnComprasPorProveedor_Click(object sender, EventArgs e)
        {

        }
    }
}
