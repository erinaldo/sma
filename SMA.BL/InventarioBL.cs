using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class InventarioBL
    {
        public void GuardarCambios(cInventario Inventario)
        {
            //Si el articulo existe procedemos a actualizarlo 
            //En caso contrario lo agregamos a la DB
         if(InventarioDA.Existe(Inventario.ID))
         {
             InventarioDA.Actualizar(Inventario);
         }
         else
         {
             InventarioDA.Crear(Inventario);
         }
        }

        public cInventario BuscarPorID(Int64 ID)
        {
            //REALIZAMOS UNA BUSQUEDA DEL ARTICULO POR SU CODIGO
            try
            {
                return InventarioDA.BuscarPorID(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public cInventario BuscarPorID(String ID)
        {
            try
            {
                return InventarioDA.BuscarPorID(ID);
            }
            catch (Exception Ex)
            {
                
                throw Ex;
            }
        }

        public void Eliminar(Int64 ID)
        {
            //Verificamos que el articulo no tenga existencia
            cInventario Inventario = BuscarPorID(ID);
            if (MovInventarioDA.Listar(Inventario.ID).Count > 1 && Inventario.Existencia > 0)
            {
                throw new Exception("El articulo posee movimiento y existencia, no es posible realizar la operacion");
            }
            else
            {
                try
                {
                    InventarioDA.Eliminar(ID);
                }
                catch(Exception Ex)
                {
                    throw Ex;
                }
            }
        }

        public List<cInventario> Listar()
        {
            return InventarioDA.Listar();
        }

        public Boolean Existe(string Codigo)
        {
            return InventarioDA.Existe(Codigo);
        }

        public  List<cInventario> Filtrar(string CodigoDesde,
                                               string CodigoHasta,
                                               Int32? FamiliaID,
                                               Int32? MarcaID,
                                               String TipoArticulo,
                                               Int32? IndicadorCreacion,
                                               Int32? IndicadorModificacion,
                                               DateTime? FechaDesde,
                                               DateTime? FechaHasta,
                                               String CriterioCantidad,
                                               Decimal Cantidad,
                                               String Descripcion)
        {
            try
            {
                return InventarioDA.Filtrar(CodigoDesde, CodigoHasta, FamiliaID, MarcaID, TipoArticulo, IndicadorCreacion, IndicadorModificacion, FechaDesde, FechaHasta, CriterioCantidad, Cantidad, Descripcion);
            }
            catch(Exception Ex)
            {
               
                throw Ex;
            }
        }

        public void ActualizarPrecios(Int32 IndPrecioPublico,
        Int32 IndPrecio2,
        Int32 IndPrecio3,
        Int32 IndPrecio4,
        Int32 IndPorcentaje,
        Int32 IndPorCosto,
        Int32 IndPorUltimoCosto,
        Int32 IndCostoPromedio,
        Int32 IndMonto,
        //Double Porcentaje,
        Decimal Monto,
        Int32? FamiliaID,
        Int32? MarcaID,
        String TipoProducto,
        DateTime? FechaDesde,
        DateTime? FechaHasta,
        String CodigoArticuloDesde,
        String CodigoArticuloHasta)
        {
            //Validamos que precio sera afectado
            if(IndPrecioPublico!=1 && IndPrecio2!=1 && IndPrecio3!=1 && IndPrecio4!=1)
            {
                throw new Exception("Debe Seleccionar al menos un precio a actualizar");
            }
            else if(IndPorCosto==1 &&(IndPorUltimoCosto!=1 && IndCostoPromedio!=1))
            {
                throw new Exception("Debe seleccionar al menos un costo como parametro");
            }
                else if(IndMonto!=1 && IndPorcentaje!=1)
            {
                throw new Exception("Debe indicador un metodo de actualizacion de precio");
            }
            else if(Monto<=0)
            {
                throw new Exception("Debe especificar un monto");
            }
                
            else
            {
            InventarioDA.ActualizarPrecios(IndPrecioPublico,
                                            IndPrecio2,
                                            IndPrecio3,
                                            IndPrecio4,
                                            IndPorcentaje,
                                            IndPorCosto,
                                            IndPorUltimoCosto,
                                            IndCostoPromedio,
                                            IndMonto,
                                            //Porcentaje,
                                            Monto,
                                            FamiliaID,
                                            MarcaID,
                                            TipoProducto,
                                            FechaDesde,
                                            FechaHasta,
                                            CodigoArticuloDesde,
                                            CodigoArticuloHasta);
            }
        }

        public List<cInventario> ReporteExistenciaCosto(String CodigoDesde, String CodigoHasta, Int32? FamiliaID, String OrdenadaPor)
        {
            try
            {
                return InventarioDA.ReporteExistenciaCosto(CodigoDesde, CodigoHasta, FamiliaID,OrdenadaPor);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

         public List<cInventario> ReporteCatalogoProductos(String CodigoDesde, String CodigoHasta, Int32? FamiliaID, Int32? MarcaID, String TipoArticulo, String OrdenadaPor)
        {
             try
             {
                 return InventarioDA.ReporteCatalogoProductos(CodigoDesde, CodigoHasta, FamiliaID, MarcaID, TipoArticulo, OrdenadaPor);
             }
             catch(Exception Ex)
             {
                 throw Ex;
             }
        }
         
        public List<cInventario> ReporteListaPrecios(String CodigoDesde, 
                                                    String CodigoHasta, 
                                                    Int32? FamiliaID, 
                                                    String IndicadorPrecio1, 
                                                    String  IndicadorPrecio2, 
                                                    Int32? ConExistencia, 
                                                    String TipoArticulo, 
                                                    String OrdenadaPor)
         {
            try
            {
                return InventarioDA.ReporteListaPrecios(CodigoDesde, CodigoHasta, FamiliaID, IndicadorPrecio1, IndicadorPrecio2, ConExistencia, TipoArticulo, OrdenadaPor);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
         }

        public List<cInventario> ReporteInventarioFisico(String CodigoDesde, String CodigoHasta, Int32? FamiliaID, Int32? MarcaID, String OrdenadaPor)
        {
            try
            {
                return InventarioDA.ReporteInventarioFisico(CodigoDesde, CodigoHasta, FamiliaID, MarcaID,OrdenadaPor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cInventario> ReporteProductosVencidos(String CodigoDesde, String CodigoHasta, Int32? Familia, Int32? Marca, String OrdenarPor, Int32? IndicadorVencimiento)
        {
            try
            {
                return InventarioDA.ReporteProductosVencidos(CodigoDesde, CodigoHasta, Familia, Marca, OrdenarPor, IndicadorVencimiento);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        
    }
}
