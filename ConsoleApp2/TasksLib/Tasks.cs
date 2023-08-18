using ConsoleApp2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.TasksLib
{
    public class Tasks
    {
        SpotifyDbContext spotifyDb = new();

        public void GetTracks(string NameofAlbum) //Get Tracks which have more count of listening than the average count of listening in album
        {
            var tmp = spotifyDb.Albums.Where(x => x.Name == NameofAlbum).First();
            tmp.Tracks.Where(x => x.CountOfListening > tmp.Tracks.Average(x => x.CountOfListening));
        }

        public void GetTop3AlbumsAndTracks(string ArtistName) //Get
        {
            var top3albums = spotifyDb.Albums.Where(x => x.Name == ArtistName).OrderByDescending(x => x.Rating).Take(3).ToList();
            var top3tracks = spotifyDb.Tracks.Where(x => x.Name == ArtistName).OrderByDescending(x => x.Rating).Take(3).ToList();
        }

        public void GetTracksByThePieceOfString(string piece)
        {
            var tmp = spotifyDb.Tracks.Where(x => x.Name.Contains(piece));
        }

        public void SearchTracksByTheirLyrics(string piece)
        {
            var tmp = spotifyDb.Tracks.Where(x => x.SongText.Contains(piece));
        }
    }
}
