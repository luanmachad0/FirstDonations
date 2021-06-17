using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FirstDonations.Models;
using FirstDonations.ViewModels;
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

            var userNotifications = await _context.UsersNotifications.Where(u => u.ReceptorTeamId == userId).ToListAsync();

            List<NotificationsViewModel> notificationViews = new List<NotificationsViewModel>();

            foreach (UsersNotifications userNotification in userNotifications)
            {
                var notification = _context.Notifications.Where(n => n.Id == userNotification.NotificationId).First();
                var teamDeliver = _authDbContext.Users.Where(u => u.Id == userNotification.DeliverTeamId).First();

                var notificationView = new NotificationsViewModel
                {
                    Content = notification.Content,
                    TeamName = teamDeliver.TeamName,
                    Id = userNotification.Id
                };

                notificationViews.Add(notificationView);
            }

            ViewBag.Notifications = notificationViews;

            return View(await _context.UsersNotifications.Where(u => u.ReceptorTeamId == userId).ToListAsync());
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userNotification = await _context.UsersNotifications
                .FirstOrDefaultAsync(m => m.Id == id);

            if (userNotification == null)
            {
                return NotFound();
            }

            return View(userNotification);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userNotification = await _context.UsersNotifications.FindAsync(id);
            _context.UsersNotifications.Remove(userNotification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
