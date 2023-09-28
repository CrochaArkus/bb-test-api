using Microsoft.EntityFrameworkCore;

namespace Challenge.Entities.Entities
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) { }


        public DbSet<Categories> categories { get; set; }
        public DbSet<SubCategories> subCategories { get; set; }
        public DbSet<ImageUpload> imageUploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().ToTable("category");
            modelBuilder.Entity<SubCategories>().ToTable("subCategory");
            modelBuilder.Entity<ImageUpload>().ToTable("imageUpload");
        }
    }
}
