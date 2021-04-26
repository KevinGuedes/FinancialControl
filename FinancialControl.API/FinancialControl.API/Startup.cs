using FinancialControl.API.Validators;
using FinancialControl.BLL.Models;
using FinancialControl.DAL;
using FinancialControl.DAL.Interfaces;
using FinancialControl.DAL.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace FinancialControl.API
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

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("FinancialControlDB")));

            services
                .AddIdentity<User, Function>()
                .AddEntityFrameworkStores<Context>();

            services.AddCors();

            services.AddTransient<IValidator<Category>, CategoryValidator>();

            services
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<ITypeRepository, TypeRepository>();

            services
                .AddControllers()
                .AddFluentValidation()
                .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddSpaStaticFiles(directory =>
            //{
            //    directory.RootPath = "FinancialControlUI";
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseStaticFiles();

            //app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "FinancialControlUI");

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseProxyToSpaDevelopmentServer($"http://localhost:4200/");
            //    }
            //});
        }
    }
}
