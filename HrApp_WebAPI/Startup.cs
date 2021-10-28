using HrApp_WebAPI.BusinessLogic.Interfaces;
using HrApp_WebAPI.BusinessLogic.Services;
using HrApp_WebAPI.Data.Entities.Companies;
using HrApp_WebAPI.Data.Entities.Companies.Employees;
using HrApp_WebAPI.Data.Entities.Pagination;
using HrApp_WebAPI.Data.Entities.Users;
using HrApp_WebAPI.Extensions;
using HrApp_WebAPI.Helpers;
using HrApp_WebAPI.Interfaces;
using HrApp_WebAPI.Middlewares;
using HrApp_WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System.Text.Json;

namespace Mini_HR_App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<CompanyContext>(opts =>
                                            opts.UseSqlServer(_config.GetConnectionString("sqlConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<CompanyContext>()
                .AddDefaultTokenProviders();

            services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                o.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            });

            services.AddCors();
            IdentityModelEventSource.ShowPII = true;
            services.AddAuthentication();
            services.AddAuthorization();

            services.AddIdentityService();
            services.AddJwtToken(_config);

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAdministratorService, AdministratorService>();
            services.AddScoped<IDataShaper<Employee>, DataShaper<Employee>>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(policy => policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
