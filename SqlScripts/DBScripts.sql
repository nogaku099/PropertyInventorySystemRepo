IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110065819_InitDb')
BEGIN
    CREATE TABLE [Contacts] (
        [Id] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [EmailAddress] nvarchar(max) NULL,
        [CreatedDateTime] datetime2 NOT NULL,
        [LastModifiedDateTime] datetime2 NOT NULL,
        CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110065819_InitDb')
BEGIN
    CREATE TABLE [Properties] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [DateOfRegistration] datetime2 NOT NULL,
        [Price] float NOT NULL,
        [EmailAddress] nvarchar(max) NOT NULL,
        [CreatedDateTime] datetime2 NOT NULL,
        [LastModifiedDateTime] datetime2 NOT NULL,
        CONSTRAINT [PK_Properties] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110065819_InitDb')
BEGIN
    CREATE TABLE [ContactProperty] (
        [ContactsId] uniqueidentifier NOT NULL,
        [PropertiesId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ContactProperty] PRIMARY KEY ([ContactsId], [PropertiesId]),
        CONSTRAINT [FK_ContactProperty_Contacts_ContactsId] FOREIGN KEY ([ContactsId]) REFERENCES [Contacts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ContactProperty_Properties_PropertiesId] FOREIGN KEY ([PropertiesId]) REFERENCES [Properties] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110065819_InitDb')
BEGIN
    CREATE TABLE [PropertyPriceAudits] (
        [Id] uniqueidentifier NOT NULL,
        [EffectedDateTime] datetime2 NOT NULL,
        [OldPrice] float NOT NULL,
        [NewPrice] float NOT NULL,
        [PropertyId] uniqueidentifier NULL,
        [CreatedDateTime] datetime2 NOT NULL,
        [LastModifiedDateTime] datetime2 NOT NULL,
        CONSTRAINT [PK_PropertyPriceAudits] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PropertyPriceAudits_Properties_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Properties] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110065819_InitDb')
BEGIN
    CREATE INDEX [IX_ContactProperty_PropertiesId] ON [ContactProperty] ([PropertiesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110065819_InitDb')
BEGIN
    CREATE INDEX [IX_PropertyPriceAudits_PropertyId] ON [PropertyPriceAudits] ([PropertyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110065819_InitDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241110065819_InitDb', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] DROP CONSTRAINT [FK_ContactProperty_Contacts_ContactsId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] DROP CONSTRAINT [FK_ContactProperty_Properties_PropertiesId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] DROP CONSTRAINT [PK_ContactProperty];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    DROP INDEX [IX_ContactProperty_PropertiesId] ON [ContactProperty];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD [Id] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD [ContactId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD [CreatedDateTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD [EffectiveFrom] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD [EffectiveTill] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD [LastModifiedDateTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD [PriceOfAcquisition] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD [PropertyId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD CONSTRAINT [PK_ContactProperty] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    CREATE INDEX [IX_ContactProperty_ContactId] ON [ContactProperty] ([ContactId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    CREATE INDEX [IX_ContactProperty_PropertyId] ON [ContactProperty] ([PropertyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD CONSTRAINT [FK_ContactProperty_Contacts_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Contacts] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD CONSTRAINT [FK_ContactProperty_Properties_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Properties] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110071227_updateContactProperty')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241110071227_updateContactProperty', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110104929_updateAllowNullPropertyAndContact')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241110104929_updateAllowNullPropertyAndContact', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110110857_AllowNullContactPropertyWithProperty')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241110110857_AllowNullContactPropertyWithProperty', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110114708_AddAutoGeneratedGUID')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PropertyPriceAudits]') AND [c].[name] = N'Id');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [PropertyPriceAudits] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [PropertyPriceAudits] ADD DEFAULT (NEWID()) FOR [Id];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110114708_AddAutoGeneratedGUID')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Properties]') AND [c].[name] = N'Id');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Properties] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Properties] ADD DEFAULT (NEWID()) FOR [Id];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110114708_AddAutoGeneratedGUID')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'Id');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Contacts] ADD DEFAULT (NEWID()) FOR [Id];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110114708_AddAutoGeneratedGUID')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContactProperty]') AND [c].[name] = N'Id');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ContactProperty] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [ContactProperty] ADD DEFAULT (NEWID()) FOR [Id];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241110114708_AddAutoGeneratedGUID')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241110114708_AddAutoGeneratedGUID', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] DROP CONSTRAINT [FK_ContactProperty_Contacts_ContactId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] DROP CONSTRAINT [FK_ContactProperty_Properties_PropertyId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    DROP INDEX [IX_ContactProperty_ContactId] ON [ContactProperty];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    DROP INDEX [IX_ContactProperty_PropertyId] ON [ContactProperty];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContactProperty]') AND [c].[name] = N'ContactId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ContactProperty] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [ContactProperty] DROP COLUMN [ContactId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContactProperty]') AND [c].[name] = N'PropertyId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ContactProperty] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [ContactProperty] DROP COLUMN [PropertyId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    CREATE INDEX [IX_ContactProperty_ContactsId] ON [ContactProperty] ([ContactsId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    CREATE INDEX [IX_ContactProperty_PropertiesId] ON [ContactProperty] ([PropertiesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD CONSTRAINT [FK_ContactProperty_Contacts_ContactsId] FOREIGN KEY ([ContactsId]) REFERENCES [Contacts] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    ALTER TABLE [ContactProperty] ADD CONSTRAINT [FK_ContactProperty_Properties_PropertiesId] FOREIGN KEY ([PropertiesId]) REFERENCES [Properties] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241111063741_updateRelationContactProperty')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241111063741_updateRelationContactProperty', N'7.0.20');
END;
GO

COMMIT;
GO

