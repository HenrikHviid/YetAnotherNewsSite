using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherNewsSite.Models
{
    public class User
    {
        [Required]
        public string Userid { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public User()
        {

        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

    }
}
