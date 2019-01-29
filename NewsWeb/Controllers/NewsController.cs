using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewsWeb.Models;

namespace NewsWeb.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: News
        public ActionResult Index()
        {
            var data = db.NewsSet.Include(m => m.Author).ToList();

            return View(data);
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.NewsSet.Include(m => m.Author).FirstOrDefault(m => m.NewsID == id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            var viewModel = new NewsViewModel
            {
                News = new News(),
                Authors = db.AuthorsSet.ToList()
            };
            return View(viewModel);
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.CreationDate = DateTime.Today;
                db.NewsSet.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new NewsViewModel
            {
                News = news,
                Authors = db.AuthorsSet.ToList()
            };

            
            return View(viewModel);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.NewsSet.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewsViewModel()
            {
                News = news,
                Authors = db.AuthorsSet.ToList()
            };

            return View(viewModel);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                News currentNews = db.NewsSet.First(m => m.NewsID == news.NewsID);

                if (currentNews == null)
                    return HttpNotFound();

                else
                {
                    currentNews.ArticleTitle = news.ArticleTitle;
                    currentNews.ArticleBody = news.ArticleBody;
                    currentNews.ImageUrl = news.ImageUrl;
                    currentNews.AuthorId = news.AuthorId;
                    currentNews.PublicationDate = news.PublicationDate;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            var viewModel = new NewsViewModel()
            {
                News = news,
                Authors = db.AuthorsSet.ToList()
            };

            return View(viewModel);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.NewsSet.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.NewsSet.Find(id);
            db.NewsSet.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.NewsSet.Include(m => m.Author).FirstOrDefault(m => m.NewsID == id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
