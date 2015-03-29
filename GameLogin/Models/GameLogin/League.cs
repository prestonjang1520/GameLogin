using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameLogin.Models.GameLogin
{
    public class League
    {
        [Key]
        public string LeagueName { get; set; }
        public string TeamLogo { get; set; }
        public int MaxPlayers { get; set; }
        public int PlayerCount { get; set; }
        public string AdminName { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}