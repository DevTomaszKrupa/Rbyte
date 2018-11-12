namespace Rbyte.database.Entities
{
    public class DbCompany
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int NIP { get; set; }
        public int UserId { get; set; }
        public virtual DbUser User { get; set; }
    }
}