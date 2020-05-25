using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherNewsSite.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Textfield { get; set; }
        public User User { get; set; }
        public DateTime DateTime { get; set; }
    }


}
