using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstDonations.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Project.Data;

namespace FirstDonations.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _context;
        private readonly AuthDbContext _authDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, AuthDbContext authDbContext)
        {
            _logger = logger;
            _context = context;
            _authDbContext = authDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.userId = userId;

            var userDonations = _context.Donations.Where(d => d.InterestedTeamId == userId).ToList();

            List<int> parts = new List<int>();

            foreach (Donation donation in userDonations)
            { 
                parts.Add(donation.PartId);
            }

            if(parts.Count == 0)
            {
                parts.Add(555);
            }

            ViewBag.userRequestsPartId = parts;

            return View(await _context.Parts.Where(p => p.Status != "NotAvailable" && p.OwnerTeam != "").ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> IndexSearch(string txtBusca)
        {
            var partsView = _context.Parts.Where(p => p.Status != "NotAvailable" && p.OwnerTeam != "" && p.Name.Contains(txtBusca)).ToList();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.userId = userId;

            var userDonations = await _context.Donations.Where(d => d.InterestedTeamId == userId).ToListAsync();

            List<int> parts = new List<int>();

            foreach (Donation donation in userDonations)
            {
                parts.Add(donation.PartId);
            }

            if (parts.Count == 0)
            {
                parts.Add(555);
            }

            ViewBag.userRequestsPartId = parts;

            return View(partsView);
        }

        public async Task<IActionResult> Ranking()
        {
            var users = await _authDbContext.Users.Where(u => u.TeamName != "Super User").OrderByDescending(u => u.NumberOfSuccessDonations).ToListAsync();

            List<int> rankingNumbers = new List<int>() {1,2,3,4,5};

            ViewBag.rankingNumbers = rankingNumbers;

            return View(users);
        }

        public async Task<IActionResult> PartDetails(int? id)
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
