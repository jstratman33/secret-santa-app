using System.Collections.Generic;

namespace SecretSantaApp.EfCore.Enitities
{
    public class User
    {
        public User()
        {
            GroupLinks = new HashSet<GroupMemberLink>();
            Lists = new HashSet<List>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public ICollection<Group> AdminOf { get; set; }
        public ICollection<GroupMemberLink> GroupLinks { get; set; }
        public ICollection<List> Lists { get; set; }
    }
}