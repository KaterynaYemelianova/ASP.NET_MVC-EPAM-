namespace HomeTaskOne.Models.PageItemModels
{
    public class Article : PageItemBase
    {
        public Article() : base(0, "", "") { }

        public Article(string title, string body) : 
            base(0, title, body) { }
    }
}