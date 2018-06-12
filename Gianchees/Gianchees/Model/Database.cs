using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Gianchees.Model
{
    class Database
    {
        private static Database instance = null;
        private string config = "datasource=127.0.0.1;port=3306;username=root;password=;database=gianchees;SslMode=none";
        private MySqlConnection connection = null;

        private Database()
        {
            this.connection = new MySqlConnection(config);
        }

        public static Database Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        public MySqlConnection Connection
        {
            get
            {
                return this.connection;
            }
        }
    }
}
