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
    public partial class frmAgregarEditarConceptos : Office2007Form
    {
        private int? ConceptoID;
        private frmGestionConceptosCxC GestionConceptos;

        public frmAgregarEditarConceptos()
        {
            InitializeComponent();
        }

        public frmAgregarEditarConceptos(int ConceptoID):this()
        {
            this.ConceptoID = ConceptoID;
        }

        public frmAgregarEditarConceptos(frmGestionConceptosCxC GestionConceptos):this()
        {
            this.GestionConceptos = GestionConceptos;
        }

        public frmAgregarEditarConceptos(frmGestionConceptosCxC GestionConceptos, int ConceptoID):this()
        {
            this.GestionConceptos = GestionConceptos;
            this.ConceptoID = ConceptoID;
        }
        private void frmAgregarEditarConceptos_Load(object sender, EventArgs e)
        {
            if(ConceptoID.HasValue)
            {
                Int16 ID = Convert.ToInt16(ConceptoID);
                ConceptoCxCBL ObjetoConcepto = new ConceptoCxCBL();
                MostrarDatos(ObjetoConcepto.BuscarPorID(ID));
            }
            else
            {
                txtCodigo.Text = "-1";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcion.Text != string.Empty)
                {
                    ConceptoCxCBL ObjetoConcepto = new ConceptoCxCBL();
                    ObjetoConcepto.GuardarCambios(ObtenerDatos());
                    GestionConceptos.Refrescar();
                    this.Close();
                }
                else
                {
                    errorProvider1.SetError(txtDescripcion, "Debe especificar una descripcion para el concepto");
                    MessageBox.Show("Debe especificar una descripcion para el concepto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error al guardar cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MostrarDatos(cConcepto Concepto)
        {
            txtCodigo.Text = Concepto.Codigo.ToString();
            txtDescripcion.Text = Concepto.Descripcion;
            
            //Referencia
            if(Concepto.Referencia=="N")
            {
                ckbConReferencia.Checked = false;
            }
            else if(Concepto.Referencia=="S")
            {
                ckbConReferencia.Checked = true;
            }
            
            //Concepto
            if(Concepto.Tipo=="C")
            {
                rbCargo.Checked = true;
            }
            else if(Concepto.Tipo=="A")
            {
                rbAbono.Checked = true;
            }

            rbAbono.Enabled = false;
            rbCargo.Enabled = false;

        }

        private cConcepto ObtenerDatos()
        {
            cConcepto Concepto = new cConcepto();
            Concepto.Codigo = Convert.ToInt16(txtCodigo.Text);
            Concepto.Descripcion = txtDescripcion.Text;
            Concepto.Tipo=ObtenerTipo();
            Concepto.Referencia = ObtenerReferencia();
            Concepto.Notas = "Conceptos Manuales";

            return Concepto;
        }

        private string ObtenerReferencia()
        {
           if(ckbConReferencia.Checked==true)
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
            else if(rbCargo.Checked)
            {
                return "C";
            }
            else
            {
                return "C";
            }
        }
    }
}
