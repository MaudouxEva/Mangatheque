CREATE TABLE [dbo].[Client]
(
	[ClientId] INT IDENTITY,
	[NumClient] INT NOT NULL,
	[Prenom] NVARCHAR(200) NOT NULL,
	[Nom] NVARCHAR(200) NOT NULL,
	[Tel] INT,
	[Email] NVARCHAR(200) NOT NULL,
	[Password] NVARCHAR(200),
    [ACarteFidelite] BIT NOT NULL DEFAULT 0,
	[Active] BIT NOT NULL DEFAULT 1,

	CONSTRAINT PK_Client PRIMARY KEY ([ClientId]),
	CONSTRAINT UK_NumClient UNIQUE ([NumClient]),
	CONSTRAINT UK_Client_Email UNIQUE ([Email]),
    CONSTRAINT CK_Client_Active CHECK ([Active] IN (0, 1))
)
