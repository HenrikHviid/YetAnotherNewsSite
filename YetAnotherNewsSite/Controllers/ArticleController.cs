using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YetAnotherNewsSite.Data;
using YetAnotherNewsSite.Models;

namespace YetAnotherNewsSite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly YansContext _context;
        private Article article;

        public ArticleController(YansContext context)
        {
            _context = context;
        }

        //Gets the article Uuid from the HomeController index view and returns a view with the selected article
        public IActionResult Index(string id)
        {
            var articles = _context.Articles.ToList();

            article = articles.Where(a => a.Uuid == id).First();
            
            return View(article);
        }

        //NOT FINISHED  commentsection for articles
        public IActionResult PostComment(string commentText)
        {
            var comment = new Comment();
            comment.Textfield = commentText;
            comment.User = null;

            return View(article);
        }
    }
}