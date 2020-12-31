using MediatR;

namespace PlainClasses.Application.Dispatchers
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult> { }
}