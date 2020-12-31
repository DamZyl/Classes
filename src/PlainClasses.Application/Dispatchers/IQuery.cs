using MediatR;

namespace PlainClasses.Application.Dispatchers
{
    public interface IQuery<out TResult> : IRequest<TResult> { }
}