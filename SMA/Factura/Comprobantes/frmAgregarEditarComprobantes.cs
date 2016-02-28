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

namespace SMA.Factura.Comprobantes
{
    public partial class frmAgregarEditarComprobantes : Office2007Form
    {
        public Int32? ParametroID;

        public frmAgregarEditarComprobantes()
        {
            InitializeComponent();
        }

        public frmAgregarEditarComprobantes(Int32 ParametroID):this()
        {
            this.ParametroID = ParametroID;
        }

        private void frmAgregarEditarComprobantes_Load(object sender, EventArgs e)
        {
            CargarDependencias();
            if(ParametroID.HasValue)
            {
                //Mostramos la informacion del parametro
                Int32 ID = Convert.ToInt32(ParametroID);
                ParametroNCFBL ObjetoParametro = new ParametroNCFBL();
                MostrarDatos(ObjetoParametro.BuscarPorID(ID));
            }
            else
            {
                lblCodigo.Text = "-1";
            }
        }

        private void CargarDependencias()
        {
            try
            {
                //Lista tipos de comprobantes
                TipoComprobanteFiscalBL ObjetoTipo = new TipoComprobanteFiscalBL();
                cbbTipoComprobante.DataSource = ObjetoTipo.Listar();
                cbbTipoComprobante.ValueMember = "ID";
                cbbTipoComprobante.DisplayMember = "Descripcion";
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void MostrarDatos(cParametroNCF Parametro)
        {
            try
            {
                lblCodigo.Text = Parametro.ID.ToString();
                cbbTipoComprobante.SelectedValue = Convert.ToInt32(Parametro.ComprobanteID);
                dtpFechaCreacion.Value = Parametro.FechaCreacion;
                ckbEstatus.Checked = Convert.ToBoolean(Parametro.Estatus);
                txtContador.Text = Parametro.Contador.ToString();
                txtPrimerosCaracteres.Text = Parametro.NumeroInicial.ToString();
                txtCantidadComprobantes.Text = Parametro.Cantidad.ToString();
                txtUltimosCaracteres.Text = Parametro.UltimoNumero.ToString();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public cParametroNCF ObtenerDatos()
        {
            //Obtenemos los datos del parametro
            try
            {
                cParametroNCF Parametro = new cParametroNCF();
                Parametro.ID = Convert.ToInt32(lblCodigo.Text);
                Parametro.NumeroInicial = txtPrimerosCaracteres.Text;
                Parametro.FechaCreacion = dtpFechaCreacion.Value.Date;
                Parametro.FechaModificacion = dtpFechaCreacion.Value.Date;
                Parametro.Estatus = ckbEstatus.CheckState;
                Parametro.UltimoNumero = txtUltimosCaracteres.Text;
                Parametro.ComprobanteID = ObtenerComprobanteID();
                Parametro.Contador = Convert.ToInt32(txtContador.Text);
                Parametro.Cantidad = Convert.ToInt32(txtCantidadComprobantes.Text);
                Parametro.Estatus = ckbEstatus.CheckState;
                return Parametro;
            }
            catch(Exception Ex)
            {
                
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private Int32 ObtenerComprobanteID()
        {
            //Obtenemos el tipo de comprobante
            Int32 ID_;
            if(Int32.TryParse(cbbTipoComprobante.SelectedValue.ToString(), out ID_))
            {
                return Convert.ToInt32(cbbTipoComprobante.SelectedValue.ToString());
            }
            else
            {
                throw new Exception("Debe seleccionar el tipo de comprobante a ser agregado");
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ParametroNCFBL ObjetoParametro = new ParametroNCFBL();
                ObjetoParametro.GuardarCambios(ObtenerDatos());
                this.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
