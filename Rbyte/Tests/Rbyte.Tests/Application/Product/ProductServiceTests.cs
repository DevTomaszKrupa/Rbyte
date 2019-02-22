using Rbyte.Application.Product.Create;
using Rbyte.Domain.Entities;
using Rbyte.Domain.Models.Product;
using Rbyte.Persistance;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Rbyte.Tests.Application.Product
{
    public class ProductServiceTests
    {
        [Fact]
        public void Create_OneProduct()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var apiProduct = new ProductDto
                {
                    Barcode = 1000,
                    Description = "description",
                    FullPrice = 100m,
                    PriceWithoutMargin = 80m,
                    Name = "name"
                };
                var sut = new ProductService(context);

                //Act
                await sut.CreateAsync(apiProduct);

                //Assert
                var products = context.Products.ToArray();
                products.Length.ShouldBe(1);
                products[0].Barcode.ShouldBe(1000);
                products[0].Description.ShouldBe("description");
                products[0].FullPrice.ShouldBe(100m);
                products[0].PriceWithoutMargin.ShouldBe(80m);
                products[0].Name.ShouldBe("name");
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Delete_ExistingProduct_DeletesProduct()
        {
            async Task Method(RbyteContext context)
            {
                //Arrange
                await context.Products.AddAsync(new DbProduct
                {
                    ProductId = 0,
                });
                await context.SaveChangesAsync();
                var sut = new ProductService(context);

                //Act
                await sut.DeleteAsync(0);

                //Assert
                context.Products.Any(x => x.ProducerId == 0).ShouldBe(false);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Delete_ProductNotExist_ThrowsException()
        {
            void Method(RbyteContext context)
            {
                //Arrange
                var sut = new ProductService(context);

                //Act
                Func<Task> f = async () => await sut.DeleteAsync(2);

                //Assert 
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }

        [Fact]
        public void GetById_ListOfItems_ReturnsItem()
        {
            async Task Method(RbyteContext context)
            {
                //Arrange
                var p1 = new DbProduct { ProductId = 0, Barcode = 1000, Description = "desc1", PriceWithoutMargin = 10m, FullPrice = 20m, Name = "name1" };
                var p2 = new DbProduct { ProductId = 1, Barcode = 2000, Description = "desc2", PriceWithoutMargin = 20m, FullPrice = 30m, Name = "name2" };
                var p3 = new DbProduct { ProductId = 2, Barcode = 3000, Description = "desc3", PriceWithoutMargin = 30m, FullPrice = 40m, Name = "name3" };
                await context.Products.AddAsync(p1);
                await context.Products.AddAsync(p2);
                await context.Products.AddAsync(p3);
                await context.SaveChangesAsync();
                var sut = new ProductService(context);

                //Act
                var product = await sut.GetAsync(1);

                //Assert
                product.Barcode.ShouldBe(2000);
                product.Description.ShouldBe("desc2");
                product.PriceWithoutMargin.ShouldBe(20m);
                product.FullPrice.ShouldBe(30m);
                product.Name.ShouldBe("name2");
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void GetById_EmptyList_ReturnsItem()
        {
            void Method(RbyteContext context)
            {
                //Arrange
                var sut = new ProductService(context);

                //Act
                Func<Task> f = async () => await sut.GetAsync(2);

                //Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }

        [Fact]
        public void Get_ListOfItems_ReturnsListOfItems()
        {
            async Task Method(RbyteContext context)
            {
                //Arrange
                var p1 = new DbProduct { ProductId = 0, Barcode = 1000, Description = "desc1", PriceWithoutMargin = 10m, FullPrice = 20m, Name = "name1" };
                var p2 = new DbProduct { ProductId = 1, Barcode = 2000, Description = "desc2", PriceWithoutMargin = 20m, FullPrice = 30m, Name = "name2" };
                var p3 = new DbProduct { ProductId = 2, Barcode = 3000, Description = "desc3", PriceWithoutMargin = 30m, FullPrice = 40m, Name = "name3" };
                await context.Products.AddAsync(p1);
                await context.Products.AddAsync(p2);
                await context.Products.AddAsync(p3);
                await context.SaveChangesAsync();
                var sut = new ProductService(context);

                //Act
                var products = await sut.GetAsync();

                //Assert
                var productArr = products.ToArray();
                productArr.Length.ShouldBe(3);
                productArr[0].Barcode.ShouldBe(1000);
                productArr[0].Description.ShouldBe("desc1");
                productArr[0].PriceWithoutMargin.ShouldBe(10m);
                productArr[0].FullPrice.ShouldBe(20m);
                productArr[0].Name.ShouldBe("name1");
                productArr[1].Barcode.ShouldBe(2000);
                productArr[1].Description.ShouldBe("desc2");
                productArr[1].PriceWithoutMargin.ShouldBe(20m);
                productArr[1].FullPrice.ShouldBe(30m);
                productArr[1].Name.ShouldBe("name2");
                productArr[2].Barcode.ShouldBe(3000);
                productArr[2].Description.ShouldBe("desc3");
                productArr[2].PriceWithoutMargin.ShouldBe(30m);
                productArr[2].FullPrice.ShouldBe(40m);
                productArr[2].Name.ShouldBe("name3");
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Get_EmptyList_ReturnsEmptyList()
        {
            async Task Method(RbyteContext context)
            {
                //Assert
                var sut = new ProductService(context);

                //Act
                var items =await sut.GetAsync();

                //Assert
                items.ToArray().Length.ShouldBe(0);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Update_ListWithUpdatingItem_UpdatesItem()
        {
            async Task Method(RbyteContext context)
            {
                //Arrange
                var p1 = new DbProduct { ProductId = 0, Barcode = 1000, Description = "desc1", PriceWithoutMargin = 10m, FullPrice = 20m, Name = "name1" };
                var p2 = new DbProduct { ProductId = 1, Barcode = 2000, Description = "desc2", PriceWithoutMargin = 20m, FullPrice = 30m, Name = "name2" };
                var p3 = new DbProduct { ProductId = 2, Barcode = 3000, Description = "desc3", PriceWithoutMargin = 30m, FullPrice = 40m, Name = "name3" };
                var p1forUpdate = new ProductDto { ProductId = 0, Barcode = 4000, Description = "updatedDesc", PriceWithoutMargin = 40m, FullPrice = 50m, Name = "updatedName" };
                await context.Products.AddAsync(p1);
                await context.Products.AddAsync(p2);
                await context.Products.AddAsync(p3);
                await context.SaveChangesAsync();
                var sut = new ProductService(context);

                //Act
                await sut.UpdateAsync(p1forUpdate);

                //Assert
                var product = context.Products.First(x => x.ProductId == 0);
                product.Barcode.ShouldBe(4000);
                product.Description.ShouldBe("updatedDesc");
                product.PriceWithoutMargin.ShouldBe(40m);
                product.FullPrice.ShouldBe(50m);
                product.Name.ShouldBe("updatedName");
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Update_ListWithoutUpdatingItem_ThrowsException()
        {
            void Method(RbyteContext context)
            {
                //Arrange
                var sut = new ProductService(context);
                var itemToUpdate = new ProductDto { ProductId = 0, Barcode = 1000, Description = "desc1", PriceWithoutMargin = 10m, FullPrice = 20m, Name = "name1" };

                //Act
                Func<Task> f = async () => await sut.UpdateAsync(itemToUpdate);

                //Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }
    }
}
