using AFORO255.MS.TEST.INVOICE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.INVOICE.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Factura> Facturas { get; set; }
        int SaveChanges();
    }
}