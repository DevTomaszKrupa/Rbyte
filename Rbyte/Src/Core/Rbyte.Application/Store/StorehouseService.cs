using Rbyte.Api.Models.Store;
using Rbyte.Persistance;
using System;
using System.Collections.Generic;

namespace Rbyte.Application.Store
{
    public interface IStorehouseService
    {
        void Create(ApiStorehouse model);
        ApiStorehouse Get(int storehouseId);
        List<ApiStorehouse> Get();
        void Update(ApiStorehouse model);
        void Delete(int storehouseId);
    }
    public class StorehouseService : IStorehouseService
    {
        private readonly RbyteContext _context;
        public StorehouseService(RbyteContext context)
        {
            _context = context;
        }

        public void Create(ApiStorehouse model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int storehouseId)
        {
            throw new NotImplementedException();
        }

        public ApiStorehouse Get(int storehouseId)
        {
            throw new NotImplementedException();
        }

        public List<ApiStorehouse> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(ApiStorehouse model)
        {
            throw new NotImplementedException();
        }
    }
}