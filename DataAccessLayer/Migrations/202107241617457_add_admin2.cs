namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_admin2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin2",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminUserName = c.Binary(),
                        AdminPasswordHash = c.Binary(),
                        AdminPasswordSalt = c.Binary(),
                        AdminRole = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admin2");
        }
    }
}
