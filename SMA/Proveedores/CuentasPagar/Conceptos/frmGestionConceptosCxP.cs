using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.BL;
using DevComponents.DotNetBar;
using SMA.Entity;

namespace SMA.Clientes.CuentasPagar.Conceptos
{
    public partial class frmGestionConceptosCxP : Office2007Form
    {
       private ConceptoCxPBL ObjetoConcepto = new ConceptoCxPBL();
       private Int32 ConceptoID;

        public frmGestionConceptosCxP()
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
                                                                where C.Modulo.Contains("Conceptos CxP")
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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarConceptosCxP EditarConcepto = new frmAgregarEditarConceptosCxP(ConceptoID,this);
            EditarConcepto.ShowDialog(this);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarEditarConceptosCxP AgregarConcepto = new frmAgregarEditarConceptosCxP(this);
            AgregarConcepto.ShowDialog(this);
        }

        private void frmGestionConceptosCxP_Load(object sender, EventArgs e)
        {

            Refrescar();
            GestionAccesos();

        }

        public void Refrescar()
        {
            dgvConcepto.AutoGenerateColumns = false;
            dgvConcepto.DataSource = ObjetoConcepto.Listar();
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
