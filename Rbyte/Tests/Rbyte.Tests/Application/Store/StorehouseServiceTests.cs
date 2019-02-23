using Rbyte.Application.Store;
using Rbyte.Domain.Entities;
using Rbyte.Domain.Models.Storehouse;
using Rbyte.Persistance;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Rbyte.Tests.Application.Store
{
    public class StorehouseServiceTests
    {
        [Fact]
        public void Create_OneStorehouse()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var sut = new StorehouseService(context);
                var apiStorehouse = new StorehouseDto { StorehouseId = 1, Name = "name" };

                // Act
                await sut.CreateAsync(apiStorehouse);

                // Assert
                var storehouse = context.Stores.ToArray();
                storehouse.Length.ShouldBe(1);
                storehouse[0].Name.ShouldBe("name");
                storehouse[0].StoreId.ShouldBe(0);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Delete_ExistingStorehouse_DeletesStorehouse()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                context.Stores.Add(new DbStore
                {
                    StoreId = 1
                });
                context.SaveChanges();
                var sut = new StorehouseService(context);

                // Act
                await sut.DeleteAsync(1);

                // Assert
                context.Stores.Any(x => x.StoreId == 1).ShouldBe(false);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Delete_StorehouseNotExist_DeletesStorehouse()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var sut = new StorehouseService(context);

                // Act
                Func<Task> f = async () => await sut.DeleteAsync(3);

                // Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }

        [Fact]
        public void GetById_ListOfItems_ReturnsSelectedItem()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var s1 = new DbStore { StoreId = 1, Name = "name1" };
                var s2 = new DbStore { StoreId = 2, Name = "name2" };
                var s3 = new DbStore { StoreId = 3, Name = "name3" };
                context.Stores.Add(s1);
                context.Stores.Add(s2);
                context.Stores.Add(s3);
                context.SaveChanges();
                var sut = new StorehouseService(context);

                // Act
                var store = await sut.GetAsync(2);

                // Assert
                store.Name.ShouldBe("name2");
                store.StorehouseId.ShouldBe(2);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void GetById_EmptyList_ThrowsException()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var sut = new StorehouseService(context);

                // Act
                Func<Task> f= async () => await sut.GetAsync(2);

                // Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }

        [Fact]
        public void Get_ListOfItems_ReturnsListOfItems()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var s1 = new DbStore { StoreId = 1, Name = "name1" };
                var s2 = new DbStore { StoreId = 2, Name = "name2" };
                var s3 = new DbStore { StoreId = 3, Name = "name3" };
                context.Stores.Add(s1);
                context.Stores.Add(s2);
                context.Stores.Add(s3);
                context.SaveChanges();
                var sut = new StorehouseService(context);

                // Act
                var stores = await sut.GetAsync();

                // Assert
                var storeArr = stores.ToArray();
                storeArr.Length.ShouldBe(3);
                storeArr[0].Name.ShouldBe("name1");
                storeArr[0].StorehouseId.ShouldBe(1);
                storeArr[1].Name.ShouldBe("name2");
                storeArr[1].StorehouseId.ShouldBe(2);
                storeArr[2].Name.ShouldBe("name3");
                storeArr[2].StorehouseId.ShouldBe(3);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Get_EmptyList_ReturnsEmptyList()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var sut = new StorehouseService(context);

                // Act
                var result = await sut.GetAsync();

                // Assert
                result.ToArray().Length.ShouldBe(0);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Update_ListWithUpdatingItem_UpdatesItem()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var s1 = new DbStore { StoreId = 1, Name = "name1" };
                var s2 = new DbStore { StoreId = 2, Name = "name2" };
                var s3 = new DbStore { StoreId = 3, Name = "name3" };
                context.Stores.Add(s1);
                context.Stores.Add(s2);
                context.Stores.Add(s3);
                context.SaveChanges();
                var s2ForUpdate = new StorehouseDto { StorehouseId = 2, Name = "updatedName" };
                var sut = new StorehouseService(context);

                // Act
                await sut.UpdateAsync(s2ForUpdate);

                // Assert
                var store = context.Stores.First(x => x.StoreId == 2);
                store.Name.ShouldBe("name2");
                store.StoreId.ShouldBe(2);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Update_ListWithoutUpdatingItem_ThrowsException()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var itemToUpdate = new StorehouseDto { StorehouseId = 1, Name = "updatedName" };
                var sut = new StorehouseService(context);

                // Act
                Func<Task> f = async () => await sut.UpdateAsync(itemToUpdate);
                 
                // Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }
    }
}
