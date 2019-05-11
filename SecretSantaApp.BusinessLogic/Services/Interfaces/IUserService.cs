using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        void Create(User user);
        User[] GetAll();
        User GetById(long id);
        User GetByEmailAddress(string emailAddress);
        User GetBySocialId(string id);
    }
}