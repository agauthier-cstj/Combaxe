INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Force')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='�p�e de pratique')
,	2
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='D�fense')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='�p�e de pratique')
,	1
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='�nergie')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='B�ton de pratique')
,	2
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Vie')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='B�ton de pratique')
,	1
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Force')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='Marteau de pratique')
,	1
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Vitesse')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='Marteau de pratique')
,	1
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Vie')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='Bouclier de pratique')
,	1
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='D�fense')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='Bouclier de pratique')
,	1
);


 /* FIN PRATIQUE */
 
INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Force')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='�p�e rouill�e')
,	6
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='D�fense')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='�p�e rouill�e')
,	2
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='�nergie')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='B�ton rouill�')
,	6
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Vie')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='B�ton rouill�')
,	2
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Vitesse')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='Marteau rouill�')
,	2
);

INSERT INTO CaracteristiquesEquipementsModeles
(idCaracteristique, idEquipementModele, valeur)
VALUES
(	
	(SELECT idCaracteristique FROM  Caracteristiques WHERE nom='Force')
,	(SELECT idEquipementModele FROM EquipementModeles WHERE nom='Marteau rouill�')
,	3
);


