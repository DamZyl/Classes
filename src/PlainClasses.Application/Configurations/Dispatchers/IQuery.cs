using MediatR;

namespace PlainClasses.Application.Configurations.Dispatchers
{
    public interface IQuery<out TResult> : IRequest<TResult> { }
}