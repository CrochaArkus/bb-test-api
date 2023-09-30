using Categories.Infrastructure.Repositories;
using Categories.lnterfaces;
using Categories.Services;
using Challenge.Entities.Entities;
using Image.Infrastructure.Repositories;
using Image.lnterfaces;
using Image.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Challenge.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesServices, CategoriesServices>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImagesServices, ImagesServices>();

            string SqlConnectionStr = Configuration.GetConnectionString("ChallegeConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(SqlConnectionStr));
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Challenge", Version = "v1" });

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
                if (context != null && context.Database != null)
                {

                    context.Database.Migrate();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Challenge v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();

            });

        }
    }
}
