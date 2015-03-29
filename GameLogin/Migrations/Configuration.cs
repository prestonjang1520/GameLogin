namespace GameLogin.Migrations
{
    using GameLogin.Models;
    using GameLogin.Models.GameLogin;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameLogin.Models.Context.LeagueContext>
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameLogin.Models.Context.LeagueContext context)
        {
            
        }
    }
}
