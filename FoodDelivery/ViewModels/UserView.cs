using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.ViewModels
{
    public class UserView
    {
        public UserView(string name, DateTime birthDate, string phone, string email, string login, string password)
        {
            Name = name;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Login = login;
            Password = password;
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
