using Rbyte.Application.Product.Read;
using System.Collections.Generic;

namespace Rbyte.Application.Store.Details
{
    public class DetailsStoreModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public List<ReadProductModel> Products { get; set; }
    }
}