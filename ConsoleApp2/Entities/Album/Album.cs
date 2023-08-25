﻿using ConsoleApp2.Entities.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } = "";
        public int Year { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public double Rating { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}