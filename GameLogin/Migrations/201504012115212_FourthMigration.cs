namespace GameLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "ExpiryDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "ExpiryDate", c => c.DateTime(nullable: false));
        }
    }
}
