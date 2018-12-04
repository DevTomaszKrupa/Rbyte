using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rbyte.Application.Store.Update
{
    public class UpdateStoreModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
    }
}