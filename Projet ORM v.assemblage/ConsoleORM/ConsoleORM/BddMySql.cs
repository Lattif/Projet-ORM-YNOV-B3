using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleORM
{
    public class BddMySql
    {
        private MySqlConnection connection;

        // Constructeur
        public BddMySql()
        {
            this.InitConnexion();
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER=localhost; DATABASE=bdd_contact; UID=root; PASSWORD=";
            this.connection = new MySqlConnection(connectionString);
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
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password");
                        break;
                }
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
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Requête Insert
        public void InsertContact(Contact contact)
        {
            string query = "INSERT INTO contact (id, name, tel) VALUES (@id, @name, @tel)";

            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@id", contact.Id);
                    cmd.Parameters.AddWithValue("@name", contact.Name);
                    cmd.Parameters.AddWithValue("@tel", contact.Tel);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch
            {
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.            }
            }
        }

            //Requête Delete
        public void DeleteContact()
        {
            if(this.OpenConnection() == true)
            {
                MySqlCommand cmd = this.connection.CreateCommand();
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
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQl Update
                cmd.CommandText = "UPDATE contact SET name='toto', tel='06 00 00 00 00' WHERE name='Mougamadou'";
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
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the query and obtain a result set
                MySqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    Console.Write("{0}\t{1}\t{2} \n", dr[0], dr[1], dr[2]);

                this.CloseConnection();
            }
        }
    }
}
