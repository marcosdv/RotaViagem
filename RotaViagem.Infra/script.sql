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
CREATE TABLE [TbRota] (
    [RotId] uniqueidentifier NOT NULL,
    [RotOrigem] nvarchar(50) NOT NULL,
    [RotDestino] nvarchar(50) NOT NULL,
    [RotPreco] float NOT NULL,
    CONSTRAINT [PK_TbRota] PRIMARY KEY ([RotId])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250722000547_CriacaoInicial', N'9.0.7');

COMMIT;
GO

