using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FirstDonations.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Data;

namespace FirstDonations.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly ILogger<NotificationsController> _logger;

        private readonly AppDbContext _context;
        private readonly AuthDbContext _authDbContext;

        public NotificationsController(ILogger<NotificationsController> logger, AppDbContext context, AuthDbContext authDbContext)
        {
            _logger = logger;
            _context = context;
            _authDbContext = authDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(await _context.UsersNotifications.Where(u => u.ReceptorTeamId == userId).ToListAsync());
        }
    }
}
