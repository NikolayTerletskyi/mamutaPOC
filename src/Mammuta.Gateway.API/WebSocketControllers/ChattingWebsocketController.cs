using Mammuta.Gateway.API.Messages.Comands;
using Mammuta.Gateway.API.Messages.Notification;
using Mammuta.Gateway.Application;
using Mammuta.Gateway.Domain;

namespace Mammuta.Gateway.API.WebSocketControllers;

public class ChattingWebsocketController: WebSocketControllerBase
{
    ChattingService _chattingService;

    public override Task OnCommand(ICommand command, ICommandContext context)
    {
        switch (command)
        {
            case NewMessageCommand newMessageCommand:
                var message = new Message(newMessageCommand.GroupId, context.UserId, newMessageCommand.Text);
                return _chattingService.SendMessage(message);
            case SubscribeCommand _:
                return _chattingService.RegisterSubscription(
                    context.UserId,
                    context.SubscriptionForResponseId,
                    CreateNotifyAboutMessage(context.SubscriptionForResponseId));
            default:
                return Task.CompletedTask;
        }
    }

    private Func<Message, Task> CreateNotifyAboutMessage (string subscriptionId) =>
        (Message message) =>
        {
            var notification = new NewMessageNotification
            {
                GroupId = message.GroupId,
                Text = message.Text,
                SubscriptionId = subscriptionId,
                UserId = message.UserId
            };

            return SendMessageToClient(notification);
        };
}
