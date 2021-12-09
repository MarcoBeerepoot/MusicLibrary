namespace TR.MusicLibrary.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Shortname { get; set; }
        public int Bpm { get; set; }
        public int Duration { get; set; }
        public string SpotifyId { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
