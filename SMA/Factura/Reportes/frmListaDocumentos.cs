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

namespace SMA.Factura.Reportes
{
    public partial class  frmListaDocumentos : Form
    {
        private String TipoDocumento;

        private Int32 Seleccion;

        public frmListaDocumentos()
        {
            InitializeComponent();
        }

        public frmListaDocumentos(String TipoDocumento, Int32 Seleccion):this()
        {
            //Pasa el tipo de Documentos a enlistar y la seleccion del control 
            //1-Desde
            //2-Hasta
            this.TipoDocumento = TipoDocumento;
            this.Seleccion = Seleccion;
        }
        private void frmListaDocumentos_Load(object sender, EventArgs e)
        {
            FacturaBL ObjetoFactura = new FacturaBL();
            dgvFacturas.AutoGenerateColumns = false;
            dgvFacturas.DataSource = ObjetoFactura.Listar(TipoDocumento);
            
        }

        private void dgvFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 DocumentoID;
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                DocumentoID = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells[1].Value);

                //Provee el codigo del Documento a ser buscado
                IBusqueda FormInterfaceReporte = this.Owner as IBusqueda;
                if (FormInterfaceReporte != null && DocumentoID != null)
                {
                    if (Seleccion == 1)
                    {
                        FormInterfaceReporte.SeleccionarDocumentoDesde(DocumentoID);
                    }
                    else if (Seleccion == 2)
                    {
                        FormInterfaceReporte.SeleccionarDocumentoHasta(DocumentoID);
                    }

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
