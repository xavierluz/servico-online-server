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

CREATE TABLE [db].[TipoServico] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(50) NOT NULL,
    [Descricao] nvarchar(500) NULL,
    [caminhoDaImage] nvarchar(200) NULL,
    [Status] nvarchar(2) NULL DEFAULT N'AT',
    CONSTRAINT [PK_TipoServico] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [db].[Servico] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(50) NOT NULL,
    [Indicacao] nvarchar(150) NULL,
    [Descricao] nvarchar(1000) NULL,
    [Preco] decimal(18, 2) NOT NULL,
    [tipoServicoDominioId] int NOT NULL,
    [Status] nvarchar(2) NULL DEFAULT N'AT',
    CONSTRAINT [PK_Servico] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Servico_TipoServico_tipoServicoDominioId] FOREIGN KEY ([tipoServicoDominioId]) REFERENCES [db].[TipoServico] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Servico_tipoServicoDominioId] ON [db].[Servico] ([tipoServicoDominioId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180703121727_InitialCreate', N'2.1.1-rtm-30846');

GO

