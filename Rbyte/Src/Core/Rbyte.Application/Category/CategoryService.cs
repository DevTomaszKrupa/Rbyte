using Microsoft.EntityFrameworkCore;
using Rbyte.Domain.Entities;
using Rbyte.Domain.Models.Category;
using Rbyte.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbyte.Application.Category
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryDto model);
        Task<CategoryDto> GetAsync(int categoryId);
        Task<List<CategoryDto>> GetAsync();
        Task UpdateAsync(CategoryDto model);
        Task DeleteAsync(int categoryId);
    }

    public class CategoryService : ICategoryService
    {
        private readonly RbyteContext _context;
        public CategoryService(RbyteContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CategoryDto model)
        {
            await _context.Categories.AddAsync(new DbCategory
            {
                Name = model.Name,
                Description = model.Description
            });
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryDto>> GetAsync()
        {
            var categories = await _context.Categories.Select(x => new CategoryDto
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
            return categories;
        }


        public async Task UpdateAsync(CategoryDto model)
        {
            var dbCategory = await _context.Categories.FirstAsync(x => x.CategoryId == model.CategoryId);

            dbCategory.Name = model.Name;
            dbCategory.Description = model.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int categoryId)
        {
            var dbCategory = await _context.Categories.FirstAsync(x => x.CategoryId == categoryId);
            if (dbCategory.CategoryProducts.Any())
            {
                throw new Exception("Cannot delete category with products");
            }
            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoryDto> GetAsync(int categoryId)
        {
            var category = await _context.Categories.Where(x => x.CategoryId == categoryId)
                                              .Select(x => new CategoryDto
                                              {
                                                  CategoryId = x.CategoryId,
                                                  Name = x.Name,
                                                  Description = x.Description
                                              }).FirstAsync();
            return category;
        }
    }
}
