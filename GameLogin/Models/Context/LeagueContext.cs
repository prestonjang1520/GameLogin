using GameLogin.Models.GameLogin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameLogin.Models.Context
{
    public class LeagueContext : DbContext
    {
        public LeagueContext() : base("name=DefaultConnection") { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AutoEmail> AutoEmails { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Roster> Rosters { get; set; }
        public DbSet<PlayerRoster> PlayerRosters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .Property(f => f.LastGame)
                .HasColumnType("datetime2");
            modelBuilder.Entity<Admin>()
                .Property(f => f.ExpiryDate)
                .HasColumnType("datetime2");
        }
    }
}