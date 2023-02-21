using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using octoco_backend_test.Models;


namespace octoco_backend_test
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
            services.AddDbContext<AppDBContext>(options => 
                 options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SurvivorRESTAPI", Version = "V1" });
            });
            // Configure your application's services here.
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure your application's middleware pipeline here.
        }
    }
}
