namespace VideoRentalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1e4f2ca0-e1f1-43fb-ad75-9e35333fc04d', N'admin@movierentals.com', 0, N'APgm+nf6cCzAVA8XVZ9P5WKEgAWW2ox3jodbg+Cv+E3oRTAb0/shJP/5H/SSVXfIxA==', N'481abcea-cb19-48bc-9b4a-e2d98572ec3c', NULL, 0, 0, NULL, 1, 0, N'admin@movierentals.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'30392160-ed05-4de0-8add-5fd139555de2', N'guest@movierentals.com', 0, N'AEK/dxev9sPwGsm0az3vEC3TbUVQTwtr2vUJoVB3EqJkxm8/v1kTQgEUyRpJfjnpZA==', N'872cca41-6f04-4a41-92a8-ba022166c487', NULL, 0, 0, NULL, 1, 0, N'guest@movierentals.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fdb6336a-2b4b-4408-9fca-8dcfa7f30116', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1e4f2ca0-e1f1-43fb-ad75-9e35333fc04d', N'fdb6336a-2b4b-4408-9fca-8dcfa7f30116')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
