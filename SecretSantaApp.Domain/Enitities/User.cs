using System.Collections.Generic;

namespace SecretSantaApp.Domain.Enitities
{
    public class User
    {
        public User()
        {
            Groups = new HashSet<Group>();
            Lists = new HashSet<List>();
            SantaLists = new HashSet<List>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<List> Lists { get; set; }
        public ICollection<List> SantaLists { get; set; }
    }
}