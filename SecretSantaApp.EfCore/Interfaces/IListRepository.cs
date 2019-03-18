using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Interfaces
{
    public interface IListRepository : IRepository<List>
    {
        List[] GetAllByGroupId(long groupId);
    }
}