namespace Mammuta.Chatting.Domain;

public record Message(string UserId, string Text, string GroupId);