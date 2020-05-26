using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Threading.Tasks;

namespace YetAnotherNewsSite.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Uuid { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Main_Image { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public string Language { get; set; }
        public string Site_Type { get; set; }
        public DateTime Published { get; set; }
        public List<Comment> Comments { get; set; }

        public Article()
        {
        }


    }
}
