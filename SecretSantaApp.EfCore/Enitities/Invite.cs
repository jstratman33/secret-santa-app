namespace SecretSantaApp.EfCore.Enitities
{
    public class Invite
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public string EmailAddress { get; set; }
        public Group Group { get; set; }
    }
}