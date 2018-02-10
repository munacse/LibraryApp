using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryApp.Core.Helpers;
using LibraryApp.Core.Services;
using LibraryApp.Core.Services.Interface;
using LibraryApp.DataAccess;
using LibraryApp.Mongo.Interfaces;
using LibraryApp.Mongo.Model;
using LibraryApp.Mongo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace LibraryApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //== Add DbContext =====
            var connectionString = Configuration["connectionStrings:DefaultConnection"];
            services.AddDbContext<LibraryAppDbContext>(o => o.UseSqlServer(connectionString));

            //== Add Identity =====
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<LibraryAppDbContext>()
                .AddDefaultTokenProviders();

            Mapper.Initialize(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            });
            

            RegisterCoreServices(services);

            //Mongo
            services.Configure<Settings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database
                    = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddTransient<IUnitOfWorkMongo, UnitOfWorkMongo>();




            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Contacts API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API V1");
            });

        }

        private void RegisterCoreServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<IBookService, BookService>();
        }
    }
}
