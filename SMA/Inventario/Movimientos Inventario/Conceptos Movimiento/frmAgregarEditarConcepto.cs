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

namespace SMA.Inventario.Movimientos_Inventario.Conceptos_Movimiento
{
    public partial class frmAgregarEditarConcepto : Office2007Form
    {
        private int? ConceptoID = null;

        public frmAgregarEditarConcepto()
        {
            InitializeComponent();
        }

        public frmAgregarEditarConcepto(int ConceptoID):this()
        {
            this.ConceptoID = ConceptoID;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();
                ObjetoConcepto.GuardarCambios(ObtenerDatos());
                this.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private cConcMovInvent ObtenerDatos()
        {
            cConcMovInvent Concepto = new cConcMovInvent();
            Concepto.Descripcion = txtDescripcion.Text;
            Concepto.Autom = IndicadorAutomatico();
            Concepto.Entrada = IndicadorTipoConcepto();
            Concepto.MovInterno = false;
            Concepto.Relacion = ObtenerRelacon();
            return Concepto;
        }

        private string ObtenerRelacon()
        {
            //OBTENEMOS LA RELACION DEL CONCEPTO
            if(rbCliente.Checked)
            {
                //CLIENTE
                return "C";
            }
            else if(rbProveedor.Checked)
            {
                //PROVEEDOR
                return "P";
            }
            else
            {
                return "N";
            }
        }

        private Boolean IndicadorAutomatico()
        {
            return false;
        }

        private Boolean IndicadorTipoConcepto()
        {
            if (rbEntrada.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbEntrada_Click(object sender, EventArgs e)
        {

        }

        private void rbSalida_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbEntrada_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbInterno_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbExterno_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmAgregarEditarConcepto_Load(object sender, EventArgs e)
        {
            //Si el codigo de concepto tiene valor buscamos el concepto
            if(ConceptoID.HasValue)
            {
                //Codigo de concepto
                int _ConceptoID = Convert.ToInt32(ConceptoID);
                ConcMovInvenBL ObjetoConcepto = new ConcMovInvenBL();
                //Mostramos los datos del conceptos seleccionado
                MostrarDatos(ObjetoConcepto.BuscarPorID(_ConceptoID));
                //Bloqueamos los campos no editables
                BloquearControles();   
            }
        }

        private void BloquearControles()
        {
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void MostrarDatos(cConcMovInvent Concepto)
        {
            txtCodigo.Text = Concepto.ID.ToString();
            txtDescripcion.Text = Concepto.Descripcion;

            //Tipo de movimiento
            if (Convert.ToBoolean(Concepto.Entrada))
            {
                rbEntrada.Checked=true;
            }
            else
            {
                rbSalida.Checked = true;
            }

            //Relacion con cliente
            if(Concepto.Relacion.ToString()=="C")
            {
                rbCliente.Checked = true;
            }
            
            //Relacion con proveedores
            if(Concepto.Relacion.ToString()=="P")
            {
                rbProveedor.Checked = true;
            }
        }
    }
}
