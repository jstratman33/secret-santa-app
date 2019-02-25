using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Repositories
{
    public class InviteRespository : Repository<Invite>
    {
        public InviteRespository(SecretSantaContext context) : base(context)
        {
        }
    }
}