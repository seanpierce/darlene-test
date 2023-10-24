using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Cmp;
using TheCypherRange.Models;

namespace TheCypherRange
{
    public interface IAlbumsRepository
    {
        public IEnumerable<Albums> GetAllAlbums();

        public Albums GetAlbum(int id);

        public void UpdateAlbum(Albums album);

        public void InsertAlbum(Albums albumToInsert);

        public void DeleteAlbum(Albums album);


    }
}