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
        
         public static DataTable ObjectToDataTable(object o)
        {
            //Creation d'une datatable contenant les attributs d'une classe

            DataTable dataClass = new DataTable(o.GetType().Name);
            DataRow rows = dataClass.NewRow();
            dataClass.Rows.Add(rows);

            //Ajout des colonnes et des lignes de la datatable en récupérant les noms des propriétés
            o.GetType().GetProperties().ToList().ForEach(f =>
            {
                try
                {
                    f.GetValue(o, null);
                    dataClass.Columns.Add(f.Name, f.PropertyType);
                    dataClass.Rows[0][f.Name] = f.GetValue(o, null);
                }
                catch { }
            });
            return dataClass;
        }

        //Genère une Requete SQL de création de table à partir d'une DataTable
        public static string GenerateReqCreate(DataTable dataClass)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder alterSql = new StringBuilder();

            sql.AppendFormat("CREATE TABLE [{0}] (", dataClass.TableName);

            for (int i = 0; i < dataClass.Columns.Count; i++)
            {
                bool isNumeric = false;
                bool usesColumnDefault = true;

                sql.AppendFormat("\n\t[{0}]", dataClass.Columns[i].ColumnName);

                //Recupère le type des paramètres de la classe pour définir le type en SQL
                switch (dataClass.Columns[i].DataType.ToString().ToUpper())
                {
                    case "SYSTEM.INT16":
                        sql.Append(" smallint");
                        isNumeric = true;
                        break;
                    case "SYSTEM.INT32":
                        sql.Append(" int");
                        isNumeric = true;
                        break;
                    case "SYSTEM.INT64":
                        sql.Append(" bigint");
                        isNumeric = true;
                        break;
                    case "SYSTEM.DATETIME":
                        sql.Append(" datetime");
                        usesColumnDefault = false;
                        break;
                    case "SYSTEM.STRING":
                        sql.AppendFormat(" nvarchar({0})", dataClass.Columns[i].MaxLength);
                        break;
                    case "SYSTEM.SINGLE":
                        sql.Append(" single");
                        isNumeric = true;
                        break;
                    case "SYSTEM.DOUBLE":
                        sql.Append(" double");
                        isNumeric = true;
                        break;
                    case "SYSTEM.DECIMAL":
                        sql.AppendFormat(" decimal(18, 6)");
                        isNumeric = true;
                        break;
                    default:
                        sql.AppendFormat(" nvarchar({0})", dataClass.Columns[i].MaxLength);
                        break;
                }

                if (dataClass.Columns[i].AutoIncrement)
                {
                    sql.AppendFormat(" IDENTITY({0},{1})",
                        dataClass.Columns[i].AutoIncrementSeed,
                        dataClass.Columns[i].AutoIncrementStep);
                }
                else
                {
                     
                    if (dataClass.Columns[i].DefaultValue != null)
                    {
                        if (usesColumnDefault)
                        {
                            if (isNumeric)
                            {
                                alterSql.AppendFormat("\nALTER TABLE {0} ADD CONSTRAINT [DF_{0}_{1}]  DEFAULT ({2}) FOR [{1}];",
                                    dataClass.TableName,
                                    dataClass.Columns[i].ColumnName,
                                    dataClass.Columns[i].DefaultValue);
                            }
                            else
                            {
                                alterSql.AppendFormat("\nALTER TABLE {0} ADD CONSTRAINT [DF_{0}_{1}]  DEFAULT ('{2}') FOR [{1}];",
                                    dataClass.TableName,
                                    dataClass.Columns[i].ColumnName,
                                    dataClass.Columns[i].DefaultValue);
                            }
                        }
                        else
                        {
                            
                            try
                            {
                                System.Xml.XmlDocument xml = new System.Xml.XmlDocument();

                                xml.LoadXml(dataClass.Columns[i].Caption);

                                alterSql.AppendFormat("\nALTER TABLE {0} ADD CONSTRAINT [DF_{0}_{1}]  DEFAULT ({2}) FOR [{1}];",
                                    dataClass.TableName,
                                    dataClass.Columns[i].ColumnName,
                                    xml.GetElementsByTagName("defaultValue")[0].InnerText);
                            }
                            catch
                            {
                                
                            }
                        }
                    }
                }

                if (!dataClass.Columns[i].AllowDBNull)
                {
                    sql.Append(" NOT NULL");
                }

                sql.Append(",");
            }

            if (dataClass.PrimaryKey.Length > 0)
            {
                StringBuilder primaryKeySql = new StringBuilder();

                primaryKeySql.AppendFormat("\n\tCONSTRAINT PK_{0} PRIMARY KEY (", dataClass.TableName);

                for (int i = 0; i < dataClass.PrimaryKey.Length; i++)
                {
                    primaryKeySql.AppendFormat("{0},", dataClass.PrimaryKey[i].ColumnName);
                }

                primaryKeySql.Remove(primaryKeySql.Length - 1, 1);
                primaryKeySql.Append(")");

                sql.Append(primaryKeySql);
            }
            else
            {
                sql.Remove(sql.Length - 1, 1);
            }

            sql.AppendFormat("\n);\n{0}", alterSql.ToString());

            return sql.ToString();
        }

        //Genere une requête SQL pour inserer une classe dans une BD en tant que table
        public String classToSQL(object o)
        {
            DataTable dt =  ObjectToDataTable(o);
            String requete = GenerateReqCreate(dt);
            return requete;
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
