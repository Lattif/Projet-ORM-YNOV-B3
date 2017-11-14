using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleORM
{
    public class BddSQL
    {
        private SqlConnection connection;

        // Constructeur
        public BddSQL()
        {
            this.InitConnexion();
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER=localhost; DATABASE=bdd_contact; UID=root; PASSWORD=";
            this.connection = new SqlConnection(connectionString);
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
            catch (SqlException ex)
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
            catch (SqlException ex)
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
                    SqlCommand cmd = new SqlCommand(query, connection);

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
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "DELETE FROM contact WHERE name='toto'";
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
                SqlCommand cmd = this.connection.CreateCommand();
                //Requête SQl Update
                cmd.CommandText = "UPDATE contact SET name='toto', tel='06 00 00 00 00' WHERE name='Mougamadou'";
                //Execute query
                cmd.ExecuteNonQuery();
                //close connection
                this.CloseConnection();
            }
        }

        //Requête Select
        public List<string>[] SelectContact()
        {

            string query = "SELECT * FROM contact";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                SqlCommand cmd = new SqlCommand(query, connection);
                //Create a data reader and Execute the command
                SqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["tel"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }

            else
            {
                return list;
            }
        }
    }
}
