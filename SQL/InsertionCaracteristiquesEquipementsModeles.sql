
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Vie')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='B�ton rouill�')
,	2
>>>>>>> origin/master
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
<<<<<<< HEAD
(
	(SELECT idCaracteristique FROM Caracteristiques WHERE nom='Défense')
,	(SELECT idEquipementModele FROM EquipementsModeles WHERE nom='Bottes de cuir')
,	1
=======
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Vitesse')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='Marteau rouill�')
,	2
>>>>>>> origin/master
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
<<<<<<< HEAD
(
	(SELECT idCaracteristique FROM Caracteristiques WHERE nom='Vitesse')
,	(SELECT idEquipementModele FROM EquipementsModeles WHERE nom='Bottes de cuir')
,	1
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(
	(SELECT idCaracteristique FROM Caracteristiques WHERE nom='Énergie')
,	(SELECT idEquipementModele FROM EquipementsModeles WHERE nom='Souliers')
,	1
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(
	(SELECT idCaracteristique FROM Caracteristiques WHERE nom='Vitesse')
,	(SELECT idEquipementModele FROM EquipementsModeles WHERE nom='Souliers')
,	1
);
=======
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Force')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='Marteau rouill�')
,	3
);


>>>>>>> origin/master
