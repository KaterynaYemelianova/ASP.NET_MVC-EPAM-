using System;
using System.Collections.Generic;

namespace HomeTaskOne.Models.PageItemModels
{
    public class Review : PageItemBase
    {
        public string AuthorName { get; private set; }
        public DateTime ReviewDate { get; private set; }
        public List<Review> Answers { get; private set; }

        public Review(string title, string body, string authorName,
                      DateTime reviewDate, List<Review> answers = null) : base(title, body)
        {
            AuthorName = authorName;
            ReviewDate = reviewDate;
            Answers = answers == null ? new List<Review>() : answers;
        }
    }
}