-- Pour consulter le stock des volumes disponibles, pour la gestion des stockets.
CREATE VIEW [dbo].[V_VolumesStock]
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
    [dbo].[Collection] c ON v.[CollectionId] = c.[CollectionId];
