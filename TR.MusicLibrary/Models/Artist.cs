namespace TR.MusicLibrary.Models
{
    public class Artist
    {
        public Artist(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; } = new List<Song>();
    }
}
