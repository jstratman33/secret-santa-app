namespace SecretSantaApp.Domain.Enitities
{
    public class GroupMemberLink
    {
        public long GroupId { get; set; }
        public Group Group { get; set; }
        public long MemberId { get; set; }
        public User Member { get; set; }
    }
}