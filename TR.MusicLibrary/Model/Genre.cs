namespace TR.MusicLibrary.Model
{
    public class Genre
    {
        public Genre(string name)
        {
            Name = name;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}
