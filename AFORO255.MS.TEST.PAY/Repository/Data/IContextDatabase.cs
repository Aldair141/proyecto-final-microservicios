using AFORO255.MS.TEST.PAY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Operacion> Operacion { get; set; }
        int SaveChanges();
    }
}