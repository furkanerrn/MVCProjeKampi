namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skill_updated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skills", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
