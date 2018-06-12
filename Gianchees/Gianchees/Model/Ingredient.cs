using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gianchees.Model
{
    class Ingredient
    {
        private int id = 0;
        private string name = null;
        private int calorie = 0;
        private int amount = 1;

        public Ingredient(int id, int amount)
        {
            this.id = id;
            this.Amount = amount;
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

        public int Calorie
        {
            get
            {
                return this.calorie;
            }
            set
            {
                this.calorie = value;
            }
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        private void load(int id)
        {
            Database database = Database.Instance;
            string query = "SELECT * FROM ingredient WHERE id = @id";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, database.Connection);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);
                database.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.Name = reader.GetString(1);
                        this.Calorie = reader.GetInt32(2);
                    }
                }
                database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<Ingredient> getIngredients(int food)
        {
            Database database = Database.Instance;
            string query = "SELECT * FROM preperation WHERE food = @food";
            List<Ingredient> ingredients = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, database.Connection);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@food", food);
                database.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    ingredients = new List<Ingredient>();
                    while (reader.Read())
                    {
                        ingredients.Add(new Ingredient(reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
                database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (ingredients != null)
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    ingredient.load(ingredient.ID);
                }
            }
            return ingredients;
        }

        public void Change()
        {
            throw new NotImplementedException();
        }
    }
}
