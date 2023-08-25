using ConsoleApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Entities.NewFolder
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public double Rating { get; set; }
        public int CountOfListening { get; set; }
        public string? SongText { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
