namespace GameLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leagues", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leagues", "Email");
        }
    }
}
