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

namespace SMA.Inventario
{
    public partial class frmGestionCombos : Office2007Form
    {
        private int InventarioID;

        public frmGestionCombos()
        {
            InitializeComponent();
        }

        #region Implementacion de Interfase
        public void AgregarArticulo(int InventarioID, double Cantidad, double PrecioPublico)
        {

        }

        public void Refrescar(int ArticuloComboID)
        {
            RelacionCombosBL ObjetoRelacion = new RelacionCombosBL();
            dgvArticulos.AutoGenerateColumns = false;
            dgvArticulos.DataSource = ObjetoRelacion.Listar(InventarioID);
        }

        #endregion
        public frmGestionCombos(int InventarioID): this()
        {
            this.InventarioID = InventarioID;
        }
        private void frmVistaComponentesCombos_Load(object sender, EventArgs e)
        {
            try
            {
                RelacionCombosBL ObjetoRelacion = new RelacionCombosBL();
                dgvArticulos.AutoGenerateColumns = false;
                dgvArticulos.DataSource = ObjetoRelacion.Listar(InventarioID);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmBuscarArticuloCombo BuscarArticulos = new frmBuscarArticuloCombo();
            BuscarArticulos.ShowDialog(this);
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
