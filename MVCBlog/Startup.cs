using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCBlog.Models.DataAccess.EntityFramework;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(@"Server=DESKTOP-3EVB481; Database=MyBlog; Trusted_Connection=True;"));
            services.AddControllersWithViews();

            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();

            //services.AddControllersWithViews().AddJsonOptions(o =>
            //{
            //    o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //    o.JsonSerializerOptions.PropertyNamingPolicy = null;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
