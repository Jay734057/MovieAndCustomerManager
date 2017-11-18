namespace MovieAndCustomerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'83064925-4628-4b97-91fb-e6abbc96b480', N'admin@gmail.com', 0, N'AG0YoVUuhLKKHOlIM/kWwxq4RFFA9xVuWtQiiHBv41zqqsT+EXYiZExQDM/ziZ4pnw==', N'f22032e8-b093-4e27-a8fd-cd7564c305fa', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a06500da-c2e0-4561-b2c0-b022bb7e3a4e', N'guest@gmail.com', 0, N'AFfr4XEkds9OJaOnyLxhrjSVN2Nl9kCDlS+awcNc+AH+KNNIaRTX86u8M3odLnQfWA==', N'a50d1788-6369-4ea0-a994-9e76d0d0010a', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
            
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'af7383b1-fe58-48fa-8dd2-17979588113c', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'83064925-4628-4b97-91fb-e6abbc96b480', N'af7383b1-fe58-48fa-8dd2-17979588113c')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
