namespace OnlineCookbook.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CookBook1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alergen",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AlergenName = c.String(nullable: false, maxLength: 50),
                        Abrv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeAlergen",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AlergenId = c.String(nullable: false, maxLength: 128),
                        RecipeId = c.String(nullable: false, maxLength: 128),
                        AlergenQuantity = c.Int(nullable: false),
                        AlergenUnit = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alergen", t => t.AlergenId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.AlergenId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CategoryId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        RecipeTitle = c.String(nullable: false, maxLength: 50),
                        RecipeDescription = c.String(nullable: false, maxLength: 50),
                        RecipeComplexity = c.Boolean(nullable: false),
                        RecipeText = c.String(nullable: false),
                        Abrv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Abrv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        RecipeId = c.String(nullable: false, maxLength: 128),
                        CommentText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Password = c.String(nullable: false, maxLength: 50),
                        ConfirmPassword = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FavouriteUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        FavouriteId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Favourite", t => t.FavouriteId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FavouriteId);
            
            CreateTable(
                "dbo.Favourite",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RecipeId = c.String(nullable: false, maxLength: 128),
                        FavouriteName = c.String(nullable: false, maxLength: 50),
                        Abrv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MessageUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MessageId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Message", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MessageId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TextMessage = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PreparationStep",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RecipeId = c.String(nullable: false, maxLength: 128),
                        StepNumber = c.Int(nullable: false),
                        PreparationText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.PreparationStepPicture",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PreparationStepId = c.String(nullable: false, maxLength: 128),
                        StepPicture = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PreparationStep", t => t.PreparationStepId, cascadeDelete: true)
                .Index(t => t.PreparationStepId);
            
            CreateTable(
                "dbo.RecipeIngradient",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IngradientId = c.String(nullable: false, maxLength: 128),
                        RecipeId = c.String(nullable: false, maxLength: 128),
                        IngradientQuantity = c.Int(nullable: false),
                        IngradientUnit = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingradient", t => t.IngradientId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.IngradientId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Ingradient",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IngradientName = c.String(nullable: false, maxLength: 50),
                        Abrv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipePicture",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RecipeId = c.String(nullable: false, maxLength: 128),
                        RecipePicture = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RecipeAlergen", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "UserId", "dbo.User");
            DropForeignKey("dbo.RecipePicture", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.RecipeIngradient", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.RecipeIngradient", "IngradientId", "dbo.Ingradient");
            DropForeignKey("dbo.PreparationStep", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.PreparationStepPicture", "PreparationStepId", "dbo.PreparationStep");
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.MessageUser", "UserId", "dbo.User");
            DropForeignKey("dbo.MessageUser", "MessageId", "dbo.Message");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.User");
            DropForeignKey("dbo.FavouriteUser", "UserId", "dbo.User");
            DropForeignKey("dbo.FavouriteUser", "FavouriteId", "dbo.Favourite");
            DropForeignKey("dbo.Favourite", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.User");
            DropForeignKey("dbo.Comment", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.RecipeAlergen", "AlergenId", "dbo.Alergen");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RecipePicture", new[] { "RecipeId" });
            DropIndex("dbo.RecipeIngradient", new[] { "RecipeId" });
            DropIndex("dbo.RecipeIngradient", new[] { "IngradientId" });
            DropIndex("dbo.PreparationStepPicture", new[] { "PreparationStepId" });
            DropIndex("dbo.PreparationStep", new[] { "RecipeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.MessageUser", new[] { "UserId" });
            DropIndex("dbo.MessageUser", new[] { "MessageId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Favourite", new[] { "RecipeId" });
            DropIndex("dbo.FavouriteUser", new[] { "FavouriteId" });
            DropIndex("dbo.FavouriteUser", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.Comment", new[] { "RecipeId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.Recipe", new[] { "UserId" });
            DropIndex("dbo.Recipe", new[] { "CategoryId" });
            DropIndex("dbo.RecipeAlergen", new[] { "RecipeId" });
            DropIndex("dbo.RecipeAlergen", new[] { "AlergenId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RecipePicture");
            DropTable("dbo.Ingradient");
            DropTable("dbo.RecipeIngradient");
            DropTable("dbo.PreparationStepPicture");
            DropTable("dbo.PreparationStep");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Message");
            DropTable("dbo.MessageUser");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Favourite");
            DropTable("dbo.FavouriteUser");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.User");
            DropTable("dbo.Comment");
            DropTable("dbo.Category");
            DropTable("dbo.Recipe");
            DropTable("dbo.RecipeAlergen");
            DropTable("dbo.Alergen");
        }
    }
}
