DELETE FROM [dbo].[OrderProducts];
GO
DELETE FROM [dbo].[Invoices];
GO
DELETE FROM [dbo].[Orders];
GO
DELETE FROM [dbo].[Products];
GO
DELETE FROM [dbo].[Categories];
GO
DELETE FROM [dbo].[AspNetRoles];
GO
DELETE FROM [dbo].[AspNetUsers];
GO
DELETE FROM [dbo].[StationaryStores];
GO
DELETE FROM [dbo].[Addresses];

SET IDENTITY_INSERT [dbo].[Addresses] ON 
GO
INSERT [dbo].[Addresses] ([Id], [City], [ZipCode], [Street], [BuildingNumber], [ApartmentNumber], [Country]) VALUES (1, N'Czestochowa', N'42-200', N'Al. Armii Krajowej', 1, 100, N'Poland')
GO
INSERT [dbo].[Addresses] ([Id], [City], [ZipCode], [Street], [BuildingNumber], [ApartmentNumber], [Country]) VALUES (2, N'Czestochowa', N'42-200', N'Wolnosci', 12, 120, N'Poland')
GO
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[StationaryStores] ON 
GO
INSERT [dbo].[StationaryStores] ([Id], [Name], [AddressId]) VALUES (1, N'Our Store', 1)
GO
SET IDENTITY_INSERT [dbo].[StationaryStores] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RegistrationDate], [UserType], [BilingAddressId], [ShippingAddressId], [StationaryStoreId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'Adam', N'Bednarski', CAST(N'2010-01-01T00:00:00.0000000' AS DateTime2), 2, NULL, NULL, NULL, N'supp1@eg.eg', N'SUPP1@EG.EG', N'supp1@eg.eg', N'SUPP1@EG.EG', 0, N'AQAAAAEAACcQAAAAEChRSHqsaFR103j4zhlctLT5uHTmpuK2ZFQAiQM13Wl/R+Pte0uhO1fBWUggsiAzrw==', N'DR5TGXGXGOF56BMKWB6RIOMC7V3RF3PL', N'0900df44-161f-4666-b7ab-c4d25111a58a', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RegistrationDate], [UserType], [BilingAddressId], [ShippingAddressId], [StationaryStoreId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (2, N'Jan', N'Nowak', CAST(N'2010-01-01T00:00:00.0000000' AS DateTime2), 3, NULL, NULL, 1, N'emp1@eg.eg', N'EMP1@EG.EG', N'emp1@eg.eg', N'EMP1@EG.EG', 0, N'AQAAAAEAACcQAAAAEKELbyAT3Nucdt2zILVY/cWITYYqF5CY9TtwhcQRRVVowq23yTKwE2bwbufFKDZ3fg==', N'LHRXRB5M6GTSO4H22Z3BZIYHUZIHQP4N', N'73445723-ca24-4f27-947e-634b7679f680', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RegistrationDate], [UserType], [BilingAddressId], [ShippingAddressId], [StationaryStoreId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (3, N'Marcin', N'Wisniewski', CAST(N'2010-01-01T00:00:00.0000000' AS DateTime2), 1, 2, 2, NULL, N'emp1@eg.eg', NULL, N'emp1@eg.eg', NULL, 0, N'AQAAAAEAACcQAAAAEIN7+9lcAw0rE0E30KnQwOw9fBAA0+81j5adsFvIW/Y47A+vLzYYAV8vD/H+JLxTYg==', N'3UR4JBGUEFDJ33K7TD2JBTRPTRX3CSZE', N'798bfa5f-1b19-41e8-a010-3440616bf2a1', NULL, 0, 0, NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Customer', N'CUSTOMER', N'b1d0c666-6d8f-484f-965c-f2479f6dd1b4')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Supplier', N'SUPPLIER', N'8acc85e3-0929-4af8-b1ea-bc3ea0cd0645')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Stationary Store Employee', N'STATIONARY STORE EMPLOYEE', N'69ba384e-4025-4262-89c9-476d078da51c')
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (3, 1)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (2, 3)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [Tag]) VALUES (1, N'Computers', N'#computer')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Description], [ImageBytes], [Name], [Price], [Weight], [CategoryId], [SupplierId]) VALUES (1, N'Bardzo praktyczny monitor 32 cale', 0xFFFFFF80, N'Monitor Dell 32', CAST(1000.0000 AS Decimal(18, 4)), 20, 1, 1)
GO
INSERT [dbo].[Products] ([Id], [Description], [ImageBytes], [Name], [Price], [Weight], [CategoryId], [SupplierId]) VALUES (2, N'Precyzyjna mysz do pracy', 0xFFFFFF70, N'Mysz Logitech', CAST(500.0000 AS Decimal(18, 4)), 0.5, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [DeliveryDate], [OrderDate], [TrackingNumber], [StationaryStoreId], [CustomerId]) VALUES (1, CAST(N'2021-12-10T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-08T00:00:00.0000000' AS DateTime2), 31234232155, 1, 3)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
INSERT [dbo].[Invoices] ([InvoiceNumber], [OrderId]) VALUES (N'123/331', 1)
GO
INSERT [dbo].[OrderProducts] ([ProductId], [OrderId], [Quantity]) VALUES (1, 1, 1)
GO
INSERT [dbo].[OrderProducts] ([ProductId], [OrderId], [Quantity]) VALUES (2, 1, 3)
GO
