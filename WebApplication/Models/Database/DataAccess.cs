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

        private const string CONNEXION = "Server=localhost;Database=tp2_commerceelec;UID=root;SslMode=none";

        protected MySqlConnection Connexion => _connexion ?? (_connexion = InitDatabaseConnexion());

        private MySqlConnection InitDatabaseConnexion()
        {
            MySqlConnection connexion = new MySqlConnection
            {                
                ConnectionString = CONNEXION
            };

            return connexion;
        }

    }
}
