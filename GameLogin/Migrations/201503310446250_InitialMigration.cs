namespace GameLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 20),
                        LeagueName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AdminId)
                .ForeignKey("dbo.Leagues", t => t.LeagueName)
                .Index(t => t.LeagueName);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        LeagueName = c.String(nullable: false, maxLength: 128),
                        TeamLogo = c.String(),
                        MaxPlayers = c.Int(nullable: false),
                        PlayerCount = c.Int(nullable: false),
                        AdminName = c.String(),
                    })
                .PrimaryKey(t => t.LeagueName);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        EventPassword = c.String(nullable: false),
                        NoticesTemp = c.String(),
                        NoticesPermanentTop = c.String(),
                        NoticesPermanentBot = c.String(),
                        NoticesEndOfSeason = c.String(),
                        RosterId = c.Int(nullable: false),
                        RosterName = c.String(),
                        LeagueName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Leagues", t => t.LeagueName)
                .ForeignKey("dbo.Rosters", t => t.RosterId, cascadeDelete: true)
                .Index(t => t.RosterId)
                .Index(t => t.LeagueName);
            
            CreateTable(
                "dbo.Rosters",
                c => new
                    {
                        RosterId = c.Int(nullable: false, identity: true),
                        RosterName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RosterId);
            
            CreateTable(
                "dbo.PlayerRosters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        RosterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Rosters", t => t.RosterId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.RosterId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        PhonePrimary = c.String(nullable: false, maxLength: 20),
                        PhoneSecondary = c.String(maxLength: 20),
                        PhoneTertiary = c.String(maxLength: 20),
                        Comments = c.String(),
                        HomeTeam = c.Boolean(nullable: false),
                        Regular = c.Boolean(nullable: false),
                        AutoLogin = c.Boolean(nullable: false),
                        LastGame = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Active = c.Boolean(nullable: false),
                        AutoEmail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AutoEmails", t => t.AutoEmail_Id)
                .Index(t => t.AutoEmail_Id);
            
            CreateTable(
                "dbo.AutoEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailHeader = c.String(nullable: false),
                        EmailSubject = c.String(),
                        EmailText = c.String(),
                        EmailOptions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "AutoEmail_Id", "dbo.AutoEmails");
            DropForeignKey("dbo.Events", "RosterId", "dbo.Rosters");
            DropForeignKey("dbo.PlayerRosters", "RosterId", "dbo.Rosters");
            DropForeignKey("dbo.PlayerRosters", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Events", "LeagueName", "dbo.Leagues");
            DropForeignKey("dbo.Admins", "LeagueName", "dbo.Leagues");
            DropIndex("dbo.Players", new[] { "AutoEmail_Id" });
            DropIndex("dbo.PlayerRosters", new[] { "RosterId" });
            DropIndex("dbo.PlayerRosters", new[] { "PlayerId" });
            DropIndex("dbo.Events", new[] { "LeagueName" });
            DropIndex("dbo.Events", new[] { "RosterId" });
            DropIndex("dbo.Admins", new[] { "LeagueName" });
            DropTable("dbo.AutoEmails");
            DropTable("dbo.Players");
            DropTable("dbo.PlayerRosters");
            DropTable("dbo.Rosters");
            DropTable("dbo.Events");
            DropTable("dbo.Leagues");
            DropTable("dbo.Admins");
        }
    }
}
