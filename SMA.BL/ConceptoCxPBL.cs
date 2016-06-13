using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class ConceptoCxPBL
    {
        public void GuardarCambios(cConcepto Concepto)
        {
            //Si el concepto existe actualizamos
            if (ConcCxPDA.Existe(Concepto.Codigo))
            {
                try
                {
                    ConcCxPDA.Actualizar(Concepto);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            else
            {
                try
                {
                    //Si no existe entonces lo creamos
                    ConcCxPDA.Crear(Concepto);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }

        public List<cConcepto> Listar()
        {

            try
            {
                return ConcCxPDA.Listar();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cConcepto BuscarPorID(Int16 ID)
        {
            try
            {
                return ConcCxPDA.BuscarPorID(ID);
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
