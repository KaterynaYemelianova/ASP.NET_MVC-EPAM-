using System.Data.Entity;

using HomeTaskOne.Models.PageItemModels;

namespace HomeTaskOne.Data
{
    public class BlogContext : DbContext
    {
        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Review> Reviews { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<Variant> Variants { get; set; }

        public const string NAME = "BlogContext";
        public BlogContext() : base(NAME) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Variant>()
                .HasRequired<Question>(V => V.Question)
                .WithMany(Q => Q.AnswerVariants)
                .HasForeignKey<int>(V => V.QuestionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}