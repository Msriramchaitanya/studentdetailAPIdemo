using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using studentdetailAPIdemo.Data;
using studentdetailAPIdemo.Models;
using studentdetailAPIdemo.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        string policy = "FirstPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddDbContext<StudentContext>(option => option.UseSqlServer(Configuration.GetConnectionString("StudentContext")));
            services.AddScoped<IProductsRepository, ProductRepository>();
            //services.AddRazorPages();
            services.Configure<MongoSettings>(Configuration.GetSection(MongoSettings.MongoSection));
            services.AddScoped<IProductsContext, ProductsContext>();
            
            services.AddCors(a => a.AddPolicy(name:policy,a=> {

                a.AllowAnyOrigin();
                a.AllowAnyMethod();
                a.AllowAnyHeader();
                }));

            services.AddSwaggerGen(options=>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "StudentDetails API Demo",
                    Description = "Demo API Showing StudentDetails",
                    Version = "v1"
                });
            });
            services.AddControllers(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(a => a.AllowAnyMethod());
            app.UseCors(a => a.AllowAnyOrigin());
            app.UseCors(a => a.AllowAnyHeader());
            app.UseCors(policy);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentDetails API Demo");
            });
        }
    }
}
