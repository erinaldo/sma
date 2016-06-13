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

namespace SMA.Vendedor
{
    public partial class frmGestionVendedor : Office2007Form
    {
        private int VendedorID;

        public frmGestionVendedor()
        {
            InitializeComponent();
        }

        private void frmGestionVendedor_Load(object sender, EventArgs e)
        {
            ActualizarGrid();

        }

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;

            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Vendedores")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR VENDEDOR
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            break;
                        //CANCELAR VENDEDOR
                        case "Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                        //EDITAR VENDEDOR
                        case "Editar":
                            btnEditar.Enabled = true;
                            break;
                        //CONSULTAR VENDEDOR
                        case "Consultar":
                            btnBuscar.Enabled = true;
                            btnRefrescar.Enabled = true;
                            break;

                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void ActualizarGrid()
        {
            try
            {
                VendedorBL ObjetoVendedor = new VendedorBL();
                dgvVendedores.AutoGenerateColumns = false;
                dgvVendedores.DataSource = ObjetoVendedor.Listar();
                GestionAccesos();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al listar vendedores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarGrid();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al actualizar grid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarVendedor BusquedaVendedor = new frmBuscarVendedor(this);
            BusquedaVendedor.ShowDialog(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar vendedor
            DialogResult Resultado = MessageBox.Show("Se eliminara el vendedor del sistema, ¿Esta seguro que desea continuar?", "Eliminar vendedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(Resultado==DialogResult.Yes)
            {
                VendedorBL ObjetoVendedor = new VendedorBL();
                cVendedor Vendedor = ObjetoVendedor.BuscarPorID(VendedorID);
                
                Vendedor.Eliminado = true;

                ObjetoVendedor.GuardarCambios(Vendedor);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VendedorID > 0)
                {
                    frmAgregarEditarVendedor EditarVendedor = new frmAgregarEditarVendedor(VendedorID);
                    EditarVendedor.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un vendedor para editar", "Error al editar vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al editar vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarVendedor AgregarVendedor = new frmAgregarEditarVendedor();
            AgregarVendedor.ShowDialog();
        }

        private void dgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                VendedorID = Convert.ToInt32(dgvVendedores.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public void BuscarVendedor(string Criterio, string Busqueda)
        {
            VendedorBL ObjetoVendedor = new VendedorBL();
            BindingSource DbVendedor = new BindingSource();
            DbVendedor.DataSource = ObjetoVendedor.Listar();

            //Realizamos la busqueda deendiendo del critrio
            dgvVendedores.AutoGenerateColumns = false;
            dgvVendedores.DataSource = DbVendedor;

            if (Criterio == "Código")
            {
                //Busqueda por codigo
                Int32 Codigo = Convert.ToInt32(Busqueda);
                var obj = DbVendedor.List.OfType<cVendedor>().ToList().Find(f => f.Codigo == Codigo);
                var pos = DbVendedor.IndexOf(obj);
                DbVendedor.Position = pos;
            }
            else if (Criterio == "Nombre")
            {
                //Busqueda por codigo
                var obj = DbVendedor.List.OfType<cVendedor>().ToList().Find(f => f.Nombre == Busqueda);
                var pos = DbVendedor.IndexOf(obj);
                DbVendedor.Position = pos;
            }
            else if (Criterio == "Teléfono")
            {
                //Busqueda por codigo
                var obj = DbVendedor.List.OfType<cVendedor>().ToList().Find(f => f.Telefono == Busqueda);
                var pos = DbVendedor.IndexOf(obj);
                DbVendedor.Position = pos;
            }
            else if (Criterio == "RNC / Cedula")
            {
                //Busqueda por codigo
                var obj = DbVendedor.List.OfType<cVendedor>().ToList().Find(f => f.Cedula == Busqueda);
                var pos = DbVendedor.IndexOf(obj);
                DbVendedor.Position = pos;
            }
        }

    }
}
