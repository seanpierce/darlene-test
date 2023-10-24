using Microsoft.AspNetCore.Mvc;
using TheCypherRange.Models;

namespace TheCypherRange.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsRepository repo;

        public AlbumsController(IAlbumsRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var albums = repo.GetAllAlbums();

            return View(albums);
        }

        public IActionResult ViewAlbum(int id)
        {
            var album = repo.GetAlbum(id);

            return View(album);
        }

        public IActionResult UpdateAlbum(int id)
        {
            Albums album = repo.GetAlbum(id);

            if (album == null)
            {
                return View("AlbumtNotFound");
            }
            return View(album);
        }

        public IActionResult UpdateAlbumToDatabase(Albums album)
        {
            repo.UpdateAlbum(album);

            return RedirectToAction("ViewAlbum", new { id = album.AlbumID });
        }

        public IActionResult InsertAlbum()
        {
            return View();
        }
      
        public IActionResult InsertAlbumToDatabase(Albums albumToInsert)
        {
            repo.InsertAlbum(albumToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAlbum(Albums album)
        {
            repo.DeleteAlbum(album);
            return RedirectToAction("Index");
        }

    }
}
