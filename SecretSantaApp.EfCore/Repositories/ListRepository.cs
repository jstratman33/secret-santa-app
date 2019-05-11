using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.EfCore.Repositories
{
    public class ListRepository : Repository<List>, IListRepository
    {
        public ListRepository(SecretSantaContext context) : base(context)
        {
        }

        public List Get(long id)
        {
            return Context.Lists
                .Include(x => x.Items)
                .First(l => l.Id == id);
        }

        public List[] GetAllByOwnerId(long ownerId, long groupId)
        {
            return Context.Lists
                .Include(x => x.Items)
                .Where(l => l.OwnerId == ownerId && l.GroupId == groupId).ToArray();
        }

        public List[] GetAllByGroupId(long groupId)
        {
            return Context.Lists
                .Include(x => x.Items)
                .Where(l => l.GroupId == groupId).ToArray();
        }
    }
}