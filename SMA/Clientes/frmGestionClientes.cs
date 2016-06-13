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

namespace SMA.Clientes
{
    public partial class frmGestionClientes : Office2007Form, IGestionClientes
    {
        //private List<cRolesModulosUsuarios> Permisos;  //LISTA DE PERMISOS
        private Int32 ClienteID;                       //CODIGO DE CLIENTE

        #region Constructores
        public frmGestionClientes()
        {
            InitializeComponent();
        }
        #endregion

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
            btnCuentasCobrar.Enabled = false;
            btnReportes.Enabled = false;
            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Clientes")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                            //AGREGAR CLIENTE
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            break;
                            //EDITAR CLIENTE
                        case "Editar":
                            btnEditar.Enabled = true;
                            break;
                        case "Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                        case "Consultar":
                            btnBuscar.Enabled = true;
                            btnRefrescar.Enabled = true;
                            break;
                        case "Imprimir reportes":
                            btnImprimir.Enabled = true;
                            btnReportes.Enabled = true;
                            break;
                    } 
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            //DETERMINAMOS SI TIENE ACCESO AL MODULO DE CUENTAS POR COBRAR
            foreach (cRolesModulosUsuarios m in cGlobal.ListaModulosPermisos)
            {
                switch(m.Modulo.ToString())
                {
                    case "Cuentas por Cobrar":
                        btnCuentasCobrar.Enabled = true;
                        break;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAgregarEditarCliente AgregarCliente = new frmAgregarEditarCliente(this);
                AgregarCliente.Show(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarCliente();
        }

        private void EditarCliente()
        {
            try
            {
                if (ClienteID > 0 && btnEditar.Enabled==true)
                {
                    frmAgregarEditarCliente EditarCliente = new frmAgregarEditarCliente(ClienteID, this);
                    EditarCliente.Show(this);
                }
                //else
                //{
                //    MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Esta seguro que desea eliminar el cliente seleccionado", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    ClienteBL ObjetoCliente = new ClienteBL();
                    ObjetoCliente.Eliminar(ClienteID);
                    ActualizarGrid();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error al eliminar cliente, " + Ex.Message,"Error eliminar cliente",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarCliente BuscarCliente = new frmBuscarCliente(this);
            BuscarCliente.ShowDialog(this);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarGrid();
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error al realizar la operacion" + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ActualizarGrid()
        {
            ClienteBL ObjetoCliente = new ClienteBL();
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = ObjetoCliente.Listar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)

        {
            ClienteBL ObjetoCliente = new ClienteBL();
            frmRptListadoClientes Reporte = new frmRptListadoClientes(ObjetoCliente.Listar());
            Reporte.Show(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGestionClientes_Load(object sender, EventArgs e)
        {
            try
            {
                //CARGAMOS LA INFORMACION DE LOS CLIENTES
                ActualizarGrid();
                //GESTIONAMOS LOS ACCESOS DE LOS USUARIOS
                GestionAccesos();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al obtener lista de clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ClienteID = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public void BuscarCliente(string Criterio, string Busqueda)
        {
            ClienteBL ObjetoCliente = new ClienteBL();
            List<cCliente> Lista = ObjetoCliente.Listar();

            //Realizamos la busqueda deendiendo del critrio
            dgvClientes.AutoGenerateColumns = false;
            

            if (Criterio == "Código")
            {
                Int32 Codigo = Convert.ToInt32(Busqueda);
                var Resultado=(from r in Lista
                                   where r.Codigo==Codigo
                                   select r).ToList();
                dgvClientes.DataSource = Resultado;
            }
            else if(Criterio=="Nombre")
            {
                var Resultado = (from r in Lista
                                 where r.NombreComercial.StartsWith(Busqueda)
                                 select r).ToList();
                dgvClientes.DataSource = Resultado;
               
            }
            else if (Criterio == "Teléfono")
            {

                var Resultado = (from r in Lista
                                 where r.Telefono.StartsWith(Busqueda)
                                 select r).ToList();
                dgvClientes.DataSource = Resultado;
            }
            else if (Criterio == "RNC / Cedula")
            {

                var Resultado = (from r in Lista
                                 where r.RNC.StartsWith(Busqueda)
                                 select r).ToList();
                dgvClientes.DataSource = Resultado;
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnCuentasCobrar_Click(object sender, EventArgs e)
        {
            frmGestionCuentasPorCobrar GestionCuentas = new frmGestionCuentasPorCobrar(ClienteID);
            GestionCuentas.ShowDialog(this);

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            //Cerrar ventana
            this.Close();
        }

        private void btnReporteCatalogo_Click(object sender, EventArgs e)
        {
            //Parametro de Catalogo de Clientes
            frmParametroCatalogoCliente ParametroCatalogoCliente = new frmParametroCatalogoCliente();
            ParametroCatalogoCliente.ShowDialog();
        }

        private void btnCobranzaGeneral_Click(object sender, EventArgs e)
        {
            

        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarCliente();
        }
    }
}
