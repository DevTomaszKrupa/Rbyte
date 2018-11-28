using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Rbyte.Mvc.Extensions
{
    public static class ErrorsExtensions
    {
        public static List<string> GetAllErrorMessages(this ModelStateDictionary modelState)
        {
            var errorMessages = modelState.Values.SelectMany(x => x.Errors.Select(err => err.ErrorMessage)).ToList();
            return errorMessages;
        }
    }
}