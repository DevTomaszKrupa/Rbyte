using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Common.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static List<string> GetAllErrorMessages(this ModelStateDictionary modelState)
        {
            var errorMessages = modelState.Values.SelectMany(x => x.Errors.Select(err => err.ErrorMessage)).ToList();
            return errorMessages;
        }
    }
}
