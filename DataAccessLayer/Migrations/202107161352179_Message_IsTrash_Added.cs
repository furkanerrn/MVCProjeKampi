namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message_IsTrash_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsTrash", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsTrash");
        }
    }
}
