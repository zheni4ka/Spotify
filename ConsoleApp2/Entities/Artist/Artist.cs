﻿using ConsoleApp2.Entities.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}