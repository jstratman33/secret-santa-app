namespace SecretSantaApp.Api.Models
{
    public class UserLoginRequest
    {
        public string SocialId { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
    }
}