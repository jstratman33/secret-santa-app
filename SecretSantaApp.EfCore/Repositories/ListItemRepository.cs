using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.EfCore.Repositories
{
    public class ListItemRepository : Repository<ListItem>, IListItemRepository
    {
        public ListItemRepository(SecretSantaContext context) : base(context)
        {
        }
    }
}