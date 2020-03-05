using System.Collections.Generic;

using HomeTaskOne.Models.PageItemModels;

namespace HomeTaskOne.Models.PageModels
{
    public class HomePageModel : PageModelBase
    {
        private const string HOME_HEADER_TEXT = "Blog";
        public IEnumerable<Article> Articles { get; private set; }

        public HomePageModel(NavigationMenuModel menuModel, IEnumerable<Article> articles = null) :
            base(HOME_HEADER_TEXT, menuModel) => Articles = articles ?? new List<Article>();
    }
}