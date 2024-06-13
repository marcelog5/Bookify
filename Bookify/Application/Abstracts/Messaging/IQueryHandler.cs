using Domain.Abstracts;
using MediatR;

namespace Application.Abstracts.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> 
        where TQuery : IQuery<TResponse>
    {
    }
}
