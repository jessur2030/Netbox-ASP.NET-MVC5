namespace Netbox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'193fad1f-00e8-47a1-a702-c05eeee7735b', N'admin@gmail.com', 0, N'ANe9vWchMNYomRgQvaKAVs5dBdpuMXb2ebGty9fT1k1j6t3DAmN7GGEy289oGLjQWQ==', N'82de6d66-6a7d-45cc-8119-7f984011c738', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7ed713f7-5679-4015-8836-f816c11c0d7a', N'guest@gmail.com', 0, N'AObXB2k6hvftr56gFLSOI4RlIWLiY0Yn6s2rzmOZDJKXaw45PCHIqzOlsA3ks8UWwQ==', N'64593299-aaf1-4972-af85-032d8ef79a8e', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b0376f22-cbb5-4ef7-aa14-355cbd438a8d', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'193fad1f-00e8-47a1-a702-c05eeee7735b', N'b0376f22-cbb5-4ef7-aa14-355cbd438a8d')


");

        }
        
        public override void Down()
        {
        }
    }
}
