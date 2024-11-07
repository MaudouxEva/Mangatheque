--  Pour analyser les performances des collections en termes de ventes et de revenus générés.

CREATE VIEW [dbo].[V_VentesParCollection]
AS
SELECT
    c.[CollectionId],
    c.[Nom] AS [NomCollection],
    SUM(mmcv.[Quantite]) AS [TotalVolumesVendus],
    SUM(mmcv.[Prix] * mmcv.[Quantite]) AS [TotalRevenu]
FROM
    [dbo].[MM_Commande_Volume] mmcv
        INNER JOIN
    [dbo].[Volume] v ON mmcv.[VolumeId] = v.[VolumeId]
        INNER JOIN
    [dbo].[Collection] c ON v.[CollectionId] = c.[CollectionId]
GROUP BY
    c.[CollectionId],
    c.[Nom];
