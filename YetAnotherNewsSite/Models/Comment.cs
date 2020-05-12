using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherNewsSite.Models
{
    public class Comment
    {
        [Required]
        public int CommentId { get; set; }
        [Required]
        public string Textfield { get; set; }
        [Required]
        public User User { get; set; }

        public Comment()
        {

        }

        public Comment(string textfield, User user)
        {
            Textfield = textfield;
            User = user;
        }
    }
}
