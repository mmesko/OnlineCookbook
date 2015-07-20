namespace OnlineCookbook.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRows : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "UserName", c => c.String());
            AddColumn("dbo.Comment", "DateCreated", c => c.DateTime()); 
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comment", "UserName");
            DropColumn("dbo.Comment", "DateCreated");
        }
    }
}
