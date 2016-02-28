using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class ConceptoCxCBL
    {
        public void GuardarCambios(cConcepto Concepto)
        {
             //Si el concepto existe actualizamos
            if (ConcCxCDA.Existe(Concepto.ID))
            {
                try
                {
                    ConcCxCDA.Actualizar(Concepto);
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
                    ConcCxCDA.Crear(Concepto);
                }
                catch(Exception Ex)
                {
                    throw Ex;
                }
            }
        }

        public List<cConcepto> Listar()
        {

            try
            {
                return ConcCxCDA.Listar();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cConcepto BuscarPorID(int ID)
        {
            try
            {
                return ConcCxCDA.BuscarPorID(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cConcepto> ListarConceptoCargos()
        {
            var resultado = (from C in Listar()
                             where C.Tipo.ToString() == "Cargo"
                             && C.Automatico.ToString() == "Manual"
                             select C).ToList();

            return resultado;
        }

        public List<cConcepto> ListarConceptoAbono()
        {
            var resultado = (from C in Listar()
                             where C.Tipo.ToString() == "Abono"
                             && C.Automatico.ToString() == "Manual"
                             select C).ToList();

            return resultado;
        }

    }
}
