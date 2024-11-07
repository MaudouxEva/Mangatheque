CREATE TABLE [dbo].[Volume]
(
	[VolumeId]  INT IDENTITY,
	[ISBN] NVARCHAR(20) NOT NULL,
	[Nom] NVARCHAR(200) NOT NULL,
	[CollectionId] INT NOT NULL,
	[NumTome] INT NOT NULL,
	[Resume] NVARCHAR(500),
	[Edition] NVARCHAR(500) NOT NULL,
	[ImageCouverture] NVARCHAR(MAX),
	[DateSortie] DATETIME NOT NULL,
	[StockQuantite] INT NOT NULL,

	CONSTRAINT PK_Volume PRIMARY KEY ([VolumeId]),
	CONSTRAINT UK_Unique UNIQUE ([ISBN]),
    
	CONSTRAINT FK_Volume_Collection FOREIGN KEY ([CollectionId]) REFERENCES [dbo].[Collection]([CollectionId]),
    
	CONSTRAINT CK_Volume__NumTome CHECK([NumTome] >= 0),
    CONSTRAINT CK_Volume_StockQuantite CHECK([StockQuantite] >= 0),
    CONSTRAINT CK_Volume_DateSortie CHECK([DateSortie] <= GETDATE())
)
