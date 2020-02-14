using IRunesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IRunesApp.Services
{
    class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string GetUserId(string username, string password)
        {
            string hashPassword = this.Hash(password);
            User user = this.db.Users
                .Where(x => x.Username == username && x.Password == hashPassword)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public string GetUsername(string id)
        {
            string username = db.Users.Where(x => x.Id == id).Select(x => x.Username).FirstOrDefault();

            return username;
        }

        public bool IsEmailExist(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameExist(string username)
        {
            return this.db.Users.Any(x => x.Username == username);

        }

        public void Register(string username, string email, string password)
        {
            User user = new User()
            {
                Username = username,
                Email = email,
                Password = this.Hash(password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
