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
using DevComponents.DotNetBar;

namespace SMA.Inventario
{
    public partial class frmVerExistenciaAlmacenes : Office2007Form
    {
        private int? InventarioID;

        public frmVerExistenciaAlmacenes()
        {
            InitializeComponent();
        }

        public frmVerExistenciaAlmacenes(int InventarioID): this()
        {
            this.InventarioID = InventarioID;
        }

        private void frmVerExistenciaAlmacenes_Load(object sender, EventArgs e)
        {
            if (InventarioID.HasValue)
            {
                RelacionAlmacenBL ObjetoRelacion= new RelacionAlmacenBL();
                Int32 ID = Convert.ToInt32(InventarioID);
                dgvExistenciaAlmacen.AutoGenerateColumns = false;
                dgvExistenciaAlmacen.DataSource=ObjetoRelacion.Listar(ID);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
