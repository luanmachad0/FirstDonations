﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using FirstDonations.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstDonations.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
            _webHostEnvironment = hostEnvironment;

            Roles = new List<SelectListItem>();
            Roles.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
            Roles.Add(new SelectListItem() { Value = "Operator", Text = "Operator" });
            Roles.Add(new SelectListItem() { Value = "User", Text = "User" });
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Perfis de usuário : ")]
        [UIHint("List")]
        public List<SelectListItem> Roles { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Team Name")]
            public string TeamName { get; set; }

            [Required]
            [EmailAddress]
            [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$",
                            ErrorMessage = "Please enter a valid email address")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(5)]
            [RegularExpression("^(0|[1-9]*)$",
                            ErrorMessage = "Please enter a valid number")]
            [Display(Name = "Team Number")]
            public string TeamNumber { get; set; }

            [Required]
            [RegularExpression(@"(([+][(]?[0-9]{1,3}[)]?)|([(]?[0-9]{2}[)]?))\s*[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?([-\s\.]?[0-9]{3})([-\s\.]?[0-9]{3,4})",
                            ErrorMessage = "Please enter a valid phone number")]
            [Phone]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Profile Image")]
            public IFormFile Image { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Perfis de usuário : ")]
            [UIHint("List")]
            public List<SelectListItem> Roles { get; set; }

            public string Role { get; set; }

            public InputModel()
            {
                Roles = new List<SelectListItem>();
                Roles.Add(new SelectListItem() { Value = "1", Text = "Admin" });
                Roles.Add(new SelectListItem() { Value = "2", Text = "Operator" });
                Roles.Add(new SelectListItem() { Value = "3", Text = "User" });
            }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Home");
            }

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(Input.Image);

                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    TeamName = Input.TeamName,
                    TeamNumber = Input.TeamNumber,
                    PhoneNumber = Input.PhoneNumber,
                    ProfileImage = uniqueFileName,
                    NumberOfSuccessDonations = 0
                };

                user.LockoutEnabled = true;

                

                var result = await _userManager.CreateAsync(user, Input.Password);

                //-------------------atribuir role ao user------------------------------
                //var applicationRole = await _roleManager.FindByNameAsync(Input.Role);
                //if (applicationRole != null)
                //{
                //    IdentityResult roleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                //}
                //-------------------atribuir role ao user------------------------------

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (user.LockoutEnabled)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./UserLocked");
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private string UploadedFile(IFormFile image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
