using System.Collections.Generic;

namespace HomeTaskOne.Models.PageModels
{
    public class NavigationMenuModel
    {
        public Dictionary<string, string> MenuButtonTextToRedirectActionPathRelations { get; private set; } =
            new Dictionary<string, string>();
    }
}