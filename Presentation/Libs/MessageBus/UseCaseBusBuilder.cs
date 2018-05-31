using Microsoft.Extensions.DependencyInjection;
using UseCase.Core;

namespace ControlPanelVueSPA.Library.Bus
{
    public class UseCaseBusBuilder
    {
        private readonly IServiceCollection services;
        private readonly UseCaseBus bus;

        public UseCaseBusBuilder(IServiceCollection services)
        {
            this.services = services;
            bus = new UseCaseBus();
        }

        public UseCaseBus Build()
        {
            var provider = services.BuildServiceProvider();
            bus.Setup(provider);

            return bus;
        }

        public void RegisterUseCase<TRequest, TUseCase, TImplement>()
            where TUseCase : class, IUseCase<TRequest, IResponse>
            where TRequest : IRequest<IResponse>
            where TImplement : class, TUseCase
        {
            services.AddSingleton<TUseCase, TImplement>();
            bus.Register<TRequest, TUseCase>();
        }
    }
}
