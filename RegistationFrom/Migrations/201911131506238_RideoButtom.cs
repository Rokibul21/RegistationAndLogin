namespace RegistationFrom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RideoButtom : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
