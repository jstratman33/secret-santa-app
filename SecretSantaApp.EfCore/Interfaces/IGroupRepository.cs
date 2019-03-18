using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        Group GetById(long id);
        Group[] GetAllByUserId(long userId);
    }
}