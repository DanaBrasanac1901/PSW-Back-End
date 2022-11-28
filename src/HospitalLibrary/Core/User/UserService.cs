using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
        public User GetByEmail(String email)
        {
            foreach (User user in _userRepository.GetAll())
                if (user.Email == email)
                    return user;
            return null;
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public bool Activate(User user)
        {
            user.Active = true;
            try
            {
                Update(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User Authenticate(User user)
        {
            // UserConstraints -> baza
            var users = _userRepository.GetAll();
            var currentUser = users.FirstOrDefault(o => o.Email.ToLower() ==
                 user.Email.ToLower() && o.Password == user.Password);


            if (currentUser != null) return currentUser;
            return null;
        }


       

    }
}
