CREATE VIEW [dbo].[V_Clients]
AS
SELECT
    [ClientId],
    [NumClient],
    [Prenom],
    [Nom],
    [Email],
    [ACarteFidelite]
FROM
    [dbo].[Client]
WHERE
    [Active] = 1;

