using AFORO255.MS.TEST.SECURITY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.SECURITY.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
