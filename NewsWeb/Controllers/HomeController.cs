using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWeb.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();



        public ActionResult Index()
        {
            List<News> newsList =  _context.NewsSet.Where(m => m.PublicationDate <= DateTime.Now).ToList();
            return View(newsList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}