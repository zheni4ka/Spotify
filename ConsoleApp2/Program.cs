using ConsoleApp2.Data;
using ConsoleApp2.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        SpotifyDbContext db = new SpotifyDbContext();
        db.AddTracksIntoPlaylist(db.Playlists.Where(x => x.Name == "1234").First());
    }
}