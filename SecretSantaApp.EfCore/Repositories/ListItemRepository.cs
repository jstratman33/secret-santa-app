using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Repositories
{
    public class ListItemRepository : Repository<ListItem>
    {
        public ListItemRepository(SecretSantaContext context) : base(context)
        {
        }
    }
}