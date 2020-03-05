using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Autofac;

using HomeTaskOne.Models.PageModels;
using HomeTaskOne.Models.PageItemModels;

namespace HomeTaskOne.Controllers
{
    public class HomeController : Controller
    {
        private static readonly NavigationMenuModel MENU_MODEL = DI.Services.Resolve<NavigationMenuModel>();

        public ActionResult Index()
        {
            List<Article> articles = new List<Article>()
            {
                new Article("LOL", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."),
                new Article("KEK", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."),
                new Article("LOL", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."),
                new Article("KEK", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."),
                new Article("KEK", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."),
                new Article("KEK", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.")
            };

            return View(new HomePageModel(MENU_MODEL, articles));
        }

        /****************************/

        private static List<Review> addedReviews = new List<Review>();
        public ActionResult AddReview(string author, string title, string text)
        {
            addedReviews.Add(new Review(title, text, author, DateTime.Now));

            return RedirectToAction("Guest");
        }

        public ActionResult Guest()
        {
            List<Review> answers = new List<Review>()
            {
                new Review("test answer1", "test", "Katia", DateTime.Now.AddDays(1))
            };

            List<Review> reviews = new List<Review>()
            {
                new Review("Review", "test review", "Oleh", DateTime.Now, answers)
            };

            return View(new GuestPageModel(MENU_MODEL, reviews.Concat(addedReviews)));
        }

        /****************************/

        private static readonly List<Question> questions = new List<Question>()
        {
            new Question(0, "Math question", "2 + 2 = ", new Dictionary<Variant, bool>()
            {
                { new Variant(0, "4"), true },
                { new Variant(1, "5"), false }
            }),

            new Question(1, "Math question 2", "3 * 3 = ", new Dictionary<Variant, bool>() {
                { new Variant(0, "6"), false },
                { new Variant(1, "8"), false },
                { new Variant(2, "9"), true }
            }),

             new Question(3, "ИЗО", "Выберите теплые цвета", new Dictionary<Variant, bool>() {
                { new Variant(0, "коричневый"), true },
                { new Variant(1, "зеленый"), false },
                { new Variant(2, "желтый"), true },
                { new Variant(3, "синий"), false }
            }),
        };

        [HttpPost]
        public ActionResult CheckForm([System.Web.Http.FromBody]List<Answer> answers)
        {
            return Json(new
            {
                Right = questions.Count(Q => Q.IsRight(answers)),
                Total = questions.Count
            });
        }

        public ActionResult Form()
        {            
            return View(new FormPageModel(MENU_MODEL, questions));
        }
    }
}