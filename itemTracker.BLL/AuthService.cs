using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using taskForTrackItem.Models.Models;
using itemTracker.DAL.Repos; 
namespace itemTracker.BLL
{
    public class AuthService
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public User Login(string username, string password)
        {
            var user = _userRepo.GetUserByUsername(username);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }

        public bool Register(string username, string password, string role)
        {
            if (_userRepo.GetUserByUsername(username) != null)
                return false;

            var hashed = HashPassword(password);
            var newUser = new User
            {
                Username = username,
                PasswordHash = hashed,
                Role = role
            };

            _userRepo.AddUser(newUser);
            return true;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }
    }
}
