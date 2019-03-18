using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.EfCore.Repositories
{
    public class GroupMemberLinkRepository : Repository<GroupMemberLink>, IGroupMemberLinkRepository
    {
        public GroupMemberLinkRepository(SecretSantaContext context) : base(context)
        {
        }
    }
}