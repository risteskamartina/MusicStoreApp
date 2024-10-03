using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Domain;
using MusicStore.Repository;
using MusicStore.Repository.Interface;
using MusicStore.Service.Interface;

namespace MusicStore.Web.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService _tracksService;
        private readonly IUserRepository _userRepository;
        private readonly IUserPlaylistsService _userPlaylistsService;
        private readonly IAlbumsService _albumsService;

        public TracksController(ITracksService tracksService,IUserRepository userRepository, IUserPlaylistsService userPlaylistsService,IAlbumsService albumsService)
        {
            _tracksService = tracksService;
            _userRepository = userRepository;
            _albumsService = albumsService;
            _userPlaylistsService = userPlaylistsService;
        }

        // GET: Tracks
        public IActionResult Index()
        {
            return View(_tracksService.GetAllTracks());
        }

        // GET: Tracks/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracks = _tracksService.GetDetailsForTrack(id.Value);
            if (tracks == null)
            {
                return NotFound();
            }

            return View(tracks);
        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_albumsService.GetAllAlbums(), "Id", "AlbumName");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,Duration,AlbumId,Id")] Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                tracks.Id = Guid.NewGuid();
                _tracksService.CreateNewTrack(tracks);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_albumsService.GetAllAlbums(), "Id", "AlbumName", tracks.AlbumId);
            return View(tracks);
        }

        // GET: Tracks/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracks = _tracksService.GetDetailsForTrack(id.Value);
            if (tracks == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_albumsService.GetAllAlbums(), "Id", "AlbumName", tracks.AlbumId);
            return View(tracks);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Title,Duration,AlbumId,Id")] Tracks tracks)
        {
            if (id != tracks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _tracksService.UpdateTrack(tracks);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TracksExists(tracks.Id))
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
            ViewData["AlbumId"] = new SelectList(_albumsService.GetAllAlbums(), "Id", "AlbumName", tracks.AlbumId);
            return View(tracks);
        }

        // GET: Tracks/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracks = _tracksService.GetDetailsForTrack(id.Value);
            if (tracks == null)
            {
                return NotFound();
            }

            return View(tracks);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _tracksService.DeleteTrack(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TracksExists(Guid id)
        {
            return _tracksService.GetDetailsForTrack(id)!=null;
        }


        [Authorize]
        public IActionResult AddTrackToPlaylist(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var createdBy = _userRepository.Get(userId);
            var playlist = createdBy.UserPlaylists;
            ViewData["UserPlaylists"] = new SelectList(playlist, "Id", "Name");
            var track = _tracksService.GetDetailsForTrack(id);
            return View(track);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddTrackToPlaylist(Guid trackId, Guid playlistId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var createdBy = _userRepository.Get(userId);
            var playlist = createdBy.UserPlaylists;
            ViewData["UserPlaylists"] = new SelectList(playlist, "Id", "Name");
            var selectedTrack = _tracksService.GetDetailsForTrack(trackId);
            var selectedPlaylist = _userPlaylistsService.GetDetailsForUserPlaylist(playlistId);

            _tracksService.AddTrackToUserPlaylist(selectedPlaylist, selectedTrack);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult DeleteTrackFromUserPlaylist(Guid id)
        {
            _tracksService.DeleteTrackFromUserPlaylist(id);
            return RedirectToAction("Index", "UserPlaylists");
        }
    }
}
