using Rbyte.Application.Store;
using Rbyte.Domain.Models.Storehouse;
using Rbyte.Persistance;
using Shouldly;
using System.Linq;
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
                var apiHousestore = new StorehouseDto
                {
                    Name = "name"
                };

                //Act
                storehouseService.CreateAsync(apiHousestore);

                //Assert
                var storehouses = context.Stores.ToArray();
                storehouses.Length.ShouldBe(1);
                storehouses[0].Name.ShouldBe("name");
            }

            RbyteContextActionInvoker.Invoke(Method);
        }
    }
}
