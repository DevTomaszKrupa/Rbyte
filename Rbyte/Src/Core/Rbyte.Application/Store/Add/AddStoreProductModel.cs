using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rbyte.Application.Store.Add
{
    public class AddStoreProductModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public int? ProductId { get; set; }
        public IEnumerable<SelectListItem> ProductSelectList { get; set; }
        public int Count { get; set; }
    }
}