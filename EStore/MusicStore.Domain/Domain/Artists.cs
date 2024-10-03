namespace MusicStore.Domain.Domain
{
    public class Artists : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StageName { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<Albums>? Albums { get; set; }
    }
}
