using Mammuta.Gateway.API.Messages.Comands;
using Mammuta.Gateway.API.Messages.Notification;

namespace Mammuta.Gateway.API;

public abstract class WebSocketControllerBase
{
    public abstract Task OnCommand(ICommand command, ICommandContext context);

    public Task SendMessageToClient(INotification notification)
    {
        return Task.CompletedTask;
    }
}
