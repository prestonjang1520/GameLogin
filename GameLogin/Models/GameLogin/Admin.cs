using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLogin.Models.GameLogin
{
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }
        [Required]
        public String Name { get; set; }

        [Required]
        [StringLength(30,
            ErrorMessage = "The {0} must be between {2} and {1} characters",
            MinimumLength = 5)]
        public String Email { get; set; }

        [Required]
        [StringLength(20,
            ErrorMessage = "The {0} must be between {2} and {1} characters",
            MinimumLength = 8)]
        public String Password { get; set; }
        public DateTime ExpiryDate { get; set; }
        public String LeagueName { get; set; }
        public League League { get; set; }
    }
}