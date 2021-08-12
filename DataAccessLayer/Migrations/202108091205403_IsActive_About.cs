namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActive_About : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "IsActive");
        }
    }
}
