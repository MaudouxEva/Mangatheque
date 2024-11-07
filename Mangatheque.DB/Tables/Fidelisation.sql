CREATE TABLE [dbo].[Fidelisation]
(
    [FidelisationId] INT IDENTITY,
    [ClientId] INT NOT NULL,
    [VendeurId] INT NOT NULL,
    [DateOctroi] DATETIME NOT NULL DEFAULT GETDATE(),
    
    CONSTRAINT PK_Fidelisation PRIMARY KEY ([FidelisationId]),
    CONSTRAINT FK_Fidelisation_Client FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client]([ClientId]),
    CONSTRAINT FK_Fidelisation_Vendeur FOREIGN KEY ([VendeurId]) REFERENCES [dbo].[Vendeur]([VendeurId]),
    CONSTRAINT CK_Fidelisation_DateOctroi CHECK ([DateOctroi] <= GETDATE())
)
                                                        