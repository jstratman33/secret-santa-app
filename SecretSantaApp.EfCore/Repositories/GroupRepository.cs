using System.Linq;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.EfCore.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(SecretSantaContext context) : base(context)
        {
        }

        public Group GetById(long id)
        {
            return Context.Groups.FirstOrDefault(g => g.Id == id);
        }

        public Group[] GetAllByUserId(long userId)
        {
            var user = Context.Users.First(u => u.Id == userId);
            var groupLinks = user.GroupLinks.ToArray();
            var groups = groupLinks.Select(l => l.Group).ToArray();

            return groups;
        }
    }
}