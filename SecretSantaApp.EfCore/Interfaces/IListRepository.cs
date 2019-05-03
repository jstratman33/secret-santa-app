using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Interfaces
{
    public interface IListRepository : IRepository<List>
    {
        List Get(long id);
        List[] GetAllByOwnerId(long ownerId);
        List[] GetAllByGroupId(long groupId);
    }
}