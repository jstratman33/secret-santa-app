using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.EfCore.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SecretSantaContext context) : base(context)
        {
        }
    }
}