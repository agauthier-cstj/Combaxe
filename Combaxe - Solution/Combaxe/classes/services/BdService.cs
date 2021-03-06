﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Combaxe___New.classes;

namespace MiniBD
{
    public class BdService
    {
        private string serveur = ConfigurationManager.ConnectionStrings["serveur"].ConnectionString;
        private string BD = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
        private string user = ConfigurationManager.ConnectionStrings["username"].ConnectionString;
        private string password = ConfigurationManager.ConnectionStrings["password"].ConnectionString;

        private MySqlConnection connexion;

        //-----------CONSTRUCTEUR--------------
        public BdService()
        {
            try
            {
                string sConnection = "SERVER="+serveur+";DATABASE="+BD+";UID="+user+";PASSWORD="+password+";";
                connexion = new MySqlConnection(sConnection);

                /* Réactiver en phase de "testing"
                MessageBox.Show("La string de connexion a le bon format");*/
            }
            catch (Exception e)
            {
                /* Réactiver en phase de testing
                MessageBox.Show("Erreur de la string de connexion");*/
            }

        }

        //-----------OUVERTURE DE LA CONNEXION--------------
        private bool Ouvrir()
        {
            try
            {
                connexion.Open();
                VarGlobales.connexion = true;
                return true;
            }
            catch 
            {
                VarGlobales.connexion = false;
                return false;
            }
        }

        //-----------FERMETURE DE LA CONNEXION--------------
        private bool Fermer()
        {
            try
            {
                connexion.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Erreur de fermeture de connexion");
                return false;
            }
        }

        //-----------INSERTION--------------
        public void Insertion(string ins)
        {
            try
            {
                if(Ouvrir())
                {
                    MySqlCommand cmd = new MySqlCommand(ins,connexion);
                    cmd.ExecuteNonQuery();
                    Fermer();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de l'insertion");
            }
        }

        //-----------MISE À JOUR--------------
        public void maj(string maj)
        {
            try
            {
                if (Ouvrir())
                {
                    MySqlCommand cmd = new MySqlCommand(maj, connexion);
                    cmd.ExecuteNonQuery();
                    Fermer();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de la mise à jour");
            }
        }

        //-----------SÉLECTION--------------
        public List<string>[] selection(string sel, int nbChamp, ref int nbRange)
        {
            List<string> infoBrute = new List<string>();

            nbRange = 0;

            try
            {
                if(Ouvrir())
                {
                    MySqlCommand cmd = new MySqlCommand(sel,connexion);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while(dataReader.Read())
                    {
                        for (int i = 0; i < nbChamp; i++)
                        {
                            infoBrute.Add(dataReader[i].ToString());
                        }

                        nbRange++;
                    }

                    dataReader.Close();
                    Fermer();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur dans le select");
            }

            List<string>[] listeRetour;

            if(nbRange == 0)
            {
                listeRetour = new List<string>[1];
                listeRetour[0] = new List<string>();
                listeRetour[0].Add("");
            }
            else
            {
                listeRetour = new List<string>[nbRange];

                for (int i = 0; i < nbRange; i++)
                {
                    listeRetour[i] = new List<string>();

                    for (int x = 0; x < nbChamp; x++)
                    {
                        int indice = x + (i * nbChamp);
                        listeRetour[i].Add(infoBrute[indice]);
                    }
                }
            }
            return listeRetour;
        }

        //--------------LAST INSERT ID----------------
        public int lastInsertId()
        { 
            int id = 0;
            List<string>[] listId;
            BdService bd = new BdService();
            int nbRangee = 0;
            

            string req = "SELECT LAST_INSERT_ID();";

            listId = bd.selection(req, 1, ref nbRangee);

            id = Int32.Parse(listId[0][0]);

            return id;
        }
    }
}
