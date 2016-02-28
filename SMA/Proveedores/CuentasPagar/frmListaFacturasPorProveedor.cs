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

namespace SMA.Clientes.CuentasPagar
{
    public partial class frmListaFacturasPorProveedor :Office2007Form
    {
        private Int64 ProveedorID;
        private String TipoDocumento;

        public frmListaFacturasPorProveedor()
        {
            InitializeComponent();
        }

        //Constructor con parametro de cliente
        public frmListaFacturasPorProveedor(Int64 ProveedorID, String TipoDocumento):this()
        {
            this.ProveedorID = ProveedorID;
            this.TipoDocumento = TipoDocumento;
        }

        private void frmListaFacturasPorCliente_Load(object sender, EventArgs e)
        {
            CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
            dgvDocumentos.AutoGenerateColumns = false;
            dgvDocumentos.DataSource = ObjetoCuenta.ListaDocumentosCxP(ProveedorID);

        }

        private void dgvDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String Referencia;
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                Referencia = Convert.ToString(dgvDocumentos.Rows[e.RowIndex].Cells[2].Value);
               
                //Provee el documento
                IAgregarCxP FormInterfaceAgregarMovimiento = this.Owner as IAgregarCxP;
                if (FormInterfaceAgregarMovimiento != null && TipoDocumento=="Documento")
                {
                    FormInterfaceAgregarMovimiento.SeleccionarDocumento(Referencia);
                    this.Close();
                }
                else if (FormInterfaceAgregarMovimiento != null && TipoDocumento=="Referencia")
                {
                    FormInterfaceAgregarMovimiento.SeleccionarReferencia(Referencia);
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }
    }
}
