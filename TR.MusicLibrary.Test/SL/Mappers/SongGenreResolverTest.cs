using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TR.MusicLibrary.DTO;
using TR.MusicLibrary.Models;
using TR.MusicLibrary.SL.Mappers;

namespace TR.MusicLibrary.Test.SL.Mappers
{
    [TestClass]
    public class SongGenreResolverTest
    {
        private SongGenreResolver _sut;
        private SongDTO _destination;

        [TestInitialize]
        public void Init()
        {
            _sut = new SongGenreResolver();
            _destination = new SongDTO();
        }

        [TestMethod]
        public void Resolve_EmptyGenres_ReturnsEmptyString()
        {
            var source = new Song { Genres = new List<Genre>() };

            string genre = _sut.Resolve(source, _destination, null, null);

            Assert.AreEqual(string.Empty, genre);
        }

        [TestMethod]
        public void Resolve_SingleGenre_ReturnsGenreName()
        {
            const string genreName = "Nu-metal";
            var nuMetalGenre = new Genre(genreName);
            var source = new Song { Genres = new List<Genre> { nuMetalGenre } };

            string genre = _sut.Resolve(source, _destination, null, null);

            Assert.AreEqual(genre, genreName);
        }

        [TestMethod]
        public void Resolve_MultipleGenres_ReturnsCompositedGenreNames()
        {
            var nuMetalGenre = new Genre("Nu-metal");
            var metalGenre = new Genre("Metal");
            var source = new Song { Genres = new List<Genre> { nuMetalGenre, metalGenre } };

            string genre = _sut.Resolve(source, _destination, null, null);

            Assert.AreEqual("Nu-metal/Metal", genre);
        }
    }
}
