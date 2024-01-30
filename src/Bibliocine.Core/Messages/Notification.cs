
using Bibliocine.Core.Messages.Common;
using MediatR;

namespace Bibliocine.Core.Messages;

public class Notification : Message, INotification
{
    public Notification(string property, string message, object attemptedValue)
    {
        Property = property;
        Message = message;
        AttemptedValue = attemptedValue;
        
        MessageType = GetType().Name;
    }

    public Notification(string property, string message) 
        : this(property, message, null){}
    
    public string Property { get; set; }
    public string Message { get; set; }
    public object AttemptedValue { get; set; }
    public string ErrorCode { get; set; }

    public override string ToString() => Message;
}