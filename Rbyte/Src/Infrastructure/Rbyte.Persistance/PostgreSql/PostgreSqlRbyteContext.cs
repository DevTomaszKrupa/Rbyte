using Microsoft.EntityFrameworkCore;

namespace Rbyte.Persistance.PostgreSql
{
    public class PostgreSqlRbyteContext : RbyteContext
    {
        public PostgreSqlRbyteContext(DbContextOptions<PostgreSqlRbyteContext> options) : base(options)
        {
        }
    }
}
