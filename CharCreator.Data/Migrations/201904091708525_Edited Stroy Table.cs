namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedStroyTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Story", "Character_ID", "dbo.Character");
            DropIndex("dbo.Story", new[] { "Character_ID" });
            CreateTable(
                "dbo.StoryCharacter",
                c => new
                    {
                        Story_ID = c.Int(nullable: false),
                        Character_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Story_ID, t.Character_ID })
                .ForeignKey("dbo.Story", t => t.Story_ID, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.Character_ID, cascadeDelete: true)
                .Index(t => t.Story_ID)
                .Index(t => t.Character_ID);
            
            DropColumn("dbo.Story", "Character_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Story", "Character_ID", c => c.Int());
            DropForeignKey("dbo.StoryCharacter", "Character_ID", "dbo.Character");
            DropForeignKey("dbo.StoryCharacter", "Story_ID", "dbo.Story");
            DropIndex("dbo.StoryCharacter", new[] { "Character_ID" });
            DropIndex("dbo.StoryCharacter", new[] { "Story_ID" });
            DropTable("dbo.StoryCharacter");
            CreateIndex("dbo.Story", "Character_ID");
            AddForeignKey("dbo.Story", "Character_ID", "dbo.Character", "ID");
        }
    }
}
