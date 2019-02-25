using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore.Repositories
{
    public class ListRepository : Repository<List>
    {
        public ListRepository(SecretSantaContext context) : base(context)
        {
        }
    }
}