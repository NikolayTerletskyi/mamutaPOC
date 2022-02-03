namespace Mammuta.Gateway.API.Messages.Notification;

public class NewMessageNotification : INotification
{
    public string GroupId { get; set; }

    public string UserId { get; set; }

    public string Text { get; set; }

    public string SubscriptionId {get; set;}
}
