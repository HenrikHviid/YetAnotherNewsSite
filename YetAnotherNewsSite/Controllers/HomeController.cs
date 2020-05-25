using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
using YetAnotherNewsSite.Models;
using Newtonsoft.Json.Linq;
using YetAnotherNewsSite.Data;
using System.Net.WebSockets;
using System;
using SQLitePCL;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using YetAnotherNewsSite.Database_Access;


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

        //

        // GET: /Home/ database Articles

        Database_Access.db dblayer = new Database_Access.db();

        //Index view with default searchterm
        public ActionResult Index()
        {
            // create a data handler
            dataHandler = new DataHandler(_context);
            
            // Get new articles
            articles = dataHandler.GetNewArticles("denmark");

            int pagesize = 20;

            var rowdata = db.GetArticles(1, pagesize);

            return View(rowdata);

            //return View(articles);

        }

        protected string renderPartialViewtostring(string Viewname, object model)

        {

            if (string.IsNullOrEmpty(Viewname))

                Viewname = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())

            {

                ViewEngineResult viewresult = ViewEngines.Engines.FindPartialView(ControllerContext, Viewname);

                ViewContext viewcontext = new ViewContext(ControllerContext, viewresult.View, ViewData, TempData, sw);

                viewresult.View.Render(viewcontext, sw);

                return sw.GetStringBuilder().ToString();

            }



        }


        public class JsonModel

        {
            public string HTMLString { get; set; }

            public bool NoMoredata { get; set; }

        }

        [System.Web.Mvc.ChildActionOnly]

        public ActionResult table_row(List<db.Articles> Model)

        {

            return PartialView(Model);

        }

        [HttpPost]

        public ActionResult InfiniteScroll(int pageindex)

        {

            System.Threading.Thread.Sleep(1000);

            int pagesize = 20;

            var tbrow = db.GetArticles(pageindex, pagesize);

            JsonModel jsonmodel = new JsonModel();

            jsonmodel.NoMoredata = tbrow.Count < pagesize;

            jsonmodel.HTMLString = renderPartialViewtostring("table_row", tbrow);

            return Json(jsonmodel);

        }

        //Index view with custom searchterm from the searchbar
        public ActionResult Search(string searchTerm)
        {
            // Get new articles
            articles = dataHandler.GetNewArticles(searchTerm);
            return View(articles);
        }

    
    }
}

