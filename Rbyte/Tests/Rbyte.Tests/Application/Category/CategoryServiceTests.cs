using Microsoft.EntityFrameworkCore;
using Rbyte.Application.Category;
using Rbyte.Application.Category.Create;
using Rbyte.Application.Category.Update;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Rbyte.Tests.Application.Category
{
    public class CategoryServiceTests
    {
        private RbyteContext Context { get; }
        private ICategoryService Sut { get; }

        public CategoryServiceTests()
        {
            var builder = new DbContextOptionsBuilder<RbyteContext>()
                                .EnableSensitiveDataLogging()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            Context = new RbyteContext(builder.Options);
            Sut = new CategoryService(Context);
        }

        [Fact]
        public void WhenCreatingCategoryWithValidModel_ThenActWithoutException()
        {
            // Arrange
            var product = new CreateCategoryModel
            {
                Description = "fake_description",
                Name = "fake_name"
            };

            // Act
            Sut.Create(product);

            // Assert
            Context.Categories.Count().ShouldBe(1);
        }

        [Fact]
        public void WhenUpdatingCategoryWithValidModel_ThenCategoryFieldsUpdated()
        {
            // Arrange
            Context.Categories.Add(new DbCategory
            {
                CategoryId = 1,
                Description = "fake_description",
                Name = "fake_name"
            });
            Context.SaveChanges();

            // Act
            Sut.Update(new UpdateCategoryModel
            {
                CategoryId = 1,
                Desctiption = "new_description",
                Name = "new_name"
            });

            // Assert
            var result = Context.Categories.First(x => x.CategoryId == 1);
            result.Name.ShouldBe("new_name");
            result.Description.ShouldBe("new_description");
        }
    }
}
