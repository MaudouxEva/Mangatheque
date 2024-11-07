CREATE TABLE [dbo].[HistoriqueStock]
(
    [HistoriqueStockId] INT IDENTITY,
    [VolumeId] INT NOT NULL,
    [VendeurId] INT NOT NULL,
    [QuantiteChangee] INT NOT NULL,
    [DateModification] DATETIME NOT NULL DEFAULT GETDATE(),
    
    CONSTRAINT PK_HistoriqueStock PRIMARY KEY ([HistoriqueStockId]),
    CONSTRAINT FK_HistoriqueStock_Volume FOREIGN KEY ([VolumeId]) REFERENCES [dbo].[Volume]([VolumeId]),
    CONSTRAINT FK_HistoriqueStock_Vendeur FOREIGN KEY ([VendeurId]) REFERENCES [dbo].[Vendeur]([VendeurId]),
)