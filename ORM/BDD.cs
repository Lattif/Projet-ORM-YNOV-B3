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
        public void SelectStatement(string providerName, string connectionString, string query)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("connexion ouverte");

                        DbCommand command = factory.CreateCommand();
                        command.CommandText = query;
                        command.Connection = connection;

                        DbDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                            Console.Write("{0}\t{1}\t{2} \n", dr[0], dr[1], dr[2]);

                        connection.Close();
                        Console.WriteLine("Connexion fermee");
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Connexion invalide.");
            }
        }

        public void UpdateStatement(string providerName, string connectionString, string query)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("connexion ouverte");

                        DbCommand command = connection.CreateCommand();
                        command.CommandText = query;
                        int rows = command.ExecuteNonQuery();

                        Console.WriteLine("{0} lignes mis à jour.", rows);

                        connection.Close();
                        Console.WriteLine("Connexion fermee");
                    }

                    catch (DbException exDb)
                    {
                        Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                        Console.WriteLine("DbException.Source: {0}", exDb.Source);
                        Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                        Console.WriteLine("DbException.Message: {0}", exDb.Message);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
               Console.WriteLine("Connexion invalide.");
            }
        }

        public void InsertStatement(string providerName, string connectionString, string query)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("connexion ouverte");

                        DbCommand command = connection.CreateCommand();
                        command.CommandText = query;
                        int rows = command.ExecuteNonQuery();

                        Console.WriteLine("{0} lignes inserées.", rows);

                        connection.Close();
                        Console.WriteLine("Connexion fermee");
                    }

                    catch (DbException exDb)
                    {
                        Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                        Console.WriteLine("DbException.Source: {0}", exDb.Source);
                        Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                        Console.WriteLine("DbException.Message: {0}", exDb.Message);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Connexion invalide.");
            }
        }

        public void DeleteStatement(string providerName, string connectionString, string query)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("connexion ouverte");

                        DbCommand command = connection.CreateCommand();
                        command.CommandText = query;
                        int rows = command.ExecuteNonQuery();

                        Console.WriteLine("{0} lignes supprimées.", rows);

                        connection.Close();
                        Console.WriteLine("Connexion fermee");
                    }

                    catch (DbException exDb)
                    {
                        Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                        Console.WriteLine("DbException.Source: {0}", exDb.Source);
                        Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                        Console.WriteLine("DbException.Message: {0}", exDb.Message);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Connexion invalide.");
            }
        }
    }
}
