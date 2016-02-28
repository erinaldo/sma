using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class RelacionCombosBL
    {
        public List<cRelacionCombos> Listar(Int64 InventarioID)
        {
            try
            {
                return RelacionCombosDA.Listar(InventarioID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void Crear(cRelacionCombos Relacion)
        {

            //Validamos el tipo de articulo que se desea agregar
            if (ValidacionTipoArticulo((Int64)Relacion.InventarioID))
            {
                //Verificamos si el articulo existe en el combo
                if (Existe((Int64)Relacion.InventarioID, (Int64)Relacion.InventComboID) == false)
                {
                    if (ValidacionAlmacen((Int64)Relacion.InventComboID, (Int32)Relacion.AlmacenID) == false)
                    {
                        //Asociamos el articulo al combo
                        try
                        {
                            RelacionCombosDA.Crear(Relacion);
                        }
                        catch (Exception Ex)
                        {
                            throw Ex;
                        }
                    }
                    else
                    {
                        //Arrojamos el aviso de que el articulo ya existe
                        throw new Exception("El almacen seleccionado es diferente al almacen de los demas articulo, seleccione el almacen correcto");
                    }
                }
                else
                {
                    //Arrojamos el aviso de que el articulo ya existe
                    throw new Exception("El articulo seleccionado ya esta asociado al Combo");
                }
            }
            else
            {
                //Arrojamos el aviso de que el articulo no es valido
                throw new Exception("El articulo seleccionado es un combo, no puede agregarse como parte del combo actual");
            }
        }

        public void ActualizarCantidad(Int64 InventarioID, Int64 InventarioComboID, Decimal Cantidad)
        {
                    try
                    {
                        RelacionCombosDA.ActualizarCantidad(InventarioID, InventarioComboID, Cantidad);
                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
            
        }
            
        

        public void Eliminar(Int64 InventarioID, Int64 InventarioComboID)
        {
            try
            {
                RelacionCombosDA.Eliminar(InventarioID, InventarioComboID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        //private Boolean Existe(int InventarioID)
        //{
        //    //Comprobamos si el articulo existe o no
            
        //}

        private Boolean Existe(Int64 InventarioID, Int64 InventarioComboID)
        {
            //Comprobamos si el articulo adicionado es de un almacen diferente al almacen de los articulos existentes
            return RelacionCombosDA.Existe(InventarioID, InventarioComboID);
        }

        private Boolean ValidacionTipoArticulo(Int64 InventarioID)
        {
            try
            {
                //Validamos el tipo de articulo a agregarse al combo, no se admiten combos.
                string TipoArticulo = InventarioDA.BuscarPorID(InventarioID).TipoArticulo;
          

            if(TipoArticulo!="C")
                {
                    return true;
                }
            else
                {
                    return false;
                }
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private Boolean ValidacionAlmacen(Int64 InventarioComboID, int AlmacenID)
        {
            return RelacionCombosDA.ValidacionAlmacen(InventarioComboID, AlmacenID);
        }
    }
}
