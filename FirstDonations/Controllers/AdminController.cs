using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDonations.Areas.Identity.Data;
using FirstDonations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace FirstDonations.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthDbContext _authDbContext;
        private readonly AppDbContext _context;

        public AdminController(AuthDbContext authDbContext, AppDbContext context)
        {
            _authDbContext = authDbContext;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageTeams()
        {
            return View(_authDbContext.Users.ToList());
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _authDbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TeamName,TeamNumber,Email,UserName,LockoutEnabled")] ApplicationUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userData = _authDbContext.Users.Where(u => u.Id == user.Id).FirstOrDefault();

                    userData.TeamName = user.TeamName;
                    userData.TeamNumber = user.TeamNumber;
                    userData.Email = user.Email;
                    userData.UserName = user.UserName;
                    userData.LockoutEnabled = user.LockoutEnabled;


                    _authDbContext.Update(userData);
                    _authDbContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        private bool UserExists(string id)
        {
            return _authDbContext.Users.Any(e => e.Id == id);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _authDbContext.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _authDbContext.Users.FindAsync(id);
            _authDbContext.Users.Remove(user);

            var parts = _context.Parts.Where(p => p.OwnerTeam == id).ToList();

            foreach (Part part in parts)
            {
                _context.Parts.Remove(part);
            }

            await _authDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(ManageTeams));
        }

    }
}
