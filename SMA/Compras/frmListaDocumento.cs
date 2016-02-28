using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.Entity;
using SMA.BL;
using DevComponents.DotNetBar;


namespace SMA.Compras
{
    public partial class frmListaDocumento : Office2007Form
    {
        Int64 FacturaID;
        String TipoDocumento;
        Int32 Seleccion;

        ComprasBL ObjetoFactura = new ComprasBL();
        List<cCompras> ListaCotizaciones;
        String Criterio;

        public frmListaDocumento()
        {
            InitializeComponent();
        }

        #region Constructores
        public frmListaDocumento(String TipoDocumento):this()
        {
            this.TipoDocumento = TipoDocumento;
        }
        public frmListaDocumento(String TipoDocumento,Int32 Seleccion): this()
        {
            this.TipoDocumento = TipoDocumento;
            this.Seleccion = Seleccion;
        }
        #endregion  

        private void frmListaDocumento_Load(object sender, EventArgs e)
        {

            //Cargamos la lista de cotizaciones 
            try
            {
                ComprasBL ObjetoFactura = new ComprasBL();
                dgvCotizaciones.AutoGenerateColumns = false;
                ListaCotizaciones = ObjetoFactura.Listar(TipoDocumento);
                dgvCotizaciones.DataSource = ListaCotizaciones;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvCotizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Numero de documento  que se obtiene desde el grid
                FacturaID = Convert.ToInt64(dgvCotizaciones.Rows[e.RowIndex].Cells[1].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //Provee el codigo del articulo a ser buscado
            IagregarEditarRecepcion FormInterfaceFactura = this.Owner as IagregarEditarRecepcion;
            if (FormInterfaceFactura != null)
            {
                FormInterfaceFactura.BuscarReferencia(FacturaID);
                this.Close();
            }

            iGestionDocumentoCompras FormInterfaceGestion = this.Owner as iGestionDocumentoCompras;
            if(FormInterfaceGestion!=null)
            {
                FormInterfaceGestion.SeleccionDocumento(Convert.ToString(FacturaID),Seleccion);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStrFind_TextChanged(object sender, EventArgs e)
        {
            if (Criterio == "Nombre proveedor")
            {
                List<cCompras> Resultado = (from C in ListaCotizaciones
                                            where Convert.ToString(C.ProveedorID).StartsWith(txtStrFind.Text)
                                            select C).ToList();
                ActualizarGrid(Resultado);

            }
            else if (Criterio == "No. Documento")
            {
                List<cCompras> Resultado = (from C in ListaCotizaciones
                                            where C.DocumentoID == Convert.ToInt32(txtStrFind.Text)
                                            select C).ToList();
                ActualizarGrid(Resultado);
            }
            else if (Criterio == "Fecha creación")
            {
                DateTime Fecha;
                if (DateTime.TryParse(txtStrFind.Text, out Fecha))
                {
                    List<cCompras> Resultado = (from C in ListaCotizaciones
                                                where C.FechaCreacion == Convert.ToDateTime(txtStrFind.Text)
                                                select C).ToList();
                    ActualizarGrid(Resultado);
                }
            }
            else
            {
                ActualizarGrid(ListaCotizaciones);
            }
        }

        private void ActualizarGrid(List<cCompras> Listado)
        {
            dgvCotizaciones.DataSource = Listado;
        }

        private void cbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbCriterio.Text)
            {
                case "Nombre proveedor":
                    Criterio = "Nombre proveedor";
                    break;
                case "No. Documento":
                    Criterio = "No. Documento";
                    break;
                case "Fecha creación":
                    Criterio = "Fecha creación";
                    break;
            }
        }

    }
}
