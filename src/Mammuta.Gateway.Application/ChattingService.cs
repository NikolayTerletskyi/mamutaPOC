using Mammuta.Chatting.Contracts;
using Mammuta.Gateway.Domain;
using Mammuta.Gateway.Infrastructure;

namespace Mammuta.Gateway.Application;

public class ChattingService
{
    IChattingRPC _chattingRPC;
    ChattingRedisFacade _redisFacade;
    Dictionary<string, Dictionary<string, Func<Message, Task>>> _groupSubscriptions = new Dictionary<string, Dictionary<string, Func<Message, Task>>>();

    public Task SendMessage(Message message)
    {
        var messageDto = new MessageDTO
        {
            UserId = message.UserId,
            Message = message.Text,
            GroupId = message.GroupId
        };

        return _chattingRPC.SendMessage(messageDto);
    }

    public async Task RegisterSubscription(string userId, string subscriptionId, Func<Message, Task> handler)
    {
        var userGroups = await _chattingRPC.GetUserGroups(userId);
        foreach (var groupId in userGroups)
        {
            if (_groupSubscriptions.TryGetValue(groupId, out var subsriptions))
            {
                subsriptions[subscriptionId] = handler;
            }
            else
            {
                _groupSubscriptions[groupId] = new Dictionary<string, Func<Message, Task>> { { subscriptionId, handler } };
                await _redisFacade.Subscribe(groupId, GroupHandler);
            }
        }
    }

    private Task GroupHandler(Message message)
    {
        if (_groupSubscriptions.TryGetValue(message.GroupId, out var handlers))
        {
            return Task.WhenAll(handlers.Select(h => h.Value(message)));
        }
        return Task.CompletedTask;
    }
}