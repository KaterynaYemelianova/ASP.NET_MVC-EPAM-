namespace HomeTaskOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Summary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayText = c.String(),
                        IsRight = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        ReviewDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                        Review_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reviews", t => t.Review_Id)
                .Index(t => t.Review_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Review_Id", "dbo.Reviews");
            DropForeignKey("dbo.Variants", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Reviews", new[] { "Review_Id" });
            DropIndex("dbo.Variants", new[] { "QuestionId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Variants");
            DropTable("dbo.Questions");
            DropTable("dbo.Articles");
        }
    }
}
