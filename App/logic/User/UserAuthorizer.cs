using System;

namespace logic.User
{
    public interface IUserAuthorizer
    {
        void Authorize(UserDto user);
    }
    public class UserAuthorizer : IUserAuthorizer
    {
        public void Authorize(UserDto user)
        {
            Console.WriteLine("Authorization...");
        }
    }
}
