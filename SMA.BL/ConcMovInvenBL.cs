using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;


namespace SMA.BL
{
    public class ConcMovInvenBL
    {
        public void GuardarCambios(cConcMovInvent Concepto)
        {
         
            //Si el concepto existe actualizamos
            if (ConcMovInventDA.Existe(Concepto.ID))
            {
                try
                {
                    ConcMovInventDA.Actualizar(Concepto);
                }
                catch(Exception Ex)
                {
                    throw Ex;
                }
            }
            else
            {
                try
                {
                    //Si no existe entonces lo creamos
                    ConcMovInventDA.Crear(Concepto);
                }
                catch(Exception Ex)
                {
                    throw Ex;
                }
            }
        }

        public List<cConcMovInvent> Listar()
        {
            try
            {
                return ConcMovInventDA.Listar();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
        
        public cConcMovInvent BuscarPorID(int ID)
        {
            try
            {
                return ConcMovInventDA.BuscarPorID(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cConcMovInvent>ListarConceptoEntrada()
        {
            var resultado = (from C in Listar()
                                        where C.Entrada.ToString()== "Entrada" 
                                        && C.Autom.ToString()=="Manual"
                                        && C.MovInterno.ToString()=="Externo"
                                        select C).ToList();

            return resultado;
        }

        public List<cConcMovInvent> ListarConceptoSalida()
        {
            var resultado = (from C in Listar()
                             where C.Entrada.ToString() == "Salida"
                             && C.Autom.ToString() == "Manual"
                             && C.MovInterno.ToString() == "Externo"
                             select C).ToList();

            return resultado;
        }
    }
}
