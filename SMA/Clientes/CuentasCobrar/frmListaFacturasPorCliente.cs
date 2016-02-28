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
    public partial class frmListaFacturasPorCliente :Office2007Form
    {
        private Int64 ClienteID;
        private String TipoDocumento;


        public frmListaFacturasPorCliente()
        {
            InitializeComponent();
        }

        //Constructor con parametro de cliente
        public frmListaFacturasPorCliente(Int64 ClienteID, String TipoDocumento):this()
        {
            this.ClienteID = ClienteID;
            this.TipoDocumento = TipoDocumento;
        }

        private void frmListaFacturasPorCliente_Load(object sender, EventArgs e)
        {
            CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
            dgvDocumentos.AutoGenerateColumns = false;
            dgvDocumentos.DataSource = ObjetoCuenta.ListaDocumentosCxC(ClienteID);

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
                IAgregarCxC FormInterfaceAgregarMovimiento = this.Owner as IAgregarCxC;
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
