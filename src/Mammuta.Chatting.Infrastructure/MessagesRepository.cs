using Mammuta.Chatting.Domain;
using Mammuta.Infrastructure;

namespace Mammuta.Chatting.Infrastructure
{
    public class MessagesRepository: RepositoryBase
    {
        public Task SaveMessage(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
