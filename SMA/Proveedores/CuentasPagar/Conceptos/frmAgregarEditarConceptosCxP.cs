using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SMA.Entity;
using SMA.BL;

namespace SMA.Clientes.CuentasPagar.Conceptos
{
    public partial class frmAgregarEditarConceptosCxP : Office2007Form
    {
        private Int32? ConceptoID;
        private frmGestionConceptosCxP GestionConceptos;
        ConceptoCxPBL ObjetoConcepto = new ConceptoCxPBL();

        public frmAgregarEditarConceptosCxP()
        {
            InitializeComponent();
        }

        public frmAgregarEditarConceptosCxP(Int32 ConceptoID, frmGestionConceptosCxP GestionConceptos):this()
        {
            this.ConceptoID = ConceptoID;
            this.GestionConceptos = GestionConceptos;
        }

        public frmAgregarEditarConceptosCxP(frmGestionConceptosCxP GestionConceptos):this()
        {
            this.GestionConceptos = GestionConceptos;
        }

        private void frmAgregarEditarConceptosCxP_Load(object sender, EventArgs e)
        {
            if(ConceptoID.HasValue)
            {
                Int16 ID = Convert.ToInt16(ConceptoID);
                MostrarDatos(ObjetoConcepto.BuscarPorID(ID));
            }
            else
            {
                txtCodigo.Text = "-1";
            }
        }

        private void MostrarDatos(cConcepto Concepto)
        {
            txtCodigo.Text = Concepto.Codigo.ToString();
            txtDescripcion.Text = Concepto.Descripcion;

            //Referencia
            if (Concepto.Referencia == "N")
            {
                ckbConReferencia.Checked = false;
            }
            else if (Concepto.Referencia == "S")
            {
                ckbConReferencia.Checked = true;
            }

            //Concepto
            if (Concepto.Tipo == "C")
            {
                rbCargo.Checked = true;
            }
          
            else if (Concepto.Tipo == "A")
            {
                rbAbono.Checked = true;
            }

            rbAbono.Enabled = false;
            rbCargo.Enabled = false;

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ObjetoConcepto.GuardarCambios(ObtenerDatos());
                GestionConceptos.Refrescar();
                this.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error al guardar cambios de conceptos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private cConcepto ObtenerDatos()
        {
            cConcepto Concepto = new cConcepto();
            Concepto.Codigo = Convert.ToSByte(txtCodigo.Text);
            Concepto.Descripcion = txtDescripcion.Text;
            Concepto.Tipo = ObtenerTipo();
            Concepto.Referencia = ObtenerReferencia();
            Concepto.Notas = "Conceptos Manuales";

            return Concepto;
        }

        private string ObtenerReferencia()
        {
            if (ckbConReferencia.Checked == true)
            {
                return "S";
            }
            else
            {
                return "N";
            }
        }

        private String ObtenerTipo()
        {
            if (rbAbono.Checked)
            {
                return "A";
            }
            else if (rbCargo.Checked)
            {
                return "C";
            }
            else
            {
                return "C";
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
