namespace VideoRentalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[EnquiryTypes] ([Id], [Name]) VALUES (1, N'Billing')");
            Sql("INSERT INTO [dbo].[EnquiryTypes] ([Id], [Name]) VALUES (2, N'Stock Availability')");
            Sql("INSERT INTO [dbo].[EnquiryTypes] ([Id], [Name]) VALUES (3, N'Membership')");
            Sql("INSERT INTO [dbo].[EnquiryTypes] ([Id], [Name]) VALUES (4, N'General')");
            
        }
        
        public override void Down()
        {
        }
    }
}
