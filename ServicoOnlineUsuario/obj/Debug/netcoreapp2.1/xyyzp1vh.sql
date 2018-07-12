IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'db') IS NULL EXEC(N'CREATE SCHEMA [db];');

GO

CREATE TABLE [db].[Empresa] (
    [Id] uniqueidentifier NOT NULL DEFAULT 'dbacd673-76b6-4c7e-b1bf-5e952f284efd',
    [CnpjCpf] nvarchar(max) NULL,
    [Nome] nvarchar(100) NOT NULL,
    [NomeFantasia] nvarchar(200) NULL,
    [Email] nvarchar(100) NULL,
    [Status] nvarchar(2) NOT NULL DEFAULT N'AT',
    CONSTRAINT [PK_Empresa] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [db].[EmpresaUsuario] (
    [EmpresaId] uniqueidentifier NOT NULL,
    [EmpresaId1] uniqueidentifier NULL,
    [UsuarioId] nvarchar(450) NOT NULL,
    [Status] nvarchar(2) NOT NULL DEFAULT N'AT',
    [Key] nvarchar(100) NULL,
    CONSTRAINT [PK_EmpresaUsuario] PRIMARY KEY ([EmpresaId], [UsuarioId]),
    CONSTRAINT [FK_EmpresaUsuario_Empresa] FOREIGN KEY ([EmpresaId]) REFERENCES [db].[Empresa] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmpresaUsuario_Empresa_EmpresaId1] FOREIGN KEY ([EmpresaId1]) REFERENCES [db].[Empresa] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [EmpresaIdIndex] ON [db].[EmpresaUsuario] ([EmpresaId]);

GO

CREATE INDEX [IX_EmpresaUsuario_EmpresaId1] ON [db].[EmpresaUsuario] ([EmpresaId1]);

GO

CREATE UNIQUE INDEX [UsuarioIdIndex] ON [db].[EmpresaUsuario] ([UsuarioId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180712154702_InitialCreate', N'2.1.1-rtm-30846');

GO

