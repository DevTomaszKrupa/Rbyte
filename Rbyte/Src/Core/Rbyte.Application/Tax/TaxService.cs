using Rbyte.Api.Models.Tax;
using Rbyte.Persistance;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public void Delete(int taxId)
        {
            throw new System.NotImplementedException();
        }

        public ApiTax Get(int taxId)
        {
            throw new System.NotImplementedException();
        }

        public List<ApiTax> Get()
        {
            throw new System.NotImplementedException();
        }

        public void Update(ApiTax model)
        {
            throw new System.NotImplementedException();
        }
    }
}