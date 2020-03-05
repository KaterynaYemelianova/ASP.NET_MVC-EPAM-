using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;

using Autofac;

using HomeTaskOne.Data;
using HomeTaskOne.Models.PageModels;
using HomeTaskOne.Models.PageItemModels;

namespace HomeTaskOne.Controllers
{
    public class HomeController : Controller
    {
        private static readonly NavigationMenuModel MENU_MODEL = 
            DI.Services.Resolve<NavigationMenuModel>();

        public ActionResult Index()
        {
            using (BlogContext ctx = new BlogContext())
                return View(new HomePageModel(MENU_MODEL, ctx.Articles.ToList()));
        }

        /****************************/

        public ActionResult AddReview(string author, string title, string text)
        {
            using (BlogContext ctx = new BlogContext())
            {
                ctx.Reviews.Add(new Review(title, text, author, DateTime.Now));
                ctx.SaveChanges();
            }

            return RedirectToAction("Guest");
        }

        public ActionResult Guest()
        {
            using(BlogContext ctx = new BlogContext())
                return View(new GuestPageModel(MENU_MODEL, ctx.Reviews.ToList()));
        }

        /****************************/

        [HttpPost]
        public ActionResult CheckForm([System.Web.Http.FromBody]List<Answer> answers)
        {
            using (BlogContext ctx = new BlogContext())
                return Json(new {
                    Right = ctx.Questions.Include(Q => Q.AnswerVariants)
                                         .ToList().Count(Q => Q.IsRight(answers)),
                    Total = ctx.Questions.Count()
                });
        }

        public ActionResult Form()
        {
            using (BlogContext ctx = new BlogContext())
            {
                List<Question> qs = ctx.Questions.Include(Q => Q.AnswerVariants).ToList();
                return View(new FormPageModel(MENU_MODEL, qs));
            }
        }
    }
}