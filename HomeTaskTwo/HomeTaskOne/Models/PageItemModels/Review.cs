using System;
using System.Linq;
using System.Collections.Generic;

namespace HomeTaskOne.Models.PageItemModels
{
    public class Review : PageItemBase
    {
        public string AuthorName { get; private set; }
        public DateTime ReviewDate { get; private set; }
        public List<Review> Answers { get; private set; } = new List<Review>();

        public Review() : base(0, "", "") { }

        public Review(string title, string body, string authorName,
                      DateTime reviewDate, IEnumerable<Review> answers = null) : base(0, title, body)
        {
            AuthorName = authorName;
            ReviewDate = reviewDate;

            if (answers != null)
                Answers = answers.ToList();
        }
    }
}