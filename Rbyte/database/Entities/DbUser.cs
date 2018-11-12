namespace Rbyte.database.Entities
{
    public class DbUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public int? CompanyId { get; set; }
        public virtual DbCompany Company { get; set; }
    }
}