﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiconMDB.DAL;
using LexiconMDB.Models;

namespace LexiconMDB.Controllers
{
    public class MoviesController : Controller
    {
        private LexiconMDBContext db = new LexiconMDBContext();
        // GET: Movies


        public ActionResult Index(string genre, string orderBy, bool? flag)
        {
            ViewBag.Title = "Movie List";
            //ViewData["Title"] = "Movie List";

            IQueryable<Movie> movies = db.Movies;
            if (genre != null)
            {
                ViewBag.Title = $"Movies in the genre {genre}";
                movies = movies.Where(m => m.Genre == genre);
            }

            if (flag != null)
            {
                if (orderBy != null)
                {
                    if (flag == true)
                    {
                      orderBy = "titleD";
                      orderBy = "lengthD";
                    } else if (flag == false)
                      {
                        ViewBag.OrderBy = orderBy;
                      }
                        else orderBy = "";

                    switch (orderBy.ToLower())
                    {
                        case "title":
                            movies = movies.OrderBy(m => m.Title);
                            ViewBag.flag = true;
                            break;
                        case "titled":
                            movies = movies.OrderByDescending(m => m.Title);
                            ViewBag.flag = "";
                            break;
                        case "length":
                            movies = movies.OrderBy(m => m.Length);
                            ViewBag.flag = true;
                            break;
                        case "lengthd":
                            movies = movies.OrderByDescending(m => m.Length);
                            ViewBag.flag = "";
                            break;
                        default:
                            break;
                    }
                }
            } else ViewBag.flag = false;

            return View(movies.ToList());
      }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Length,Genre,AgeLimit,MetaScore")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Length,Genre,AgeLimit,MetaScore")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
