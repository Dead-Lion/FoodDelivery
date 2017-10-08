using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Models
{
    public class User
    {
        public User(string name, DateTime birthDate, string phone, string email, string login, string password)
        {
            Name = name;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Login = login;
            Password = password;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}