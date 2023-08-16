using ConsoleApp2.Entities.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Track> TrackList { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
