namespace Rbyte.Models
{
    public class DbUser
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
