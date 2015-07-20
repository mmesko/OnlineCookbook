namespace OnlineCookbook.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ff : DbMigration
    {
        public override void Up()
        {


            //RenameTable(name: "dbo.FavouriteUserUsers", newName: "UserFavouriteUsers");
            //DropForeignKey("dbo.PreparationStepPicture", "PreparationStepId", "dbo.PreparationStep");
            //DropForeignKey("dbo.PreparationStep", "RecipeId", "dbo.Recipe");
            //DropForeignKey("dbo.RecipePicture", "RecipeId", "dbo.Recipe");
            //DropIndex("dbo.PreparationStep", new[] { "RecipeId" });
            //DropIndex("dbo.PreparationStepPicture", new[] { "PreparationStepId" });
            //DropIndex("dbo.RecipePicture", new[] { "RecipeId" });
            //DropPrimaryKey("dbo.UserFavouriteUsers");
            //AddPrimaryKey("dbo.UserFavouriteUsers", new[] { "User_Id", "FavouriteUser_Id" });
            //DropTable("dbo.PreparationStep");
            //DropTable("dbo.PreparationStepPicture");
            //DropTable("dbo.RecipePicture");
        }

        public override void Down()
        {

            //    CreateTable(
            //        "dbo.RecipePicture",
            //        c => new
            //            {
            //                Id = c.String(nullable: false, maxLength: 128),
            //                RecipeId = c.String(nullable: false, maxLength: 128),
            //                RecipePicture = c.Binary(nullable: false),
            //            })
            //        .PrimaryKey(t => t.Id);

            //    CreateTable(
            //        "dbo.PreparationStepPicture",
            //        c => new
            //            {
            //                Id = c.String(nullable: false, maxLength: 128),
            //                PreparationStepId = c.String(nullable: false, maxLength: 128),
            //                StepPicture = c.Binary(nullable: false),
            //            })
            //        .PrimaryKey(t => t.Id);

            //    CreateTable(
            //        "dbo.PreparationStep",
            //        c => new
            //            {
            //                Id = c.String(nullable: false, maxLength: 128),
            //                RecipeId = c.String(nullable: false, maxLength: 128),
            //                StepNumber = c.Int(nullable: false),
            //                PreparationText = c.String(nullable: false),
            //            })
            //        .PrimaryKey(t => t.Id);

            //    DropPrimaryKey("dbo.UserFavouriteUsers");
            //    AddPrimaryKey("dbo.UserFavouriteUsers", new[] { "FavouriteUser_Id", "User_Id" });
            //    CreateIndex("dbo.RecipePicture", "RecipeId");
            //    CreateIndex("dbo.PreparationStepPicture", "PreparationStepId");
            //    CreateIndex("dbo.PreparationStep", "RecipeId");
            //    AddForeignKey("dbo.RecipePicture", "RecipeId", "dbo.Recipe", "Id", cascadeDelete: true);
            //    AddForeignKey("dbo.PreparationStep", "RecipeId", "dbo.Recipe", "Id", cascadeDelete: true);
            //    AddForeignKey("dbo.PreparationStepPicture", "PreparationStepId", "dbo.PreparationStep", "Id", cascadeDelete: true);
            //    RenameTable(name: "dbo.UserFavouriteUsers", newName: "FavouriteUserUsers");
            //}
        }
    }
}
