namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedKeytoCharRace : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CharRace", "ID", "dbo.Character");
            DropIndex("dbo.CharRace", new[] { "ID" });
            DropPrimaryKey("dbo.CharRace");
            AddColumn("dbo.CharRace", "CharacterID", c => c.Int(nullable: false));
            AlterColumn("dbo.CharRace", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CharRace", "ID");
            CreateIndex("dbo.CharRace", "CharacterID");
            AddForeignKey("dbo.CharRace", "CharacterID", "dbo.Character", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharRace", "CharacterID", "dbo.Character");
            DropIndex("dbo.CharRace", new[] { "CharacterID" });
            DropPrimaryKey("dbo.CharRace");
            AlterColumn("dbo.CharRace", "ID", c => c.Int(nullable: false));
            DropColumn("dbo.CharRace", "CharacterID");
            AddPrimaryKey("dbo.CharRace", "ID");
            CreateIndex("dbo.CharRace", "ID");
            AddForeignKey("dbo.CharRace", "ID", "dbo.Character", "ID");
        }
    }
}
