using System.Collections.Generic;
using Rbyte.Application.Product.Read;

namespace Rbyte.Application.Category.Details
{
    public class DetailsCategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<ReadProductModel> Products { get; set; }
    }
}