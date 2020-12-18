using AFORO255.MS.TEST.INVOICE.Models;
using AFORO255.MS.TEST.INVOICE.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.INVOICE.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IContextDatabase _contextDatabase;

        public FacturaRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public Factura Get(int FacturaID)
        {
            return _contextDatabase.Facturas.FirstOrDefault(x => x.IdInvoice == FacturaID);
        }

        public IEnumerable<Factura> GetAll()
        {
            return _contextDatabase.Facturas.OrderBy(x => x.IdInvoice);
        }

        public bool Update(Factura factura)
        {
            _contextDatabase.Facturas.Update(factura);
            return _contextDatabase.SaveChanges() > 0;
        }
    }
}