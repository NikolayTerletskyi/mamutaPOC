using Mammuta.Chatting.Application;
using Mammuta.Chatting.Contracts;
using Mammuta.Chatting.Domain;

namespace Mammuta.Chatting.Host;

public class ChattingRPCImplementation : IChattingRPC
{
    ChattingService _service;

    public Task<IEnumerable<string>> GetUserGroups(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task SendMessage(MessageDTO message)
    {
        await _service.SendMessage(MapMessage(message));
    }

    private Message MapMessage(MessageDTO dto)
    {
        throw new NotImplementedException();
    }
}
