using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TheCypherRange.Models;

namespace TheCypherRange
{
    public class AlbumsRepository : IAlbumsRepository
    {
        private readonly IDbConnection _conn;

        public AlbumsRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Albums> GetAllAlbums()
        {
            return _conn.Query<Albums>("SELECT * FROM ALBUMS");
        }

        public Albums GetAlbum(int id)
        {
            return _conn.QuerySingle<Albums>("SELECT * FROM ALBUMS WHERE ALBUMID = @id", 
                new { id });
        }

        public void UpdateAlbum(Albums Albums)
        {
            _conn.Execute("UPDATE Albums SET AlbumName = @albumname, RELEASEYEAR = @releaseyear, Price = @price WHERE AlbumID = @id",
             new {Albumname = Albums.AlbumName, releaseyear = Albums.ReleaseYear, Artist = Albums.Artist, price = Albums.Price, id = Albums.AlbumID });
        }

        public void InsertAlbum(Albums albumToInsert)
        {
            _conn.Execute("INSERT INTO albums (ALBUMNAME, RELEASEYEAR, ARTIST, PRICE) VALUES (@name, @releaseyear, @artist, @price);",
            new { name = albumToInsert.AlbumName, releaseyear = albumToInsert.ReleaseYear, Artist = albumToInsert.Artist, Price = albumToInsert.Price });
        }

        public void DeleteAlbum(Albums Albums)
        {
            _conn.Execute("DELETE FROM Albums WHERE AlbumID = @id;", new { id = Albums.AlbumID });
            
        }
    }

}
    
