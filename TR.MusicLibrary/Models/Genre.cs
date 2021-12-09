using TR.MusicLibrary.Interfaces;

namespace TR.MusicLibrary.Models
{
    public class Genre : IHasKey
    {
        public Genre(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
