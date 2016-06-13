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


namespace SMA.Factura
{
    public partial class frmBuscarCliente : Office2007Form
        {
            
        ClienteBL ObjetoCliente = new ClienteBL();
        List<cCliente> ListaCliente;
        String Criterio;
        Int32 ClienteID;
        Int32 Indicador;

        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        public frmBuscarCliente(Int32 Indicador):this()
        {
            this.Indicador = Indicador;
        }
        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            dgvClientes.AutoGenerateColumns = false;
            ListaCliente = ObjetoCliente.Listar();
            dgvClientes.DataSource = ListaCliente;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            ClienteID = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            SeleccionarCliente(ClienteID);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            Criterio = "Nombre";
        }

        private void rbTelefono_CheckedChanged(object sender, EventArgs e)
        {
            Criterio = "Telefono";
        }

        private void rbRNC_CheckedChanged(object sender, EventArgs e)
        {
            Criterio = "RNC";
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

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (Criterio == "Nombre")
            {
                List<cCliente> Resultado = (from C in ListaCliente
                                               where C.NombreComercial.StartsWith(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);

            }
            else if (Criterio == "Telefono")
            {
                List<cCliente> Resultado = (from C in ListaCliente
                                               where C.Telefono.StartsWith(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);
            }
            else if (Criterio == "RNC")
            {
                List<cCliente> Resultado = (from C in ListaCliente
                                               where C.RNC.StartsWith(txtBusqueda.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);
            }

        }

        private void ActualizarGrid(List<cCliente> Listado)
        {
            dgvClientes.DataSource = Listado;
        }

        private void SeleccionarCliente(Int32 _ClienteID)
        {
            //Refresca los cambios realizados en la tabla de clientes en el formulario de muestra
            IagregarEditarFacturas FormInterface = this.Owner as IagregarEditarFacturas;
            if (FormInterface != null)
            {
                FormInterface.BusquedaCliente(_ClienteID);
            }
            this.Close();

            Inventario.Reportes.IReportes InterfaseReportes = this.Owner as Inventario.Reportes.IReportes;
            if(InterfaseReportes!=null)
            {
                InterfaseReportes.SeleccionarCliente(_ClienteID, Indicador);
            }
        }
        private void frmBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                Int32 i=dgvClientes.CurrentRow.Index - 1;

                SeleccionarCliente(Convert.ToInt32(dgvClientes.Rows[i].Cells[0].Value));
            }
        }
    }
}
