namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Story", "CharacterID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Story", "CharacterID");
        }
    }
}
