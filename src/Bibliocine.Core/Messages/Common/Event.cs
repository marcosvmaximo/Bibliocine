using MediatR;

namespace Bibliocine.Core.Messages.Common;

public abstract class Event : Message
{
    protected Event()
    {
        MessageType = GetType().Name;
    }
}