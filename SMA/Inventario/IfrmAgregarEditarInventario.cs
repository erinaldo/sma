using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Inventario
{
    interface IfrmAgregarEditarInventario
    {
        void SeleccionarFamilia(int ID); //Seleccion de familia de articulo
        void SeleccionarMarca(int ID);  //Seleccion de Marca de articulo
        void SeleccionarUnidadEntrada(int ID);  //Seleccion de unidad de entrada
        void SeleccionarUnidadSalida(int ID);   //Seleccion de unidad de salida
        void AgregarArticulo(Int64 InventarioID); //Agregar articulo de Combo
        void ModificarCantidad(Int64 InventarioID, Decimal Cantidad); //Modificar cantidad de articulo en combo
        void Refrescar();        //Refrescar articulos de combo
        void SeleccionarProveedor1(Int64 ID);
        void SeleccionarProveedor2(Int64 ID);
    }
}
