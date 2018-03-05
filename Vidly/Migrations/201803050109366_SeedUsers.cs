namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'005e95d7-d24b-46ac-b540-e4af7daf7346', N'admin@vidly.com', 0, N'AGvHlhLjJTP+EpA4zFWLSuiDUeyNDrpwXILUfL6xy3BMVrtbmJMBgyibrPB0qFaNiw==', N'1d9ccfa3-5e1b-48ec-86a9-624dd3f4bc00', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c376a88-b79a-485d-9e87-860b5bf1883c', N'guest@vidly.com', 0, N'ABV6T5PgWjaQ3ipWyGW2/R3V1KISU+GgjYAhmtHJMe8+ArXJtbv2Xym3o6xhWu2+Zw==', N'c1295abb-e073-43c9-9f05-97f5161668e0', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'28b7c563-521f-438a-ae6d-d5a6374b083e', N'rubennavaja@hotmail.com', 0, N'ADiLu511MUkJnUDoCH30ZvdsumlufGzfRAtXzBCu9kCqNzBrt1DxW8eCaxQsP0zc9A==', N'4cdc933c-f2a7-42b2-8fc6-813ac287a43e', NULL, 0, 0, NULL, 1, 0, N'rubennavaja@hotmail.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'47207b61-3037-4f5f-a674-0d5ba3ceb42c', N'CanManageMovie')
            
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'005e95d7-d24b-46ac-b540-e4af7daf7346', N'47207b61-3037-4f5f-a674-0d5ba3ceb42c')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
