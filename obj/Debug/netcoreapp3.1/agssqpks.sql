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

CREATE TABLE [TipoPermiso] (
    [Id] int NOT NULL IDENTITY,
    [Descripcion] text NOT NULL,
    CONSTRAINT [PK_TipoPermiso] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Permiso] (
    [Id] int NOT NULL IDENTITY,
    [NombreEmpleado] text NOT NULL,
    [ApellidosEmpleado] text NOT NULL,
    [TipoPermiso] int NOT NULL,
    [FechaPermiso] datetime NOT NULL,
    CONSTRAINT [PK_Permiso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__Permiso__TipoPer__4BAC3F29] FOREIGN KEY ([TipoPermiso]) REFERENCES [TipoPermiso] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Permiso_TipoPermiso] ON [Permiso] ([TipoPermiso]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210924051821_Inicial', N'5.0.10');
GO

COMMIT;
GO

