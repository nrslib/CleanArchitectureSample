using ControlPanelVueSPA.Library.Bus;
using Domain.Application.Articles;
using Domain.Domain.Model.Articles;
using Domain.Domain.Model.Users;
using InMemoryDataStore.Articles;
using InMemoryDataStore.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Services.Article;
using UseCase.Articles.CreateCommand;
using UseCase.Articles.DetailQuery;
using UseCase.Articles.GetByAutherQuery;

namespace Presentation
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

            services.AddSingleton<IArticleRepository, ArticleRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IArticleService, ArticleService>();

            var busBuilder = new UseCaseBusBuilder(services);
            busBuilder.RegisterUseCase<ArticleCreateParameter, IArticleCreateCommand, ArticleCreateCommand>();
            busBuilder.RegisterUseCase<ArticleDetailParameter, IArticleDetailQuery, ArticleDetailQuery>();
            busBuilder.RegisterUseCase<ArticleGetByAutherParameter, IArticleGetByAutherQuery, ArticleGetByAutherQuery>();
            var bus = busBuilder.Build();
            services.AddSingleton(bus);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
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
            });
        }
    }
}
