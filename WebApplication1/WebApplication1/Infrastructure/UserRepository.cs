using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.Data.ValueObjetcs;
using WebApplication1.Domain.Context;
using WebApplication1.Domain.Users;
using WebApplication1.Domain.Users.Interfaces;

namespace WebApplication1.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVo user)
        {
            var pass = ComputHash(user.Password, new SHA1CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        
        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.IdUser.Equals(user.IdUser))) return null;
            {
                
            }
            var result = _context.Users.SingleOrDefault(u => u.IdUser.Equals(user.IdUser));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }
        
        
        /*
         *
         *
         *
         *
         *
         *
         * SE DER ERRO MUDAR DE STRING PRA OBJECT
         */
        
        private string ComputHash(string input, SHA1CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}