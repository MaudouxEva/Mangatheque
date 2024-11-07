--Pour identifier les volumes en rupture de stock

CREATE VIEW [dbo].[V_VolumesStockZero]
AS
SELECT
    v.[VolumeId],
    v.[Nom] AS [NomVolume],
    v.[NumTome],
    c.[Nom] AS [NomCollection],
    v.[StockQuantite],
    v.[DateSortie],
    v.[ISBN]
FROM
    [dbo].[Volume] v
        INNER JOIN
    [dbo].[Collection] c ON v.[CollectionId] = c.[CollectionId]
WHERE
    v.[StockQuantite] <= 0;
