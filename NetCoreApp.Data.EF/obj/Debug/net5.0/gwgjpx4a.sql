BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tours]') AND [c].[name] = N'EditById');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tours] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tours] ALTER COLUMN [EditById] uniqueidentifier NOT NULL;
ALTER TABLE [Tours] ADD DEFAULT '00000000-0000-0000-0000-000000000000' FOR [EditById];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tours]') AND [c].[name] = N'CreateById');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Tours] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Tours] ALTER COLUMN [CreateById] uniqueidentifier NOT NULL;
ALTER TABLE [Tours] ADD DEFAULT '00000000-0000-0000-0000-000000000000' FOR [CreateById];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TourDates]') AND [c].[name] = N'EditById');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TourDates] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [TourDates] ALTER COLUMN [EditById] uniqueidentifier NOT NULL;
ALTER TABLE [TourDates] ADD DEFAULT '00000000-0000-0000-0000-000000000000' FOR [EditById];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TourDates]') AND [c].[name] = N'CreateById');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [TourDates] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [TourDates] ALTER COLUMN [CreateById] uniqueidentifier NOT NULL;
ALTER TABLE [TourDates] ADD DEFAULT '00000000-0000-0000-0000-000000000000' FOR [CreateById];
GO

ALTER TABLE [Products] ADD [CreateById] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

ALTER TABLE [Products] ADD [EditById] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'EditById');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Categories] ALTER COLUMN [EditById] uniqueidentifier NOT NULL;
ALTER TABLE [Categories] ADD DEFAULT '00000000-0000-0000-0000-000000000000' FOR [EditById];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'CreateById');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Categories] ALTER COLUMN [CreateById] uniqueidentifier NOT NULL;
ALTER TABLE [Categories] ADD DEFAULT '00000000-0000-0000-0000-000000000000' FOR [CreateById];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231211092143_editgui', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Functions]') AND [c].[name] = N'IsType');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Functions] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Functions] DROP COLUMN [IsType];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231213040734_functione', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Functions]') AND [c].[name] = N'CategoryTypeID');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Functions] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Functions] DROP COLUMN [CategoryTypeID];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214024625_editf', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Functions] ADD [CategoryTypeID] int NULL;
GO

ALTER TABLE [Functions] ADD [IsType] bit NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214025350_editFun1', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Functions]') AND [c].[name] = N'IsType');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Functions] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Functions] ALTER COLUMN [IsType] bit NOT NULL;
ALTER TABLE [Functions] ADD DEFAULT CAST(0 AS bit) FOR [IsType];
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Functions]') AND [c].[name] = N'CategoryTypeID');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Functions] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Functions] ALTER COLUMN [CategoryTypeID] int NOT NULL;
ALTER TABLE [Functions] ADD DEFAULT 0 FOR [CategoryTypeID];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214025750_fixisnull', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tours]') AND [c].[name] = N'Status');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Tours] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Tours] DROP COLUMN [Status];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240123082202_delete_status_tour', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Tours] ADD [Status] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240123082500_add-statu-tour', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [ProductCategories];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240229080506_remoreProductCategory', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Products] ADD [HomeOrder] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Products] ADD [Order] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240312074841_updateProductEntity', N'5.0.13');
GO

COMMIT;
GO

