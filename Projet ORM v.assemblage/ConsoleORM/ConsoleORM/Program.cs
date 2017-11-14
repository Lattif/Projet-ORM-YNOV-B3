using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        ConnexionMySQL();
                        break;

                    case "2":
                        ConnexionSqlServer();
                        break;

                    case "3":
                        ConnexionPostgreSql();
                        break;

                    case "q":
                        return;

                    default:
                        Console.WriteLine("Erreur dans le choix");
                        break;

                }
            }

        }

        private static void ConnexionPostgreSql()
        {
            // Création d'un contact à insérer
            Contact c1 = new Contact();
            c1.Id = 1;
            c1.Name = "Rio";
            c1.Tel = "06 05 04 03 02";

            Contact c2 = new Contact();
            c2.Id = 2;
            c2.Name = "Titi";
            c2.Tel = "06 00 00 00 00";

            Contact c3 = new Contact();
            c3.Id = 3;
            c3.Name = "sasa";
            c3.Tel = "06 50 50 50 50";

            Contact c4 = new Contact();
            c4.Id = 4;
            c4.Name = "vj";
            c4.Tel = "06 02 00 01 05";

            // Création de l'objet Bdd pour interagir avec la base de donnée MySQL
            BDDPostgreSQL bddpostgresql = new BDDPostgreSQL();
            //bddpostgresql.InsertContact(c1);
            //bddpostgresql.InsertContact(c2);
            //bddpostgresql.InsertContact(c3);
            //bddpostgresql.InsertContact(c4);
            //bddpostgresql.DeleteContact();                              //Suppression d'un contact
            //bddpostgresql.UpdateContact();                              //Mise à jour d'un contact
            bddpostgresql.SelectContact();
        }

        private static void ConnexionSqlServer()
        {
            throw new NotImplementedException();
        }

        private static void ConnexionMySQL()
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
            BddMySql bddmysql = new BddMySql();
            //bddmysql.InsertContact(c1);
            //bddmysql.InsertContact(c2);    
            //bddmysql.InsertContact(c3);
            //bddmysql.InsertContact(c4);
            //bddmysql.DeleteContact();                              //Suppression d'un contact
            bddmysql.UpdateContact();                              //Mise à jour d'un contact
            bddmysql.SelectContact();

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
