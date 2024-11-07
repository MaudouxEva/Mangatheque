-- Insertion des vendeurs
INSERT INTO [dbo].[Vendeur] ([Prenom], [Nom], [Email], [Password])
VALUES
    ('Sala','Mèche', 'sala.meche@example.com', 'salameche'),
    ('Bob', 'Razowski', 'bob.razowski@example.com', 'bobrazowski');
    

-- Insertion des clients
INSERT INTO [dbo].[Client] ([NumClient], [Prenom], [Nom], [Tel], [Email], [Password])
VALUES
    (1001, 'Charles', 'Durand', '0123456789', 'charles.durand@example.com', 'PasswordCharles'),
    (1002, 'Danielle', 'Lefèvre', '0987654321', 'danielle.lefevre@example.com', 'PasswordDanielle');
-- On suppose que les VendeurId générés sont 1 et 2

-- Insertion des collections de mangas
INSERT INTO [dbo].[Collection] ([Nom], [Description], [Auteur], [Illustration], [DateSortie], [Prix])
VALUES
    ('Jujutsu Kaisen', 'Un manga qui suit les aventures de Yuji Itadori dans un monde de malédictions.', 'Gege Akutami', 'test', '2018-07-04', 7.99),
    ('Demon Slayer', 'L''histoire de Tanjiro Kamado qui devient un tueur de démons pour sauver sa sœur.', 'Koyoharu Gotouge', 'test', '2016-02-15', 6.99),
    ('My Hero Academia', 'Dans un monde où presque tout le monde possède un super-pouvoir, Izuku Midoriya rêve de devenir un héros.', 'Kōhei Horikoshi', 'test', '2014-07-07', 7.99),
    ('Hunter x Hunter', 'Les aventures de Gon Freecss, un jeune garçon qui veut devenir Hunter comme son père.', 'Yoshihiro Togashi', 'test', '1998-03-16', 6.99),
    ('Berserk', 'Un manga sombre et mature qui suit le guerrier Guts dans un monde médiéval fantastique.', 'Kentaro Miura', 'test', '1990-11-26', 9.99);


-- insertion des volumes
    
-- Récupérer les collections générées dans des constantes
DECLARE @CollectionId_JK INT = (SELECT [CollectionId] FROM [dbo].[Collection] WHERE [Nom] = 'Jujutsu Kaisen');
DECLARE @CollectionId_DS INT = (SELECT [CollectionId] FROM [dbo].[Collection] WHERE [Nom] = 'Demon Slayer');
DECLARE @CollectionId_MHA INT = (SELECT [CollectionId] FROM [dbo].[Collection] WHERE [Nom] = 'My Hero Academia');
DECLARE @CollectionId_HxH INT = (SELECT [CollectionId] FROM [dbo].[Collection] WHERE [Nom] = 'Hunter x Hunter');
DECLARE @CollectionId_Berserk INT = (SELECT [CollectionId] FROM [dbo].[Collection] WHERE [Nom] = 'Berserk');

-- Insertion des volumes pour chaque collection
-- On suppose que le VendeurId 1 est associé aux collections insérées par ce vendeur

-- Volumes de Jujutsu Kaisen
INSERT INTO [dbo].[Volume] ([ISBN], [Nom], [CollectionId], [NumTome], [Resume], [Edition], [ImageCouverture], [DateSortie], [StockQuantite])
VALUES
    ('9782344028590', 'Ryomen Sukuna', @CollectionId_JK, 1, 'Introduction à l''univers de Jujutsu Kaisen.', 'Shūeisha', 'test', '2018-07-04', 30),
    ('9782344028606', 'Le secret de la malédiction', @CollectionId_JK, 2, 'Continuation des aventures de Yuji Itadori.', 'Shūeisha', 'test', '2018-09-04', 25),
    ('9782344028613', 'Métamorphose', @CollectionId_JK, 3, 'Nouvelles épreuves pour Yuji et ses amis.', 'Shūeisha', 'test', '2018-12-04', 20);

-- Volumes de Demon Slayer
INSERT INTO [dbo].[Volume] ([ISBN], [Nom], [CollectionId], [NumTome], [Resume], [Edition], [ImageCouverture], [DateSortie], [StockQuantite])
VALUES
    ('9782344032429', 'Cruauté', @CollectionId_DS, 1, 'Tanjiro commence son voyage pour sauver sa sœur.', 'Shūeisha', 'test', '2016-02-15', 40),
    ('9782344032436', 'Il faut rester en vie', @CollectionId_DS, 2, 'Tanjiro rencontre de nouveaux alliés.', 'Shūeisha', 'test', '2016-05-13', 35),
    ('9782344032443', 'Retour impossible', @CollectionId_DS, 3, 'Défis croissants pour Tanjiro et Nezuko.', 'Shūeisha', 'test', '2016-08-10', 30);

-- Volumes de My Hero Academia
INSERT INTO [dbo].[Volume] ([ISBN], [Nom], [CollectionId], [NumTome], [Resume], [Edition], [ImageCouverture], [DateSortie], [StockQuantite])
VALUES
    ('9784088802640', 'Izuku Midoriya : Les origines', @CollectionId_MHA, 1, 'Izuku rêve de devenir un héros malgré son absence de pouvoir.', 'Shūeisha', 'test', '2014-07-07', 50),
    ('9784088802930', 'Dechaine toi, maudit nerd', @CollectionId_MHA, 2, 'Izuku commence sa formation au lycée Yuei.', 'Shūeisha', 'test', '2014-10-06', 45),
    ('9784088803227', 'All Might', @CollectionId_MHA, 3, 'Izuku fait face à de nouveaux défis.', 'Shūeisha', 'test', '2015-01-05', 40);

-- Volumes de Hunter x Hunter
INSERT INTO [dbo].[Volume] ([ISBN], [Nom], [CollectionId], [NumTome], [Resume], [Edition], [ImageCouverture], [DateSortie], [StockQuantite])
VALUES
    ('9784088718064', 'Départ', @CollectionId_HxH, 1, 'Gon quitte son île pour devenir Hunter.', 'Shūeisha', 'test', '1998-06-04', 20),
    ('9784088725666', 'Examen Hunter', @CollectionId_HxH, 2, 'Gon participe à l''examen pour devenir Hunter.', 'Shūeisha', 'test', '1998-08-04', 18),
    ('9784088725673', 'Succession', @CollectionId_HxH, 3, 'Les épreuves continuent pour Gon et ses amis.', 'Shūeisha', 'test', '1998-10-02', 15);

-- Volumes de Berserk
INSERT INTO [dbo].[Volume] ([ISBN], [Nom], [CollectionId], [NumTome], [Resume], [Edition], [ImageCouverture], [DateSortie], [StockQuantite])
VALUES
    ('9784884193014', 'Le Chevalier Noir', @CollectionId_Berserk, 1, 'Présentation de Guts, le guerrier noir.', 'Hakusensha', 'test', '1990-11-26', 10),
    ('9784884193021', 'La Marque', @CollectionId_Berserk, 2, 'Guts continue sa quête de vengeance.', 'Hakusensha', 'test', '1991-04-26', 8),
    ('9784884193038', 'La Naissance', @CollectionId_Berserk, 3, 'Flashback sur le passé de Guts.', 'Hakusensha', 'test', '1991-09-26', 5);

-- Insertion des commandes
-- On suppose que les ClientId sont 1 et 2

-- Commande réalisée par le client 1
INSERT INTO [dbo].[Commande] ([ClientId], [DateCommande], [EstPaye], [TotalPrix])
VALUES
    (1, '2024-09-04', 1, 23.97); -- Achat de 3 volumes à 7.99€

-- Récupération de l'identifiant de la commande pour le client1
DECLARE @CommandeId_Client1 INT = SCOPE_IDENTITY(); 

-- Détails de la commande en question du client 1
INSERT INTO [dbo].[MM_Commande_Volume] ([CommandeId], [VolumeId], [Quantite], [Prix])
VALUES
    (@CommandeId_Client1, (SELECT [VolumeId] FROM [dbo].[Volume] WHERE [Nom] = 'Ryomen Sukuna'), 1, 7.99),
    (@CommandeId_Client1, (SELECT [VolumeId] FROM [dbo].[Volume] WHERE [Nom] = 'Cruauté'), 1, 7.99),
    (@CommandeId_Client1, (SELECT [VolumeId] FROM [dbo].[Volume] WHERE [Nom] = 'Izuku Midoriya : Les origines'), 1, 7.99);

-- Commande réalisée par le client 2
INSERT INTO [dbo].[Commande] ([ClientId], [DateCommande], [EstPaye], [TotalPrix])
VALUES
    (2, '2024-11-03',0, 9.99); -- Achat de 1 volume à 9.99€
-- 
DECLARE @CommandeId_Client2 INT = SCOPE_IDENTITY();

-- Détails de la commande du client 2
INSERT INTO [dbo].[MM_Commande_Volume] ([CommandeId], [VolumeId], [Quantite], [Prix])
VALUES
    (@CommandeId_Client2, (SELECT [VolumeId] FROM [dbo].[Volume] WHERE [Nom] = 'Le Chevalier Noir'), 1, 9.99);

-- Octroi de la carte de fidélité par le vendeur 1 au client 2
INSERT INTO [dbo].[Fidelisation] ([ClientId], [VendeurId], [DateOctroi])
VALUES
    (2, 1, GETDATE());