using Rbyte.Application.Category;
using Rbyte.Domain.Entities;
using Rbyte.Domain.Models.Category;
using Rbyte.Persistance;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Rbyte.Tests.Application.Category
{
    public class CategoryServiceTests
    {
        [Fact]
        public void Create_OneCategory()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var sut = new CategoryService(context);
                var apiCategory = new CategoryDto
                {
                    Description = "description",
                    Name = "name",
                };

                // Act
                await sut.CreateAsync(apiCategory);

                //Assert
                var categories = context.Categories.ToArray();
                categories.Length.ShouldBe(1);
                categories[0].Name.ShouldBe("name");
                categories[0].Description.ShouldBe("description");
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Delete_CategoryExist_DeletesCategory()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                context.Categories.Add(new DbCategory
                {
                    CategoryId = 1,
                    Description = "desc",
                    Name = "name"
                });
                context.SaveChanges();
                var sut = new CategoryService(context);

                // Act
                await sut.DeleteAsync(1);

                //Assert
                context.Categories.Any(x => x.CategoryId == 1).ShouldBe(false);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Delete_CategoryNotExist_ThrowsException()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var sut = new CategoryService(context);

                // Act
                Func<Task> f = async () => { await sut.DeleteAsync(1); };

                //Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }

        [Fact]
        public void GetById_ListOfItems_ReturnsItemSelectedById()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var c1 = new DbCategory { CategoryId = 1, Description = "desc1", Name = "name1" };
                var c2 = new DbCategory { CategoryId = 2, Description = "desc2", Name = "name2" };
                var c3 = new DbCategory { CategoryId = 3, Description = "desc3", Name = "name3" };
                await context.Categories.AddAsync(c1);
                await context.Categories.AddAsync(c2);
                await context.Categories.AddAsync(c3);
                await context.SaveChangesAsync();
                var sut = new CategoryService(context);

                // Act
                var result = await sut.GetAsync(2);

                //Assert
                result.CategoryId.ShouldBe(2);
                result.Description.ShouldBe("desc2");
                result.Name.ShouldBe("name2");
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void GetById_EmptyList_ThrowsException()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var sut = new CategoryService(context);

                // Act

                Func<Task> f = async () => { await sut.GetAsync(103); };

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
                // Arrange
                var c1 = new DbCategory { CategoryId = 1, Description = "desc1", Name = "name1" };
                var c2 = new DbCategory { CategoryId = 2, Description = "desc2", Name = "name2" };
                var c3 = new DbCategory { CategoryId = 3, Description = "desc3", Name = "name3" };
                await context.Categories.AddAsync(c1);
                await context.Categories.AddAsync(c2);
                await context.Categories.AddAsync(c3);
                await context.SaveChangesAsync();
                var sut = new CategoryService(context);

                // Act
                var result = await sut.GetAsync();

                //Assert
                var resultArr = result.ToArray();
                resultArr.Length.ShouldBe(3);
                resultArr[0].CategoryId.ShouldBe(1);
                resultArr[0].Description.ShouldBe("desc1");
                resultArr[0].Name.ShouldBe("name1");
                resultArr[1].CategoryId.ShouldBe(2);
                resultArr[1].Description.ShouldBe("desc2");
                resultArr[1].Name.ShouldBe("name2");
                resultArr[2].CategoryId.ShouldBe(3);
                resultArr[2].Description.ShouldBe("desc3");
                resultArr[2].Name.ShouldBe("name3");
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Get_EmptyList_ReturnsEmptyList()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var sut = new CategoryService(context);

                // Act
                var result = await sut.GetAsync();

                //Assert
                var resultArr = result.ToArray();
                resultArr.Length.ShouldBe(0);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Update_ListWithUpdatingItem_UpdatesItem()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var c1 = new DbCategory { CategoryId = 1, Description = "desc1", Name = "name1" };
                var c2 = new DbCategory { CategoryId = 2, Description = "desc2", Name = "name2" };
                var c3 = new DbCategory { CategoryId = 3, Description = "desc3", Name = "name3" };
                await context.Categories.AddAsync(c1);
                await context.Categories.AddAsync(c2);
                await context.Categories.AddAsync(c3);
                await context.SaveChangesAsync();
                var c2forUpdate = new CategoryDto { CategoryId = 2, Description = "updated_desc2", Name = "updated_name2" };
                var sut = new CategoryService(context);

                // Act
                await sut.UpdateAsync(c2forUpdate);

                //Assert
                var updatedItem = context.Categories.First(x => x.CategoryId == 2);
                updatedItem.Name.ShouldBe("updated_name2");
                updatedItem.Description.ShouldBe("updated_desc2");
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Update_ListWithoutUpdatingItem_ThrowsException()
        {
            async Task Method(RbyteContext context)
            {
                var itemForUpdate = new CategoryDto { CategoryId = 2, Description = "updated_desc2", Name = "updated_name2" };
                var sut = new CategoryService(context);

                // Act
                await sut.UpdateAsync(itemForUpdate);

                Func<Task> f = async () => { await sut.UpdateAsync(itemForUpdate); };

                //Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }
    }
}
