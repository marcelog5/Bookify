using Domain.Abstracts;
using MediatR;

namespace Application.Abstracts.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
