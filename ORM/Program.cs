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
        
          private static void ConnexionSqlServer()
        {
            //Définition de la connexion et de la référence nécessaire pour Sql server
            string SqlConnection = "Server = ASLAM-PC; Database = appliORM; Trusted_Connection = True";
            string SqlProvider = "System.Data.SqlClient";

            //Requêtes Sql server
            string selectquery = "SELECT * FROM Contact1";
            string insertquery = "INSERT INTO Contact1 (nom, prenom) VALUES('nomdefamille', 'prenom')";
            string updatequery = "UPDATE Contact1 SET nom = 'nomdefamillechage' WHERE prenom = 'prenom'";
            string deletequery = "DELETE FROM Contact1";

            //Instance de la classe BDD pour appeler chaque méthode faisant référence à une requête
            BDD sql = new BDD();
            //sql.InsertStatement(SqlProvider, SqlConnection, insertquery);
            //sql.UpdateStatement(SqlProvider, SqlConnection, updatequery);
            //sql.DeleteStatement(SqlProvider, SqlConnection, deletequery);
            sql.SelectStatement(SqlProvider, SqlConnection, selectquery);

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
