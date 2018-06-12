using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gianchees.Model
{
    class Food
    {
        private int id = 0;
        private string name = null;
        private float price = 0;
        private List<Ingredient> ingredients = null;

        public Food(int id, string name, float price)
        {
            this.id = id;
            this.Name = name;
            this.Price = price;
        }

        public int ID
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public float Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public List<Ingredient> Ingredients
        {
            get
            {
                return this.ingredients;
            }
            set
            {
                this.ingredients = value;
            }
        }

        public void load()
        {
            this.Ingredients = Ingredient.getIngredients(this.ID);
        }

        public static List<Food> getFoods(int type)
        {
            Database database = Database.Instance;
            string query = "SELECT * FROM food WHERE type = @type";
            List<Food> foods = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, database.Connection);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@type", type);
                database.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    foods = new List<Food>();
                    while (reader.Read())
                    {
                        foods.Add(new Food(reader.GetInt32(0), reader.GetString(2), reader.GetFloat(3)));
                    }
                }
                database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (foods != null)
            {
                foreach (Food food in foods)
                {
                    food.load();
                }
            }
            return foods;
        }

        public void Change()
        {
            throw new NotImplementedException();
        }
    }
}
