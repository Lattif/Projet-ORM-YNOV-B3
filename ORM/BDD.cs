using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    class BDD
    {
        // Méthode qui permet d'exécuter la requête Select 
        public void SelectStatement(string providerName, string connectionString, string query)
        {
            // Creation du DbProviderFactory et de la DbConnection
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            // Vérification de la connexion valide
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        // Ouverture de la connexion
                        connection.Open();
                        Console.WriteLine("connexion ouverte");

                        // Creation d'une commande en factory (DbCommand)
                        DbCommand command = factory.CreateCommand();
                        command.CommandText = query;
                        command.Connection = connection;

                        // Exécution de la commande (DbDataReader)
                        DbDataReader dr = command.ExecuteReader();

                        // Affichage des éléments de la table
                        while (dr.Read())
                            Console.Write("{0}\t{1}\t{2} \n", dr[0], dr[1], dr[2]);

                        // Fermeture de la connexion
                        connection.Close();
                        Console.WriteLine("Connexion fermee");
                    }

                    // Gère toutes les exceptions
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                // Connexion invalide 
                Console.WriteLine("Connexion invalide.");
            }
        }

        // Méthode qui permet d'exécuter la requête Update 
        public void UpdateStatement(string providerName, string connectionString, string query)
        {
            // Creation du DbProviderFactory et de la DbConnection
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            // Vérification de la connexion valide
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        // Ouverture de la connexion
                        connection.Open();
                        Console.WriteLine("connexion ouverte");

                        // Creation et exécution de la commande
                        DbCommand command = connection.CreateCommand();
                        command.CommandText = query;
                        int rows = command.ExecuteNonQuery();

                        // Affichage du nombre de lignes mis à jour
                        Console.WriteLine("{0} lignes mis à jour.", rows);

                        // Fermeture de la connexion
                        connection.Close();
                        Console.WriteLine("Connexion fermee");
                    }

                    // Gère les erreurs de données
                    catch (DbException exDb)
                    {
                        Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                        Console.WriteLine("DbException.Source: {0}", exDb.Source);
                        Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                        Console.WriteLine("DbException.Message: {0}", exDb.Message);
                    }

                    // Gère les autres exceptions
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                // Connexion invalide
                Console.WriteLine("Connexion invalide.");
            }
        }

        // Méthode qui permet d'exécuter la requête Insert 
        public void InsertStatement(string providerName, string connectionString, string query)
        {
            // Creation du DbProviderFactory et de la DbConnection
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            // Vérification de la connexion valide
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        // Ouverture de la connexion
                        connection.Open();
                        Console.WriteLine("connexion ouverte");

                        // Creation et exécution de la commande
                        DbCommand command = connection.CreateCommand();
                        command.CommandText = query;
                        int rows = command.ExecuteNonQuery();

                        // Affichage du nombre de lignes inserées
                        Console.WriteLine("{0} lignes inserées.", rows);

                        // Fermeture de la connexion
                        connection.Close();
                        Console.WriteLine("Connexion fermee");
                    }

                    // Gère les erreurs de données
                    catch (DbException exDb)
                    {
                        Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                        Console.WriteLine("DbException.Source: {0}", exDb.Source);
                        Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                        Console.WriteLine("DbException.Message: {0}", exDb.Message);
                    }

                    // Gère les autres exceptions
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                // Connexion invalide
                Console.WriteLine("Connexion invalide.");
            }
        }

        // Méthode qui permet d'exécuter la requête Delete 
        public void DeleteStatement(string providerName, string connectionString, string query)
        {
            // Creation du DbProviderFactory et de la DbConnection
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            // Vérification de la connexion valide
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        // Ouverture de la connexion
                        connection.Open();
                        Console.WriteLine("connexion ouverte");

                        // Creation et exécution de la commande
                        DbCommand command = connection.CreateCommand();
                        command.CommandText = query;
                        int rows = command.ExecuteNonQuery();

                        // Affichadge du nombre de lignes supprimées
                        Console.WriteLine("{0} lignes supprimées.", rows);

                        // Fermeture de la connexion
                        connection.Close();
                        Console.WriteLine("Connexion fermee");
                    }

                    // Gère les erreurs de données
                    catch (DbException exDb)
                    {
                        Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                        Console.WriteLine("DbException.Source: {0}", exDb.Source);
                        Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                        Console.WriteLine("DbException.Message: {0}", exDb.Message);
                    }

                    // Gèreles autres exceptions
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                // Connexion invalide
                Console.WriteLine("Connexion invalide.");
            }
        }
    }
}
