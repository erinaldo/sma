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
using SMA.Clientes.Reportes;
using SMA.Clientes.CuentasPagar;
using DevComponents.DotNetBar;
using SMA.Proveedores;

namespace SMA.Clientes
{
    public partial class frmGestionProveedores : Office2007Form, IGestionProveedores
    {
        private Int32 ProveedorID;

        public frmGestionProveedores()
        {
            InitializeComponent();
        }

        #region Implementacion de Interfase
        public void ActualizarLista()
        {
            ActualizarGrid();
        }

        #endregion

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnImprimir.Enabled = false;
            btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnCuentasPorPagar.Enabled = false;
            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Proveedores")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR PROVEEDOR
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            break;
                        //EDITAR PROVEEDOR
                        case "Editar":
                            btnEditar.Enabled = true;
                            break;
                         //ELIMINAR PROVEEDOR
                        case "Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                        //CONSULTAR PROVEEDORES
                        case "Consultar":
                            btnBuscar.Enabled = true;
                            btnRefrescar.Enabled = true;
                            break;
                        //IMPRIMIR REPORTES
                        case "Imprimir reportes":
                            btnImprimir.Enabled = true;
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
                    case "Cuentas por Pagar":
                        btnCuentasPorPagar.Enabled = true;
                        break;
                }
            }
        }

        private void frmGestionProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                ProveedorBL ObjetoProveedor = new ProveedorBL();
                dgvProveedor.AutoGenerateColumns = false;
                dgvProveedor.DataSource = ObjetoProveedor.Listar();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            GestionAccesos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProveedor AgregarProveedor = new frmAgregarEditarProveedor(this);
            AgregarProveedor.ShowDialog(this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EditarProveedor();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        { 
            DialogResult Resultado = MessageBox.Show("Esta seguro que desea eliminar el proveedor seleccionado", "Eliminar proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    ProveedorBL ObjetoProveedor = new ProveedorBL();
                    ObjetoProveedor.Eliminar(ProveedorID);
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }


        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarGrid();
            }
            catch(Exception  Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public void ActualizarGrid()
        {
            try
            {
                ProveedorBL ObjetoProveedor = new ProveedorBL();
                dgvProveedor.AutoGenerateColumns = false;
                dgvProveedor.DataSource = ObjetoProveedor.Listar();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            frmRptListadoProveedores ReporteProveedores = new frmRptListadoProveedores(ObjetoProveedor.Listar());
            ReporteProveedores.Show(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
               ProveedorID = Convert.ToInt32(dgvProveedor.Rows[e.RowIndex].Cells[0].Value);
            }   
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor BuscarProveedor = new frmBuscarProveedor(this);
            BuscarProveedor.ShowDialog(this);
        }

        public void BuscarProveedor(string Criterio, string Busqueda)
        {
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            BindingSource DbProveedor = new BindingSource();
            DbProveedor.DataSource = ObjetoProveedor.Listar();

            //Realizamos la busqueda deendiendo del critrio
            dgvProveedor.AutoGenerateColumns = false;
            dgvProveedor.DataSource = DbProveedor;

            if (Criterio == "Código")
            {
                //Busqueda por codigo
                Int32 Codigo = Convert.ToInt32(Busqueda);
                var obj = DbProveedor.List.OfType<cProveedor>().ToList().Find(f => f.Codigo == Codigo);
                var pos = DbProveedor.IndexOf(obj);
                DbProveedor.Position = pos;
            }
            else if (Criterio == "Nombre")
            {
                //Busqueda por codigo
                var obj = DbProveedor.List.OfType<cProveedor>().ToList().Find(f => f.NombreComercial == Busqueda);
                var pos = DbProveedor.IndexOf(obj);
                DbProveedor.Position = pos;
            }
            else if (Criterio == "Teléfono")
            {
                //Busqueda por codigo
                var obj = DbProveedor.List.OfType<cProveedor>().ToList().Find(f => f.Telefono == Busqueda);
                var pos = DbProveedor.IndexOf(obj);
                DbProveedor.Position = pos;
            }
            else if (Criterio == "RNC / Cedula")
            {
                //Busqueda por codigo
                var obj = DbProveedor.List.OfType<cProveedor>().ToList().Find(f => f.RNC == Busqueda);
                var pos = DbProveedor.IndexOf(obj);
                DbProveedor.Position = pos;
            }
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            frmGestionCuentasPorPagar CuentasPagar = new frmGestionCuentasPorPagar(ProveedorID);
            CuentasPagar.ShowDialog(this);
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarProveedor();
        }

        private void EditarProveedor()
        {
            frmAgregarEditarProveedor EditarProveedor = new frmAgregarEditarProveedor(ProveedorID,this);
            EditarProveedor.ShowDialog(this);
        }
    }
}
