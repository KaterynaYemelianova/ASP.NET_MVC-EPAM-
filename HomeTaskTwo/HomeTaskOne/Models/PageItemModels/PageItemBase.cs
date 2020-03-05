namespace HomeTaskOne.Models.PageItemModels
{
    public abstract class PageItemBase
    {
        public int Id { get; private set; }
        public string Title { get; protected set; }
        public string Body { get; protected set; }

        public PageItemBase(int id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }
    }
}
