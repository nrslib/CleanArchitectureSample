using Microsoft.Extensions.DependencyInjection;

namespace UseCase.Core.Bus
{
    public class UseCaseBusBuilder
    {
        private readonly IServiceCollection services;
        private readonly UseCaseBus bus = new UseCaseBus();

        public UseCaseBusBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public UseCaseBus Build()
        {
            var provider = services.BuildServiceProvider();
            bus.Setup(provider);
            return bus;
        }

        public void RegisterUseCase<TRequest, TImplement>()
            where TRequest : IRequest<IResponse>
            where TImplement : class, IUseCase<TRequest, IResponse>
        {
            services.AddSingleton<TImplement>();
            bus.Register<TRequest, TImplement>();
        }
    }
}
