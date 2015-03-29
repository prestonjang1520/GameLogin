using GameLogin.Models.GameLogin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLogin.Models
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(30,
            ErrorMessage = "The {0} must be between {2} and {1} characters",
            MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(30,
            ErrorMessage = "The {0} must be between {2} and {1} characters",
            MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(20,
            ErrorMessage = "The {0} must be between {2} and {1} characters",
            MinimumLength = 10)]
        public string PhonePrimary { get; set; }

        [StringLength(20,
            ErrorMessage = "The {0} must be between {2} and {1} characters",
            MinimumLength = 10)]
        public string PhoneSecondary { get; set; }

        [StringLength(20,
            ErrorMessage = "The {0} must be between {2} and {1} characters",
            MinimumLength = 10)]
        public string PhoneTertiary { get; set; }

        public string Comments { get; set; }

        [Required]
        public bool HomeTeam { get; set; }

        [Required]
        public bool Regular { get; set; }

        public bool AutoLogin { get; set; }

        public DateTime LastGame { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ICollection<Roster> Rosters { get; set; }
    }
}