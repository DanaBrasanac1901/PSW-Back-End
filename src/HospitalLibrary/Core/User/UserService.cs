﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
