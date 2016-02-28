using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.Clientes.CuentasPagar.Conceptos;
using SMA.Clientes.CuentasPagar.Reportes;
using SMA.BL;
using SMA.Entity;
using SMA.Clientes.CuentasCobrar.Reportes;


namespace SMA.Clientes.CuentasPagar
{
    public partial class frmGestionCuentasPorCobrar : Office2007Form, IGestionCuentasCobrar
    {
        private Int64? ClienteID; //Codigo de cliente
        private String Referencia;
        private Int64 CuentaID;

        #region Constructores
        public frmGestionCuentasPorCobrar()
        {
            InitializeComponent();
        }

        public frmGestionCuentasPorCobrar(Int64 ClienteID)
            : this()
        {
            this.ClienteID = ClienteID;
        }
        #endregion

        #region Implementacion de Interfase
        public void AplicarFiltro(List<cCuentasCobrar> Lista)
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
                                                                where C.Modulo.Contains("Cuentas por Cobrar")
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
                    case "Conceptos CxC":
                        btnConceptos.Enabled = true;
                        break;
                }
            }
        }

        private void frmGestionCuentasPorCobrar_Load(object sender, EventArgs e)
        {
            CargarInformacion();
            GestionAccesos();
        }

        private void CargarInformacion()
        {
            try
            {
                if (ClienteID.HasValue && ClienteID > 0)
                {
                    Int64 Codigo = Convert.ToInt64(ClienteID);
                    //Informacion de cuentas
                    CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                    dgvCargosGenerales.AutoGenerateColumns = false;
                    dgvCargosGenerales.DataSource = ObjetoCuenta.ListarCargosGenerales(Codigo);
                    //Informacion de Clientes
                    ClienteBL ObjetoCliente = new ClienteBL();
                    cCliente Cliente = ObjetoCliente.BuscarPorID(Codigo);
                    txtNombreCliente.Text = Cliente.NombreComercial.ToString();
                    txtCodigoCliente.Text = Cliente.ID.ToString();
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

        private void ButtonItem6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConceptos_Click(object sender, EventArgs e)
        {
            frmGestionConceptosCxC GestionConceptos = new frmGestionConceptosCxC();
            GestionConceptos.ShowDialog();
        }

        private void btnRecibirPago_Click(object sender, EventArgs e)
        {
            try
            {
                //Si la variable cliente posee codigo entonces lo pasamos
                if (ClienteID.HasValue)
                {
                    Int64 Codigo = Convert.ToInt64(ClienteID);
                    frmRecibirPago RecibirPago = new frmRecibirPago(Codigo);
                    RecibirPago.ShowDialog(this);
                }
                else
                {
                    //Si no posee codigo entonces instanciamos el formulario
                    frmRecibirPago RecibirPago = new frmRecibirPago();
                    RecibirPago.ShowDialog(this);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmInfoCliente InformacionCliente = new frmInfoCliente(Codigo);
                InformacionCliente.ShowDialog(this);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmBuscarCxC BuscarCuenta = new frmBuscarCxC(Codigo);
                BuscarCuenta.ShowDialog(this);
            }

        }

        private void btnCrearAsiento_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmAgregarCxC AgregarMovimiento = new frmAgregarCxC(Codigo, this);
                AgregarMovimiento.ShowDialog(this);
            }

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                frmrptReciboCuentasCobrar ReciboCuentaCobrar = new frmrptReciboCuentasCobrar(ObjetoCuenta.ImpresionComprobanteAbono(CuentaID));
                ReciboCuentaCobrar.ShowDialog(this);
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
                if (ClienteID.HasValue)
                {
                    Int64 Codigo = Convert.ToInt64(ClienteID);
                    CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                    dgvDetalle.AutoGenerateColumns = false;
                    dgvDetalle.DataSource = ObjetoCuenta.ListaPagoCargos(Referencia, Codigo);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al listar cargos o pagos relacionados al documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvDetalle_DoubleClick(object sender, EventArgs e)
        {


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
                CuentaID = Convert.ToInt64(dgvDetalle.Rows[e.RowIndex].Cells[0].Value);
                frmAgregarCxC VerCuenta = new frmAgregarCxC(CuentaID);
                VerCuenta.ShowDialog(this);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
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
                CuentaID = Convert.ToInt64(dgvCargosGenerales.Rows[e.RowIndex].Cells[0].Value);
                frmAgregarCxC VerCuenta = new frmAgregarCxC(CuentaID);
                VerCuenta.ShowDialog(this);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void btnImprimirEstadoGeneral_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmParametroEstadoCuentaCliente ParametrosEstadosCuenta = new frmParametroEstadoCuentaCliente(Codigo, "General");
                ParametrosEstadosCuenta.Text = "Estado de cuenta general";
                ParametrosEstadosCuenta.ShowDialog(this);
            }

        }

        private void btnImprimirEstadoDetallado_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmParametroEstadoCuentaCliente ParametrosEstadosCuenta = new frmParametroEstadoCuentaCliente(Codigo, "Detallado");
                ParametrosEstadosCuenta.Text = "Estado de cuenta detallado";
                ParametrosEstadosCuenta.ShowDialog(this);
            }
            else
            {
                frmParametroEstadoCuentaCliente ParametrosEstadosCuenta = new frmParametroEstadoCuentaCliente();
                ParametrosEstadosCuenta.Text = "Estado de cuenta detallado";
                ParametrosEstadosCuenta.ShowDialog(this);
            }
        }

        private void btnCobranzaGeneral_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmParametroCobranzaGeneral CobranzaGeneral = new frmParametroCobranzaGeneral(Codigo);
                CobranzaGeneral.ShowDialog(this);
            }
            else
            {
                frmParametroCobranzaGeneral CobranzaGeneral = new frmParametroCobranzaGeneral();
                CobranzaGeneral.ShowDialog(this);
            }
        }

        private void btnAntiguedadSaldo_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmParametroAntiguedadSaldo ParametroAntiguedadSaldo = new frmParametroAntiguedadSaldo(Codigo);
                ParametroAntiguedadSaldo.Text = "Antiguedad de Saldo";
                ParametroAntiguedadSaldo.ShowDialog(this);
            }
            else
            {
                frmParametroAntiguedadSaldoCuentaPagar ParametroAntiguedadSaldo = new frmParametroAntiguedadSaldoCuentaPagar();
                ParametroAntiguedadSaldo.Text = "Antiguedad de Saldo";
                ParametroAntiguedadSaldo.ShowDialog(this);
            }
        }

        private void btnReportePorConcepto_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmParametroReportePorConcepto ReportePorConcepto = new frmParametroReportePorConcepto(Codigo);
                ReportePorConcepto.ShowDialog(this);
            }
            else
            {
                frmParametroReportePorConcepto ReportePorConcepto = new frmParametroReportePorConcepto();
                ReportePorConcepto.ShowDialog(this);
            }
        }

        private void btnResumenMovimientos_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmParametroResumenCuentaCobrar ParametrosResumenCuentaCobrar = new frmParametroResumenCuentaCobrar(Codigo);
                ParametrosResumenCuentaCobrar.ShowDialog(this);
            }
            else
            {
                frmParametroResumenCuentaCobrar ParametrosResumenCuentaCobrar = new frmParametroResumenCuentaCobrar();
                ParametrosResumenCuentaCobrar.ShowDialog(this);
            }


        }

        private void btnAbonoPorPeriodo_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmParametroAbonosCuentaCobrar ParametrosResumenCuentaCobrar = new frmParametroAbonosCuentaCobrar(Codigo);
                ParametrosResumenCuentaCobrar.ShowDialog(this);
            }
            else
            {
                frmParametroAbonosCuentaCobrar ParametrosResumenCuentaCobrar = new frmParametroAbonosCuentaCobrar();
                ParametrosResumenCuentaCobrar.ShowDialog(this);
            }


        }

        private void btnEstadoCuentaDetallado_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmParametroEstadoCuentaCliente ParametrosEstadosCuenta = new frmParametroEstadoCuentaCliente(Codigo, "Detallado");
                ParametrosEstadosCuenta.Text = "Estado de cuenta detallado";
                ParametrosEstadosCuenta.ShowDialog(this);
            }
            else
            {
                frmParametroEstadoCuentaCliente ParametrosEstadosCuenta = new frmParametroEstadoCuentaCliente();
                ParametrosEstadosCuenta.Text = "Estado de cuenta detallado";
                ParametrosEstadosCuenta.ShowDialog(this);
            }
        }

        private void btnEstadoCuenta_Click(object sender, EventArgs e)
        {
            if (ClienteID.HasValue)
            {
                Int64 Codigo = Convert.ToInt64(ClienteID);
                frmParametroEstadoCuentaCliente ParametrosEstadosCuenta = new frmParametroEstadoCuentaCliente(Codigo, "General");
                ParametrosEstadosCuenta.Text = "Estado de cuenta general";
                ParametrosEstadosCuenta.ShowDialog(this);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Resultado = MessageBox.Show("Se procedera a eliminar el registro seleccionado y afectara las cuentas por cobrar, ¿Desea continuar?", "Eliminar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (Resultado == DialogResult.Yes)
                {
                    //CANCELACION DE DOCUMENTOS EN CUENTAS POR COBRAR
                    CuentasCobrarBL ObjetoCuenta = new CuentasCobrarBL();
                    cCuentasCobrar Cuenta = ObjetoCuenta.BuscarPorID(CuentaID);
                    ObjetoCuenta.CancelarDocumento(Cuenta);
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al cancelar transacción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    }




