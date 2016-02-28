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

namespace SMA.Factura.Comprobantes
{
    public partial class frmGestionComprobantes : Office2007Form
    {
        private int ParametroID;        //Variable del parametro de NCF

        public frmGestionComprobantes()
        {
            InitializeComponent();
        }
        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
           
            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Comprobantes fiscales")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR COMPROBANTES
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            break;
                        //EDITAR COMPROBANTES
                        case "Editar":
                            btnEditar.Enabled = true;
                            break;
                        //ELIMINAR COMPROBANTES
                        case "Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                         //CONSULTAR COMPROBANTES
                        case "Consultar":
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

        private void frmGestionComprobantes_Load(object sender, EventArgs e)
        {
            CargarParametros();
            GestionAccesos();
        }

        private void CargarParametros()
        {
            try
            {
                ParametroNCFBL ObjetoParametro = new ParametroNCFBL();
                CargaComprobantesConCreditoFiscal(ObjetoParametro.Listar(1));
                CargaComprobantesParaConsumidorFinal(ObjetoParametro.Listar(2));
                CargarComprobantesGubernamentales(ObjetoParametro.Listar(3));
                CargaComprobanteRegimenEspecial(ObjetoParametro.Listar(4));
                CargaComprobanteNotasCredito(ObjetoParametro.Listar(5));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #region Carga de lista de parametros
        private void CargaComprobantesConCreditoFiscal(List<cParametroNCF> ListaParametro)
        {
            //Lista de comprobantes con credito fiscal
            dgvCreditoFiscal.AutoGenerateColumns = false;
            dgvCreditoFiscal.DataSource = ListaParametro;
        }

        private void CargaComprobantesParaConsumidorFinal(List<cParametroNCF> ListaParametro)
        {
            //Lista de comprobantes para consumidor final
            dgvConsumidorFiscal.AutoGenerateColumns = false;
            dgvConsumidorFiscal.DataSource = ListaParametro;
        }

        private void CargarComprobantesGubernamentales(List<cParametroNCF> ListaParametro)
        {
            //Lista de comprobantes gubernamentales
            dgvGubernamental.AutoGenerateColumns = false;
            dgvGubernamental.DataSource = ListaParametro;
        }

        private void CargaComprobanteRegimenEspecial(List<cParametroNCF> ListaParametro)
        {
            dgvEspecial.AutoGenerateColumns = false;
            dgvEspecial.DataSource = ListaParametro;
        }

        private void CargaComprobanteNotasCredito(List<cParametroNCF> ListaParametro)
        {
            dgvNotasCredito.AutoGenerateColumns = false;
            dgvNotasCredito.DataSource = ListaParametro;
        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAgregarEditarComprobantes AgregarComprobante = new frmAgregarEditarComprobantes();
                AgregarComprobante.Text = "Agregar comprobante";
                AgregarComprobante.ShowDialog();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvCreditoFiscal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ParametroID = Convert.ToInt32(dgvCreditoFiscal.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvConsumidorFiscal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ParametroID = Convert.ToInt32(dgvConsumidorFiscal.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvGubernamental_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ParametroID = Convert.ToInt32(dgvGubernamental.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvEspecial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ParametroID = Convert.ToInt32(dgvEspecial.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                frmAgregarEditarComprobantes EditarComprobante = new frmAgregarEditarComprobantes(ParametroID);
                EditarComprobante.Text = "Editar comprante";
                EditarComprobante.ShowDialog(this);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvCreditoFiscal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Actualizamos el estatus del parametro
            DialogResult Resultado;
            Resultado = MessageBox.Show("Esta seguro de suspender el uso de este parametro de comprobante fiscal?", "Suspender parametro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                ParametroNCFBL ObjetoParametro = new ParametroNCFBL();
                cParametroNCF Parametro = ObjetoParametro.BuscarPorID(ParametroID); //Buscamos el parametro por codigo
                ObjetoParametro.Eliminar(Parametro); //Actualizamos el estatus del parametro
            }

            
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarParametros();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void dgvNotasCredito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ParametroID = Convert.ToInt32(dgvNotasCredito.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvGubernamental_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
