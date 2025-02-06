using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Domain.PartnerDomain;
using MusicStore.Repository;

namespace MusicStore.Web.Controllers.PartnerStore
{
    public class PartnerTracksController : Controller
    {
        private readonly PartnerStoreDbContext _context;

        public PartnerTracksController(PartnerStoreDbContext context)
        {
            _context = context;
        }

        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            var partnerStoreDbContext = _context.Tracks.Include(t => t.Album).Include(t => t.Artist);
            return View(await partnerStoreDbContext.ToListAsync());
        }

        //    // GET: Tracks/Details/5
        //    public async Task<IActionResult> Details(Guid? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var track = await _context.Tracks
        //            .Include(t => t.Album)
        //            .Include(t => t.Artist)
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (track == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(track);
        //    }

        //    // GET: Tracks/Create
        //    public IActionResult Create()
        //    {
        //        ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Title");
        //        ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name");
        //        return View();
        //    }

        //    // POST: Tracks/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,Title,Duration,Price,FileUrl,Genres,AlbumId,ArtistId")] Track track)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            track.Id = Guid.NewGuid();
        //            _context.Add(track);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Title", track.AlbumId);
        //        ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", track.ArtistId);
        //        return View(track);
        //    }

        //    // GET: Tracks/Edit/5
        //    public async Task<IActionResult> Edit(Guid? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var track = await _context.Tracks.FindAsync(id);
        //        if (track == null)
        //        {
        //            return NotFound();
        //        }
        //        ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Title", track.AlbumId);
        //        ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", track.ArtistId);
        //        return View(track);
        //    }

        //    // POST: Tracks/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Duration,Price,FileUrl,Genres,AlbumId,ArtistId")] Track track)
        //    {
        //        if (id != track.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(track);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!TrackExists(track.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Title", track.AlbumId);
        //        ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", track.ArtistId);
        //        return View(track);
        //    }

        //    // GET: Tracks/Delete/5
        //    public async Task<IActionResult> Delete(Guid? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var track = await _context.Tracks
        //            .Include(t => t.Album)
        //            .Include(t => t.Artist)
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (track == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(track);
        //    }

        //    // POST: Tracks/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(Guid id)
        //    {
        //        var track = await _context.Tracks.FindAsync(id);
        //        if (track != null)
        //        {
        //            _context.Tracks.Remove(track);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool TrackExists(Guid id)
        //    {
        //        return _context.Tracks.Any(e => e.Id == id);
        //    }
        //}
    }
}
