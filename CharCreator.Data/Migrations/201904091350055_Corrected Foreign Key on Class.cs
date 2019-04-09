namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedForeignKeyonClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CharClass", "ID", "dbo.Character");
            DropIndex("dbo.CharClass", new[] { "ID" });
            DropPrimaryKey("dbo.CharClass");
            AlterColumn("dbo.CharClass", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CharClass", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CharClass");
            AlterColumn("dbo.CharClass", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CharClass", "ID");
            CreateIndex("dbo.CharClass", "ID");
            AddForeignKey("dbo.CharClass", "ID", "dbo.Character", "ID");
        }
    }
}
