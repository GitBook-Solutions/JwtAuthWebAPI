using System;
using System.Collections.Generic;
using System.Linq;
namespace JwtModels
{
    public class UserService:IUserService
    {
        private List<User> _users;
        public UserService()
        {
            _users= new List<User>
            {
                new User() { Id = 1, FirstName = "Shyam", LastName = "Bora", Username = "syam", Password="password"},
                new User() { Id = 2, FirstName = "Anoop", LastName = "C.K", Username = "anoop", Password="password"},
            };
        }
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password==password);
            // check if username exists
            if (user == null)
                return null;
            // authentication successful
            return user;
        }
    }
}