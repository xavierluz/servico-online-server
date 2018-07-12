﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [dbo].[Empresa] (
    [Id] uniqueidentifier NOT NULL DEFAULT '31cf3144-4c41-4cd0-b696-d74a8b66736f',
    [CnpjCpf] nvarchar(max) NULL,
    [Nome] nvarchar(100) NOT NULL,
    [NomeFantasia] nvarchar(200) NULL,
    [Email] nvarchar(100) NULL,
    [Status] nvarchar(2) NOT NULL DEFAULT N'AT',
    CONSTRAINT [PK_Empresa] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [dbo].[EmpresaUsuario] (
    [EmpresaId] uniqueidentifier NOT NULL,
    [UsuarioId] nvarchar(50) NOT NULL,
    [Status] nvarchar(2) NOT NULL DEFAULT N'AT',
    [Key] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_EmpresaUsuario] PRIMARY KEY ([EmpresaId], [UsuarioId]),
    CONSTRAINT [FK_EmpresaUsuario_Empresa] FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [EmpresaIdIndex] ON [dbo].[EmpresaUsuario] ([EmpresaId]);

GO

CREATE UNIQUE INDEX [UsuarioIdIndex] ON [dbo].[EmpresaUsuario] ([UsuarioId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180712160022_InitialCreate', N'2.1.1-rtm-30846');

GO

