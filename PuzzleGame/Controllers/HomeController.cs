using PuzzleGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PuzzleGame.Controllers
{
    public class HomeController : Controller
    {
        DataContext database = new DataContext();

        public String Index()
        {
            return "Server run...";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult AllScores()
        {
            return Json(database.Score.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddScore(String Name, int Score, int Difficulty)
        {
            database.Score.Add(new TabelScore { Name = Name, Score = Score, Difficulty = Difficulty});
            database.SaveChanges();
            return Json(database.Score.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
