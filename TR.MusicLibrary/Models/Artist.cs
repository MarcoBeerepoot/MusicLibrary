using TR.MusicLibrary.Interfaces;

namespace TR.MusicLibrary.Models
{
    public class Artist : IHasKey
    {
        public Artist(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public ICollection<Song> Songs { get; } = new List<Song>();
    }
}
