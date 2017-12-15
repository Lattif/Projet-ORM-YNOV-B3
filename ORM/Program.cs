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
            //Définition de la connexion et de la référence nécessaire pour PostgreSql
            string PostgreSqlConnection = "SERVER=localhost; DATABASE=bdd_contact; UID=postgres; PASSWORD=1234";
            string PostgreSqlProvider = "npgsql";

            Console.WriteLine("Entrez votre requête:");
            string query = Console.ReadLine();

            //Requêtes PostgreSql maniuel (exemple de syntaxe)
            //string insertquery = "INSERT INTO contact (id,nom,prenom) VALUES ('1', 'nomdefamille', 'prenom')";
            //string selectquery = "SELECT * FROM contact";
            //string updatequery = "UPDATE contact SET nom = 'nomchange' WHERE id = 1";
            //string deletequery = "DELETE FROM contact";

            //Instance de la classe BDD pour appeler chaque méthode faisant référence à une requête
            BDD postgresql = new BDD();

            /// Requêtes PostgreSql à saisir par l'utilisateur
            if (query.Contains("SELECT"))
            {
                postgresql.SelectStatement(PostgreSqlProvider, PostgreSqlConnection, query);
            }

            if (query.Contains("INSERT"))
            {
                postgresql.InsertStatement(PostgreSqlProvider, PostgreSqlConnection, query);
            }

            if (query.Contains("UPDATE"))
            {
                postgresql.UpdateStatement(PostgreSqlProvider, PostgreSqlConnection, query);
            }

            if (query.Contains("DELETE"))
            {
                postgresql.DeleteStatement(PostgreSqlProvider, PostgreSqlConnection, query);
            }

        }

        private static void ConnexionMySQL()
        {
            //Définition de la connexion et de la référence nécessaire pour MySQL
            string MySqlConnection = "SERVER=localhost; DATABASE=bdd_contact; UID=root; PASSWORD=";
            string MySqlProvider = "MySql.Data.MySqlClient";

            Console.WriteLine("Entrez votre requête:");
            string query = Console.ReadLine();

            //Requêtes MySQL manuel (exemple de syntaxe)
            //string selectquery = "SELECT * FROM contact";
            //string insertquery = "INSERT INTO contact (id, nom, prenom) VALUES('1', 'nomdefamille', 'prenom')";
            //string updatequery = "UPDATE contact SET nom = 'nomdefamillechange' WHERE prenom = 'prenom'";
            //string deletequery = "DELETE FROM contact WHERE id = 1";

            //Instance de la classe BDD pour appeler chaque méthode faisant référence à une requête
            BDD mysql = new BDD();

            /// Requêtes MYSQL à saisir par l'utilisateur
            if (query.Contains("SELECT"))
            {
                mysql.SelectStatement(MySqlProvider, MySqlConnection, query);
            }

            if (query.Contains("INSERT"))
            {
                mysql.InsertStatement(MySqlProvider, MySqlConnection, query);
            }

            if (query.Contains("UPDATE"))
            {
                mysql.UpdateStatement(MySqlProvider, MySqlConnection, query);
            }

            if (query.Contains("DELETE"))
            {
                mysql.DeleteStatement(MySqlProvider, MySqlConnection, query);
            }
        }

        private static void ConnexionSqlServer()
        {
            //Définition de la connexion et de la référence nécessaire pour Sql server
            string SqlConnection = "Server = localhost; Database = bdd_contact; Trusted_Connection = True";
            string SqlProvider = "System.Data.SqlClient";

            Console.WriteLine("Entrez votre requête:");
            string query = Console.ReadLine();

            //Requêtes Sqlserver manuel (exemple de syntaxe)
            //string selectquery = "SELECT * FROM contact";
            //string insertquery = "INSERT INTO contact (nom, prenom) VALUES('nomdefamille', 'prenom')";
            //string updatequery = "UPDATE contact SET nom = 'nomdefamillechage' WHERE prenom = 'prenom'";
            //string deletequery = "DELETE FROM contact";

            //Instance de la classe BDD pour appeler chaque méthode faisant référence à une requête
            BDD sql = new BDD();

            /// Requêtes SQLserver à saisir par l'utilisateur
            if (query.Contains("SELECT"))
            {
                sql.SelectStatement(SqlProvider, SqlConnection, query);
            }

            if (query.Contains("INSERT"))
            {
                sql.InsertStatement(SqlProvider, SqlConnection, query);
            }

            if (query.Contains("UPDATE"))
            {
                sql.UpdateStatement(SqlProvider, SqlConnection, query);
            }

            if (query.Contains("DELETE"))
            {
                sql.DeleteStatement(SqlProvider, SqlConnection, query);
            }

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
