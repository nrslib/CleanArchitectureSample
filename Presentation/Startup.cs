using Domain.Application.Articles;
using Domain.Domain.Model.Articles;
using Domain.Domain.Model.Users;
using InMemoryDataStore.Articles;
using InMemoryDataStore.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Articles.Create;
using UseCase.Articles.GetDetail;
using UseCase.Articles.GetByAutherQuery;
using UseCase.Core.Bus;

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
            
            var busBuilder = new UseCaseBusBuilder(services);
            busBuilder.RegisterUseCase<ArticleCreateRequest, ArticleCreateInteractor>();
            busBuilder.RegisterUseCase<ArticleGetDetailRequest, ArticleDetailGetInteractor>();
            busBuilder.RegisterUseCase<ArticleGetByAutherRequest, ArticleGetByAutherInteractor>();
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
