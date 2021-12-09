using TR.MusicLibrary.Interfaces;

namespace TR.MusicLibrary.Models
{
    public class Album : IHasKey
    {
        public Album()
        {
        }

        public Album(string name, Artist artist)
        {
            Name = name;
            Artist = artist;
        }

        public string Name { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; } = new List<Song>();
    }
}
