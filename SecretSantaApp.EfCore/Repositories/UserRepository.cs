using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(SecretSantaContext context) : base(context)
        {
        }
    }
}