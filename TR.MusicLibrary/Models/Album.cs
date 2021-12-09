namespace TR.MusicLibrary.Models
{
    public class Album
    {
        public Album(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public ICollection<Song> Songs { get; } = new List<Song>();
    }
}
