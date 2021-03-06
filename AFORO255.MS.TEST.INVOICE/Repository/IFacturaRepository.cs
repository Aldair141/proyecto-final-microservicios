﻿using AFORO255.MS.TEST.INVOICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.INVOICE.Repository
{
    public interface IFacturaRepository
    {
        IEnumerable<Factura> GetAll();
        bool Update(Factura factura);
        Factura Get(int FacturaID);
    }
}