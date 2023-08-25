using Azure.Core.GeoJson;
using ConsoleApp2.Data;
using ConsoleApp2.Entities;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        SpotifyDbContext db = new SpotifyDbContext();
        //foreach (var i in db.Playlists.Include(x => x.Category))
        //    Console.WriteLine(i.Name + " " + i.Category.Name);

    }
}