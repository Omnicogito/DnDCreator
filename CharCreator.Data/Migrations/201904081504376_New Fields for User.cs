namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFieldsforUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "Location", c => c.String());
            AddColumn("dbo.ApplicationUser", "ExperienceLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "ExperienceLevel");
            DropColumn("dbo.ApplicationUser", "Location");
            DropColumn("dbo.ApplicationUser", "Age");
        }
    }
}
