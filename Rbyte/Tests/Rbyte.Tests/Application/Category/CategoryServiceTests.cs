using Rbyte.Api.Models.Category;
using Rbyte.Application.Category;
using Rbyte.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var apiCategory = new ApiCategory
                {
                    Description = "description",
                    Name = "name",
                };

                // Act
                categoryService.Create(apiCategory);

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
