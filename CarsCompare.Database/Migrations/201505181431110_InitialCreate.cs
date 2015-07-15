using System.Data.Entity.Migrations;

namespace CarsCompare.Database.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(nullable: false, maxLength: 128),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    RoleId = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Brand",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                    DatabaseVersion = c.Int(nullable: false),
                    ItemType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Model",
                c => new
                {
                    Id = c.Int(nullable: false),
                    BrandId = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                    DatabaseVersion = c.Int(nullable: false),
                    ItemType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.BrandId)
                .Index(t => t.BrandId);

            CreateTable(
                "dbo.Modify",
                c => new
                {
                    Id = c.Int(nullable: false),
                    ModelId = c.Int(nullable: false),
                    VersionId = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                    YearFrom = c.Int(nullable: false),
                    YearTo = c.Int(nullable: false),
                    DatabaseVersion = c.Int(nullable: false),
                    ItemType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Version", t => t.VersionId)
                .ForeignKey("dbo.Model", t => t.ModelId)
                .Index(t => t.ModelId)
                .Index(t => t.VersionId);

            CreateTable(
                "dbo.Param",
                c => new
                {
                    Id = c.Int(nullable: false),
                    ModifyId = c.Int(nullable: false),
                    ParamNameId = c.Int(nullable: false),
                    Value = c.String(nullable: false, maxLength: 255),
                    DatabaseVersion = c.Int(nullable: false),
                    ItemType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParamName", t => t.ParamNameId)
                .ForeignKey("dbo.Modify", t => t.ModifyId)
                .Index(t => t.ModifyId)
                .Index(t => t.ParamNameId);

            CreateTable(
                "dbo.ParamName",
                c => new
                {
                    Id = c.Int(nullable: false),
                    ParamGroupId = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                    Units = c.String(nullable: false, maxLength: 255),
                    DatabaseVersion = c.Int(nullable: false),
                    ItemType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParamGroup", t => t.ParamGroupId)
                .Index(t => t.ParamGroupId);

            CreateTable(
                "dbo.ParamGroup",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                    DatabaseVersion = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Version",
                c => new
                {
                    Id = c.Int(nullable: false),
                    ModelId = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                    Gen = c.String(nullable: false, maxLength: 255),
                    Mod = c.String(nullable: false, maxLength: 255),
                    DatabaseVersion = c.Int(nullable: false),
                    ItemType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Model", t => t.ModelId)
                .Index(t => t.ModelId);

            CreateTable(
                "dbo.Log",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    Thread = c.String(maxLength: 255),
                    Level = c.String(maxLength: 50),
                    IpAddress = c.String(maxLength: 25),
                    Message = c.String(maxLength: 4000),
                    Exception = c.String(maxLength: 2000),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Model", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Version", "ModelId", "dbo.Model");
            DropForeignKey("dbo.Modify", "ModelId", "dbo.Model");
            DropForeignKey("dbo.Modify", "VersionId", "dbo.Version");
            DropForeignKey("dbo.Param", "ModifyId", "dbo.Modify");
            DropForeignKey("dbo.Param", "ParamNameId", "dbo.ParamName");
            DropForeignKey("dbo.ParamName", "ParamGroupId", "dbo.ParamGroup");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Version", new[] { "ModelId" });
            DropIndex("dbo.ParamName", new[] { "ParamGroupId" });
            DropIndex("dbo.Param", new[] { "ParamNameId" });
            DropIndex("dbo.Param", new[] { "ModifyId" });
            DropIndex("dbo.Modify", new[] { "VersionId" });
            DropIndex("dbo.Modify", new[] { "ModelId" });
            DropIndex("dbo.Model", new[] { "BrandId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Log");
            DropTable("dbo.Version");
            DropTable("dbo.ParamGroup");
            DropTable("dbo.ParamName");
            DropTable("dbo.Param");
            DropTable("dbo.Modify");
            DropTable("dbo.Model");
            DropTable("dbo.Brand");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}