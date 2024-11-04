﻿-- Table pour associer les volumes aux commandes avec les quantités et les prix

CREATE TABLE [dbo].[MM_Commande_Volume]
(
    [CommandeId] INT NOT NULL,
    [VolumeId] INT NOT NULL,
    [Quantity] INT NOT NULL,
    [Price] DECIMAL(10,2) NOT NULL,

    CONSTRAINT PK_MM_Commande_Volume PRIMARY KEY ([CommandeId], [VolumeId]),
    CONSTRAINT FK_Commande_Volume_Commande FOREIGN KEY ([CommandeId]) REFERENCES [dbo].[Commande]([CommandeId]),
    CONSTRAINT FK_Commande_Volume_Volume FOREIGN KEY ([VolumeId]) REFERENCES [dbo].[Volume]([VolumeId])
)