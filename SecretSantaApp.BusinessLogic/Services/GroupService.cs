using System.Linq;
using SecretSantaApp.BusinessLogic.Services.Interfaces;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.BusinessLogic.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public Group Create(Group group)
        {
            _groupRepository.Create(group);
            return _groupRepository.GetById(group.Id);
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

        public void Update(Group group)
        {
            var entity = _groupRepository.GetById(group.Id);
            entity.Description = group.Description;
            entity.ListDeadline = group.ListDeadline;
            entity.ExchangeTime = group.ExchangeTime;
            _groupRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _groupRepository.GetById(id);
            _groupRepository.Delete(entity);
            _groupRepository.SaveChanges();
        }
    }
}