namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Something : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Character", newName: "CharacterListItem");
            RenameTable(name: "dbo.StoryCharacter", newName: "StoryCharacterListItem");
            RenameColumn(table: "dbo.StoryCharacterListItem", name: "Character_ID", newName: "CharacterListItem_ID");
            RenameIndex(table: "dbo.StoryCharacterListItem", name: "IX_Character_ID", newName: "IX_CharacterListItem_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StoryCharacterListItem", name: "IX_CharacterListItem_ID", newName: "IX_Character_ID");
            RenameColumn(table: "dbo.StoryCharacterListItem", name: "CharacterListItem_ID", newName: "Character_ID");
            RenameTable(name: "dbo.StoryCharacterListItem", newName: "StoryCharacter");
            RenameTable(name: "dbo.CharacterListItem", newName: "Character");
        }
    }
}
