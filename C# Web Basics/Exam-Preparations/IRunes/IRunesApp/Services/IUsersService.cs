using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesApp.Services
{
    public interface IUsersService
    {
        string GetUsername(string UserId);

        string GetUserId(string username, string password);

        void Register(string username, string email, string password);

        bool IsUsernameExist(string username);

        bool IsEmailExist(string email);
    }
}
