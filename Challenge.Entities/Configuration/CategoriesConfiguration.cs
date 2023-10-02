using Challenge.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Entities.Configuration
{
    public class CategoriesConfiguration: IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {

            builder.HasData(
                new Categories
                {
                    id_categories = 1,
                    name = "Marketing",
                    active = true,
                    create_date = DateTime.Now,
                    update_date = Convert.ToDateTime("0001-01-01 00:00:00.0000000")               },
                new Categories
                {
                    id_categories = 2,
                    name = "Products",
                    active = true,
                    create_date = DateTime.Now,
                    update_date = Convert.ToDateTime("0001-01-01 00:00:00.0000000")

                }
             );
        }
    }
}
