using MediatR;

namespace e_Government.Application.Abstractions
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
