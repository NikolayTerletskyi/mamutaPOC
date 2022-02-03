using Mammuta.Chatting.Contracts;
using Mammuta.Gateway.Domain;
using Mammuta.Infrastructure;

namespace Mammuta.Gateway.Infrastructure;
    
public class ChattingRedisFacade
{
    private readonly RedisFacade _redisFacade;

    public ChattingRedisFacade(RedisFacade redisFacade)
    {
        _redisFacade = redisFacade;
    }

    public Task Subscribe(string groupName, Func<Message, Task> handler)
    {
        return _redisFacade.Subscribe<MessageDTO>(groupName, dto => handler(new Message(dto.UserId, dto.Message, dto.GroupId)));
    }

    public Task Unsubscribe(string channelName)
    {
        return _redisFacade.Unsubscribe(channelName);
    }
}