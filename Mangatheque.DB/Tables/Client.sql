CREATE TABLE [dbo].[Client]
(
	[ClientId] INT IDENTITY,
	[NumClient] INT NOT NULL,
	[Prenom] NVARCHAR(200) NOT NULL,
	[Nom] NVARCHAR(200) NOT NULL,
	[Tel] INT,
	[Email] NVARCHAR(20) NOT NULL,
	[Password] VARBINARY(200),
	[Active] BIT NOT NULL DEFAULT 1,

	CONSTRAINT PK_Client PRIMARY KEY ([ClientId]),
	CONSTRAINT UK_NumClient UNIQUE ([NumClient]),
	CONSTRAINT UK_Client_Email UNIQUE ([Email])
)
