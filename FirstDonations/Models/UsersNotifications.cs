using FirstDonations.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDonations.Models
{
    public class UsersNotifications
    {
        [Key]
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string ReceptorTeamId { get; set; }
        public string DeliverTeamId { get; set; }
    }
}
