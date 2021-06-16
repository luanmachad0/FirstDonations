﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FirstDonations.Models;
using Microsoft.AspNetCore.Identity;

namespace FirstDonations.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string TeamName { get; set; }
        public string ProfileImage { get; set; }
        public string TeamNumber { get; set; }
        public int NumberOfSuccessDonations { get; set; }
    }
}
