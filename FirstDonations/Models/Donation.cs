﻿using FirstDonations.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDonations.Models
{
    public class Donation
    {
        [Key]
        public int Id { get; set; }
        public string NamePart { get; set; }
        public string ImagePart { get; set; }
        public Part Part { get; set; }
        public int PartId { get; set; }
        public string Status { get; set; }
        public string InterestedTeamId { get; set; }
        public string InterestedTeamName { get; set; }
        public string DonatorTeamId { get; set; }
        public string DonatorTeamName { get; set; }
    }
}
