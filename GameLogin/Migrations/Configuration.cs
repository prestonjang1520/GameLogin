namespace GameLogin.Migrations
{
    using GameLogin.Models;
    using GameLogin.Models.GameLogin;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameLogin.Models.Context.LeagueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameLogin.Models.Context.LeagueContext context)
        {
            //data for the leagues
            List<League> leagues = new List<League>(){
                new League{
                    LeagueName = "BCIT Hockey",
                    TeamLogo = "HockeyPlayer",
                    MaxPlayers = 10,
                    PlayerCount = 0,
                    AdminName = "John",
                    Email = "j@j.j"
                },
                new League{
                    LeagueName = "BCIT Soccer",
                    TeamLogo = "SoccerPlayer",
                    MaxPlayers = 20,
                    PlayerCount = 0,
                    AdminName = "Alice",
                    Email = "a@a.a"
                }
            };

            leagues.ForEach(s => context.Leagues.AddOrUpdate(p => p.LeagueName, s));
            context.SaveChanges();

            //data for the admins
            List<Admin> admins = new List<Admin>(){
                new Admin{
                    Name = "John",
                    Email = "j@j.j",
                    Password = "password",
                    LeagueName = context.Leagues.Single(s => s.LeagueName.Equals("BCIT Hockey")).LeagueName
                },
                new Admin{
                    Name = "Alice",
                    Email = "a@a.a",
                    Password = "password",
                    LeagueName = context.Leagues.Single(s => s.LeagueName.Equals("BCIT Soccer")).LeagueName
                }
            };

            admins.ForEach(s => context.Admins.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            //data for all the rosters
            List<Roster> rosters = new List<Roster>(){
                new Roster{
                    RosterName = "Game 1 hockey roster"
                },
                new Roster{
                    RosterName = "Game 1 soccer roster"
                },
                new Roster{
                    RosterName = "Game 2 hockey roster"
                }
            };

            rosters.ForEach(s => context.Rosters.AddOrUpdate(p => p.RosterName, s));
            context.SaveChanges();

            //data for all the players
            List<Player> players = new List<Player>()
            {
                new Player{
                    Name = "Preston",
                    Email = "p@p.p",
                    PhonePrimary = "1111111111",
                    Comments = " ",
                    HomeTeam = true,
                    Regular = true,
                    Active = true
                },
                new Player{
                    Name = "Duy",
                    Email = "d@d.d",
                    PhonePrimary = "1111111111",
                    Comments = " ",
                    HomeTeam = true,
                    Regular = true,
                    Active = true
                },
                new Player{
                    Name = "Andrew",
                    Email = "a@a.a",
                    PhonePrimary = "1111111111",
                    Comments = " ",
                    HomeTeam = false,
                    Regular = true,
                    Active = true
                },
                new Player{
                    Name = "Jim",
                    Email = "j@j.j",
                    PhonePrimary = "1111111111",
                    Comments = " ",
                    HomeTeam = false,
                    Regular = true,
                    Active = true
                },
                new Player{
                    Name = "Kevin",
                    Email = "k@k.k",
                    PhonePrimary = "1111111111",
                    Comments = " ",
                    HomeTeam = true,
                    Regular = false,
                    Active = false
                }
            };

            players.ForEach(s => context.Players.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

        }
    }
}
