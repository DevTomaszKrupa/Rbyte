using Rbyte.Api.Models.Category;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Category
{
    public interface ICategoryService
    {
        void Create(ApiCategory model);
        ApiCategory Get(int categoryId);
        List<ApiCategory> Get();
        void Update(ApiCategory model);
        void Delete(int categoryId);
    }
    public class CategoryService : ICategoryService
    {
        private readonly RbyteContext _context;
        public CategoryService(RbyteContext context)
        {
            _context = context;
        }

        public void Create(ApiCategory model)
        {
            _context.Categories.Add(new DbCategory
            {
                Name = model.Name,
                Description = model.Description
            });
            _context.SaveChanges();
        }

        // public DetailsCategoryModel Read(int categoryId)
        // {
        //     var category = _context.Categories.Where(x => x.CategoryId == categoryId)
        //                                       .Select(x => new DetailsCategoryModel
        //                                       {
        //                                           CategoryId = x.CategoryId,
        //                                           Name = x.Name,
        //                                           Products = x.CategoryProducts.Select(prod => new ReadProductModel
        //                                           {
        //                                               Barcode = prod.Product.Barcode,
        //                                               Description = prod.Product.Description,
        //                                               Name = prod.Product.Name,
        //                                               Price = prod.Product.StandardPrice.ToString(),
        //                                               ProductId = prod.ProductId
        //                                           }).ToList()
        //                                       }).First();
        //     return category;
        // }

        public List<ApiCategory> Get()
        {
            var categories = _context.Categories.Select(x => new ApiCategory
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
            return categories;
        }


        public void Update(ApiCategory model)
        {
            var dbCategory = _context.Categories.First(x => x.CategoryId == model.CategoryId);
            dbCategory.Name = model.Name;
            dbCategory.Description = model.Description;

            _context.SaveChanges();
        }
        public void Delete(int categoryId)
        {
            var dbCategory = _context.Categories.First(x => x.CategoryId == categoryId);
            // if (dbCategory.CategoryProducts.Any())
            // {
            //     throw new Exception("Cannot delete category with products");
            // }
            _context.Categories.Remove(dbCategory);
            _context.SaveChanges();
        }

        public ApiCategory Get(int categoryId)
        {
            var category = _context.Categories.Where(x => x.CategoryId == categoryId)
                                              .Select(x => new ApiCategory
                                              {
                                                  CategoryId = x.CategoryId,
                                                  Name = x.Name,
                                                  Description = x.Description
                                              }).First();
            return category;
        }

        // public void DeleteProduct(int productId)
        // {
        //     var dbProduct = _context.CategoryProducts.Where(x => x.ProductId == productId).First();
        //     _context.CategoryProducts.Remove(dbProduct);
        //     _context.SaveChanges();
        // }
    }
}
