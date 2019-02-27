using System.Linq;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Repositories;

namespace SecretSantaApp.BusinessLogic.Services
{
    public class UserService : BaseService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {

            _userRepository = new UserRepository();
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
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