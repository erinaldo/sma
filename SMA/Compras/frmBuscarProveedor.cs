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

namespace SMA.Compras
{
    public partial class frmBuscarProveedor : Office2007Form
    {
        ProveedorBL ObjetoProveedor = new ProveedorBL();
        List<cProveedor> ListaProveedor;
        String Criterio;
        Int32 ProveedorID;
        Int32 Indicador;

        #region Construtores
        public frmBuscarProveedor()
        {
            InitializeComponent();
        }

        public frmBuscarProveedor(Int32 Indicador):this()
        {
            this.Indicador = Indicador;
        }

        #endregion
        private void frmBuscarProveedor_Load(object sender, EventArgs e)
        {
            //Cargamos la lista de proveedores
            dgvClientes.AutoGenerateColumns = false;
            ListaProveedor = ObjetoProveedor.Listar();
            dgvClientes.DataSource = ListaProveedor;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //Seleccionamos el Codigo del proveedor
            ProveedorID = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            SeleccionarProveedor(ProveedorID);
        }

        private void SeleccionarProveedor(Int64 _ProveedorID)
        {
            //Refresca los cambios realizados en la tabla de clientes en el formulario de muestra
            IagregarEditarRecepcion FormInterface = this.Owner as IagregarEditarRecepcion;
            if (FormInterface != null)
            {
                FormInterface.BusquedaProveedor(_ProveedorID);
            }

            //Busca el proveedor seleccionado
            iGestionDocumentoCompras FormInterface_ = this.Owner as iGestionDocumentoCompras;
            if(FormInterface_!=null)
            {
               if(Indicador>0)
               {
                   FormInterface_.SeleccionProveedor(ProveedorID, Indicador);
               }
               else
               {
                FormInterface_.BusquedaProveedor(_ProveedorID);
               }
            }

            //Interfase de reportes de inventario
            Inventario.Reportes.IReportes InterfaseReportes = this.Owner as Inventario.Reportes.IReportes;
            if(InterfaseReportes!=null)
            {
                InterfaseReportes.SeleccionarCliente(_ProveedorID, Indicador);
            }

            this.Close();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (Criterio == "Codigo")
            {
                List<cProveedor> Resultado = (from C in ListaProveedor
                                               where C.ID==Convert.ToInt32(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);

            }
            else if (Criterio == "Nombre")
            {
                List<cProveedor> Resultado = (from C in ListaProveedor
                                               where C.NombreComercial.StartsWith(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);
            }
            else if (Criterio == "Telefono")
            {
                List<cProveedor> Resultado = (from C in ListaProveedor
                                               where C.Telefono.StartsWith(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);
            }
            else if (Criterio == "RNC")
            {
                List<cProveedor> Resultado = (from C in ListaProveedor
                                              where C.RNC.StartsWith(txtBusqueda.Text)
                                              select C).ToList();
                ActualizarGrid(Resultado);
            }


        }

        private void ActualizarGrid(List<cProveedor> Listado)
        {
            dgvClientes.DataSource = Listado;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbCriterio.Text)
            {
                case "Codigo":
                    Criterio = "Codigo";
                    break;
                case "Nombre":
                    Criterio = "Nombre";
                    break;
                case "Telefono":
                    Criterio = "Telefono";
                    break;
                case "RNC":
                    Criterio = "RNC";
                    break;
            }
        }

        private void frmBuscarProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (dgvClientes.Rows.Count > 0)
                {
                    Int32 i = dgvClientes.CurrentRow.Index;
                    if (i != -1)
                    {
                        SeleccionarProveedor(Convert.ToInt32(dgvClientes.Rows[i].Cells[0].Value));
                    }
                }
                else
                {
                    MessageBox.Show("Error al seleccionar articulo, la busqueda no arrojo ninguna resultado", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        


    }
}
