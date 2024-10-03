namespace MusicStore.Domain.Domain
{
    public class Albums : BaseEntity
    {
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public Artists? Artist { get; set; }
        public Guid ArtistId { get; set; }
        public virtual ICollection<Tracks>? Tracks { get; set; }
    }
}
