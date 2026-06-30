CREATE TABLE [dbo].[Utilisateur]
(
	[Id] BIGINT NOT NULL IDENTITY, 
	[Nom] NVARCHAR(50) NOT NULL, 
	[Prenom] NVARCHAR(50) NOT NULL, 
	[Email] NVARCHAR(50) NOT NULL, 
	[Passwd] BINARY(64) NOT NULL,
	[IsAdmin] BIT NOT NULL DEFAULT (0),
    CONSTRAINT [PK_Utilisateur] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_Utilisateur_Email] UNIQUE ([Email]),
	CONSTRAINT [CK_UTilisateur_Nom] CHECK (LEN(TRIM([Nom])) > 0),
	CONSTRAINT [CK_UTilisateur_Prenom] CHECK (LEN(TRIM([Prenom])) > 0),
)
