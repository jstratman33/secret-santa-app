using System.Linq;
using SecretSantaApp.BusinessLogic.Services.Interfaces;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.BusinessLogic.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
            _userRepository.SaveChanges();
        }

        public User[] GetAll()
        {
            return _userRepository.GetAll().ToArray();
        }

        public User GetById(long id)
        {
            return _userRepository.First(u => u.Id == id);
        }

        public User GetByEmailAddress(string emailAddress)
        {
            return _userRepository.First(u => u.EmailAddress == emailAddress);
        }
    }
}