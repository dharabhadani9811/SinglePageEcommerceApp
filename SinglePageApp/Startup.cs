
using DharaProject.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SinglePageApp.Api.Services;
using SinglePageApp.Configuration;
using System.Text;

namespace DharaProject
{
    public class Startup
    {
        private const string value = "http://localhost:4000";
        private IConfiguration Configuration;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services.AddControllers();
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DharaProjectConnection")));
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            services.AddScoped<IUserService, UserService>();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JWTMiddleware>();

            app.UseEndpoints(x => x.MapControllers("/api/user"));

           

        }
    }   
}
