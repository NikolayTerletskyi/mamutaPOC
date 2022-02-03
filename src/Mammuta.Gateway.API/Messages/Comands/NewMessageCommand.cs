namespace Mammuta.Gateway.API.Messages.Comands;

public class NewMessageCommand : ICommand
{
    public string GroupId { get; set; }

    public string Text { get; set; }
}
