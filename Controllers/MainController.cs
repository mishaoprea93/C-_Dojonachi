		using Microsoft.AspNetCore.Http;
		using Microsoft.AspNetCore.Mvc;
		using System;
		namespace dojonachi.Controllers {
		    public class MainController : Controller {
		        int fullness = 20;
		        int happiness = 20;
		        int energy = 50;
		        int meals = 3;

		        [Route ("")]
		        [HttpGet]
		        public IActionResult Index () {
		            int? Sfullness = HttpContext.Session.GetInt32 ("fullness");
		            int? Shappiness = HttpContext.Session.GetInt32 ("happiness");
		            int? Senergy = HttpContext.Session.GetInt32 ("energy");
		            int? Smeals = HttpContext.Session.GetInt32 ("meals");
		            string Smessage = HttpContext.Session.GetString ("message");
		            if (Sfullness == null) {
		                HttpContext.Session.SetInt32 ("fullness", fullness);
		            }
		            if (Shappiness == null) {
		                HttpContext.Session.SetInt32 ("happiness", happiness);
		            }
		            if (Senergy == null) {
		                HttpContext.Session.SetInt32 ("energy", energy);
		            }
		            if (Smeals == null) {
		                HttpContext.Session.SetInt32 ("meals", meals);
		            }
		            ViewBag.fullness = Sfullness;
		            ViewBag.happiness = Shappiness;
		            ViewBag.energy = Senergy;
		            ViewBag.meals = Smeals;
		            ViewBag.message = Smessage;
		            return View ("Index");
		        }

		        [Route ("/feed")]
		        [HttpGet]
		        public IActionResult feed () {
		            Random rand = new Random ();
		            int full = rand.Next (5, 10);
		            int like = rand.Next (1, 4);
		            int? Smeals = HttpContext.Session.GetInt32 ("meals");
		            if (Smeals == 0) {
		                string nofood = $"You can not feed your Dojonachi,because you have no meals left!";
		                HttpContext.Session.SetString ("message", nofood);
		                return RedirectToAction ("Index");
		            }
		            if (like != 1) {
		                int? Sfullness = HttpContext.Session.GetInt32 ("fullness");
		                Sfullness += full;
		                int f = Convert.ToInt32 (Sfullness);
		                HttpContext.Session.SetInt32 ("fullness", f);
		            }
		            Smeals -= 1;
		            int m = Convert.ToInt32 (Smeals);
		            HttpContext.Session.SetInt32 ("meals", m);
		            string message = $"You fed your Dojonachi.Fullness + {full} Meals - 1!";
		            HttpContext.Session.SetString ("message", message);
		            return RedirectToAction ("Index");
		        }

		        [Route ("/play")]
		        [HttpGet]
		        public IActionResult play () {
		            Random rand = new Random ();
		            int happ = rand.Next (5, 10);
		            int like = rand.Next (1, 4);
		            if (like != 1) {
		                int? Shappiness = HttpContext.Session.GetInt32 ("happiness");
		                Shappiness += happ;
		                int h = Convert.ToInt32 (Shappiness);
		                HttpContext.Session.SetInt32 ("happiness", h);
		            }
		            int? Senergy = HttpContext.Session.GetInt32 ("energy");
		            Senergy -= 5;
		            int e = Convert.ToInt32 (Senergy);
		            HttpContext.Session.SetInt32 ("energy", e);
		            string message = $"You played with your Dojonachi.Happiness + {happ} Energy - 5!";
		            HttpContext.Session.SetString ("message", message);
		            return RedirectToAction ("Index");
		        }

		        [Route ("/work")]
		        [HttpGet]
		        public IActionResult work () {
		            Random rand = new Random ();
		            int meal = rand.Next (1, 3);
		            int? Smeals = HttpContext.Session.GetInt32 ("meals");
		            Smeals += meal;
		            int m = Convert.ToInt32 (Smeals);
		            HttpContext.Session.SetInt32 ("meals", m);
		            int? Senergy = HttpContext.Session.GetInt32 ("energy");
		            Senergy -= 5;
		            int e = Convert.ToInt32 (Senergy);
		            HttpContext.Session.SetInt32 ("energy", e);
		            string message = $"Your Dojonachi worked.Meals + {meal} Energy - 5!";
		            HttpContext.Session.SetString ("message", message);
		            return RedirectToAction ("Index");
		        }

		        [Route ("/sleep")]
		        [HttpGet]
		        public IActionResult sleep () {
		            int? Senergy = HttpContext.Session.GetInt32 ("energy");
		            Senergy += 15;
		            int e = Convert.ToInt32 (Senergy);
		            HttpContext.Session.SetInt32 ("energy", e);
		            int? Sfullness = HttpContext.Session.GetInt32 ("fullness");
		            Sfullness -= 5;
		            int f = Convert.ToInt32 (Sfullness);
		            HttpContext.Session.SetInt32 ("fullness", f);
		            int? Shappiness = HttpContext.Session.GetInt32 ("happiness");
		            Shappiness -= 5;
		            int h = Convert.ToInt32 (Shappiness);
		            HttpContext.Session.SetInt32 ("happiness", h);
		            string message = $"Dojonachi slept.Energy + 15,Fullness - 5, Happiness - 5!";
		            HttpContext.Session.SetString ("message", message);
		            return RedirectToAction ("Index");
		        }

		        [Route ("win-lost")]
		        [HttpGet]
		        public IActionResult reset () {
		            HttpContext.Session.Clear ();
		            return RedirectToAction ("Index");
		        }
		    }
		}