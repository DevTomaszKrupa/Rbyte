using Microsoft.AspNetCore.Mvc.Rendering;
using Rbyte.Application.Category.Create;
using Rbyte.Application.Category.Details;
using Rbyte.Application.Category.Read;
using Rbyte.Application.Category.Update;
using Rbyte.Application.Product.Read;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Category
{
    public interface ICategoryService
    {
        void Create(CreateCategoryModel model);
        IEnumerable<ReadCategoryModel> Read();
        DetailsCategoryModel Read(int categoryId);
        List<SelectListItem> GetSelectListItems();
        UpdateCategoryModel GetForEdition(int categoryId);
        void Update(UpdateCategoryModel model);
        void Delete(int categoryId);
    }
    public class CategoryService : ICategoryService
    {
        private readonly RbyteContext _context;
        public CategoryService(RbyteContext context)
        {
            _context = context;
        }

        public void Create(CreateCategoryModel model)
        {
            _context.Categories.Add(new DbCategory
            {
                Name = model.Name,
                Description = model.Description
            });
            _context.SaveChanges();
        }

        public DetailsCategoryModel Read(int categoryId)
        {
            var category = _context.Categories.Where(x => x.CategoryId == categoryId)
                                              .Select(x => new DetailsCategoryModel
                                              {
                                                  CategoryId = x.CategoryId,
                                                  Name = x.Name,
                                                  Products = x.CategoryProducts.Select(prod => new ReadProductModel
                                                  {
                                                      Barcode = prod.Product.Barcode,
                                                      Description = prod.Product.Description,
                                                      Name = prod.Product.Name,
                                                      Price = prod.Product.StandardPrice.ToString(),
                                                      ProductId = prod.ProductId
                                                  }).ToList()
                                              }).First();
            return category;
        }

        public IEnumerable<ReadCategoryModel> Read()
        {
            var categories = _context.Categories.Select(x => new ReadCategoryModel
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
                Desctiption = x.Description,
            }).ToList();
            return categories;
        }
        public UpdateCategoryModel GetForEdition(int categoryId)
        {
            var product = _context.Categories.Where(x => x.CategoryId == categoryId)
                                             .Select(x => new UpdateCategoryModel
                                             {
                                                 CategoryId = x.CategoryId,
                                                 Name = x.Name,
                                                 Desctiption = x.Description
                                             }).First();
            return product;
        }


        public void Update(UpdateCategoryModel model)
        {
            var dbCategory = _context.Categories.First(x => x.CategoryId == model.CategoryId);
            dbCategory.Name = model.Name;
            dbCategory.Description = model.Desctiption;

            _context.SaveChanges();
        }
        public void Delete(int categoryId)
        {
            var dbCategory = _context.Categories.First(x => x.CategoryId == categoryId);
            if (dbCategory.CategoryProducts.Any())
            {
                throw new Exception("Cannot delete category with products");
            }
            _context.Categories.Remove(dbCategory);
            _context.SaveChanges();
        }

        public List<SelectListItem> GetSelectListItems()
        {
            var productList = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();
            return productList;
        }
    }
}
