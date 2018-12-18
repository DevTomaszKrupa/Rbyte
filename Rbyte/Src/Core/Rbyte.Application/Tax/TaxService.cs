using Rbyte.Api.Models;
using Rbyte.Api.Models.Product;
using Rbyte.Api.Models.Tax;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Tax
{
    public interface ITaxService
    {
        void Create(ApiTax model);
        ApiTax Get(int taxId);
        List<ApiTax> Get();
        void Update(ApiTax model);
        void Delete(int taxId);
    }
    public class TaxService : ITaxService
    {
        private readonly RbyteContext _context;
        public TaxService(RbyteContext context)
        {
            _context = context;
        }

        public void Create(ApiTax model)
        {
            var dbTax = new DbTax()
            {
                Value = model.Value
            };
            _context.Taxes.Add(dbTax);
            _context.SaveChanges();
        }

        public void Delete(int taxId)
        {
            var dbTax = _context.Taxes.Where(x => x.TaxId == taxId).First();
            _context.Taxes.Remove(dbTax);
            _context.SaveChanges();
        }

        public ApiTax Get(int taxId)
        {
            var dbTax = _context.Taxes.First(x => x.TaxId == taxId);
            return new ApiTax
            {
                TaxId = dbTax.TaxId,
                Value = dbTax.Value
            };
        }

        public List<ApiTax> Get()
        {
            return _context.Taxes.Select(x => new ApiTax
            {
                TaxId = x.TaxId,
                Value = x.Value
            }).ToList();
        }

        public void Update(ApiTax model)
        {
            var dbTax = _context.Taxes.First(x => x.TaxId == model.TaxId);
            dbTax.Value = model.Value;
            _context.SaveChanges();
        }
    }
} 