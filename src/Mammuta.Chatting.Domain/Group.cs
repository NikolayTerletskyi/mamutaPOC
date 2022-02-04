using LanguageExt;

namespace Mammuta.Chatting.Domain;

public record Group(IReadOnlyCollection<string> masters) 
{
    public interface IDomainMessagePostingError { }

    public record AccessDeniedError(): IDomainMessagePostingError;

    public record SpamError() : IDomainMessagePostingError;

    public Option<IDomainMessagePostingError> IsMessagePositngAllowed(Message message) =>
        masters.Contains(message.UserId)? Option<IDomainMessagePostingError>.None: Option<IDomainMessagePostingError>.Some(new AccessDeniedError());
}