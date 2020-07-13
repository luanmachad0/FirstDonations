﻿using FirstDonations.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDonations.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter part")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please choose area")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Please enter quantity")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Please enter part image")]
        public string Image { get; set; }

        public ApplicationUser OwnerTeam { get; set; }
    }
}