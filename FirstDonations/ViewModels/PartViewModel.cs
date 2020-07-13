using FirstDonations.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDonations.ViewModels
{
    public class PartViewModel
    {
        [Required(ErrorMessage = "Please enter part")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please choose area")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Please enter quantity")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Please enter part image")]
        public IFormFile Image { get; set; }
    }
}
