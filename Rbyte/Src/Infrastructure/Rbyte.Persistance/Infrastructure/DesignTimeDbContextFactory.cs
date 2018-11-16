//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace Rbyte.Persistance.Infrastructure
//{
//    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RbyteContext>
//    {
//        public RbyteContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<RbyteContext>();
//            optionsBuilder.UseMySQL("server=localhost;database=rByte;user=root;password=admin");

//            return new RbyteContext(optionsBuilder.Options);
//        }
//    }
//}
