﻿using Combaxe___New.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Combaxe___New.classes.services;

namespace Combaxe___New.écrans
{
    /// <summary>
    /// Interaction logic for EcranInventaireMagasin.xaml
    /// </summary>
    public partial class EcranInventaireMagasin : Window
    {
        PersonnageService personnageService = new PersonnageService();
        InventaireService inventaireService = new InventaireService();
        EquipementService equipementService = new EquipementService();
        ConsommationService consomationService = new ConsommationService();

        private const int MAXEQUIPEMENTPORTE = 8;
        private const int MAXEQUIPEMENTINVENTAIRE = 16;
        private const int MARGIN = 2;
        private const int RANGEEMAGASIN = 2;
        private const int COLONNEMAGASIN = 3;

        private Image dragImage;
        private Point startDragPoint;
        private List<Equipement> equipementInventaire = null;
        private List<Equipement> equipementUtilise = VarGlobales.Personnage.Inventaire.listeEquipementUtilise;
        private List<Equipement> equipementMagasin = new List<Equipement>();
        private List<Caracteristique> lstCaracteristiqueEquipement = VarGlobales.lstCaracteristiqueEquipement;

        public EcranInventaireMagasin()
        {
            InitializeComponent();
            chargerPersonnage();
            chargerEquipementInventaire();
            chargerEquipementPorte();
            genererMagasin();
        }

        private void btnRetour_Click_1(object sender, RoutedEventArgs e)
        {
            personnageService.MAJEquipementPersonnage(equipementUtilise);
            inventaireService.MAJEquipementInventaire(equipementInventaire);
            inventaireService.MAJArgent();
            consomationService.MAJConsommation();
            var MenuPrincipal = new EcranMenuPrincipal();
            MenuPrincipal.Show();
            this.Close();
        }

        /// <summary>
        /// Fonciton qui charge le personnage (Son inventaire, les équipements portés et ses caractéristiques
        /// </summary>
        private void chargerPersonnage()
        {
            majCaracteristiques();
            txtbArgent.Text = VarGlobales.Personnage.Inventaire.argent.ToString()+"$";
            txtbNiveau.Text = VarGlobales.Personnage.Niveau.ToString();
            txtbProfession.Text = VarGlobales.Personnage.profession.Nom.ToString();
        }

        /// <summary>
        /// Fonction qui va inscrire dans les champs de caractéristique les valeurs
        /// </summary>
        private void majCaracteristiques()
        {
            txtbForce.Text = (VarGlobales.Personnage.ListeCaracteristique[(int)Caracteristiques.Force].Valeur + lstCaracteristiqueEquipement[(int)Caracteristiques.Force].Valeur).ToString();
            txtbEnergie.Text = (VarGlobales.Personnage.ListeCaracteristique[(int)Caracteristiques.Energie].Valeur + lstCaracteristiqueEquipement[(int)Caracteristiques.Energie].Valeur).ToString();
            txtbVie.Text = (VarGlobales.Personnage.ListeCaracteristique[(int)Caracteristiques.Vie].Valeur + lstCaracteristiqueEquipement[(int)Caracteristiques.Vie].Valeur).ToString();
            txtbVitesse.Text = (VarGlobales.Personnage.ListeCaracteristique[(int)Caracteristiques.Vitesse].Valeur + lstCaracteristiqueEquipement[(int)Caracteristiques.Vitesse].Valeur).ToString();
            txtbDefense.Text = (VarGlobales.Personnage.ListeCaracteristique[(int)Caracteristiques.Defense].Valeur + lstCaracteristiqueEquipement[(int)Caracteristiques.Defense].Valeur).ToString();
            txtViePerso.Content = "Points de vie (PV): " + VarGlobales.Personnage.Vie.ToString() + "/" + VarGlobales.Personnage.VieMaximale.ToString();
            txtEnergiePerso.Content = "Points d'énergie (PE): " + VarGlobales.Personnage.Energie.ToString() + "/" + VarGlobales.Personnage.EnergieMaximale.ToString();
        }

        /// <summary>
        /// Fonction qui charge les équipements qui sont portés par le personnage
        /// </summary>
        private void chargerEquipementPorte()
        {
            Image equipement = new Image(); ;
            GridEquiper.Children.Clear();
            borderEquipementPorte();
            for (int i = 1; i <= MAXEQUIPEMENTPORTE; i++)
            {
                switch(i)
                {
                    case (int)Modele.Modeles.ArmeUneMain:
                        //(Image equipement, int idModele, int colonne, int rangée, string span)
                        attribueImage(equipement, i, 0, 1, "row");
                        break;
                    case (int)Modele.Modeles.Bottes:
                        //(Image equipement, int idModele, int colonne, int rangée, string span)
                        attribueImage(equipement, i, 2, 2, "");
                        break;
                    case (int)Modele.Modeles.Bouclier:
                        //(Image equipement, int idModele, int colonne, int rangée, string span)
                        attribueImage(equipement, i, 3, 1, "row");
                        break;
                    case (int)Modele.Modeles.Casque:
                        //(Image equipement, int idModele, int colonne, int rangée, string span)
                        attribueImage(equipement, i, 1, 0, "column");
                        break;
                    case (int)Modele.Modeles.Épaulette:
                        //(Image equipement, int idModele, int colonne, int rangée, string span)
                        attribueImage(equipement, i, 0, 0, "");
                        break;
                    case (int)Modele.Modeles.Pantalon:
                        //(Image equipement, int idModele, int colonne, int rangée, string span)
                        attribueImage(equipement, i, 1, 2, "");
                        break;
                    case (int)Modele.Modeles.Plastron:
                        //(Image equipement, int idModele, int colonne, int rangée, string span)
                        attribueImage(equipement, i, 1, 1, "column");
                        break;
                }
            }
        }

        /// <summary>
        /// Charge les equipements dans l'inventaire du personnage
        /// </summary>
        private void chargerEquipementInventaire()
        {
            Border border;
            Image equipement;
            if (equipementInventaire == null)
            {
                equipementInventaire = new List<Equipement>();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        border = new Border();
                        border.BorderThickness = new Thickness(1);
                        border.CornerRadius = new CornerRadius(5);
                        border.BorderBrush = Brushes.White;
                        border.Name = "border" + (i + j);
                        Grid.SetColumn(border, j);
                        Grid.SetRow(border, i);

                        if (((i * 4) + j) < VarGlobales.Personnage.Inventaire.listeEquipement.Count())
                        {
                            equipement = new Image();
                            equipement.Name = "e" + VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].IdEquipement.ToString();
                            equipement.ToolTip = "Nom: " + VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].Nom
                            + "\n Dégat: " + VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].DegatMin + " - " + VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].DegatMax;
                            for (int k = 0; k < VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].lstCaracteristique.Count(); k++)
                            {
                                if (VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].lstCaracteristique[k].Valeur != 0)
                                {
                                    equipement.ToolTip += "\n" + VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].lstCaracteristique[k].Nom + ": " + VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].lstCaracteristique[k].Valeur;
                                }
                            }
                            equipement.ToolTip += "\n Prix: " + Math.Round(VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].Prix / 1.131416, 2) + "$";
                            equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].ImageUrl, UriKind.RelativeOrAbsolute));
                            equipement.Tag = VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].IdEquipement;
                            equipement.PreviewMouseMove += equipement_PreviewMouseMove;
                            equipement.DragEnter += equipement_DragEnter;
                            equipement.PreviewMouseLeftButtonDown += equipement_PreviewMouseLeftButtonDown;
                            equipement.Drop += equipement_Drop;
                            Grid.SetColumn(equipement, j);
                            Grid.SetRow(equipement, i);
                            GridInventaire.Children.Add(equipement);
                            equipementInventaire.Add(VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j]);
                        }

                        GridInventaire.Children.Add(border);
                    }
                }
            }
            else
            {
                GridInventaire.Children.Clear();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        border = new Border();
                        border.BorderThickness = new Thickness(1);
                        border.CornerRadius = new CornerRadius(5);
                        border.BorderBrush = Brushes.White;
                        border.Name = "border" + (i + j);
                        Grid.SetColumn(border, j);
                        Grid.SetRow(border, i);
                        GridInventaire.Children.Add(border);

                        if (((i * 4) + j) < equipementInventaire.Count())
                        {
                            equipement = new Image();
                            equipement.Name = "e" + equipementInventaire[(i * 4) + j].IdEquipement.ToString();
                            equipement.ToolTip = "Nom: " + equipementInventaire[(i * 4) + j].Nom
                            + "\n Dégat: " + equipementInventaire[(i * 4) + j].DegatMin + " - " + equipementInventaire[(i * 4) + j].DegatMax;
                            for (int k = 0; k < VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].lstCaracteristique.Count(); k++)
                            {
                                if (VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].lstCaracteristique[k].Valeur != 0)
                                {
                                    equipement.ToolTip += "\n" + VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].lstCaracteristique[k].Nom + ": " + VarGlobales.Personnage.Inventaire.listeEquipement[(i * 4) + j].lstCaracteristique[k].Valeur;
                                }
                            }
                            equipement.ToolTip += "\n Prix: " + Math.Round(equipementInventaire[(i * 4) + j].Prix / 1.131416, 2) + "$\n";
                            equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + equipementInventaire[(i * 4) + j].ImageUrl, UriKind.RelativeOrAbsolute));
                            equipement.Tag = equipementInventaire[(i * 4) + j].IdEquipement;
                            equipement.PreviewMouseMove += equipement_PreviewMouseMove;
                            equipement.DragEnter += equipement_DragEnter;
                            equipement.PreviewMouseLeftButtonDown += equipement_PreviewMouseLeftButtonDown;
                            equipement.Drop += equipement_Drop;
                            Grid.SetColumn(equipement, j);
                            Grid.SetRow(equipement, i);
                            GridInventaire.Children.Add(equipement);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Verifie si l'équipement fait partie de l'inventaire
        /// </summary>
        /// <param name="idEquipement">Le id de l'équipement qui est recherché</param>
        /// <returns>Retourne true si l'équipement est dans l'inventaire</returns>
        private bool estDansInventaire(int idEquipement)
        {
            bool estDansInventaire = false;

            for (int i = 0; i < equipementInventaire.Count(); i++)
            {
                if(equipementInventaire[i].IdEquipement == idEquipement)
                {
                    estDansInventaire = true;
                    break;
                }
            }

            return estDansInventaire;
        }

        /// <summary>
        /// Ajoute l'équipement inventaire dans la liste d'équipement porté et le supprime de la liste d'équipement inventaire
        /// Ajoute l'équipement porté dans la liste d'équipement inventaire et le supprime de la liste d'équipement porté
        /// </summary>
        /// <param name="idEquipementInventaire">Le id de l'équipement qui était dans l'inventaire</param>
        private void equiperEquipement(int idEquipementInventaire)
        {
            Equipement unEquipementPorte = new Equipement();
            Equipement unEquipementInventaire = new Equipement();
            int positionInventaire = 0;

            //trouve et va chercher les informations de l'équipement de l'inventaire
            for (int i = 0; i < equipementInventaire.Count; i++)
            {
                if(equipementInventaire[i].IdEquipement==idEquipementInventaire)
                {
                    unEquipementInventaire = equipementInventaire[i];
                    positionInventaire = i;
                    
                    break;
                }
            }

            if(equipementUtilise.Count !=0)
            {
                //trouve et va chercher les informations de l'équipement porté
                for (int i = 0; i < equipementUtilise.Count; i++)
                {
                    if (equipementUtilise[i].Modele.IdModele == unEquipementInventaire.Modele.IdModele
                        || (equipementUtilise[i].Modele.IdModele == (int)Modele.Modeles.ArmeDeuxMains && (int)Modele.Modeles.ArmeUneMain == unEquipementInventaire.Modele.IdModele)
                        || (equipementUtilise[i].Modele.IdModele == (int)Modele.Modeles.ArmeDeuxMains && (int)Modele.Modeles.Bouclier == unEquipementInventaire.Modele.IdModele))
                    {
                        unEquipementPorte = equipementUtilise[i];
                        //Supprime l'équipement de la liste d'équipement porté
                        equipementUtilise.RemoveAt(i);
                        equipementUtilise.Add(unEquipementInventaire);
                        //Supprime l'équipement de la liste d'équipement de l'inventaire
                        equipementInventaire.RemoveAt(positionInventaire);
                        //On ajoute unEquipementPorte dans la liste d'equipementInventaire
                        equipementInventaire.Add(unEquipementPorte);

                        for (int j = 0; j < unEquipementInventaire.lstCaracteristique.Count(); j++)
                        {
                            lstCaracteristiqueEquipement[j].Valeur = lstCaracteristiqueEquipement[j].Valeur - unEquipementPorte.lstCaracteristique[j].Valeur;
                            lstCaracteristiqueEquipement[j].Valeur = lstCaracteristiqueEquipement[j].Valeur + unEquipementInventaire.lstCaracteristique[j].Valeur;
                        }
                        break;
                    }
                    else if((equipementUtilise[i].Modele.IdModele == (int)Modele.Modeles.ArmeUneMain && (int)Modele.Modeles.ArmeDeuxMains == unEquipementInventaire.Modele.IdModele)
                        || (equipementUtilise[i].Modele.IdModele == (int)Modele.Modeles.Bouclier && (int)Modele.Modeles.ArmeDeuxMains == unEquipementInventaire.Modele.IdModele))
                    {
                        Equipement deuxiemeEquipementPorte = new Equipement();
                        int position = 0;
                        for (int j = 0; j < equipementUtilise.Count; j++)
                        {
                            if((equipementUtilise[i].Modele.IdModele == (int)Modele.Modeles.ArmeUneMain && equipementUtilise[j].Modele.IdModele == (int)Modele.Modeles.Bouclier && (int)Modele.Modeles.ArmeDeuxMains == unEquipementInventaire.Modele.IdModele)
                                || (equipementUtilise[i].Modele.IdModele == (int)Modele.Modeles.Bouclier && equipementUtilise[j].Modele.IdModele == (int)Modele.Modeles.ArmeUneMain && (int)Modele.Modeles.ArmeDeuxMains == unEquipementInventaire.Modele.IdModele))
                            {
                                deuxiemeEquipementPorte = equipementUtilise[j];
                                position = j;
                                break;
                            }
                        }
                        if (deuxiemeEquipementPorte.Nom != "")
                        {
                            if (equipementInventaire.Count == MAXEQUIPEMENTINVENTAIRE)
                            {
                                if (MessageBox.Show("Votre inventaire est plein, veuillez libérer une case de votre inventaire", "Inventaire plein", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                unEquipementPorte = equipementUtilise[i];
                                //Supprime l'équipement de la liste d'équipement de l'inventaire
                                equipementInventaire.RemoveAt(positionInventaire);
                                //Supprime l'équipement de la liste d'équipement porté
                                if (i < position)
                                {
                                    equipementUtilise.RemoveAt(i);
                                    equipementUtilise.RemoveAt(position - 1);
                                }
                                else
                                {
                                    equipementUtilise.RemoveAt(position);
                                    equipementUtilise.RemoveAt(i - 1);
                                }
                                equipementUtilise.Add(unEquipementInventaire);
                                //On ajoute unEquipementPorte dans la liste d'equipementInventaire
                                equipementInventaire.Add(unEquipementPorte);
                                equipementInventaire.Add(deuxiemeEquipementPorte);

                                for (int j = 0; j < unEquipementInventaire.lstCaracteristique.Count(); j++)
                                {
                                    lstCaracteristiqueEquipement[j].Valeur = lstCaracteristiqueEquipement[j].Valeur - unEquipementPorte.lstCaracteristique[j].Valeur;
                                    lstCaracteristiqueEquipement[j].Valeur = lstCaracteristiqueEquipement[j].Valeur - deuxiemeEquipementPorte.lstCaracteristique[j].Valeur;
                                    lstCaracteristiqueEquipement[j].Valeur = lstCaracteristiqueEquipement[j].Valeur + unEquipementInventaire.lstCaracteristique[j].Valeur;
                                }
                                break;
                            }
                        }
                        else
                        {
                            unEquipementPorte = equipementUtilise[i];
                            //Supprime l'équipement de la liste d'équipement porté
                            equipementUtilise.RemoveAt(i);
                            equipementUtilise.Add(unEquipementInventaire);
                            //Supprime l'équipement de la liste d'équipement de l'inventaire
                            equipementInventaire.RemoveAt(positionInventaire);
                            //On ajoute unEquipementPorte dans la liste d'equipementInventaire
                            equipementInventaire.Add(unEquipementPorte);

                            for (int j = 0; j < unEquipementInventaire.lstCaracteristique.Count(); j++)
                            {
                                lstCaracteristiqueEquipement[j].Valeur = lstCaracteristiqueEquipement[j].Valeur - unEquipementPorte.lstCaracteristique[j].Valeur;
                                lstCaracteristiqueEquipement[j].Valeur = lstCaracteristiqueEquipement[j].Valeur + unEquipementInventaire.lstCaracteristique[j].Valeur;
                            }
                            break;
                        }
                    }
                    else if(i == equipementUtilise.Count-1)
                    {
                        equipementUtilise.Add(unEquipementInventaire);
                        //Supprime l'équipement de la liste d'équipement de l'inventaire
                        equipementInventaire.RemoveAt(positionInventaire);

                        for (int j = 0; j < unEquipementInventaire.lstCaracteristique.Count(); j++)
                        {
                            lstCaracteristiqueEquipement[j].Valeur = lstCaracteristiqueEquipement[j].Valeur + unEquipementInventaire.lstCaracteristique[j].Valeur;
                        }
                        break;
                    }
                }
            }
            else
            {
                equipementUtilise.Add(unEquipementInventaire);
                //Supprime l'équipement de la liste d'équipement de l'inventaire
                equipementInventaire.RemoveAt(positionInventaire);

                for (int j = 0; j < unEquipementInventaire.lstCaracteristique.Count(); j++)
                {
                    lstCaracteristiqueEquipement[j].Valeur = lstCaracteristiqueEquipement[j].Valeur + unEquipementInventaire.lstCaracteristique[j].Valeur;
                }
            }

            chargerEquipementPorte();
            VarGlobales.lstCaracteristiqueEquipement = lstCaracteristiqueEquipement;
            VarGlobales.Personnage.VieMaximale = Convert.ToInt32(((VarGlobales.Personnage.ListeCaracteristique[(int)Caracteristiques.Vie].Valeur + lstCaracteristiqueEquipement[(int)Caracteristiques.Vie].Valeur) * 20) / 3.1416);
            VarGlobales.Personnage.EnergieMaximale = Convert.ToInt32(((VarGlobales.Personnage.ListeCaracteristique[(int)Caracteristiques.Energie].Valeur + lstCaracteristiqueEquipement[(int)Caracteristiques.Energie].Valeur) * 10) / 3.1416);
            MajBarreEnergiePerso((int)(brdMaxWidth.ActualWidth));
            MajBarreViePerso((int)(brdMaxWidth.ActualWidth));
        }

        void equipement_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point position = e.GetPosition(null);

                if (Math.Abs(position.X - startDragPoint.X) >
                        SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(position.Y - startDragPoint.Y) >
                        SystemParameters.MinimumVerticalDragDistance)
                {
                    if (dragImage!=null)
                    {
                        if (dragImage.Name != "")
                        {
                            DataObject data = new DataObject(typeof(ImageSource), dragImage.Source);
                            DragDrop.DoDragDrop(dragImage, data, DragDropEffects.Move);
                        }
                    }
                }
            }
        }

        void equipement_Drop(object sender, DragEventArgs e)
        {
            Image dropImage = e.Source as Image;

            //Si l'image qui se situe à l'endroit où l'on veut se déplacer ne porte pas de nom, ça signifie que
            //L'équipement qui est draguer veut être équipé et qu'il n'y a pas déjà un équipement de se modèle qui est porté.
            if (dropImage.Name != "")
            {
                //Si le nom de l'image sur laquel on dropper l'équipement est "Vendre", ça signifie que l'équipement veut être vendu
                if (dropImage.Name == "Vendre")
                {
                    vendreEquipement((int)dragImage.Tag);
                }
                else
                {
                    if (!estDansInventaire((int)dropImage.Tag))
                    {
                        equiperEquipement((int)dragImage.Tag);
                    }
                }
            }
            else
            {
                equiperEquipement((int)dragImage.Tag);
            }
            chargerEquipementInventaire();
            majCaracteristiques();
            VarGlobales.Personnage.Inventaire.listeEquipement = equipementInventaire;
            VarGlobales.Personnage.Inventaire.listeEquipementUtilise = equipementUtilise;
        }

        void equipement_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dragImage = e.Source as Image;
            startDragPoint = e.GetPosition(null);
        }

        void equipement_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataObject)))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Créer les borders du grid équipement utilisé
        /// </summary>
        private void borderEquipementPorte()
        {
            Border border=new Border();
            border.CornerRadius = new CornerRadius(5);
            border.BorderBrush = Brushes.White;
            border.BorderThickness = new Thickness(1);

            //ÉPAULE
            //(Border border, int colonne, int rangée, string span)
            borderEquipementUtilise(border, 0, 0, "");

            //TÊTE
            //(Border border, int colonne, int rangée, string span)
            borderEquipementUtilise(border, 1, 0, "column");

            //ARME 1
            //(Border border, int colonne, int rangée, string span)
            borderEquipementUtilise(border, 0, 1, "row");

            //TORSE
            //(Border border, int colonne, int rangée, string span)
            borderEquipementUtilise(border, 1, 1, "column");

            //Bouclier
            //(Border border, int colonne, int rangée, string span)
            borderEquipementUtilise(border, 3, 1, "row");

            //JAMBE
            //(Border border, int colonne, int rangée, string span)
            borderEquipementUtilise(border, 1, 3, "");

            //PIED
            //(Border border, int colonne, int rangée, string span)
            borderEquipementUtilise(border, 2, 2, "");
        }

        /// <summary>
        /// Fonction qui créer le border de l'équipement équipé et l'insère dans le gridÉquiper
        /// </summary>
        /// <param name="border">Le border</param>
        /// <param name="column">Sa colonne du grid</param>
        /// <param name="row">La rangée du grid</param>
        /// <param name="span">String qui dit si le span est avec la row ou avec le column</param>
        private void borderEquipementUtilise(Border border, int column, int row, string span)
        {
            Thickness margin;
            border = new Border();
            border.BorderThickness = new Thickness(1);
            border.CornerRadius = new CornerRadius(5);
            border.BorderBrush = Brushes.White;
            margin = border.Margin;
            margin.Left = MARGIN;
            margin.Bottom = MARGIN;
            margin.Right = MARGIN;
            margin.Top = MARGIN;
            border.Margin = margin;
            //Détermine dans quel colonne du grid et rangée du grid se trouvera le border
            Grid.SetColumn(border, column);
            Grid.SetRow(border, row);
            //Si le border nécessite un rowspan ou un columnspan
            if (span == "row")
            {
                Grid.SetRowSpan(border, 2);
            }
            else if (span == "column")
            {
                Grid.SetColumnSpan(border, 2);
            }

            //On ajoute le border dans le grid
            GridEquiper.Children.Add(border);
        }

        /// <summary>
        /// Insère une image dans le grid des équipements portés par le personnage
        /// </summary>
        /// <param name="equipement">L'image où les attributs doivent être ajoutés</param>
        /// <param name="idModele">Le idModele où l'équipement doit être ajouté</param>
        /// <param name="column">La colonne du grid</param>
        /// <param name="row">La rangée du grid</param>
        /// <param name="span">S'il y a un rowspan ou un columnspan</param>
        private void attribueImage(Image equipement, int idModele, int column, int row, string span)
        {
            if (equipementUtilise.Count != 0)
            {
                Equipement leEquipement = null;

                for (int i = 0; i < equipementUtilise.Count; i++)
                {
                    if(idModele == equipementUtilise[i].Modele.IdModele || (idModele == (int)Modele.Modeles.ArmeUneMain && (int)Modele.Modeles.ArmeDeuxMains == equipementUtilise[i].Modele.IdModele))
                    {
                        leEquipement = equipementUtilise[i];
                    }
                }
                if (leEquipement != null)
                {
                    equipement = new Image();
                    equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + leEquipement.ImageUrl, UriKind.RelativeOrAbsolute));
                    equipement.Tag = leEquipement.IdEquipement;
                    equipement.AllowDrop = true;
                    equipement.Drop += equipement_Drop;
                    Grid.SetColumn(equipement, column);
                    Grid.SetRow(equipement, row);
                    equipement.ToolTip = "Nom: " + leEquipement.Nom;

                    if (leEquipement.Modele.IdModele == (int)Modele.Modeles.ArmeDeuxMains || leEquipement.Modele.IdModele == (int)Modele.Modeles.ArmeUneMain)
                    {
                            equipement.ToolTip += "\n Dégat: " + leEquipement.DegatMin + " - " + leEquipement.DegatMax;
                    }

                    for (int i = 0; i < leEquipement.lstCaracteristique.Count(); i++)
                    {
                        if(leEquipement.lstCaracteristique[i].Valeur != 0)
                        {
                            equipement.ToolTip += "\n" + leEquipement.lstCaracteristique[i].Nom + ": " + leEquipement.lstCaracteristique[i].Valeur;
                        }
                    }

                    if (span == "row")
                    {
                        Grid.SetRowSpan(equipement, 2);
                        equipement.VerticalAlignment = VerticalAlignment.Center;
                    }
                    else if (span == "column")
                    {
                        Grid.SetColumnSpan(equipement, 2);
                        equipement.HorizontalAlignment = HorizontalAlignment.Center;
                    }
                    GridEquiper.Children.Add(equipement);
                }
                else
                {
                    imageBase(idModele, column, row, span);
                }
            }
            else
            {
                imageBase(idModele, column, row, span);
            }
        }

        /// <summary>
        /// Fonction qui insère les images de base dans le grid si celui-ci ne possède pas d'équipement
        /// </summary>
        /// <param name="idModele">Le idModele servira à savoir quel image mettre</param>
        /// <param name="column">La colonne où se trouve la case du grid</param>
        /// <param name="row">La rangée où se trouve la case du grid</param>
        /// <param name="span">Permet de savoir s'il y a un rowspan ou un columnspan</param>
        private void imageBase(int idModele, int column, int row, string span)
        {
            Image equipement = new Image();
            switch(idModele)
            {
                case (int)Modele.Modeles.ArmeUneMain:
                    equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/epeeDefault.png", UriKind.RelativeOrAbsolute));
                    break;
                case (int)Modele.Modeles.Bottes:
                    equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/bottesDefault.png", UriKind.RelativeOrAbsolute));
                    break;
                case (int)Modele.Modeles.Bouclier:
                    equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/bouclierDefault.png", UriKind.RelativeOrAbsolute));
                    break;
                case (int)Modele.Modeles.Casque:
                    equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/casqueDefault.png", UriKind.RelativeOrAbsolute));
                    break;
                case (int)Modele.Modeles.Épaulette:
                    equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/epauletteDefault.png", UriKind.RelativeOrAbsolute));
                    break;
                case (int)Modele.Modeles.Pantalon:
                    equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/pantsDefault.png", UriKind.RelativeOrAbsolute));
                    break;
                case (int)Modele.Modeles.Plastron:
                    equipement.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/plateDefault.png", UriKind.RelativeOrAbsolute));
                    break;
            }
            equipement.AllowDrop = true;
            equipement.PreviewMouseMove += equipement_PreviewMouseMove;
            equipement.Drop += equipement_Drop;

            Grid.SetColumn(equipement, column);
            Grid.SetRow(equipement, row);
            if (span == "row")
            {
                Grid.SetRowSpan(equipement, 2);
                equipement.VerticalAlignment = VerticalAlignment.Center;
            }
            else if (span == "column")
            {
                Grid.SetColumnSpan(equipement, 2);
                equipement.HorizontalAlignment = HorizontalAlignment.Center;
            }
            GridEquiper.Children.Add(equipement);
        }
        /// <summary>
        /// Quand le joueur se fait attaquer, sa barre de vie se réduit - Anthony Gauthier 04/11/2014
        /// </summary>
        private void MajBarreViePerso(int max)
        {
            if (VarGlobales.Personnage.Vie > VarGlobales.Personnage.VieMaximale)
                VarGlobales.Personnage.Vie = VarGlobales.Personnage.VieMaximale;

            int poucentageVie = (VarGlobales.Personnage.Vie * 100) / VarGlobales.Personnage.VieMaximale;

            int widthAjuste = max - ((max * poucentageVie) / 100);
            brdViePerso.Margin = new Thickness(2, 2, widthAjuste, 2);
            MajCouleurBarreVie(brdViePerso, VarGlobales.Personnage);
            txtViePerso.Content = "Points de vie (PV): " + VarGlobales.Personnage.Vie.ToString() + "/" + VarGlobales.Personnage.VieMaximale.ToString();
        }

        /// <summary>
        /// Quand le joueur utilise un sort, sa barre d'énergie se réduit - Anthony Gauthier 05/11/2014
        /// </summary>
        private void MajBarreEnergiePerso(int max)
        {
            if (VarGlobales.Personnage.Energie > VarGlobales.Personnage.EnergieMaximale)
                VarGlobales.Personnage.Energie = VarGlobales.Personnage.EnergieMaximale;

            int pourcentageEnergie = (VarGlobales.Personnage.Energie * 100) / VarGlobales.Personnage.EnergieMaximale;

            int widthAjuste = max - ((max * pourcentageEnergie) / 100);
            brdEnergiePerso.Margin = new Thickness(2, 2, widthAjuste, 2);
            txtEnergiePerso.Content = "Points d'énergie (PE): " + VarGlobales.Personnage.Energie.ToString() + "/" + VarGlobales.Personnage.EnergieMaximale.ToString();
        }

        /// <summary>
        /// Met à jour la couleur des barres de vie de l'ennemi et du perso - Anthony Gauthier 05/11/2014 
        /// </summary>
        /// <param name="uneBordure">Recoit la barre a modifier</param>
        private void MajCouleurBarreVie(Border uneBordure, object unObjet)
        {
            //Si l'objet passé est un personnage, on met à jour la couleur de la barre de vie du personnage
            if (unObjet.GetType() == VarGlobales.Personnage.GetType())
            {
                //Si la vie du personnage est inférieur ou égale à 50%
                if (VarGlobales.Personnage.Vie <= VarGlobales.Personnage.VieMaximale * 0.5)
                {
                    if (VarGlobales.Personnage.Vie <= VarGlobales.Personnage.VieMaximale * 0.25)
                    {
                        uneBordure.Background = Brushes.Red;
                    }
                    else
                    {
                        uneBordure.Background = Brushes.Yellow;
                    }
                }
                else if (VarGlobales.Personnage.Vie > VarGlobales.Personnage.VieMaximale * 0.50)
                {
                    uneBordure.Background = Brushes.Green;
                }
            }
        }

        private void brdMaxWidth_Loaded(object sender, RoutedEventArgs e)
        {
            MajBarreViePerso((int)(brdMaxWidth.ActualWidth));
            MajBarreEnergiePerso((int)(brdMaxWidth.ActualWidth));
        }

        #region Magasin

        /// <summary>
        /// Fonction qui génère le magasin
        /// </summary>
        private void genererMagasin()
        {
            insererMagasin();
        }

        /// <summary>
        /// Fonction qui insère des équipements dans le magasin
        /// </summary>
        private void insererMagasin()
        {
            Image vendre = new Image();
            vendre.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/piece.png", UriKind.RelativeOrAbsolute));
            vendre.ToolTip = "Glissez l'équipement que vous désirez vendre";
            vendre.Name = "Vendre";
            vendre.AllowDrop = true;
            vendre.Drop += equipement_Drop;
            Grid.SetColumn(vendre, 0);
            Grid.SetRow(vendre, 1);
            Grid.SetRowSpan(vendre, 2);
            GridMagasin.Children.Add(vendre);

            Image boutonPotionVie = new Image();
            boutonPotionVie.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/potionVie.png", UriKind.RelativeOrAbsolute));
            boutonPotionVie.Name = "btnPotionVie";
            boutonPotionVie.ToolTip = "Prix : " + VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Vie].Prix + "$";
            boutonPotionVie.MouseLeftButtonUp += boutonPotionVie_MouseLeftButtonUp;
            Grid.SetColumn(boutonPotionVie, 1);
            Grid.SetRow(boutonPotionVie, 1);
            GridMagasin.Children.Add(boutonPotionVie);

            Image boutonPotionEnergie = new Image();
            boutonPotionEnergie.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "resources/images/objets/potionMana.png", UriKind.RelativeOrAbsolute));
            boutonPotionEnergie.Name = "btnPotionEnergie";
            boutonPotionEnergie.ToolTip = "Prix : " + VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Energie].Prix + "$";
            boutonPotionEnergie.MouseLeftButtonUp += boutonPotionEnergie_MouseLeftButtonUp;
            Grid.SetColumn(boutonPotionEnergie, 2);
            Grid.SetRow(boutonPotionEnergie, 1);
            GridMagasin.Children.Add(boutonPotionEnergie);

            lblVendreEquipement.Content = "Vendre équipement";
            lblAcheterPotionVie.Content = "Acheter des potions de vie";
            lblAcheterPotionEnergie.Content = "Acheter des potions d'énergie";
            nombrePotionVie.Content = VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Vie].Quantite+ " potions de vie en inventaire";
            nombrePotionEnergie.Content = VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Energie].Quantite + " potions d'énergie en inventaire";

        }

        void boutonPotionEnergie_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (VarGlobales.Personnage.Inventaire.argent < VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Vie].Prix)
            { 
                VarGlobales.Personnage.Inventaire.argent = 0;
                txtbArgent.Text = VarGlobales.Personnage.Inventaire.argent.ToString() + "$";
                
            }
            else
            {
                VarGlobales.Personnage.Inventaire.argent -= VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Energie].Prix;
                VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Energie].Quantite += 1;
                nombrePotionEnergie.Content = VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Energie].Quantite + " potions d'énergie en inventaire";
                txtbArgent.Text = VarGlobales.Personnage.Inventaire.argent.ToString() + "$";
            }
        }

        void boutonPotionVie_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (VarGlobales.Personnage.Inventaire.argent < VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Vie].Prix)
            { 
                VarGlobales.Personnage.Inventaire.argent = 0;
                txtbArgent.Text = VarGlobales.Personnage.Inventaire.argent.ToString() + "$";
            }
            else
            {
                VarGlobales.Personnage.Inventaire.argent -= VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Vie].Prix;
                VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Vie].Quantite += 1;
                nombrePotionVie.Content = VarGlobales.Personnage.Inventaire.listeConsommation[(int)Consommations.Vie].Quantite + " potions de vie en inventaire";
                txtbArgent.Text = VarGlobales.Personnage.Inventaire.argent.ToString() + "$";
            }
        }

        /// <summary>
        /// Fonction qui permet de vendre un équipement
        /// </summary>
        /// <param name="idEquipementInventaire">Le id de l'équipement qui est vendu</param>
        private void vendreEquipement(int idEquipementInventaire)
        {
            //On trouve l'équipement dans l'inventaire avec son id
            for (int i = 0; i < equipementInventaire.Count; i++)
            {
                if(equipementInventaire[i].IdEquipement == idEquipementInventaire)
                {
                    //On ajoute l'argent reçu pour avoir vendu l'équipement
                    VarGlobales.Personnage.Inventaire.argent += Math.Round(equipementInventaire[i].Prix/ 1.131416, 2);
                    txtbArgent.Text = VarGlobales.Personnage.Inventaire.argent.ToString() + "$";
                    //On retire l'équipement de la liste d'équipement inventaire
                    equipementInventaire.RemoveAt(i);
                    VarGlobales.Personnage.Inventaire.listeEquipement = equipementInventaire;
                    break;
                }
            }
        }

        #endregion
    }
}
