using FirstDonations.Areas.Identity.Data;
using FirstDonations.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDonations.ViewModels
{
    public class UsersPartsViewModel
    {
        public Part Part { get; set; }

        public string OwnerTeamName { get; set; }
    }
}
