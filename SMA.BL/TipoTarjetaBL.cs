﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
public    class TipoTarjetaBL
    {
    public List<cTipoTarjeta> Listar()
    {
        try
        {
            return TipoTarjetaDA.Listar();
        }
        catch(Exception Ex)
        {
            return null;
            throw Ex;
        }
    }
    }
}