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

CREATE TABLE [Utilizadores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Email] varchar(5) NULL,
    [Nif] varchar(9) NULL,
    [Excluido] bit NOT NULL,
    CONSTRAINT [PK_Utilizadores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Moradas] (
    [Id] uniqueidentifier NOT NULL,
    [Rua] varchar(200) NOT NULL,
    [CP] varchar(8) NOT NULL,
    [Porta] varchar(10) NOT NULL,
    [UtilizadorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Moradas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Moradas_Utilizadores_UtilizadorId] FOREIGN KEY ([UtilizadorId]) REFERENCES [Utilizadores] ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Moradas_UtilizadorId] ON [Moradas] ([UtilizadorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221104122029_Initial', N'6.0.10');
GO

COMMIT;
GO

