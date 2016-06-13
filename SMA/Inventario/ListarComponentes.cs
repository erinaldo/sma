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

namespace SMA.Inventario
{
    public partial class frmListarComponentes : Office2007Form
    {
        public string TipoComponente;
        private int ComponenteID;

        public frmListarComponentes()
        {
            InitializeComponent();
        }

        public frmListarComponentes(string TipoComponente):this()
        {
            this.TipoComponente = TipoComponente;
        }

        //Binding source de componentes
        BindingSource BDcomponentes = new BindingSource();
            

        private void ListarComponentes_Load(object sender, EventArgs e)
        {
            CargarDatos();
            
        }

        private void CargarDatos()
        {
            dgvComponente.AutoGenerateColumns = false;

            if (TipoComponente == "Familia")
            {
                //Cargamos la lista de familias
                FamiliaBL Familias = new FamiliaBL();
                BDcomponentes.DataSource = Familias.Listar();
                dgvComponente.DataSource = BDcomponentes;
                this.Text = "Lista Familias Articulos";
            }
            else if (TipoComponente == "Marca")
            {
                //Cargamos la lista de Marca
                MarcaBL Marcas = new MarcaBL();
                BDcomponentes.DataSource = Marcas.Listar();
                dgvComponente.DataSource = BDcomponentes;
                this.Text = "Lista Marcas Articulos";
            }
            else if (TipoComponente == "UnidadEntrada")
            {
                UnidadInventarioBL UnidadEntrada = new UnidadInventarioBL();
                BDcomponentes.DataSource = UnidadEntrada.Listar();
                dgvComponente.DataSource = BDcomponentes;
                this.Text = "Lista unidad de entrada";
            }
            else if (TipoComponente == "UnidadSalida")
            {
                UnidadInventarioBL UnidadSalida = new UnidadInventarioBL();
                BDcomponentes.DataSource = UnidadSalida.Listar();
                dgvComponente.DataSource = BDcomponentes;
                this.Text = "Lista unidad de salida";
            }
        }

        private void dgvComponente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ComponenteID = Convert.ToInt32(dgvComponente.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }



        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
             String Descripcion = txtBusqueda.Text;

            if (TipoComponente == "Familia")
                    {
                    //Buscamos Familia
                    var obj = BDcomponentes.List.OfType<cFamilia>().ToList().Find(f => f.Descripcion == Descripcion);
                    var pos = BDcomponentes.IndexOf(obj);               
                    BDcomponentes.Position = pos;
                    }
                    else if (TipoComponente == "Marca")
                    {
                        //Buscamos Marca
                        var obj = BDcomponentes.List.OfType<cMarca>().ToList().Find(f => f.Descripcion == Descripcion);
                        var pos = BDcomponentes.IndexOf(obj);
                        BDcomponentes.Position = pos;
                    }
                    else if(TipoComponente=="UnidadEntrada")
                    {
                        //Buscamos Unidad Entrada
                        var obj = BDcomponentes.List.OfType<cUnidadInventario>().ToList().Find(f => f.Descripcion == Descripcion);
                        var pos = BDcomponentes.IndexOf(obj);
                        BDcomponentes.Position = pos;
                    }
                    else if(TipoComponente=="UnidadSalida")
                    {
                        //Buscamos Unidad Salida
                        var obj = BDcomponentes.List.OfType<cUnidadInventario>().ToList().Find(f => f.Descripcion == Descripcion);
                        var pos = BDcomponentes.IndexOf(obj);
                        BDcomponentes.Position = pos;
                    }
            
        }

        private void dgvComponente_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //evita el error al tratar de reordenar la lista
                if (e.RowIndex == -1)
                {
                    return;
                }
                //Codigo  que se obtiene desde el grid
                ComponenteID = Convert.ToInt32(dgvComponente.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

       

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                //Refresca los cambios realizados en la tabla de clientes en el formulario de muestra
                IfrmAgregarEditarInventario FormInterface = this.Owner as IfrmAgregarEditarInventario;

                if (FormInterface != null)
                {


                    if (TipoComponente == "Familia")
                    {
                        //LLamamos el componente de Familia
                        FormInterface.SeleccionarFamilia(ComponenteID);
                    }
                    else if (TipoComponente == "Marca")
                    {
                        //Llamamos el componente Marca
                        FormInterface.SeleccionarMarca(ComponenteID);
                    }
                    else if (TipoComponente == "UnidadEntrada")
                    {
                        //Llamamos el componente Unidad Entrada
                        FormInterface.SeleccionarUnidadEntrada(ComponenteID);
                    }
                    else if (TipoComponente == "UnidadSalida")
                    {
                        //Llamamos el componente Unidad Salida
                        FormInterface.SeleccionarUnidadSalida(ComponenteID);
                    }
                }

                //INTERFASE DE VENTANAS DE BUSQUEDA

                IGeneral FormInterface2 = this.Owner as IGeneral;

                if (FormInterface2 != null)
                {
                    if (TipoComponente == "Familia")
                    {
                        //LLamamos el componente de Familia
                        FormInterface2.SeleccionarFamilia(ComponenteID);
                    }
                    else if (TipoComponente == "Marca")
                    {
                        //Llamamos el componente Marca
                        FormInterface2.SeleccionarMarca(ComponenteID);
                    }
                }

                Compras.iGestionDocumentoCompras FormInterfaseGestionCompras = this.Owner as Compras.iGestionDocumentoCompras;
                if(FormInterfaseGestionCompras!=null)
                {
                    FormInterfaseGestionCompras.SeleccionFamilia(ComponenteID);
                }


                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListarComponentes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtBusqueda.Text.Length >= 10 && dgvComponente.RowCount==0)
                {
                    //AGREGAMOS FAMILIA
                    if (TipoComponente=="Familia")
                    {
                    DialogResult result = MessageBox.Show("La busqueda no arrojado ningun resultado, ¿Desea agregar " + txtBusqueda.Text + " a la lista de familias", "Agregar nueva familia", MessageBoxButtons.YesNoCancel);

                        if (result == DialogResult.Yes)
                    
                        {
                            try
                            {
                                FamiliaBL ObjetoFamilia = new FamiliaBL();
                                //ASIGNAMOS VALORES A LA FAMILIA
                                cFamilia Familia = new cFamilia();
                                Familia.Codigo = -1;
                                Familia.Descripcion = txtBusqueda.Text;
                                Familia.Notas = "";
                                //AGREGAMOS LA FAMILIA
                                ObjetoFamilia.GuardarCambios(Familia);
                                //ACTUALIZAMOS EL GRID
                                CargarDatos();
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.Message);
                            }
                        }

                    }
                    else if(TipoComponente=="Marca")
                    {
                        DialogResult result = MessageBox.Show("La busqueda no arrojado ningun resultado, ¿Desea agregar " + txtBusqueda.Text + " a la lista de marcas", "Agregar nueva marca", MessageBoxButtons.YesNoCancel);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MarcaBL ObjetoMarca = new MarcaBL();
                                //ASIGNAMOS VALORES A LA FAMILIA
                                cMarca Marca = new cMarca();
                                Marca.Codigo = -1;  
                                Marca.Descripcion = txtBusqueda.Text;
                                Marca.Notas = "";
                                //AGREGAMOS LA FAMILIA
                                ObjetoMarca.GuardarCambios(Marca);
                                //ACTUALIZAR GRID
                                CargarDatos();
                            }
                                catch(Exception Ex)
                            {
                                MessageBox.Show(Ex.Message);
                            }
                           
                        }
                    }


                }
            }
        }
    }
}
