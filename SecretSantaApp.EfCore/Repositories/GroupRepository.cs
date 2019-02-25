using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Repositories
{
    public class GroupRepository : Repository<Group>
    {
        public GroupRepository(SecretSantaContext context) : base(context)
        {
        }
    }
}