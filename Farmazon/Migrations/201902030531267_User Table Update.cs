namespace Farmazon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserType", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "Hometown");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Hometown", c => c.String());
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "UserType");
        }
    }
}
