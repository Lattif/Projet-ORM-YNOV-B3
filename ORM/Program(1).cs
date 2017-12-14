using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ORM
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
                        //ConnexionSqlServer();
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
            string PostgreSqlConnection = "SERVER=localhost; DATABASE=bdd_contact; UID=postgres; PASSWORD=1234";
            string PostgreSqlProvider = "npgsql";
            string insertquery = "INSERT INTO contact (id,nom,prenom) VALUES ('1', 'nomdefamille', 'prenom')";
            string selectquery = "SELECT * FROM contact";
            string updatequery = "UPDATE contact SET nom = 'nomchange' WHERE id = 1";
            string deletequery = "DELETE FROM contact";

            BDD postgresql = new BDD();
            //postgresql.InsertStatement(PostgreSqlProvider, PostgreSqlConnection,insertquery);
            //postgresql.UpdateStatement(PostgreSqlProvider, PostgreSqlConnection, updatequery);
            //postgresql.DeleteStatement(PostgreSqlProvider, PostgreSqlConnection, deletequery);
            postgresql.SelectStatement(PostgreSqlProvider, PostgreSqlConnection, selectquery);
        }

        private static void afficherMenu()
        {
            //Affichage du Menu démarrage
            Console.WriteLine("-- MENU --");
            Console.WriteLine("1- Connexion MySQL");
            Console.WriteLine("2- Connexion Sql Server");
            Console.WriteLine("3- Connexion Postgre Sql");
            Console.WriteLine("Q- Quitter");
        }

    }
}
