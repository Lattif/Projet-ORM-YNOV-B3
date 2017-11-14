using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace ConsoleORM
{
    class BDDPostgreSQL
    {
        private NpgsqlConnection connection;

        // Constructeur
        public BDDPostgreSQL()
        {
            this.InitConnexion();
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER=localhost; DATABASE=bdd_contact; UID=postgres; PASSWORD=1234";
            this.connection = new NpgsqlConnection(connectionString);
        }

        //Ouverture de la connexion à la base de données
        private bool OpenConnection()
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                Console.WriteLine("Ouverture de la connexion !");
                return true;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Fermeture de la connexion
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                Console.WriteLine("Fermeture de la connexion !");
                return true;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Requête Insert
        public void InsertContact(Contact contact)
        {
            string query = "INSERT INTO \"contact\"(id,name,tel) values(:id,:name,:tel)";

            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                    cmd.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer)).Value = contact.Id;
                    cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Varchar)).Value = contact.Name;
                    cmd.Parameters.Add(new NpgsqlParameter("tel", NpgsqlDbType.Varchar)).Value = contact.Tel;

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch(NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.            }
            }
        }

        //Requête Delete
        public void DeleteContact()
        {
            if (this.OpenConnection() == true)
            {
                NpgsqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "DELETE FROM contact WHERE id='4'";
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }

        }

        //requête Update
        public void UpdateContact()
        {
            if (this.OpenConnection() == true)
            {
                //Création de la commande mysql
                NpgsqlCommand cmd = this.connection.CreateCommand();
                //Requête SQl Update
                cmd.CommandText = "UPDATE contact SET name='toto', tel='06 00 00 00 00' WHERE id='3'";
                //Execute query
                cmd.ExecuteNonQuery();
                //close connection
                this.CloseConnection();
            }
        }

        //Requête Select
        public void SelectContact()
        {
            string query = "SELECT * FROM contact";

            //Open connection
            if (this.OpenConnection() == true)
            {
                // Define a query
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    Console.Write("{0}\t{1}\t{2} \n", dr[0], dr[1], dr[2]);

                this.CloseConnection();
            }
        }
    }
}
