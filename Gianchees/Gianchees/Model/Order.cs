using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gianchees.Model
{
    class Order
    {
        private string id = null;
        private Food food = null;
        private int amount = 1;

        public Order(Food food, int amount)
        {
            this.Food = food;
            this.Amount = amount;
            this.id = getID();
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public Food Food
        {
            get
            {
                return this.food;
            }
            set
            {
                this.food = value;
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

        private string getID()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
