using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleORM
{
    public class Contact
    {
        // Création de 3 propriétés identifiant, nom et téléphone
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }

        // Constructeur
        public Contact()
        {

        }
    }
}
