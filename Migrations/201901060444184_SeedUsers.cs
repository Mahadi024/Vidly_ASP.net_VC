namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1825e6fb-2692-4730-97ac-716c8ff9a4ef', N'guest@vidly.com', 0, N'AHZ/W8NZuU5Z9Xv83CmK+2YCytFsOyXDVMnfsUz3Yyk/tVM+u29f5rFUdpa4G57qWg==', N'934c584e-b5bb-4f58-94dd-3f2fe142d4f5', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de28640c-c3df-4667-8cd4-cbec4157041f', N'admin@vidly.com', 0, N'AD6TSOpf+6yfd69pBYxPvvH+vWVhC3Xvv/mfzQrq7WU1Ie96FNw+71OjZ19+XuqU0g==', N'515d67f2-dfd5-4615-a801-feddc380b8b4', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b110b9e9-a137-44fa-acd6-f8bcf9acc252', N'CanManageMovie')
            
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'de28640c-c3df-4667-8cd4-cbec4157041f', N'b110b9e9-a137-44fa-acd6-f8bcf9acc252')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
