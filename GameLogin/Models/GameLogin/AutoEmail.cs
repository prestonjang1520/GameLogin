using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameLogin.Models.GameLogin
{
    public class AutoEmail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string EmailHeader { get; set; }
        public string EmailSubject { get; set; }
        public string EmailText { get; set; }
        public int EmailOptions { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}