using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FirstDonations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstDonations.Controllers
{
    public class DonationsController : Controller
    {
        private readonly AppDbContext _context;

        public DonationsController(AppDbContext context)
        {
            _context = context;
        }

        //GET: Parts
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(await _context.Donations.Where(d => d.InterestedTeamId == userId && d.Part.Status != "Unavailable").ToListAsync());
        }

        public async Task<IActionResult> Create(int id)
        {
            if (ModelState.IsValid)
            {
                var interestedTeamId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var interestedTeamName = this.User.Identity.Name;

                var part = await _context.Parts.FindAsync(id);

                var donatorTeamId = part.OwnerTeam;

                Donation donation = new Donation
                {
                    NamePart = part.Name,
                    ImagePart = part.Image,
                    Part = part,
                    Status = "Requested",
                    InterestedTeamId = interestedTeamId,
                    InterestedTeamName = interestedTeamName,
                    DonatorTeamId = donatorTeamId
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
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }
    }
}
