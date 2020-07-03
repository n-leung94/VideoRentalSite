namespace VideoRentalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnquiryAndEnquiryTypeModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enquiries",
                c => new
                    {
                        Id = c.Byte(),
                        Email = c.String(nullable: false, maxLength: 255),
                        Name = c.String(nullable: false, maxLength: 255),
                        EnquiryTypeId = c.Byte(nullable: false),
                        MessageField = c.String(nullable: false),
                        DateSubmitted = c.DateTime(nullable: false),
                        DateResolved = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnquiryTypes", t => t.EnquiryTypeId, cascadeDelete: true)
                .Index(t => t.EnquiryTypeId);
            
            CreateTable(
                "dbo.EnquiryTypes",
                c => new
                    {
                        Id = c.Byte(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enquiries", "EnquiryTypeId", "dbo.EnquiryTypes");
            DropIndex("dbo.Enquiries", new[] { "EnquiryTypeId" });
            DropTable("dbo.EnquiryTypes");
            DropTable("dbo.Enquiries");
        }
    }
}
