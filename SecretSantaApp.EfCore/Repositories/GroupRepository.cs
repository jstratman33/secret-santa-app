using System;
using System.Linq;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.EfCore.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(SecretSantaContext context) : base(context)
        {
        }

        public override void Create(Group group)
        {
            if (group == null) throw new ArgumentNullException(nameof(group));
            Context.Groups.Add(group);
            Context.SaveChanges();

           Context.GroupMemberLinks.Add(new GroupMemberLink
            {
                GroupId = group.Id,
                MemberId = group.AdminId
            });
            Context.SaveChanges();
        }

        public Group GetById(long id)
        {
            return Context.Groups.FirstOrDefault(g => g.Id == id);
        }

        public Group[] GetAllByUserId(long userId)
        {
            var groupIds = Context.GroupMemberLinks
                .Where(x => x.MemberId == userId)
                .Select(x=>x.GroupId)
                .ToArray();
            var groups = Context.Groups.Where(g => groupIds.Contains(g.Id)).ToArray();
            return groups;
        }

        public override void Delete(Group group)
        {
            var links = Context.GroupMemberLinks.Where(x => x.GroupId == group.Id).ToArray();
            Context.GroupMemberLinks.RemoveRange(links);
            Context.Groups.Remove(group);
            Context.SaveChanges();
        }
    }
}