using LanguageExt;
using Mammuta.Chatting.Domain;
using Mammuta.Infrastructure;

namespace Mammuta.Chatting.Infrastructure
{
    public interface IGetGroupRepositoryError { }

    public class GroupsRepository : RepositoryBase
    {
        public EitherAsync<IGetGroupRepositoryError, Group> GetGroup(string groupId)
        {
            throw new NotImplementedException();
        }
    }
}
