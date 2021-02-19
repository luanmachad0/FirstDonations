using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstDonations.Models;
using Microsoft.AspNetCore.Authorization;
using FirstDonations.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Security.Claims;
using System.Collections.Generic;
using FirstDonations.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Project.Data;

namespace FirstDonations.Controllers
{
    [Authorize]
    public class PartsController : Controller
    {
        private readonly AuthDbContext _authDbContext;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PartsController(AppDbContext context, IWebHostEnvironment hostEnvironment, AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        // GET: Parts
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(await _context.Parts.Where(p => p.OwnerTeam == userId).ToListAsync());
        }

        public async Task<IActionResult> AvailableParts()
        {
            return View(await _context.Parts.Where(p => p.OwnerTeam == "").ToListAsync());
        }

        public async Task<IActionResult> Requests(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Donation> ViewBagUserDonations = new List<Donation>();

            var partDonations = await _context.Donations.Where(d => d.Part.Id == id).ToListAsync();

            foreach (var donation in partDonations)
            {
                ViewBagUserDonations.Add(donation);
            }

            return View(ViewBagUserDonations);
        }

        public async Task<IActionResult> AcceptRequest(int id, string interestedTeamId)
        {
            var donation = _context.Donations.Where(d => d.Id == id && d.InterestedTeamId == interestedTeamId).FirstOrDefault();
            var interestedTeamIdFromDonation = donation.InterestedTeamId;
            donation.Status = "Unavailable";

            var part = _context.Parts.Where(p => p.Id == donation.PartId).FirstOrDefault();
            part.Status = "Unavailable";

            _context.Update(donation);
            _context.Update(part);
            await _context.SaveChangesAsync();

            return RedirectToAction("InterestedTeamProfile", "Profile", new { interestedTeamId = interestedTeamIdFromDonation });
        }

        public async Task<IActionResult> DeclineRequest(int id, string interestedTeamId)
        {
            var donation = _context.Donations.Where(d => d.Id == id && d.InterestedTeamId == interestedTeamId).FirstOrDefault();

            _context.Remove(donation);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Parts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // GET: Parts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Area,Count,Image")] PartViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var ownerTeam = _authDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();

                Part part = new Part
                {
                    Name = model.Name,
                    Area = model.Area,
                    Count = model.Count,
                    Image = uniqueFileName,
                    OwnerTeam = userId,
                    Status = "Available",
                    ProfileImage = ownerTeam.ProfileImage
                };

                part.OwnerTeam = "";

                _context.Add(part);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AvailableParts));
            }

            return View(model);
        }

        // GET: Parts/CreateUserPart
        public IActionResult CreateUserPart()
        {
            List<Part> cl = new List<Part>();
            cl = (from c in _context.Parts.Where(p => p.OwnerTeam == "") select c).ToList();
            cl.Insert(0, new Part { Id = 0, Name = "Select Part" });
            ViewBag.message = cl;

            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUserPart([Bind("Id,Name,Area,Count,Image")] Part model)
        {
            var partSelected = _context.Parts.Where(p => p.Name == model.Name).FirstOrDefault();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ownerTeam = _authDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();

            Part part = new Part
            {
                Name = partSelected.Name,
                Area = partSelected.Area,
                Count = partSelected.Count,
                Image = partSelected.Image,
                OwnerTeam = userId,
                Status = "Available",
                ProfileImage = ownerTeam.ProfileImage
            };

            _context.Add(part);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Parts/GetPart/5
        [HttpPost]
        public ActionResult GetPart(int? pId)
        {
            if (pId == null)
            {
                return NotFound();
            }

            var data = _context.Parts.Find(pId);
            if (data == null)
            {
                return NotFound();
            }

            var teste = data.Image;

            return Json(data);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Parts.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Area,Count,Image")] Part part)
        {
            if (id != part.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(part);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartExists(part.Id))
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
            return View(part);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Parts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }

        private string UploadedFile(PartViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
