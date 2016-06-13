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
using SMA.Factura.Comprobantes;
using SMA.Factura.Reportes;

namespace SMA.Factura
{
    public partial class frmGestionFactura : Form
    {
        private Int32 FacturaID;

        public frmGestionFactura()
        {
            InitializeComponent();
        }

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnNuevo.Enabled = false;
            btnVisualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnComprobantes.Enabled = false;
            btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnReportes.Enabled = false;
            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Facturas")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //AGREGAR FACTURA
                        case "Agregar":
                            btnNuevo.Enabled = true;
                            break;
                        //CANCELAR FACTURA
                        case "Eliminar":
                            btnEliminar.Enabled = true;
                            break;
                        case "Consultar":
                            btnBuscar.Enabled = true;
                            btnRefrescar.Enabled = true;
                            break;
                        case "Imprimir reportes":
                            btnVisualizar.Enabled = true;
                            btnReportes.Enabled = true;
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            //DETERMINAMOS SI TIENE ACCESO AL MODULO DE COMPROBANTES FISCALES
            foreach (cRolesModulosUsuarios m in cGlobal.ListaModulosPermisos)
            {
                switch (m.Modulo.ToString())
                {
                    case "Comprobantes fiscales":
                        btnComprobantes.Enabled = true;
                        break;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAgregarFactura CrearFactura = new frmAgregarFactura();
                CrearFactura.ShowDialog();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //SE CANCELARA LA FACTURA COMO EFECTO DE ESTO SE DEVOLVERA LA CANTIDAD FACTURADA A INVENTARIO
            DialogResult Resultado;

            Resultado = MessageBox.Show("Se cancelara la factura, esto devolvera los articulos facturados al inventario nuevamente, ¿Esta seguro que desea continuar?", "Cancelacion de Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    FacturaBL ObjetoFactura = new FacturaBL();
                    ObjetoFactura.Cancelar(FacturaID);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error en cancelacion de factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGestionFactura_Load(object sender, EventArgs e)
        {
            CargarFacturas();
            GestionAccesos();
        }

        private void CargarFacturas()
        {
            try
            {
                FacturaBL ObjetoFactura = new FacturaBL();
                dgvFacturas.AutoGenerateColumns = false;
                dgvFacturas.DataSource = ObjetoFactura.Listar("F");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnComprobantes_Click(object sender, EventArgs e)
        {
            try
            {
                frmGestionComprobantes GestionComprobante = new frmGestionComprobantes();
                GestionComprobante.ShowDialog();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            frmrptFactura Reporte = new frmrptFactura(FacturaID);
            Reporte.ShowDialog(this);
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                FacturaID = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmFiltrarFactura BuscarFactura = new frmFiltrarFactura(this);
            BuscarFactura.ShowDialog(this);
        }

        public void BuscarFactura(List<cFactura> Resultado)
        {
            //BUSQUEDA DE FACTURAS
            FacturaBL ObjetoFactura= new FacturaBL();
            dgvFacturas.AutoGenerateColumns=false;
            dgvFacturas.DataSource = Resultado;
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
        }

        private void Acciones_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            frmFiltrarFactura FiltrarFactura = new frmFiltrarFactura(this);
            FiltrarFactura.ShowDialog(this);
        }

        private void btnResumenDocumentos_Click(object sender, EventArgs e)
        {
            frmParametroResumenFacturas ResumenFacturas = new frmParametroResumenFacturas("F");
            ResumenFacturas.ShowDialog(this);
        }

        private void btnRelacionNCF_Click(object sender, EventArgs e)
        {
            frmParametroRelacionFacturasNCF RelacionNCF = new frmParametroRelacionFacturasNCF();
            RelacionNCF.ShowDialog(this);
        }

        private void btnPagosComisiones_Click(object sender, EventArgs e)
        {
            frmParametroComisionVenta ComisionVenta = new frmParametroComisionVenta();
            ComisionVenta.ShowDialog(this);
        }

        private void btnResumenProductosDevueltos_Click(object sender, EventArgs e)
        {
            frmParametroArticulosDevueltos ArticulosDevueltos = new frmParametroArticulosDevueltos();
            ArticulosDevueltos.ShowDialog(this);
        }

        private void btnDetalladoFacturas_Click(object sender, EventArgs e)
        {
            frmParametroDetalladoDocumentos DetalleDocumento = new frmParametroDetalladoDocumentos("F");
            DetalleDocumento.ShowDialog(this);
        }
    }
}
