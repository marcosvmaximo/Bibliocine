using Bibliocine.Core.Messages.Common;
using MediatR;

namespace Bibliocine.Core.Messages;

public abstract class Command<TResponse> : Message, IRequest<TResponse>
{
    public Command()
    {
        MessageType = GetType().Name;
    }
}