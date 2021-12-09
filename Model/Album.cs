namespace TR.MusicLibrary.Model
{
    public class Album
    {
        public Album(string name)
        {
            Name = name;
        }

        public int Id { get; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; } = new List<Song>();
    }
}
