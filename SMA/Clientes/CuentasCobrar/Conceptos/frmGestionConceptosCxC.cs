using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.Entity;
using SMA.BL;

namespace SMA.Clientes.CuentasPagar.Conceptos
{
    public partial class frmGestionConceptosCxC : Office2007Form
    {
        private int ConceptoID;

        public frmGestionConceptosCxC()
        {
            InitializeComponent();
        }

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnRefrescar.Enabled = false;
            
            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Conceptos CxC")
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGestionConceptosCxC_Load(object sender, EventArgs e)
        {
            Refrescar();
            GestionAccesos();
        }

       public void Refrescar()
        {
            try
            {
                ConceptoCxCBL ObjetoConcepto = new ConceptoCxCBL();
                dgvConcepto.AutoGenerateColumns = false;
                dgvConcepto.DataSource = ObjetoConcepto.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al listar conceptos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarConceptos AgregarConceptos = new frmAgregarEditarConceptos(this);
            AgregarConceptos.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarConceptos EditarConcepto = new frmAgregarEditarConceptos(this, ConceptoID);
            EditarConcepto.ShowDialog(this);
            Refrescar();

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void dgvConcepto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ConceptoID = Convert.ToInt32(dgvConcepto.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
