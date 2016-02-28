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

namespace SMA.Clientes.CuentasCobrar.Reportes
{
    public partial class frmParametroReportePorConcepto : Office2007Form
    {
        private Int64? ClienteID;
        private DateTime? FechaDesde=null;
        private DateTime? FechaHasta=null;

        public frmParametroReportePorConcepto()
        {
            InitializeComponent();
        }

        public frmParametroReportePorConcepto(Int64 ClienteID):this()
        {
            this.ClienteID = ClienteID;
        }

        private void frmParametroReportePorConcepto_Load(object sender, EventArgs e)
        {
            CargarDependencias();
            BloquearConceptos();
        }

        private void CargarDependencias()
        {
            ClienteBL ObjetoCliente = new ClienteBL();

            Int64 Codigo = Convert.ToInt64(ClienteID);
            cbbClienteDesde.DataSource = ObjetoCliente.Listar();
            cbbClienteHasta.DataSource = ObjetoCliente.Listar();

            cbbClienteDesde.ValueMember = "ID";
            cbbClienteHasta.ValueMember = "ID";
            cbbClienteDesde.DisplayMember = "NombreComercial";
            cbbClienteHasta.DisplayMember = "NombreComercial";

            //Colocamos en seleccion al cliente 
            if (ClienteID.HasValue)
            {
                cbbClienteDesde.SelectedValue = ClienteID;
                cbbClienteHasta.SelectedValue = ClienteID;
            }
            
            
            //Conceptos
            ConceptoCxCBL ObjetoConcepto=new ConceptoCxCBL();
            lbConceptos.DataSource=ObjetoConcepto.Listar();
            lbConceptos.DisplayMember="Descripcion";
            lbConceptos.ValueMember="ID";
        }

        private void rbTodosConceptos_CheckedChanged(object sender, EventArgs e)
        {
            BloquearConceptos();
        }

        private void BloquearConceptos()
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
                CuentasCobrarBL Cuenta = new CuentasCobrarBL();
                Int64? ClienteDesde = ObtenerCliente(cbbClienteDesde.SelectedValue);
                Int64? ClienteHasta = ObtenerCliente(cbbClienteHasta.SelectedValue);
                String CriterioCantidad = ObtenerCriterio();
                Decimal ValorMonto = ObtenerMontos();
                String Conceptos = ObtenerConceptos();
                List<cCuentasCobrar> Lista = Cuenta.ReportePorConcepto(ClienteDesde, ClienteHasta, FechaDesde, FechaHasta, CriterioCantidad, Conceptos, ValorMonto);
                frmrptPorConcepto ReportePorConcepto = new frmrptPorConcepto(Lista);
                ReportePorConcepto.ShowDialog(this);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private Int64? ObtenerCliente(object p)
        {
            if(p!=null)
            {
                Int64 Codigo;
                if(Int64.TryParse(p.ToString(),out Codigo))
                {
                    return Convert.ToInt64(p.ToString());
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ObtenerDatos()
        {
            //Obtenemos los datos para el query
            try
            {
                
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private string ObtenerCriterio()
        {
            if(cbCriterio.Text!=String.Empty)
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
            if (rbTodosConceptos.Checked)
            {
                return null;
            }

            else
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
        }

        private Decimal ObtenerMontos()
        {
            //Obtener montos de criterios
            Decimal Monto;
            if (txtMonto.Text != String.Empty)
            {
                if (Decimal.TryParse(txtMonto.Text, out Monto))
                {
                    return Convert.ToDecimal(txtMonto.Text);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
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

        private void rbSeleccion_CheckedChanged(object sender, EventArgs e)
        {

        }

       
    }
}
