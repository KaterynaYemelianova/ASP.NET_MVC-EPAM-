namespace HomeTaskOne.Models.PageModels
{
    public class DefaultNavigationMenuModel : NavigationMenuModel
    { 
        public DefaultNavigationMenuModel() : base()
        {
            MenuButtonTextToRedirectActionPathRelations.Add("Home", "Home/Index");
            MenuButtonTextToRedirectActionPathRelations.Add("Guest", "Home/Guest");
            MenuButtonTextToRedirectActionPathRelations.Add("Forms", "Home/Form");
        }
    }
}