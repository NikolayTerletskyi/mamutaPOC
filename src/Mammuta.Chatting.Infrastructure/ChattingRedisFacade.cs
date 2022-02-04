using Mammuta.Chatting.Contracts;
using Mammuta.Chatting.Domain;
using Mammuta.Infrastructure;

namespace Mammuta.Chatting.Infrastructure;
    
public class ChattingRedisFacade
{
    RedisFacade _redisFacade;

    public Task BroadcastGroupMessage(Message message)
    {
        var dto = new MessageDTO
        {
            GroupId = message.GroupId,
            Message = message.Text,
            UserId = message.UserId
        };

        return _redisFacade.BroadcastMessage(message.GroupId, dto);
    }
}