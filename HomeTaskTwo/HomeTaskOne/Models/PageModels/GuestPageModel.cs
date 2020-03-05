using System.Collections.Generic;

using HomeTaskOne.Models.PageItemModels;

namespace HomeTaskOne.Models.PageModels
{
    public class GuestPageModel : PageModelBase
    {
        private const string GUEST_HEADER_TEXT = "Blog";
        public IEnumerable<Review> Reviews { get; private set; }

        public GuestPageModel(NavigationMenuModel menuModel, IEnumerable<Review> reviews = null) :
            base(GUEST_HEADER_TEXT, menuModel) => Reviews = reviews ?? new List<Review>();
    }
}