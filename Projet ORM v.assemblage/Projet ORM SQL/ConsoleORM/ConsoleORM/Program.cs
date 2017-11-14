using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleORM
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Affichage du menu principal
                afficherMenu();
                Console.WriteLine("Votre choix :");
                // Choix de l'option souhaité
                string choix = Console.ReadLine();
                switch (choix.ToLower())
                {
                    case "1":
                        //ConnexionMySQL();
                        break;

                    case "2":
                        ConnexionSqlServer();
                        break;

                    case "3":
                        //ConnexionPostgreSql();
                        break;

                    case "q":
                        return;

                    default:
                        Console.WriteLine("Erreur dans le choix");
                        break;

                }
            }
        }

        private static void ConnexionSqlServer()
        {
            // Création d'un contact à insérer
            Contact c1 = new Contact();
            c1.Id = 1;
            c1.Name = "Lattif";
            c1.Tel = "06 05 04 03 02";

            Contact c2 = new Contact();
            c2.Id = 2;
            c2.Name = "Mougamadou";
            c2.Tel = "06 00 00 00 00";

            Contact c3 = new Contact();
            c3.Id = 3;
            c3.Name = "Mouga";
            c3.Tel = "06 50 50 50 50";

            Contact c4 = new Contact();
            c4.Id = 4;
            c4.Name = "SK";
            c4.Tel = "06 02 00 01 05";

            // Création de l'objet Bdd pour interagir avec la base de donnée MySQL
            BddSQL bddsql = new BddSQL();
            bddsql.InsertContact(c1);
            //bdd.InsertContact(c2);    
            //bdd.InsertContact(c3);
            //bdd.InsertContact(c4);
            //bdd.DeleteContact();                              //Suppression d'un contact
            //bdd.UpdateContact();                              //Mise à jour d'un contact
            /*List<string>[] list = bdd.SelectContact();        
            foreach (var item in list)
            {
                Console.WriteLine("item");
            }*/
        }

        private static void afficherMenu()
        {
            //Affichage du Menu démarrage
            Console.WriteLine("-- MENU --");
            Console.WriteLine("01- Connexion MySQL");
            Console.WriteLine("02- Connexion Sql Server");
            Console.WriteLine("03- Connexion Postgre Sql");
            Console.WriteLine("Q- Quitter");
        }
    }
}
