INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(		(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Force')
	,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='�p�e de pratique')
	,	7.07
	,	2
	,	4
	);