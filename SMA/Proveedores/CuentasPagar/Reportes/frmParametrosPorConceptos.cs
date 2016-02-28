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

namespace SMA.Clientes.CuentasPagar.Reportes
{
    public partial class frmParametrosPorConceptos : Office2007Form
    {
        private Int64? ProveedorID;
        private Int64 ProveedorDesde;
        private Int64 ProveedorHasta;
        private DateTime? FechaDesde = null;
        private DateTime? FechaHasta = null;
        private String CriterioCantidad;
        private String Conceptos;
        private Double ValorMonto;

        public frmParametrosPorConceptos()
        {
            InitializeComponent();
        }

        public frmParametrosPorConceptos(Int32 ProveedorID):this()
        {
            this.ProveedorID = ProveedorID;
        }

        private void frmParametrosPorConceptos_Load(object sender, EventArgs e)
        {
            CargarDependencias();
        }

        private void CargarDependencias()
        {
            //Cliente
            ProveedorBL ObjetoProveedor = new ProveedorBL();
            if (ProveedorID.HasValue)
            {
                //Si el parametro de Proveedor tiene algun valor entonces filtramos al Proveedor seleccionado para que
                //solo muestre informacion de este
                Int32 Codigo = Convert.ToInt32(ProveedorID);
                cbbProveedorDesde.DataSource = ObjetoProveedor.Filtrar(Codigo, Codigo, null, null);
                cbbProveedorHasta.DataSource = ObjetoProveedor.Filtrar(Codigo, Codigo, null, null);
            }
            else
            {
                cbbProveedorDesde.DataSource = ObjetoProveedor.Listar();
                cbbProveedorHasta.DataSource = ObjetoProveedor.Listar();

            }
            cbbProveedorDesde.ValueMember = "ID";
            cbbProveedorHasta.ValueMember = "ID";
            cbbProveedorDesde.DisplayMember = "NombreComercial";
            cbbProveedorHasta.DisplayMember = "NombreComercial";

            //Conceptos
            ConceptoCxPBL ObjetoConcepto = new ConceptoCxPBL();
            lbConceptos.DataSource = ObjetoConcepto.Listar();
            lbConceptos.DisplayMember = "Descripcion";
            lbConceptos.ValueMember = "ID";
        }

        private void rbTodosConceptos_CheckedChanged(object sender, EventArgs e)
        {
            //Deshabilita y habilita la lista de conceptos
            if (rbTodosConceptos.Checked)
            {
                lbConceptos.Enabled = false;
            }
            else
            {
                lbConceptos.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                CuentasPagarBL Cuenta = new CuentasPagarBL();
                ObtenerDatos();
                List<cCuentasPagar> Lista = Cuenta.ReportePorConcepto(ProveedorDesde, ProveedorHasta, FechaDesde, FechaHasta, CriterioCantidad, Conceptos, ValorMonto);
                frmrptPorConcepto ReportePorConcepto = new frmrptPorConcepto(Lista);
                ReportePorConcepto.ShowDialog(this);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ObtenerDatos()
        {
            //Obtenemos los datos para el query
            try
            {
                ProveedorDesde = Convert.ToInt64(cbbProveedorDesde.SelectedValue.ToString());
                ProveedorHasta = Convert.ToInt64(cbbProveedorHasta.SelectedValue.ToString());
                CriterioCantidad = ObtenerCriterio();
                ValorMonto = ObtenerMontos();
                Conceptos = ObtenerConceptos();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private string ObtenerCriterio()
        {
            if (cbCriterio.Text != String.Empty)
            {
                return cbCriterio.Text;
            }
            else
            {
                return "Todos";
            }
        }

        private String ObtenerConceptos()
        {



            try
            {
                String Item;
                StringBuilder strCategory = new StringBuilder();
                String Resultado;

                //Recorremos los elementos seleccionados
                foreach (int Ind in lbConceptos.SelectedIndices)
                {
                    Item = (lbConceptos.Items[Ind] as cConcepto).Descripcion.ToString();

                    //strCategory.Append("'");
                    strCategory.Append(Item);
                    //strCategory.Append("'");
                    strCategory.Append(",");

                }

                if (strCategory.ToString() != String.Empty)
                {
                    //Convertimos en una cadena
                    Resultado = strCategory.ToString();
                    //Eliminamos la ultima coma para evitar errores
                    Resultado = Resultado.TrimEnd(new char[] { ',' });
                }
                else
                {
                    Resultado = null;
                }

                return Resultado;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        private double ObtenerMontos()
        {
            //Obtener montos de criterios
            Double Monto;
            if (txtMonto.Text != String.Empty)
            {
                if (Double.TryParse(txtMonto.Text, out Monto))
                {
                    return Convert.ToDouble(txtMonto.Text);
                }
                else
                {
                    return 0.00;
                }
            }
            else
            {
                return 0.00;
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FechaDesde = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FechaHasta = dtpFechaHasta.Value;
        }

    }
}
