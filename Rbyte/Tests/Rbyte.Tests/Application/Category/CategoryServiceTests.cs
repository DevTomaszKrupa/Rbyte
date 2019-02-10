using Rbyte.Application.Category;
using Rbyte.Domain.Models.Category;
using Rbyte.Persistance;
using Shouldly;
using System.Linq;
using Xunit;

namespace Rbyte.Tests.Application.Category
{
    public class CategoryServiceTests
    {
        [Fact]
        public void Create_OneCategory()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var categoryService = new CategoryService(context);
                var apiCategory = new CategoryDto
                {
                    Description = "description",
                    Name = "name",
                };

                // Act
                categoryService.CreateAsync(apiCategory);

                //Assert
                var categories = context.Categories.ToArray();
                categories.Length.ShouldBe(1);
                categories[0].Name.ShouldBe("name");
                categories[0].Description.ShouldBe("description");
            }
            RbyteContextActionInvoker.Invoke(Method);
        }
    }
}
