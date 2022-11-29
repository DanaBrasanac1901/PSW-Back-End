using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.User
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        bool Activate(string email, string token);
        bool SaveTokenToDatabase(string email, SecurityToken token);

        public User Authenticate(User user);
        public SecurityToken GenerateFullToken(User user);
        public SecurityToken GenerateActivationToken(string email);

    }
}
