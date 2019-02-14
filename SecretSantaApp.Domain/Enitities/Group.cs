using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretSantaApp.Domain.Enitities
{
    public class Group
    {
        public Group()
        {
            MemberLinks = new HashSet<GroupMemberLink>();
            Lists = new HashSet<List>();
            Invites = new HashSet<Invite>();
        }

        public long Id { get; set; }
        public long AdminId { get; set; }
        public string Description { get; set; }
        public DateTime ListDeadline { get; set; }
        public DateTime ExchangeTime { get; set; }
        public User Admin { get; set; }
        public ICollection<GroupMemberLink> MemberLinks { get; set; }
        public ICollection<List> Lists { get; set; }
        public ICollection<Invite> Invites { get; set; }
    }
}