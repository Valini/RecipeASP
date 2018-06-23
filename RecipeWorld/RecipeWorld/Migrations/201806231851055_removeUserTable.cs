namespace RecipeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUserTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Recipes", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Recipes", new[] { "UserId" });
            CreateTable(
                "dbo.RecipeComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        ParentArticleId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Contents = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipes", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Recipes", "UserId");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        ParentArticleId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Contents = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipes", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Recipes", "Email");
            DropTable("dbo.RecipeComments");
            CreateIndex("dbo.Recipes", "UserId");
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Recipes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
