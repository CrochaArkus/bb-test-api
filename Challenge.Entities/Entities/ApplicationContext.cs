using Microsoft.EntityFrameworkCore;

namespace Challenge.Entities.Entities
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) { }


        public DbSet<Categories> categories { get; set; }
        public DbSet<SubCategories> subCategories { get; set; }
        public DbSet<InteriorSubcategoriesCategories> interiorSubCategories { get; set; }
        public DbSet<ImageUpload> imageUploads { get; set; }
        public DbSet<Content> contents { get; set; }
        public DbSet<MagnamentContentsCategories> magnamentContentsCategories { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Categories>().ToTable("category");
            modelBuilder.Entity<SubCategories>().ToTable("subCategory");
            modelBuilder.Entity<InteriorSubcategoriesCategories>().ToTable("interiorSubCategory");
            modelBuilder.Entity<ImageUpload>().ToTable("imageUpload");
            modelBuilder.Entity<Content>().ToTable("content");
            modelBuilder.Entity<MagnamentContentsCategories>().ToTable("magnamentContentCategory");
        }
    }
}
