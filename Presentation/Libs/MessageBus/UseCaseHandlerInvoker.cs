using System;
using UseCase.Core;

namespace ControlPanelVueSPA.Library.Bus
{
    public class UseCaseHandlerInvoker
    {
        private readonly Type usecaseType;
        private readonly Func<object, object> invokeMethod;
        
        public UseCaseHandlerInvoker(Type usecaseType, Func<object, object> invokeMethod)
        {
            this.usecaseType = usecaseType;
            this.invokeMethod = invokeMethod;
        }

        public TResponse Invoke<TResponse>(object request)
            where TResponse : IResponse
        {
            var responseObject = invokeMethod(request);
            var response = (TResponse)responseObject;

            return response;
        }
    }
}
