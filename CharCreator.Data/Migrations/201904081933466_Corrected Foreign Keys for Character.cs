namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedForeignKeysforCharacter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CharRace", "CharacterID", "dbo.Character");
            DropIndex("dbo.CharRace", new[] { "CharacterID" });
            DropColumn("dbo.CharRace", "CharacterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CharRace", "CharacterID", c => c.Int(nullable: false));
            CreateIndex("dbo.CharRace", "CharacterID");
            AddForeignKey("dbo.CharRace", "CharacterID", "dbo.Character", "ID", cascadeDelete: true);
        }
    }
}
