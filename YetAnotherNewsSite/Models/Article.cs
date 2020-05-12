using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace YetAnotherNewsSite.Models
{
    public class Article
    {
        [Required]
        public int ArticleId { get; set; } 
        [Required]
        public string Headline { get; set; }
        [Required]
        public string TextField { get; set; }
        public string Picture { get; set; }
        [Required]
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Comment Comment { get; set; }

        public Article()
        {

        }

        public Article(string headline, string textField, string author, DateTime date)
        {
            Headline = headline;
            TextField = textField;
            Author = author;
            Date = date;
        }

        public Article(string headline, string textField, string picture, string author, DateTime date)
        {
            Headline = headline;
            TextField = textField;
            Picture = picture;
            Author = author;
            Date = date;
        }
    }
}
