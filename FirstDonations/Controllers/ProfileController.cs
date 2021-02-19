using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FirstDonations.Models;
using FirstDonations.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Project.Data;

namespace FirstDonations.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AuthDbContext _context;

        public ProfileController(AuthDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InterestedTeamProfile(string interestedTeamId)
        {
            var interestedTeamProfile = _context.Users.Where(u => u.Id == interestedTeamId).FirstOrDefault();

            ProfileViewModel model = new ProfileViewModel
            {
                TeamName = interestedTeamProfile.TeamName,
                UserName = interestedTeamProfile.UserName,
                TeamNumber = interestedTeamProfile.TeamNumber,
                PhoneNumber = interestedTeamProfile.PhoneNumber,
                ProfileImage = interestedTeamProfile.ProfileImage
            };

            return View(model);
        }

        public IActionResult PartOwnerProfile(string partOwnerId)
        {
            var partOwnerProfile = _context.Users.Where(u => u.Id == partOwnerId).FirstOrDefault();

            ProfileViewModel model = new ProfileViewModel
            {
                TeamName = partOwnerProfile.TeamName,
                UserName = partOwnerProfile.UserName,
                TeamNumber = partOwnerProfile.TeamNumber,
                PhoneNumber = partOwnerProfile.PhoneNumber,
                ProfileImage = partOwnerProfile.ProfileImage
            };

            return View(model);
        }
    }
}
