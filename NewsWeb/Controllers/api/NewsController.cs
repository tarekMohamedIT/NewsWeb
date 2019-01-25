using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NewsWeb.Models;

namespace NewsWeb.Controllers.api
{
    public class NewsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/News
        public IQueryable<News> GetNewsSet()
        {
            return db.NewsSet;
        }

        [ResponseType(typeof(News))]
        [Route("api/news/search/{authorName}")]
        [HttpGet]
        public IHttpActionResult Search(string authorName)
        {
            List<News> news = db.NewsSet.Where(n => n.Author.Name.Contains(authorName)).ToList();
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        // GET: api/News/5
        [ResponseType(typeof(News))]
        [Route("api/news/id/{id}")]
        [HttpGet]
        public IHttpActionResult GetNews(int id)
        {
            News news = db.NewsSet.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        // PUT: api/News/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNews(int id, News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != news.NewsID)
            {
                return BadRequest();
            }

            db.Entry(news).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/News
        [ResponseType(typeof(News))]
        public IHttpActionResult PostNews(News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewsSet.Add(news);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = news.NewsID }, news);
        }

        // DELETE: api/News/5
        [ResponseType(typeof(News))]
        public IHttpActionResult DeleteNews(int id)
        {
            News news = db.NewsSet.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            db.NewsSet.Remove(news);
            db.SaveChanges();

            return Ok(news);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsExists(int id)
        {
            return db.NewsSet.Count(e => e.NewsID == id) > 0;
        }
    }
}