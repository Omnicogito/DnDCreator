namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchange : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Character", "CharRaceID");
            CreateIndex("dbo.Character", "CharClassID");
            AddForeignKey("dbo.Character", "CharClassID", "dbo.CharClass", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Character", "CharRaceID", "dbo.CharRace", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "CharRaceID", "dbo.CharRace");
            DropForeignKey("dbo.Character", "CharClassID", "dbo.CharClass");
            DropIndex("dbo.Character", new[] { "CharClassID" });
            DropIndex("dbo.Character", new[] { "CharRaceID" });
        }
    }
}
