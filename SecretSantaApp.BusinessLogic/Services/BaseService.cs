using SecretSantaApp.EfCore;

namespace SecretSantaApp.BusinessLogic.Services
{
    public class BaseService
    {
        protected readonly SecretSantaContext Context;

        public BaseService()
        {
            Context = new SecretSantaContext();
        }
    }
}