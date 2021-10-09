using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants.Controllers
{
  public class ReviewsController : Controller
  {
    private readonly RestaurantsContext _db;

    public ReviewsController(RestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Review> model= _db.Reviews.Include(review => review.Restaurant).ToList();
      // IQueryable<Review , int> Reviews= _db.Reviews.Include(review => review.Restaurant)
      //                         .Max<int>(star => star.Stars.Length);
      // return View(Reviews.ToList());
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View();
    }   

    [HttpPost]
    public ActionResult Create(Review review)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      return View(thisReview);
    }
  }
}  