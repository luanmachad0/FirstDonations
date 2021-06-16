using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FirstDonations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace FirstDonations.Controllers
{
    public class DonationsController : Controller
    {
        private readonly AuthDbContext _authDbContext;
        private readonly AppDbContext _context;

        public DonationsController(AppDbContext context, AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
            _context = context;
        }

        //GET: Parts
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(await _context.Donations.Where(d => d.InterestedTeamId == userId && d.Part.Status != "Closed").ToListAsync());
        }

        public async Task<IActionResult> UsersDonations()
        {
            return View(await _context.Donations.ToListAsync());
        }

        public async Task<IActionResult> Create(int id)
        {
            if (ModelState.IsValid)
            {
                var interestedTeamId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var interestedTeam = await _authDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == interestedTeamId);
                var interestedTeamName = interestedTeam.TeamName;

                var part = await _context.Parts.FindAsync(id);

                var donatorTeam = await _authDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == part.OwnerTeam);

                var donatorTeamId = donatorTeam.Id;
                var donatorTeamName = donatorTeam.TeamName;

                Donation donation = new Donation
                {
                    NamePart = part.Name,
                    ImagePart = part.Image,
                    Part = part,
                    Status = "Requested",
                    InterestedTeamId = interestedTeamId,
                    InterestedTeamName = interestedTeamName,
                    DonatorTeamId = donatorTeamId,
                    DonatorTeamName = donatorTeamName
                };

                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .FirstOrDefaultAsync(m => m.Id == id);

            var donatorTeam = await _authDbContext.Users
                .FirstOrDefaultAsync(u => u.Id  == donation.DonatorTeamId);

            ViewBag.DonatorTeamProfileImage = donatorTeam.ProfileImage;

            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            _context.Donations.Remove(donation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }
            return View(donation);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NamePart,ImagePart,Part,PartId,Status,InterestedTeamId,InterestedTeamName,DonatorTeamId,DonatorTeamName")] Donation donation)
        {
            if (id != donation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationExists(donation.Id))
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
            return View(donation);
        }

        private bool DonationExists(int id)
        {
            return _context.Donations.Any(e => e.Id == id);
        }
    }
}
