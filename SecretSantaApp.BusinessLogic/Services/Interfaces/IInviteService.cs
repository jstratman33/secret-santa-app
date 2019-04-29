using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.BusinessLogic.Services.Interfaces
{
    public interface IInviteService
    {
        void Create(Invite invite);
        void Send(long id);
        Invite GetByEmailAndHash(string emailAddress, string hash);
        void Delete(long id);
    }
}