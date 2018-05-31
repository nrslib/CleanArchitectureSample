using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCase.Core;

namespace ControlPanelVueSPA.Library.Bus
{
    public class UseCaseBus
    {
        /// <summary>
        /// Request と Handler の対応表
        /// </summary>
        private readonly Dictionary<Type, Type> handlerTypes = new Dictionary<Type, Type>();
        private readonly ConcurrentDictionary<Type, UseCaseHandlerInvoker> invokers = new ConcurrentDictionary<Type, UseCaseHandlerInvoker>();
        private IServiceProvider provider;

        public void Setup(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public void Register<TRequest, TUseCase>()
            where TRequest : IRequest<IResponse>
            where TUseCase : IUseCase<TRequest, IResponse>
        {
            if (handlerTypes.ContainsKey(typeof(TRequest)))
            {
                throw new Exception($"Duplicate register(RequestType: { typeof(TRequest).Name }).");
            }

            handlerTypes.Add(typeof(TRequest), typeof(TUseCase));
        }

        public TResponse Handle<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse
        {
            var invoker = Invoker(request);
            var response = invoker.Invoke<TResponse>(request);

            return response;
        }

        public async Task<TResponse> HandleAsync<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse
        {
            var invoker = Invoker(request);
            var result = await Task.Run(() => invoker.Invoke<TResponse>(request));

            return result;
        }

        private UseCaseHandlerInvoker Invoker<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse
        {
            var requestType = request.GetType();
            if (invokers.TryGetValue(requestType, out var searchedInvoker))
            {
                return searchedInvoker;
            }
            if (!handlerTypes.TryGetValue(requestType, out var handlerType))
            {
                throw new Exception($"Not registered usecase for this request(RequestType: { request.GetType().Name })");
            }
            var handlerObject = provider.GetService(handlerType);
            var method = handlerObject.GetType().GetMethod("Handle");

            var createdInvokeMethod = new Func<object, object>((req) =>
            {
                var result = method.Invoke(handlerObject, new[] { req });
                return result;
            });

            var createdInvoker = new UseCaseHandlerInvoker(handlerObject.GetType(), createdInvokeMethod);
            var instance = invokers.GetOrAdd(requestType, createdInvoker);

            return instance;
        }
    }
}
