using System.Collections.Generic;

namespace SecretSantaApp.EfCore.Enitities
{
    public class List
    {
        public List()
        {
            Items = new HashSet<ListItem>();
        }

        public long Id { get; set; }
        public long OwnerId { get; set; }
        public long SantaId { get; set; }
        public long GroupId { get; set; }
        public string Name { get; set; }
        public bool IsPrimary { get; set; }
        public User Owner { get; set; }
        public User Santa { get; set; }
        public Group Group { get; set; }
        public ICollection<ListItem> Items { get; set; }
    }
}