using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.BusinessLogic.Services.Interfaces
{
    public interface IListService
    {
        void Create(List list);
        List[] GetAllByOwner(long ownerId, long groupId);
        List[] GetAllByGroup(long id);
        List GetOne(long id);
        void Update(List list);
        void Delete(long id);
        void AssignListsToSantas(long groupId);
    }
}