using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Manager
{
    public class Manager
    {
        public Manager(int id, string email, int password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public Manager()
        {
        }

        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Email { get; set; }
        [Range(1, 10)]
        public int Password { get; set; }

    }
}
