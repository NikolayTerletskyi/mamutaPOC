namespace Mammuta.Gateway.API.Messages.Comands;

public interface ICommandContext
{
    string SubscriptionForResponseId { get; set; }

    string UserId { get; set; }
}