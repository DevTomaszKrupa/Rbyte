using Microsoft.EntityFrameworkCore;
using Rbyte.Persistance;
using System;

namespace Rbyte.Tests.Application
{
    public static class RbyteContextActionInvoker
    {
        public static void Invoke(Action<RbyteContext> action)
        {
            var builder = new DbContextOptionsBuilder<RbyteContext>()
                    .EnableSensitiveDataLogging()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            using (var context = new RbyteContext(builder.Options))
            {
                action.Invoke(context);
            }
        }
    }
}
