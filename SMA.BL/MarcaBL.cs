using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class MarcaBL
    {

        public void GuardarCambios(cMarca Marca)
        {
            if (MarcaDA.Existe(Marca.Codigo))
            {
                if (Validacion(Marca))
                {
                    MarcaDA.Actualizar(Marca);
                }
                else
                {
                    throw new Exception("Debe especificar una descripcion valida para la marca");
                }
            }
            else
            {
                if(Validacion(Marca))
                {
                MarcaDA.Crear(Marca);
                }
                else
                {
                    throw new Exception("Debe especificar una descripcion valida para la marca");
                }
            }
        }

        private Boolean Validacion(cMarca Marca)
        {
            //Validacion de Campos
            if(Marca.Descripcion!=null && Marca.Descripcion.Length>=5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public cMarca BuscarPorID(int ID)
        {
            return MarcaDA.BuscarPorID(ID);
        }

        public List<cMarca> Listar()
        {
            return MarcaDA.Listar();
        }

        public void Eliminar(int ID)
        {
            MarcaDA.Eliminar(ID);
        }
    }
}
