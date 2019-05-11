using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Interfaces
{
    public interface IListRepository : IRepository<List>
    {
        List Get(long id);
        List[] GetAllByOwnerId(long ownerId, long longId);
        List[] GetAllByGroupId(long groupId);
    }
}