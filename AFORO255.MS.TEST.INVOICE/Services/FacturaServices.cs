using AFORO255.MS.TEST.INVOICE.Models;
using AFORO255.MS.TEST.INVOICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.INVOICE.Services
{
    public class FacturaServices : IFacturaServices
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaServices(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public Factura Get(int FacturaID)
        {
            return _facturaRepository.Get(FacturaID);
        }

        public IEnumerable<Factura> GetAll()
        {
            return _facturaRepository.GetAll();
        }

        public bool Update(Factura factura)
        {
            return _facturaRepository.Update(factura);
        }
    }
}