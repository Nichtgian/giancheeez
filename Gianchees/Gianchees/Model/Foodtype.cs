using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gianchees.Model
{
    class Foodtype
    {
        private int id = 0;
        private string type = null;
        private List<Food> foods = null;

        public Foodtype(int id, string type)
        {
            this.id = id;
            this.Type = type;
        }

        public int ID
        {
            get
            {
                return this.id;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public List<Food> Foods
        {
            get
            {
                return this.foods;
            }
            set
            {
                this.foods = value;
            }
        }

        public void load()
        {
            this.Foods = Food.getFoods(this.ID);
        }

        public static List<Foodtype> getFoodtypes()
        {
            Database database = Database.Instance;
            string query = "SELECT * FROM foodtype";
            List<Foodtype> foodtypes = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, database.Connection);
                database.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    foodtypes = new List<Foodtype>();
                    while (reader.Read())
                    {
                        foodtypes.Add(new Foodtype(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
                database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (foodtypes != null)
            {
                foreach (Foodtype foodtype in foodtypes)
                {
                    foodtype.load();
                }
            }
            return foodtypes;
        }

        public void Change()
        {
            throw new NotImplementedException();
        }
    }
}
