﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

CREATE TABLE [db].[Pagamento] (
    [Id] uniqueidentifier NOT NULL DEFAULT '3ec728a4-c7ae-4ac2-b2d9-c59d3223fc53',
    [Nome] nvarchar(50) NOT NULL,
    [Telefone] nvarchar(12) NULL,
    [Email] nvarchar(100) NULL,
    [FormaPagamento] nvarchar(3) NOT NULL DEFAULT N'DHR',
    [Descricao] nvarchar(1000) NULL,
    [Status] nvarchar(2) NULL DEFAULT N'AT',
    CONSTRAINT [PK_Pagamento] PRIMARY KEY ([Id])
);

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

CREATE TABLE [db].[PagamentoItem] (
    [Id] uniqueidentifier NOT NULL DEFAULT '6364b146-0dad-41d8-a34a-b5bcfcd08245',
    [PagamentoDominioId] uniqueidentifier NOT NULL,
    [Quantidade] int NOT NULL,
    [Status] nvarchar(2) NULL DEFAULT N'AT',
    [ServicoDominioId] int NULL,
    [ServicoId] int NOT NULL,
    CONSTRAINT [PK_PagamentoItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PagamentoItem_Pagamento_PagamentoDominioId] FOREIGN KEY ([PagamentoDominioId]) REFERENCES [db].[Pagamento] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PagamentoItem_Servico_ServicoDominioId] FOREIGN KEY ([ServicoDominioId]) REFERENCES [db].[Servico] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_PagamentoItem_PagamentoDominioId] ON [db].[PagamentoItem] ([PagamentoDominioId]);

GO

CREATE INDEX [IX_PagamentoItem_ServicoDominioId] ON [db].[PagamentoItem] ([ServicoDominioId]);

GO

CREATE INDEX [IX_Servico_tipoServicoDominioId] ON [db].[Servico] ([tipoServicoDominioId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180704130458_InitialCreate', N'2.1.1-rtm-30846');

GO

