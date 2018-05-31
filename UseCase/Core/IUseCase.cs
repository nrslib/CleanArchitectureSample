namespace UseCase.Core
{
    public interface IUseCase<in TRequest, out TResponse> 
        where TRequest : IRequest<TResponse> 
        where TResponse : IResponse
    {
        TResponse Handle(TRequest request);
    }
}
