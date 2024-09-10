namespace Catalog.Application.Contracts;

public interface IRequestHandler<in TRequest, TResponse>
    where TRequest : IRequest
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
}