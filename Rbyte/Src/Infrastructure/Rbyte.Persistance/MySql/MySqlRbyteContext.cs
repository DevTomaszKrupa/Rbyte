using Microsoft.EntityFrameworkCore;

namespace Rbyte.Persistance.MySql
{
    public class MySqlRbyteContext : RbyteContext
    {
        public MySqlRbyteContext(DbContextOptions<MySqlRbyteContext> options) : base(options)
        {
        }
    }
}
