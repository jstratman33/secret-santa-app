using System.Linq;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.EfCore.Repositories
{
    public class ListRepository : Repository<List>, IListRepository
    {
        public ListRepository(SecretSantaContext context) : base(context)
        {
        }

        public List[] GetAllByGroupId(long groupId)
        {
            return Context.Lists.Where(l => l.GroupId == groupId).ToArray();
        }
    }
}