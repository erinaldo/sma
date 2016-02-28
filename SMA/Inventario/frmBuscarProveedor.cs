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
using DevComponents.DotNetBar;

namespace SMA.Inventario
{
    public partial class frmBuscarProveedor : Office2007Form
    {
        int Seleccion;
        ProveedorBL ObjetoProveedor = new ProveedorBL();
        List<cProveedor> ListaProveedores;
        String Criterio;
        Int32 ProveedorID;

        public frmBuscarProveedor()
        {
            InitializeComponent();
        }

        public frmBuscarProveedor(int Seleccion):this()
        {
            this.Seleccion = Seleccion;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //Refresca los cambios realizados en la tabla de clientes en el formulario de muestra
            IfrmAgregarEditarInventario FormInterface = this.Owner as IfrmAgregarEditarInventario;
            if (FormInterface != null)
            {
                if (Seleccion == 1)
                {
                    FormInterface.SeleccionarProveedor1(ProveedorID);
                }
                else
                {
                    FormInterface.SeleccionarProveedor2(ProveedorID);
                }
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void frmBuscarProveedor_Load(object sender, EventArgs e)
        {
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            dgvClientes.AutoGenerateColumns = false;
           ListaProveedores = ObjetoProveedor.Listar();
           dgvClientes.DataSource = ListaProveedores;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (Criterio == "Nombre")
            {
                List<cProveedor> Resultado = (from C in ListaProveedores
                                            where C.NombreComercial.StartsWith(txtBusqueda.Text)
                                            select C).ToList();
                ActualizarGrid(Resultado);

            }
            else if (Criterio == "Telefono")
            {
                List<cProveedor> Resultado = (from C in ListaProveedores
                                            where C.Telefono.StartsWith(txtBusqueda.Text)
                                            select C).ToList();
                ActualizarGrid(Resultado);
            }
            else if (Criterio == "RNC")
            {
                List<cProveedor> Resultado = (from C in ListaProveedores
                                            where C.RNC.StartsWith(txtBusqueda.Text)
                                            select C).ToList();
                ActualizarGrid(Resultado);
            }
        }

        private void ActualizarGrid(List<cProveedor> Listado)
        {
            dgvClientes.DataSource = Listado;
        }


        private void cbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbCriterio.Text)
            {
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
                ProveedorID = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
