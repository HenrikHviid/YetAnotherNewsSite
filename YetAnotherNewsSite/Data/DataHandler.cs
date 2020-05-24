using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using YetAnotherNewsSite.Data;

namespace YetAnotherNewsSite.Models
{
    public class DataHandler
    {
        private const string API_KEY = "307546ea-92f0-406e-bff9-891ef14289b0";

        private readonly YansContext _context;
        public DataHandler(YansContext context)
        {
            _context = context;
        }

        //Get data for new articles
        internal List<Article> GetNewArticles(string searchTerm)
        {
            List<Article> articles = new List<Article>();
            
            string data = "";

            using (WebClient wc = new WebClient())
            {
                data = wc.DownloadString($"http://webhose.io/filterWebContent?token={API_KEY}&format=json&sort=crawled&q={searchTerm}");
            }

            //Parse data to json
            JObject json = JObject.Parse(data);

            //iterate over posts in json
            foreach (var post in json["posts"])
            {
                //Create article object
                var article = new Article();
                //Fill out article properties
                article.Uuid = post["uuid"].ToString();
                article.Title = post["title"].ToString();
                article.Text = post["text"].ToString();
                article.Main_Image = post["thread"]["main_image"].ToString();
                article.Author = post["author"].ToString();
                article.Url = post["url"].ToString();

                //converting published time from string to DateTime
                var published = post["published"].ToString();
                var dateTime = Convert.ToDateTime(published);
                article.Published = dateTime;

                //checking if articles from the API has the matching Uuid 
                if ((articles.Where(a => a.Uuid == article.Uuid)).Count() > 0)
                {
                    continue;
                }
                //checking if articles from the API has the matching Titles
                if ((articles.Where(a => a.Title == article.Title)).Count() > 0)
                {
                    continue;
                }
                //checking if articles from the API has the matching Image
                if ((articles.Where(a => a.Main_Image == article.Main_Image)).Count() > 0)
                {
                    continue;
                }
                //checking if the article contains image and has title
                if (ContainsImage(article) && HasTitle(article))
                {
                    articles.Add(article);
                    //if so. Add to database
                    if (!IsArticleInDatabase(article))
                    {
                        _context.Articles.Add(article);
                    }
                }
            }
            _context.SaveChanges();
            return articles;
        }

        //Checking if article is already in the database to stop it from dublicating
        private bool IsArticleInDatabase(Article article)
        {
            foreach (var existingArticle in _context.Articles)
            {
                if(existingArticle.Uuid == article.Uuid)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ContainsImage(Article article)
        {
            return article.Main_Image != "";
        }

        private bool HasTitle(Article article)
        {
            return article.Title != "";
        }
    }
}
