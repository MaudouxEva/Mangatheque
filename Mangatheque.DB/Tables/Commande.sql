CREATE TABLE [dbo].[Commande]
(
    [CommandeId] INT IDENTITY,
    [ClientId] INT NOT NULL,
    [DateCommande] DATETIME NOT NULL DEFAULT GETDATE(),
    [EstPaye] BIT NOT NULL DEFAULT 0,
    [TotalPrix] DECIMAL(10,2) NOT NULL,

    CONSTRAINT PK_Commande PRIMARY KEY ([CommandeId]),
    CONSTRAINT FK_Commande_Client FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client]([ClientId]),
    CONSTRAINT CK_Commande_TotalPrix CHECK ([TotalPrix] >= 0),
    CONSTRAINT CK_Commande_EstPaye CHECK ([EstPaye] IN (0, 1)),
    CONSTRAINT CK_Commande_DateCommande CHECK ([DateCommande] <= GETDATE())
)