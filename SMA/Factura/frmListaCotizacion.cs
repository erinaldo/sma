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

namespace SMA.Factura
{
    public partial class frmListaCotizacion : Office2007Form
    {
        Int32 FacturaID;
        String TipoDocumento;

        public frmListaCotizacion()
        {
            InitializeComponent();
        }

        public frmListaCotizacion(String TipoDocumento):this()
        {
            this.TipoDocumento = TipoDocumento;
        }

        //Variable para la busqueda
        FacturaBL ObjetoFactura = new FacturaBL();
        List<cFactura> ListaCotizaciones;
        String Criterio;

        private void frmListaCotizacion_Load(object sender, EventArgs e)
        {

            //Cargamos la lista de cotizaciones 
            try
            {
                FacturaBL ObjetoFactura = new FacturaBL();
                dgvCotizaciones.AutoGenerateColumns = false;
                ListaCotizaciones = ObjetoFactura.Listar(TipoDocumento);
                dgvCotizaciones.DataSource = ListaCotizaciones;
            }
            catch(Exception Ex)
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
                FacturaID = Convert.ToInt32(dgvCotizaciones.Rows[e.RowIndex].Cells[1].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //Provee el codigo del articulo a ser buscado
            IagregarEditarFacturas FormInterfaceFactura = this.Owner as IagregarEditarFacturas;
            if (FormInterfaceFactura != null)
            {
                FormInterfaceFactura.BuscarReferencia(FacturaID);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStrFind_TextChanged(object sender, EventArgs e)
        {
            if (Criterio == "Nombre cliente")
            {
                List<cFactura> Resultado = (from C in ListaCotizaciones
                                               where Convert.ToString(C.ClienteID).StartsWith(txtStrFind.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);

            }
            else if (Criterio == "No. Documento")
            {
                List<cFactura> Resultado = (from C in ListaCotizaciones
                                               where C.DocumentoID==Convert.ToInt32(txtStrFind.Text)
                                               select C).ToList();
                ActualizarGrid(Resultado);
            }
            else if (Criterio == "Fecha creación")
            {
                DateTime Fecha;
                if (DateTime.TryParse(txtStrFind.Text, out Fecha))
                {
                    List<cFactura> Resultado = (from C in ListaCotizaciones
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
        private void ActualizarGrid(List<cFactura> Listado)
        {
            dgvCotizaciones.DataSource = Listado;
        }

        private void cbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbCriterio.Text)
            {
                case "Nombre cliente":
                    Criterio = "Nombre cliente";
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
