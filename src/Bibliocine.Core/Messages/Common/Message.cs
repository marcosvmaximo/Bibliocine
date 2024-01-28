using System.Text.Json.Serialization;

namespace Bibliocine.Core.Messages.Common;

public abstract class Message
{
    [JsonIgnore]
    public Guid MessageId { get; init; }
    
    [JsonIgnore]
    public DateTime MessageTimeStamp { get; init; }
    
    public Message()
    {
        MessageId = Guid.NewGuid();
        MessageTimeStamp = DateTime.Now;
    }
     
    [JsonIgnore]
    public string MessageType { get; protected set; }
}