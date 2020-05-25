using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YetAnotherNewsSite.Models;
using Newtonsoft.Json.Linq;
using YetAnotherNewsSite.Data;
using System.Net.WebSockets;
using System;
using SQLitePCL;
using System.Linq;

namespace YetAnotherNewsSite.Controllers
{
    public class HomeController : Controller
    {
        private DataHandler dataHandler;
        private readonly YansContext _context;
        private List<Article> articles;
        
        public HomeController(YansContext context)
        {
            _context = context;
        }

        //Index view with default searchterm
        public IActionResult Index()
        {
            // create a data handler
            dataHandler = new DataHandler(_context);
            
            // Get new articles
            articles = dataHandler.GetNewArticles("denmark");

            return View(articles);
        }

        //Index view with custom searchterm from the searchbar
        public IActionResult Search(string searchTerm)
        {
            // Get new articles
            articles = dataHandler.GetNewArticles(searchTerm);
            return View(articles);
        }
    }
}
