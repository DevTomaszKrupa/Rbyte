using System.Collections.Generic;

namespace Rbyte.Domain.Entities
{
    public class DbCategory
    {
        public DbCategory()
        {
            ChildernCategories = new HashSet<DbCategory>();
            CategoryProducts = new HashSet<DbCategoryProduct>();
        }
        
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Parents { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual DbCategory ParentCategory { get; set; }
        public virtual ICollection<DbCategory> ChildernCategories { get; private set; }
        public virtual ICollection<DbCategoryProduct> CategoryProducts { get; private set; }
    }
}