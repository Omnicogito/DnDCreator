namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stuff2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CharacterListItem", newName: "Character");
            RenameTable(name: "dbo.StoryCharacterListItem", newName: "StoryCharacter");
            RenameColumn(table: "dbo.StoryCharacter", name: "CharacterListItem_ID", newName: "Character_ID");
            RenameIndex(table: "dbo.StoryCharacter", name: "IX_CharacterListItem_ID", newName: "IX_Character_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StoryCharacter", name: "IX_Character_ID", newName: "IX_CharacterListItem_ID");
            RenameColumn(table: "dbo.StoryCharacter", name: "Character_ID", newName: "CharacterListItem_ID");
            RenameTable(name: "dbo.StoryCharacter", newName: "StoryCharacterListItem");
            RenameTable(name: "dbo.Character", newName: "CharacterListItem");
        }
    }
}
