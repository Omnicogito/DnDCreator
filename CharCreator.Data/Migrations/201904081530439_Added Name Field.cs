namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "Player_ID", "dbo.Player");
            DropIndex("dbo.Character", new[] { "Player_ID" });
            AddColumn("dbo.ApplicationUser", "Name", c => c.String());
            DropColumn("dbo.Character", "Player_ID");
            DropTable("dbo.Player");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        Location = c.String(),
                        ExperienceLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Character", "Player_ID", c => c.Int());
            DropColumn("dbo.ApplicationUser", "Name");
            CreateIndex("dbo.Character", "Player_ID");
            AddForeignKey("dbo.Character", "Player_ID", "dbo.Player", "ID");
        }
    }
}
