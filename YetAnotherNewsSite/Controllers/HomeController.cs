using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YetAnotherNewsSite.Models;
using Newtonsoft.Json.Linq;
using YetAnotherNewsSite.Data;

namespace YetAnotherNewsSite.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            //Creating a fetch object
            var fetch = new Fetch();
            //fetch data with the fetch object
            string data = fetch.GetNews("denmark");
            //Parse data to json
            JObject json = JObject.Parse(data);


            //json["posts"][7]["title"].ToString();

            //creating a list of articles
            var articles = new List<Article>();
            //iterate over posts in json
            foreach(var post in json["posts"])
            {
                //Create article object
                var article = new Article();
                //Fill out article properties
                article.Author = post["author"].ToString();
                article.Text = post["text"].ToString();


                //add article to list
                articles.Add(article);
                
            }


            //send articles to view
            return View(articles);
        }

    }
}
