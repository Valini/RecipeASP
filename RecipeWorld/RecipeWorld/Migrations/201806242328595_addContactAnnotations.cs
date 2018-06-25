namespace RecipeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContactAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Contacts", "Message", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Contacts", "Message", c => c.String());
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Contacts", "FullName", c => c.String());
        }
    }
}
