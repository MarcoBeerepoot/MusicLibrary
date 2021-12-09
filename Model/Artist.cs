namespace TR.MusicLibrary.Model
{
    public class Artist
    {
        public Artist(string name)
        {
            Name = name;
        }

        public int Id { get; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; } = new List<Song>();
    }
}
