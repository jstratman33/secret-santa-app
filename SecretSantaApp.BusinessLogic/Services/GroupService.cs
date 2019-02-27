using System.Linq;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Repositories;

namespace SecretSantaApp.BusinessLogic.Services
{
    public class GroupService
    {
        private readonly GroupRepository _groupRepository;

        public GroupService(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public void Create(Group group)
        {
            _groupRepository.Create(group);
        }

        public Group[] GetAll()
        {
            return _groupRepository.GetAll().ToArray();
        }

        public Group GetById(long id)
        {
            return _groupRepository.GetById(id);
        }

        public Group[] GetAllByUser(long userId)
        {
            return _groupRepository.GetAllByUserId(userId);
        }
    }
}