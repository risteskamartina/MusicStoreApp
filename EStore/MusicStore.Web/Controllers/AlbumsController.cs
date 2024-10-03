using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Domain;
using MusicStore.Repository;
using MusicStore.Service.Interface;

namespace MusicStore.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService _albumsService;
        private readonly IArtistsService _artistsService;
        private readonly ITracksService _tracksService;

        public AlbumsController(IAlbumsService albumsService, IArtistsService artistsService, ITracksService tracksService)
        {
            _albumsService = albumsService;
            _artistsService = artistsService;   
            _tracksService = tracksService;
        }

        // GET: Albums
        public IActionResult Index()
        {
            return View(_albumsService.GetAllAlbums());
        }

        // GET: Albums/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albums = _albumsService.GetDetailsForAlbum(id.Value);
            if (albums == null)
            {
                return NotFound();
            }

            return View(albums);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_artistsService.GetAllArtists(), "Id", "StageName");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AlbumName,ReleaseDate,Price,Image,Rating,ArtistId,Id")] Albums albums)
        {
            if (ModelState.IsValid)
            {
                albums.Id = Guid.NewGuid();
                _albumsService.CreateNewAlbum(albums);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_artistsService.GetAllArtists(), "Id", "FirstName", albums.ArtistId);
            return View(albums);
        }

        // GET: Albums/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albums = _albumsService.GetDetailsForAlbum(id.Value);
            if (albums == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_artistsService.GetAllArtists(), "Id", "FirstName", albums.ArtistId);
            return View(albums);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("AlbumName,ReleaseDate,Price,Image,Rating,ArtistId,Id")] Albums albums)
        {
            if (id != albums.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _albumsService.UpdateAlbum(albums);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumsExists(albums.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_artistsService.GetAllArtists(), "Id", "FirstName", albums.ArtistId);
            return View(albums);
        }

        // GET: Albums/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albums = _albumsService.GetDetailsForAlbum(id.Value);
            if (albums == null)
            {
                return NotFound();
            }

            return View(albums);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _albumsService.DeleteAlbum(id);
            _tracksService.updateAllTracks();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumsExists(Guid id)
        {
            return _albumsService.GetDetailsForAlbum(id)!=null;
        }
    }
}
