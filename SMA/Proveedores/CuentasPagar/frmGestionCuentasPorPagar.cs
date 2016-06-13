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
using SMA.Clientes.CuentasPagar.Conceptos;
using SMA.Clientes.CuentasPagar.Reportes;

namespace SMA.Clientes.CuentasPagar
{
    public partial class frmGestionCuentasPorPagar : Office2007Form, IGestionCuentasPagar
    {
        private Int64? ProveedorID;
        private String Referencia;
        private Int64 CuentaID;

        #region Constructores
        public frmGestionCuentasPorPagar()
        {
            InitializeComponent();
        }

        public frmGestionCuentasPorPagar(Int64 ProveedorID):this()
        {
            this.ProveedorID = ProveedorID;
        }
        #endregion

        #region Implementacion de Interface
        public void AplicarFiltro(List<cCuentasPagar> Lista)
        {
            dgvCargosGenerales.AutoGenerateColumns = false;
            dgvCargosGenerales.DataSource = Lista;
        }
        #endregion

        private void GestionAccesos()
        {
            //BLOQUEA TODOS LOS CONTROLES
            btnInformacion.Enabled = false;
            btnRecibirPago.Enabled = false;
            btnCrearAsiento.Enabled = false;
            btnRecibirPago.Enabled = false;
            btnConceptos.Enabled = false;
            btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnImprimir.Enabled = false;
            btnReportes.Enabled = false;
            btnImprimir.Enabled = false;
            btnBuscar.Enabled = false;
            btnRefrescar.Enabled = false;

            try
            {
                //SELECCIONAMOS EL MODULO DE CLIENTES
                List<cRolesModulosUsuarios> PermisosClientes = (from C in cGlobal.ListaModulosPermisos
                                                                where C.Modulo.Contains("Cuentas por Pagar")
                                                                select C).ToList();
                //Recorremos la lista de modulos para permitir o no el acceso
                foreach (cRolesModulosUsuarios p in PermisosClientes)
                {
                    switch (p.Rol.ToString())
                    {
                        //REALIZAR PAGOS
                        case "Registrar pagos":
                            btnRecibirPago.Enabled = true;
                            break;
                        //REALIZAR CARGOS
                        case "Registrar cargos":
                            btnCrearAsiento.Enabled = true;
                            break;
                        //CONSULTAR PROVEEDORES
                        case "Consultar":
                            btnBuscar.Enabled = true;
                            btnRefrescar.Enabled = true;
                            btnInformacion.Enabled = true;
                            break;
                        //IMPRIMIR REPORTES
                        case "Imprimir reportes":
                            btnImprimir.Enabled = true;
                            btnReportes.Enabled = true;
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            //DETERMINAMOS SI TIENE ACCESO AL MODULO DE CONCEPTOS DE CUENTAS POR COBRAR
            foreach (cRolesModulosUsuarios m in cGlobal.ListaModulosPermisos)
            {
                switch (m.Modulo.ToString())
                {
                    case "Conceptos CxP":
                        btnConceptos.Enabled = true;
                        break;
                }
            }
        }

        private void frmGestionCuentasPorPagar_Load(object sender, EventArgs e)
        {
            CargarInformacion();
            GestionAccesos();
        }

        private void CargarInformacion()
        {
            try
            {
                if (ProveedorID.HasValue && ProveedorID > 0)
                {
                    Int32 Codigo = Convert.ToInt32(ProveedorID);
                    //Informacion de cuentas
                    CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
                    dgvCargosGenerales.AutoGenerateColumns = false;
                    dgvCargosGenerales.DataSource = ObjetoCuenta.ListarCargosGenerales(Codigo);
                    //Informacion de Clientes
                    ProveedorBL ObjetoProveedor = new ProveedorBL();
                    cProveedor Cliente = ObjetoProveedor.BuscarPorID(Codigo);
                    txtNombreProveedor.Text = Cliente.NombreComercial.ToString();
                    txtCodigo.Text = Cliente.Codigo.ToString();
                    txtBalance.Text = Cliente.Balance.ToString("C2");
                }
                else
                {
                    //Enviamos un mensaje indicando que debe seleccionar un cliente
                    MessageBox.Show("Debe seleccionar un cliente para verificar su estado de cuenta", "Seleccione un cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Cerramos el formulario
                    this.Close();
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void tabStrip1_Click(object sender, EventArgs e)
        {

        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            if (ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                frmInfoProveedor InformacionProveedor = new frmInfoProveedor(Codigo);
                InformacionProveedor.ShowDialog(this);
            }

        }

        private void btnCrearAsiento_Click(object sender, EventArgs e)
        {
            if (ProveedorID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ProveedorID);
                frmAgregarCxP AgregarMovimiento = new frmAgregarCxP(Codigo, this);
                AgregarMovimiento.ShowDialog(this);
            }
        }

        private void btnRecibirPago_Click(object sender, EventArgs e)
        {
            //Si la variable cliente posee codigo entonces lo pasamos
            if (ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                frmRealizarPago RecibirPago = new frmRealizarPago(Codigo);
                RecibirPago.ShowDialog(this);
            }
            else
            {
                //Si no posee codigo entonces instanciamos el formulario
                frmRealizarPago RecibirPago = new frmRealizarPago();
                RecibirPago.ShowDialog(this);
            }
        }

        private void btnConceptos_Click(object sender, EventArgs e)
        {
            frmGestionConceptosCxP Conceptos = new frmGestionConceptosCxP();
            Conceptos.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                frmBuscarCxP BuscarMovimiento = new frmBuscarCxP(Codigo);
                BuscarMovimiento.ShowDialog(this);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCargosGenerales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                CuentaID = Convert.ToInt32(dgvCargosGenerales.Rows[e.RowIndex].Cells[0].Value);
                frmAgregarCxP VerCuenta = new frmAgregarCxP(CuentaID);
                VerCuenta.ShowDialog(this);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvCargosGenerales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                Referencia = Convert.ToString(dgvCargosGenerales.Rows[e.RowIndex].Cells[2].Value);
                CuentaID = Convert.ToInt64(dgvCargosGenerales.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void stbDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProveedorID.HasValue)
                {
                    Int64 Codigo = Convert.ToInt64(ProveedorID);
                    CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
                    dgvDetalle.AutoGenerateColumns = false;
                    dgvDetalle.DataSource = ObjetoCuenta.ListaPagoCargos(Referencia, Codigo);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al listar cargos o pagos relacionados al documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                CuentaID = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells[0].Value);
                frmAgregarCxP VerCuenta = new frmAgregarCxP(CuentaID);
                VerCuenta.ShowDialog(this);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnImprimirEstadoGeneral_Click(object sender, EventArgs e)
        {
            if (ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                frmParametroCuentaGeneralProveedor ParametrosEstadosCuenta = new frmParametroCuentaGeneralProveedor(Codigo, "General");
                ParametrosEstadosCuenta.Text = "Estado de cuenta general";
                ParametrosEstadosCuenta.ShowDialog(this);
            }

        }

        private void btnImprimirEstadoDetallado_Click(object sender, EventArgs e)
        {
            if (ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                frmParametroCuentaGeneralProveedor ParametrosEstadosCuenta = new frmParametroCuentaGeneralProveedor(Codigo, "Detallado");
                ParametrosEstadosCuenta.Text = "Estado de cuenta detallado";
                ParametrosEstadosCuenta.ShowDialog(this);
            }
        }

        private void btnRptPorConcepto_Click(object sender, EventArgs e)
        {
            if(ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);

                frmParametrosPorConceptos ReportePorConcepto = new frmParametrosPorConceptos(Codigo);
                ReportePorConcepto.ShowDialog(this);
            }
            else
            {
                frmParametrosPorConceptos ReportePorConcepto = new frmParametrosPorConceptos();
                ReportePorConcepto.ShowDialog(this);
            }
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {

            if (ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);

                frmParametroResumenMovimientos ParametrosResumen = new frmParametroResumenMovimientos(Codigo);
                ParametrosResumen.ShowDialog(this);
            }
            else
            {
                frmParametroResumenMovimientos ParametrosResumen = new frmParametroResumenMovimientos();
                ParametrosResumen.ShowDialog(this);
            }

        }

        private void btnPagosPorPeriodo_Click(object sender, EventArgs e)
        {
            if (ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);

                frmParametrosPagosPorPeriodo PagosPorPeriodo = new frmParametrosPagosPorPeriodo(Codigo);
                PagosPorPeriodo.ShowDialog(this);
            }
            else
            {
                frmParametrosPagosPorPeriodo PagosPorPeriodo = new frmParametrosPagosPorPeriodo();
                PagosPorPeriodo.ShowDialog(this);
            }
        }

        private void btnAntiguedadSaldoProveedor_Click(object sender, EventArgs e)
        {
            if (ProveedorID.HasValue)
            {
                Int32 Codigo = Convert.ToInt32(ProveedorID);

                frmParametroAntiguedadSaldoCuentaPagar AntiguedadSaldo = new frmParametroAntiguedadSaldoCuentaPagar(Codigo);
                AntiguedadSaldo.ShowDialog(this);
            }
            else
            {
                frmParametroAntiguedadSaldoCuentaPagar AntiguedadSaldo = new frmParametroAntiguedadSaldoCuentaPagar();
                AntiguedadSaldo.ShowDialog(this);
            }
        }

        private void btnCatalogoProveedores_Click(object sender, EventArgs e)
        {
            frmParametroCatalogoProveedores CatalogoProveedor = new frmParametroCatalogoProveedores();
            CatalogoProveedor.ShowDialog(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                CuentasPagarBL ObjetoCuenta = new CuentasPagarBL();
                cCuentasPagar Cuenta = ObjetoCuenta.BuscarPorID(CuentaID);
                ObjetoCuenta.CancelarDocumento(Cuenta);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Error el cancelar transaccion","Error al eliminar transacción",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                CuentaID = Convert.ToInt64(dgvDetalle.Rows[e.RowIndex].Cells[0].Value);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
