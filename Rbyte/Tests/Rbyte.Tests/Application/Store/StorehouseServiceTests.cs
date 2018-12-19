using Rbyte.Api.Models.Store;
using Rbyte.Application.Store;
using Rbyte.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rbyte.Tests.Application.Store
{
    public class StorehouseServiceTests
    {
        [Fact]
        public void Create_OneStorehouse()
        {
            void Method(RbyteContext context)
            {
                //Arrange
                var storehouseService = new StorehouseService(context);
                var apiHousestore = new ApiStorehouse
                {
                    Name = "name"
                };

                //Act
                storehouseService.Create(apiHousestore);

                //Assert
                var storehouses = context.Stores.ToArray();
                storehouses.Length.ShouldBe(1);
                storehouses[0].Name.ShouldBe("name");
            }

            RbyteContextActionInvoker.Invoke(Method);
        }
    }
}
