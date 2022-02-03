namespace Mammuta.Chatting.Contracts;

public class MessageArrivedNotificationDTO
{
    public string GroupId { get; set; }

    public MessageDTO Message { get; set; }
}
