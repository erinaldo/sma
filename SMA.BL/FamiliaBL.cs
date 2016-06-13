using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class FamiliaBL
    {
        public void GuardarCambios(cFamilia Familia)
        {
            try
            {
                if (FamiliaDA.Existe(Familia.Codigo)) //Validamos que el elemento exista
                {
                    
                    if (Validacion(Familia))
                    {
                        FamiliaDA.Actualizar(Familia); //Actualizamos la familia
                    }
                    else
                    {
                        throw new Exception("Debe especificar una descripcion valida para la familia");
                    }
                }
                else
                {
                    if (Validacion(Familia)) 
                    {
                        FamiliaDA.Crear(Familia); //Agregamos una nueva familia
                    }
                    else
                    {
                        throw new Exception("Debe especificar una descripcion valida para la familia");
                    }
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public cFamilia BuscarPorID(int ID)
        {
            return FamiliaDA.BuscarPorID(ID);
        }

        private Boolean Validacion(cFamilia Familia)
        {
            //VALIDAMOS LA DESCRIPCION Y LA LONGITUD DEL CAMPO
            if(Familia.Descripcion!=null && Familia.Descripcion.Length>=5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<cFamilia> Listar()
        {
            return FamiliaDA.Listar();
        }

        public void Eliminar(int ID)
        {
            FamiliaDA.Eliminar(ID);
        }
    }
}
