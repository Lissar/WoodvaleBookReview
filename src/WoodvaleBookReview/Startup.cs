using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using WoodvaleBookReview.Models;
using Microsoft.EntityFrameworkCore;
using WoodvaleBookReview.Models.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WoodvaleBookReview
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionStrings:MainConnection"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionStrings:IdentityConnection"]));

            services.AddIdentity<User, IdentityRole>(opts =>
            { opts.Cookies.ApplicationCookie.LoginPath = "/Login/Login"; })
                 .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddIdentity<User, IdentityRole>(options => options.Cookies.ApplicationCookie.AccessDeniedPath = "/Error/Error");

            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseIdentity();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseSession();
            SeedData.EnsurePopulated(app);
        }
    }
}
