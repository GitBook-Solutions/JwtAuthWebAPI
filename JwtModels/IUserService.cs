using System;
using System.Collections.Generic;
namespace JwtModels
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}