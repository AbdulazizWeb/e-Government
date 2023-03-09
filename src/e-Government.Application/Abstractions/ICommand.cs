using MediatR;

namespace e_Government.Application.Abstractions
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
