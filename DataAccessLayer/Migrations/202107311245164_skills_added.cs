namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skills_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillCardId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Text = c.String(),
                        Image = c.String(maxLength: 250),
                        SkillName1 = c.String(),
                        SkillStage1 = c.Int(nullable: false),
                        SkillName2 = c.String(),
                        SkillStage2 = c.Int(nullable: false),
                        SkillName3 = c.String(),
                        SkillStage3 = c.Int(nullable: false),
                        SkillName4 = c.String(),
                        SkillStage4 = c.Int(nullable: false),
                        SkillName5 = c.String(),
                        SkillStage5 = c.Int(nullable: false),
                        SkillName6 = c.String(),
                        SkillStage6 = c.Int(nullable: false),
                        SkillName7 = c.String(),
                        SkillStage7 = c.Int(nullable: false),
                        SkillName8 = c.String(),
                        SkillStage8 = c.Int(nullable: false),
                        SkillName9 = c.String(),
                        SkillStage9 = c.Int(nullable: false),
                        SkillName10 = c.String(),
                        SkillStage10 = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillCardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
        }
    }
}
