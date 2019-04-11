namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "CharClassID", "dbo.CharClass");
            DropForeignKey("dbo.Character", "CharRaceID", "dbo.CharRace");
            DropIndex("dbo.Character", new[] { "CharRaceID" });
            DropIndex("dbo.Character", new[] { "CharClassID" });
            AddColumn("dbo.Story", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Story", "Description");
            CreateIndex("dbo.Character", "CharClassID");
            CreateIndex("dbo.Character", "CharRaceID");
            AddForeignKey("dbo.Character", "CharRaceID", "dbo.CharRace", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Character", "CharClassID", "dbo.CharClass", "ID", cascadeDelete: true);
        }
    }
}
