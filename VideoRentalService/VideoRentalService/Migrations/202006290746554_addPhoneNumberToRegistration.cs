namespace VideoRentalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPhoneNumberToRegistration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
        }
    }
}
