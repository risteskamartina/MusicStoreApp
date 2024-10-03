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
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _artistsService;
        private readonly ITracksService _tracksService;

        public ArtistsController(IArtistsService artistsService, ITracksService tracksService)
        {
            _tracksService = tracksService;
            _artistsService = artistsService;
        }

        // GET: Artists
        public IActionResult Index()
        {
            return View(_artistsService.GetAllArtists());
        }

        // GET: Artists/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artists = _artistsService.GetDetailsForArtist(id.Value);
            if (artists == null)
            {
                return NotFound();
            }

            return View(artists);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,StageName,Age,Genre,Id")] Artists artists)
        {
            if (ModelState.IsValid)
            {
                artists.Id = Guid.NewGuid();
                _artistsService.CreateNewArtist(artists);
                return RedirectToAction(nameof(Index));
            }
            return View(artists);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artists = _artistsService.GetDetailsForArtist(id.Value);
            if (artists == null)
            {
                return NotFound();
            }
            return View(artists);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("FirstName,LastName,StageName,Age,Genre,Id")] Artists artists)
        {
            if (id != artists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _artistsService.UpdateArtist(artists);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistsExists(artists.Id))
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
            return View(artists);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artists = _artistsService.GetDetailsForArtist(id.Value);
            if (artists == null)
            {
                return NotFound();
            }

            return View(artists);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _artistsService.DeleteArtist(id);
            _tracksService.updateAllTracks();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistsExists(Guid id)
        {
            return _artistsService.GetDetailsForArtist(id)!=null;
        }
    }
}
