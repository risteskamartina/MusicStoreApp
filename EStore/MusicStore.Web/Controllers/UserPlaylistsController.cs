using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Domain;
using MusicStore.Repository;
using MusicStore.Repository.Interface;
using MusicStore.Service.Interface;

namespace MusicStore.Web.Controllers
{
    public class UserPlaylistsController : Controller
    {
        private readonly IUserPlaylistsService _userPlaylistsService;
        private readonly IUserRepository _userRepository;

        public UserPlaylistsController(IUserPlaylistsService userPlaylistsService, IUserRepository userRepository)
        {
            _userPlaylistsService = userPlaylistsService;
            _userRepository = userRepository;
        }

        // GET: UserPlaylists
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_userPlaylistsService.GetAllUserPlaylists(userId));
        }

        // GET: UserPlaylists/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPlaylists = _userPlaylistsService.GetDetailsForUserPlaylist(id.Value);
            if (userPlaylists == null)
            {
                return NotFound();
            }

            return View(userPlaylists);
        }

        // GET: UserPlaylists/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPlaylists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("Name,NumOfTracks,Id")] UserPlaylists userPlaylists)
        {
            if (ModelState.IsValid)
            {
                userPlaylists.Id = Guid.NewGuid();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var createdBy = _userRepository.Get(userId);
                userPlaylists.User = createdBy;
                userPlaylists.Id = Guid.NewGuid();
                _userPlaylistsService.CreateNewUserPlaylist(userPlaylists);
                return RedirectToAction(nameof(Index));
            }
            return View(userPlaylists);
        }

        // GET: UserPlaylists/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPlaylists = _userPlaylistsService.GetDetailsForUserPlaylist(id.Value);
            if (userPlaylists == null)
            {
                return NotFound();
            }
            return View(userPlaylists);
        }

        // POST: UserPlaylists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,NumOfTracks,Id")] UserPlaylists userPlaylists)
        {
            if (id != userPlaylists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _userPlaylistsService.UpdateUserPlaylist(userPlaylists);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPlaylistsExists(userPlaylists.Id))
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
            return View(userPlaylists);
        }

        // GET: UserPlaylists/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPlaylists = _userPlaylistsService.GetDetailsForUserPlaylist(id.Value);
            if (userPlaylists == null)
            {
                return NotFound();
            }

            return View(userPlaylists);
        }

        // POST: UserPlaylists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _userPlaylistsService.DeleteUserPlaylist(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserPlaylistsExists(Guid id)
        {
            return _userPlaylistsService.GetDetailsForUserPlaylist(id)!=null;
        }


        //ExportAllPlaylists
    }
}
