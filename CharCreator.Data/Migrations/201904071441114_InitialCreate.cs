namespace CharCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        CharName = c.String(),
                        CharRaceID = c.Int(nullable: false),
                        CharClassID = c.Int(nullable: false),
                        Alignment = c.Int(nullable: false),
                        Background = c.Int(nullable: false),
                        CharHistory = c.String(),
                        ExperiencePoints = c.Int(nullable: false),
                        Traits = c.String(),
                        Level = c.Int(nullable: false),
                        Player_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Player", t => t.Player_ID)
                .Index(t => t.Player_ID);
            
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoryName = c.String(),
                        Character_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Character", t => t.Character_ID)
                .Index(t => t.Character_ID);
            
            CreateTable(
                "dbo.CharClass",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ClassName = c.String(),
                        SpellCaster = c.Boolean(nullable: false),
                        HitPointsFirstLevel = c.Int(nullable: false),
                        Proficiencies = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Character", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.CharRace",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        RaceName = c.String(),
                        Size = c.Int(nullable: false),
                        Speed = c.String(),
                        SpecialAttributes = c.String(),
                        Languages = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Character", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        Location = c.String(),
                        ExperienceLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Character", "Player_ID", "dbo.Player");
            DropForeignKey("dbo.CharRace", "ID", "dbo.Character");
            DropForeignKey("dbo.CharClass", "ID", "dbo.Character");
            DropForeignKey("dbo.Story", "Character_ID", "dbo.Character");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CharRace", new[] { "ID" });
            DropIndex("dbo.CharClass", new[] { "ID" });
            DropIndex("dbo.Story", new[] { "Character_ID" });
            DropIndex("dbo.Character", new[] { "Player_ID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Player");
            DropTable("dbo.CharRace");
            DropTable("dbo.CharClass");
            DropTable("dbo.Story");
            DropTable("dbo.Character");
        }
    }
}
