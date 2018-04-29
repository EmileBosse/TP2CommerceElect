using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Database
{
    public abstract class DataAccess
    {
        private MySqlConnection _connexion;

        private const string CONNEXION_JEAN = "Server=localhost;Database=tp2_commerceelec;UID=root;Password=root;SslMode=none";

        //private const string CONNEXION_EMILE = "Server=localhost;Database=tp2_commerceelec;UID=root;SslMode=none";

        protected MySqlConnection Connexion => _connexion ?? (_connexion = InitDatabaseConnexion());

        private MySqlConnection InitDatabaseConnexion()
        {
            MySqlConnection connexion = new MySqlConnection
            {
                // Changer cette ligne pour s'adapter à ce qu'on a à la maison
                ConnectionString = CONNEXION_JEAN
            };

            return connexion;
        }

    }
}
