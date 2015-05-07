using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using OnlineCookbook.DAL.Models.Mapping;

namespace OnlineCookbook.DAL.Models
{
    public partial class CookBookContext : DbContext, ICookBookContext
    {
        static CookBookContext()
        {
            Database.SetInitializer<CookBookContext>(null);
        }

        public CookBookContext()
            : base("Name=CookBookContext")
        {
        }

        public DbSet<Alergen> Alergens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<FavouriteUser> FavouriteUsers { get; set; }
        public DbSet<Ingradient> Ingradients { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageUser> MessageUsers { get; set; }
        public DbSet<PreparationStep> PreparationSteps { get; set; }
        public DbSet<PreparationStepPicture> PreparationStepPictures { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeAlergen> RecipeAlergens { get; set; }
        public DbSet<RecipeIngradient> RecipeIngradients { get; set; }
        public DbSet<RecipePicture> RecipePictures { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlergenMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new FavouriteMap());
            modelBuilder.Configurations.Add(new FavouriteUserMap());
            modelBuilder.Configurations.Add(new IngradientMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new MessageUserMap());
            modelBuilder.Configurations.Add(new PreparationStepMap());
            modelBuilder.Configurations.Add(new PreparationStepPictureMap());
            modelBuilder.Configurations.Add(new RecipeMap());
            modelBuilder.Configurations.Add(new RecipeAlergenMap());
            modelBuilder.Configurations.Add(new RecipeIngradientMap());
            modelBuilder.Configurations.Add(new RecipePictureMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
        }
    }

   public interface ICookBookContext : IDisposable
   {
	         DbSet<Alergen> Alergens { get; set; }
            DbSet<Category> Categories { get; set; }
            DbSet<Comment> Comments { get; set; }
            DbSet<Favourite> Favourites { get; set; }
            DbSet<FavouriteUser> FavouriteUsers { get; set; }
            DbSet<Ingradient> Ingradients { get; set; }
            DbSet<Message> Messages { get; set; }
            DbSet<MessageUser> MessageUsers { get; set; }
            DbSet<PreparationStep> PreparationSteps { get; set; }
            DbSet<PreparationStepPicture> PreparationStepPictures { get; set; }
            DbSet<Recipe> Recipes { get; set; }
            DbSet<RecipeAlergen> RecipeAlergens { get; set; }
            DbSet<RecipeIngradient> RecipeIngradients { get; set; }
            DbSet<RecipePicture> RecipePictures { get; set; }
            DbSet<Role> Roles { get; set; }
            DbSet<User> Users { get; set; }
            DbSet<UserRole> UserRoles { get; set; }
   
     
         DbSet<TEntity> Set<TEntity>() where TEntity : class;
         DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
         Task<int> SaveChangesAsync();

   }

}
