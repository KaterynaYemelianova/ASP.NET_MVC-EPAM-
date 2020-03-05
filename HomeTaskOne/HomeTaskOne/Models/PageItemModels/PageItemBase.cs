namespace HomeTaskOne.Models.PageItemModels
{
    public abstract class PageItemBase
    {
        public string Title { get; protected set; }
        public string Body { get; protected set; }

        public PageItemBase(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
