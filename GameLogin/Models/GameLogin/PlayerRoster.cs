using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLogin.Models.GameLogin
{
    public class PlayerRoster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int RosterId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Roster Roster { get; set; }
    }
}