using Rbyte.Application.Product.Create;
using Rbyte.Domain.Models.Product;
using Rbyte.Persistance;
using Shouldly;
using System.Linq;
using Xunit;

namespace Rbyte.Tests.Application.Product
{
    public class ProductServiceTests
    {
        [Fact]
        public void Create_OneProduct()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var apiProduct = new ProductDto
                {
                    Barcode = 1000,
                    Description = "fake_description",
                    FullPrice = 100m,
                    PriceWithoutMargin = 80m,
                    Name = "fake_name"
                };
                var sut = new ProductService(context);

                // Act
                sut.CreateAsync(apiProduct);

                // Assert
                var products = context.Products.ToArray();
                products.Length.ShouldBe(1);
                products[0].Barcode.ShouldBe(1000);
                products[0].Description.ShouldBe("fake_description");
                products[0].FullPrice.ShouldBe(100m);
                products[0].PriceWithoutMargin.ShouldBe(80m);
                products[0].Name.ShouldBe("fake_name");
            }

            RbyteContextActionInvoker.Invoke(Method);
        }
    }
}
