﻿CREATE TABLE [dbo].[Vendeur]
(
	[VendeurId] INT IDENTITY,
	[Prenom] NVARCHAR(200) NOT NULL,
	[Nom] NVARCHAR(200) NOT NULL,
	[Email] NVARCHAR(200) NOT NULL,
	[Password] NVARCHAR(200),

	CONSTRAINT PK_Vendeur PRIMARY KEY ([VendeurId]),
	CONSTRAINT UK_Email UNIQUE ([Email]),
)
