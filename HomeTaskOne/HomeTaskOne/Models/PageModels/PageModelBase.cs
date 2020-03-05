namespace HomeTaskOne.Models.PageModels
{
    public abstract class PageModelBase
    {
        public string HeaderText { get; protected set; }
        public NavigationMenuModel MenuModel { get; protected set; }

        public PageModelBase(string headerText, NavigationMenuModel menuModel)
        {
            HeaderText = headerText;
            MenuModel = menuModel;
        }
    }
}