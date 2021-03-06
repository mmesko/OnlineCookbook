using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using OnlineCookbook.DAL.Models.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineCookbook.DAL.Models
{
    public partial class CookBookContext : IdentityDbContext<User>, ICookBookContext
    {
        static CookBookContext()
        {
            Database.SetInitializer<CookBookContext>(null);
        }

        public CookBookContext()
            : base("Name=CookBookContext", throwIfV1Schema: false)
        {
        }

        // remove user bc you're using identity!
        public DbSet<Alergen> Alergens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<FavouriteUser> FavouriteUsers { get; set; }
        public DbSet<Ingradient> Ingradients { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageUser> MessageUsers { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeAlergen> RecipeAlergens { get; set; }
        public DbSet<RecipeIngradient> RecipeIngradients { get; set; }

        public DbSet<RecipePicture> RecipePictures { get; set; }

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

            modelBuilder.Configurations.Add(new RecipeMap());
            modelBuilder.Configurations.Add(new RecipeAlergenMap());
            modelBuilder.Configurations.Add(new RecipeIngradientMap());
            modelBuilder.Configurations.Add(new RecipePictureMap());

            modelBuilder.Configurations.Add(new UserMap());

            base.OnModelCreating(modelBuilder);
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

        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipeAlergen> RecipeAlergens { get; set; }
        DbSet<RecipeIngradient> RecipeIngradients { get; set; }
        DbSet<RecipePicture> RecipePictures { get; set; }



        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync();

    }

}
