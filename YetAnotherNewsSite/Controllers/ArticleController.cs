using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ArticleController(YansContext context)
        {
            _context = context;
        }

        //Gets the article Uuid from the HomeController index view and returns a view with the selected article
        public IActionResult Index(string id)
        {
            var article = GetArticle(id);
            //Gets comments assosiated with this article
            var comments = _context.Comments.Where(c => c.ArticleId == article.ArticleId).ToList();
            //Put comments from database into article model before returning to view
            article.Comments = comments;
            return View(article);
        }

        //commentsection for articles
         [HttpPost]
        public IActionResult PostComment(string id, string text)
        {
            var article = GetArticle(id);
            //Create the new comment
            Comment comment = new Comment();
            comment.Textfield = text;
            comment.User = null; //_context.Users.First();
            comment.ArticleId = article.ArticleId;
            //add the comment to database and save changes
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = id });
        }

        //Gets article from database
        private Article GetArticle(string id)
        {
            var articles = _context.Articles.ToList();
            return articles.Where(a => a.Uuid == id).First();
        } 
    }
}