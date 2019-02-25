using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Repositories
{
    public class GroupMemberLinkRepository : Repository<GroupMemberLink>
    {
        public GroupMemberLinkRepository(SecretSantaContext context) : base(context)
        {
        }
    }
}