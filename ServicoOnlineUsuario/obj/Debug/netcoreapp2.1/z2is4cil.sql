IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(50) NOT NULL,
    [Nome] nvarchar(256) NULL,
    [NomeNormalizado] nvarchar(256) NULL,
    [TempoConcorrencia] nvarchar(max) NULL,
    CONSTRAINT [PK_Funcao] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(50) NOT NULL,
    [Nome] nvarchar(256) NULL,
    [NomeNormalizado] nvarchar(256) NOT NULL,
    [Email] nvarchar(256) NULL,
    [EmailNormalizado] nvarchar(256) NOT NULL,
    [EmailConfirmado] bit NOT NULL,
    [Senha] nvarchar(256) NULL,
    [CodigoSeguranca] nvarchar(256) NULL,
    [TempoConcorrencia] nvarchar(256) NULL,
    [Telefone] nvarchar(20) NULL,
    [TelefoneCofirmado] bit NOT NULL,
    [MultiploAcessoHabilitado] bit NOT NULL,
    [BloqueioFinalizado] datetimeoffset NULL,
    [BloqueioAtivo] bit NOT NULL,
    [ContagemAcessoFalho] int NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RequisicaoFuncaoId] nvarchar(50) NOT NULL,
    [TipoRequisicao] nvarchar(256) NULL,
    [ValorRequisicao] nvarchar(256) NULL,
    CONSTRAINT [PK_FuncaoRequisicao] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FuncaoRequisicao_Funcao] FOREIGN KEY ([RequisicaoFuncaoId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UsuarioId] nvarchar(50) NOT NULL,
    [TipoRequisicao] nvarchar(256) NULL,
    [ValorRequisicao] nvarchar(256) NULL,
    CONSTRAINT [PK_UsuarioRequisicaoId] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UsuarioRequisicao_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [dbo].[AspNetUserLogins] (
    [ProvedorLogin] nvarchar(256) NOT NULL,
    [ChaveProvedor] nvarchar(256) NOT NULL,
    [NomeProvedor] nvarchar(256) NULL,
    [UsuarioId] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_UsuarioLogin] PRIMARY KEY ([ProvedorLogin], [ChaveProvedor]),
    CONSTRAINT [FK_UsuarioLogin_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UsuarioId] nvarchar(256) NOT NULL,
    [FuncaoId] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_UsuarioFuncao] PRIMARY KEY ([UsuarioId], [FuncaoId]),
    CONSTRAINT [FK_UsuarioFuncao_Funcao] FOREIGN KEY ([FuncaoId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UsuarioFuncao_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [dbo].[AspNetUserTokens] (
    [UsuarioId] nvarchar(50) NOT NULL,
    [ProvedorLogin] nvarchar(256) NOT NULL,
    [Nome] nvarchar(256) NOT NULL,
    [Valor] nvarchar(256) NULL,
    CONSTRAINT [PK_UsuarioToken] PRIMARY KEY ([UsuarioId], [ProvedorLogin], [Nome]),
    CONSTRAINT [FK_UsuarioToken_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [FuncaoRequisicaoFuncaoIndex] ON [dbo].[AspNetRoleClaims] ([RequisicaoFuncaoId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[AspNetRoles] ([NomeNormalizado]) WHERE [NomeNormalizado] IS NOT NULL;

GO

CREATE INDEX [UsuarioIdIndex] ON [dbo].[AspNetUserClaims] ([UsuarioId]);

GO

CREATE INDEX [UsuarioIdIndex] ON [dbo].[AspNetUserLogins] ([UsuarioId]);

GO

CREATE INDEX [FuncaoIdIndex] ON [dbo].[AspNetUserRoles] ([FuncaoId]);

GO

CREATE INDEX [EmailIndex] ON [dbo].[AspNetUsers] ([EmailNormalizado]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[AspNetUsers] ([NomeNormalizado]) WHERE [NomeNormalizado] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180711182504_InitialCreate', N'2.1.1-rtm-30846');

GO

