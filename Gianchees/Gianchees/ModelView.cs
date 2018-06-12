using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gianchees
{
    class ModelView : INotifyPropertyChanged
    {
        private static ModelView instance = null;
        private Model.Database database = null;

        private List<Model.Foodtype> foodtypes = null;
        private ObservableCollection<Model.CustomerOrder> customerOrders = new ObservableCollection<Model.CustomerOrder>();
        private ObservableCollection<Model.CustomerOrder> completeCustomerOrders = new ObservableCollection<Model.CustomerOrder>();

        private ModelView()
        {
            this.database = Model.Database.Instance;
            this.Foodtypes = Model.Foodtype.getFoodtypes();
        }

        public static ModelView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModelView();
                }
                return instance;
            }
        }

        public List<Model.Foodtype> Foodtypes
        {
            get
            {
                return this.foodtypes;
            }
            set
            {
                this.foodtypes = value;
            }
        }

        public ObservableCollection<Model.CustomerOrder> CustomerOrders
        {
            get
            {
                return this.customerOrders;
            }
            set
            {
                this.customerOrders = value;
                OnPropertyChanged("CustomerOrders");
            }
        }

        public ObservableCollection<Model.CustomerOrder> CompleteCustomerOrders
        {
            get
            {
                return this.completeCustomerOrders;
            }
            set
            {
                this.completeCustomerOrders = value;
                OnPropertyChanged("CompleteCustomerOrders");
            }
        }

        public void addOrder(Model.CustomerOrder order)
        {
            this.CustomerOrders.Add(order);
            OnPropertyChanged("CustomerOrders");
        }

        public string showSelectedFoodDetails(Model.Food food)
        {
            string ingredients = "";
            if (food.Ingredients != null && food.Ingredients.Count > 0)
            {
                foreach (Model.Ingredient ingredient in food.Ingredients)
                {
                    ingredients += "\nName: " + ingredient.Name + " Amount: " + ingredient.Amount + " Calorie: " + ingredient.Calorie;
                }
            }
            return "ID: " + food.ID + "\nName: " + food.Name + "\nPiece Price: " + food.Price + "\n\n Ingredients:" + ingredients;
        }

        public void selectedOrderComplete(Model.CustomerOrder selectedCustomerOrder)
        {
            for (int i = 0; i < this.CustomerOrders.Count; i++)
            {
                Model.CustomerOrder customerOrder = this.CustomerOrders[i];
                if (customerOrder == selectedCustomerOrder)
                {
                    this.CustomerOrders.RemoveAt(i);
                    this.CompleteCustomerOrders.Add(selectedCustomerOrder);
                }
            }
        }

        public void removeCustomerOrder(Model.CustomerOrder selectedCustomerOrder)
        {
            for (int i = 0; i < this.CompleteCustomerOrders.Count; i++)
            {
                Model.CustomerOrder customerOrder = this.CompleteCustomerOrders[i];
                if (customerOrder == selectedCustomerOrder)
                {
                    this.CompleteCustomerOrders.RemoveAt(i);
                    this.safeOrder(selectedCustomerOrder);
                }
            }
        }

        public void safeOrder(Model.CustomerOrder order)
        {
            try
            {
                string query = "INSERT INTO orders (id, date) VALUES (?id, ?date)";
                MySqlCommand cmd = new MySqlCommand(query, database.Connection);
                cmd.Parameters.AddWithValue("?id", order.ID);
                cmd.Parameters.AddWithValue("?date", DateTime.Now);
                database.Connection.Open();
                cmd.ExecuteNonQuery();
                database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void openCashWindow()
        {
            new CashWindow().Show();
        }

        public void openCheckoutWindow()
        {
            new CheckoutWindow().Show();
        }

        public void openCustomerWindow()
        {
            new CustomerWindow().Show();
        }

        /*interface INotifyPropertyChanged*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
