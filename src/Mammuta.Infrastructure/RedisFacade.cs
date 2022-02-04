namespace Mammuta.Infrastructure;
    
public class RedisFacade
{
    public Task Subscribe<TDTO>(string channelName, Func<TDTO, Task> handler)
    {
        return Task.CompletedTask;
    }

    public Task Unsubscribe(string channelName)
    {
        return Task.CompletedTask;
    }

    public Task BroadcastMessage<TDTO>(string channelName, TDTO dto)
    {
        return Task.CompletedTask;
    }
}