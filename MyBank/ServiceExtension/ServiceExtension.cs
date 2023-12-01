using Microsoft.EntityFrameworkCore;

namespace MyBank.ServiceExtension
{
    public class ServiceExtension
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer("ConnectionStrings:DefaultConnection"));

            services.AddCors( options =>
            {
                options.AddPolicy("CorsPolicy",

                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials()
                    ); 

            });
        }
    }
}
