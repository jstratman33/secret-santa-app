namespace SecretSantaApp.EfCore.Enitities
{
    public class ListItem
    {
        public long Id { get; set; }
        public long ListId { get; set; }
        public string Description { get; set; }
        public bool IsPurchased { get; set; }
        public List List { get; set; }
    }
}
