using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gianchees.Model
{
    class CustomerOrder
    {
        private string id = null;
        private ObservableCollection<Order> orders = new ObservableCollection<Order>();

        public CustomerOrder()
        {
            this.id = getID();
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public ObservableCollection<Order> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
            }
        }

        public void addFoodToOrder(Food food)
        {
            if (food != null)
            {
                ObservableCollection<Order> orders = this.Orders;
                bool found = false;
                foreach (Order order in orders)
                {
                    if (order.Food == food)
                    {
                        order.Amount++;
                        found = true;
                    }
                }
                if (!found)
                {
                    orders.Add(new Order(food, 1));
                }
                this.Orders = orders;
            }
        }

        public void clearOrders()
        {
            ObservableCollection<Order> orders = new ObservableCollection<Order>();
            this.Orders = orders;
        }

        private string getID()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
