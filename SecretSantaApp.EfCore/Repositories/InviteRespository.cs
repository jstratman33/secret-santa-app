using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.EfCore.Repositories
{
    public class InviteRespository : Repository<Invite>, IInviteRepository
    {
        public InviteRespository(SecretSantaContext context) : base(context)
        {
        }
    }
}