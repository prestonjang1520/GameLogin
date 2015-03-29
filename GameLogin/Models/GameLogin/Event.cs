using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLogin.Models.GameLogin
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public string NoticesTemp { get; set; }
        public string NoticesPermanentTop { get; set; }
        public string NoticesPermanentBot { get; set; }
        public string NoticesEndOfSeason { get; set; }
        public int RosterId { get; set; }
        public string RosterName { get; set; }
        public string LeagueName { get; set; }

        public virtual Roster Roster { get; set; }
        public virtual League League { get; set; }
    }
}