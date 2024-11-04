CREATE TABLE [dbo].[Commande]
(
    [CommandeId] INT IDENTITY,
    [ClientId] INT NOT NULL,
    [DateCommande] DATETIME NOT NULL DEFAULT GETDATE(),
    [EstPaye] BIT NOT NULL DEFAULT 0,
    [TotalPrix] DECIMAL(10,2) NOT NULL,

    CONSTRAINT PK_Commande PRIMARY KEY ([CommandeId]),
    CONSTRAINT FK_Commande_Client FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client]([ClientId])
)