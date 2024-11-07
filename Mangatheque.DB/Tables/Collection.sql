CREATE TABLE [dbo].[Collection]
(
	[CollectionId] INT IDENTITY,
	[Nom] NVARCHAR(200) NOT NULL,
	[Description] NVARCHAR(500),
	[Auteur] NVARCHAR(200) NOT NULL,
	[Illustration] NVARCHAR(MAX),
	[DateSortie] DATETIME NOT NULL,
	[Prix] DECIMAL(10,2) NOT NULL,

	CONSTRAINT PK_Collection PRIMARY KEY ([CollectionId]),
	CONSTRAINT UK_Nom UNIQUE ([Nom]),
    CONSTRAINT CK_Collection_Prix CHECK ([Prix] >= 0),
    CONSTRAINT CK_Collection_DateSortie CHECK ([DateSortie] <= GETDATE())
)
