using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YetAnotherNewsSite.Data;
using YetAnotherNewsSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace YetAnotherNewsSite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly YansContext _context;
        private Article article;
        private NewsViewModel news { get; set; }

        public ArticleController(YansContext context)
        {
            _context = context;
        }

        //Gets the article Uuid from the HomeController index view and returns a view with the selected article
        public IActionResult Index(string id)
        {
            var articles = _context.Articles.ToList();
            var comments = _context.Comments.ToList();


            article = articles.Where(a => a.Uuid == id).First();
            news = new NewsViewModel()
            {
                Article = article,
                Comments = comments
            };

            Comment comment = new Comment();
            comment.Textfield = "";
            comment.User = _context.Users.First();
            comment.ArticleId = article.ArticleId;
            comments.Add(comment);
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return View(news);
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