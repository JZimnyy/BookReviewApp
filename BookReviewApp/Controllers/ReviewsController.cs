using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookReviewApp.Models;

namespace BookReviewApp.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Book);
            return View(reviews.ToList());
        }
        [Authorize]
        public ActionResult MyReviews()
        {
            var user = from u in db.Users where u.UserName == User.Identity.Name select u;

            var name = user.First().Nickname;
            var reviews = db.Reviews.Where(u=>u.Name.Equals(name)).Include(r => r.Book);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        [Authorize]
        public ActionResult Create([Bind(Include ="id")]int? id)
        {
            var book = db.Books.Find(id);
            ViewBag.Ksiazka = book.BookId;
            if (id != null)
            {
                var user = from u in db.Users where u.UserName == User.Identity.Name select u;

                var name = user.First().Nickname;
                var review = from r in db.Reviews where r.Name == name && r.BookId == id select r;

                if(review!=null)
                {
                    return RedirectToAction("Edit", new { BookId = id });
                }

                return View();
            }
            
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title");
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Reviews/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ReviewId,Rating,Description,BookId")] Review review)
        {
            var user = from u in db.Users where u.UserName == User.Identity.Name select u;
            review.Name = user.First().Nickname;
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", review.BookId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id, int? BookId)
        {
            if(BookId!=null)
            {
                var user = from u in db.Users where u.UserName == User.Identity.Name select u;

                var name = user.First().Nickname;
                var reviewlist = from r in db.Reviews where r.Name == name && r.BookId == BookId select r;
                Review review1 = db.Reviews.Find(reviewlist.First().ReviewId);

                return View(review1);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", review.BookId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewId,Rating,Description,Name,BookId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","Books", new { id = review.BookId });
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", review.BookId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
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
