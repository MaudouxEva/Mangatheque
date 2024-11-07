-- Pour visualiser quels clients possèdent une carte de fidélité, la date d'obtention, et le vendeur qui l'a octroyée.
CREATE VIEW [dbo].[V_ClientsFidelite]
AS
SELECT
    cl.[ClientId],
    cl.[NumClient],
    cl.[Prenom],
    cl.[Nom] AS [NomClient],
    cl.[Tel],
    cl.[Email],
    cl.[ACarteFidelite],
    f.[DateOctroi] AS [DateObtentionCarte],
    vend.[Prenom] AS [PrenomVendeur],
    vend.[Nom] AS [NomVendeur]
FROM
    [dbo].[Client] cl
        LEFT JOIN
    [dbo].[Fidelisation] f ON cl.[ClientId] = f.[ClientId]
        LEFT JOIN
    [dbo].[Vendeur] vend ON f.[VendeurId] = vend.[VendeurId];

