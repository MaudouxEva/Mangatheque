-- Pour que les clients puissent consulter leur historique d'achats, et pour que les vendeurs puissent voir les achats des clients.

CREATE VIEW [dbo].[V_HistoriqueAchatsClients]
AS
SELECT
    cl.[ClientId],
    cl.[NumClient],
    cl.[Prenom],
    cl.[Nom] AS [NomClient],
    cl.[Email],
    cl.[ACarteFidelite],
    cmd.[CommandeId],
    cmd.[EstPaye],
    cmd.[TotalPrix],
    v.[VolumeId],
    v.[Nom] AS [NomVolume],
    v.[NumTome],
    c.[Nom] AS [NomCollection],
    mmcv.[Quantite],
    mmcv.[Prix]
FROM
    [dbo].[Client] cl
        INNER JOIN
    [dbo].[Commande] cmd ON cl.[ClientId] = cmd.[ClientId]
        INNER JOIN
    [dbo].[MM_Commande_Volume] mmcv ON cmd.[CommandeId] = mmcv.[CommandeId]
        INNER JOIN
    [dbo].[Volume] v ON mmcv.[VolumeId] = v.[VolumeId]
        INNER JOIN
    [dbo].[Collection] c ON v.[CollectionId] = c.[CollectionId];

