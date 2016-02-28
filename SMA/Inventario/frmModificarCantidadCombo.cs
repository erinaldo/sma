using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
namespace SMA.Inventario
{
    public partial class frmModificarCantidadCombo : Office2007Form
    {
        public Int64 InventarioID;

        public frmModificarCantidadCombo()
        {
            InitializeComponent();
        }

        public frmModificarCantidadCombo(Int64 InventarioID): this()
        {
            this.InventarioID = InventarioID;
        }

        private void frmModificarCantidadCombo_Load(object sender, EventArgs e)
        {
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitamos que se entre un caracter que no sea numerico
            if ((char.IsNumber(e.KeyChar)) || (char.IsControl(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Actualiza la cantidad del articulo en inventario
            IfrmAgregarEditarInventario FormInterface = this.Owner as IfrmAgregarEditarInventario;

            if (FormInterface != null)
            {
                Decimal Cantidad = Convert.ToDecimal(txtCantidad.Text);
                FormInterface.ModificarCantidad(InventarioID, Cantidad);
                FormInterface.Refrescar();
                this.Close();
            }
        }
    }
}
