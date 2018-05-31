namespace UseCase.Core
{
    public interface IRequest<out TResponse> where TResponse : IResponse
    {
    }
}
