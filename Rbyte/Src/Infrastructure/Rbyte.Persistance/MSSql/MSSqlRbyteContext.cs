using Microsoft.EntityFrameworkCore;

namespace Rbyte.Persistance.MySql
{
    public class MSSqlRbyteContext : RbyteContext
    {
        public MSSqlRbyteContext(DbContextOptions<MSSqlRbyteContext> options) : base(options)
        {
        }
    }
}
