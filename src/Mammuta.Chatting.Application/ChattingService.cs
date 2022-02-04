using LanguageExt;
using Mammuta.Chatting.Domain;
using Mammuta.Chatting.Infrastructure;
using static Mammuta.Chatting.Domain.Group;

namespace Mammuta.Chatting.Application;
    
public class ChattingService
{
    ChattingRedisFacade _redisFacade;
    MessagesRepository _messagesRepository;
    GroupsRepository _groupRepository;

    public interface IAppMessagePostingError { }

    public async Task<Option<IAppMessagePostingError>> SendMessage(Message message) =>
        await _groupRepository.GetGroup(message.GroupId)
            .MapLeft(MapGetGroupError)
            .Bind(group =>
                group.
                IsMessagePositngAllowed(message)
                .Map(MapMessagePositngError)
                .Match(EitherAsync<IAppMessagePostingError, Group>.Left, () => EitherAsync<IAppMessagePostingError, Group>.Right(group)))
            .MapAsync(async group =>
            {
                await _redisFacade.BroadcastGroupMessage(message);
                return group;
            })
            .MapAsync(async group =>
            {
                await _messagesRepository.SaveMessage(message);
                return group;
            })
            .Match(_ => Option<IAppMessagePostingError>.None, Option<IAppMessagePostingError>.Some);

    private IAppMessagePostingError MapMessagePositngError(IDomainMessagePostingError e)
    {
        throw new NotImplementedException();
    }

    private IAppMessagePostingError MapGetGroupError(IGetGroupRepositoryError e)
    {
        throw new NotImplementedException();
    }
}