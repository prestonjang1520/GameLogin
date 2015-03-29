using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLogin.Models.GameLogin
{
    public class Roster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RosterId { get; set; }
        [Required]
        public string RosterName { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}