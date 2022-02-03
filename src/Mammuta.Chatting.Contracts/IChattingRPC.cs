namespace Mammuta.Chatting.Contracts;

public interface IChattingRPC
{
    Task SendMessage(MessageDTO message);

    Task<IEnumerable<string>> GetUserGroups(string userId);
}