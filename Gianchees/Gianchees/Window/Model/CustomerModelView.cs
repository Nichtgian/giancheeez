using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gianchees
{
    class CustomerModelView : INotifyPropertyChanged
    {
        private Model.Foodtype selectedFoodtype = null;
        private Model.Food selectedFood = null;
        private Model.CustomerOrder order = new Model.CustomerOrder();

        public Model.Foodtype SelectedFoodtype
        {
            get
            {
                return this.selectedFoodtype;
            }
            set
            {
                this.selectedFoodtype = value;
                OnPropertyChanged("SelectedFoodtype");
            }
        }

        public Model.Food SelectedFood
        {
            get
            {
                return this.selectedFood;
            }
            set
            {
                this.selectedFood = value;
                OnPropertyChanged("SelectedFood");
            }
        }

        public Model.CustomerOrder Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
                OnPropertyChanged("Order");
            }
        }

        public void addFoodToOrder(Model.Food food)
        {
            this.Order.addFoodToOrder(food);
            OnPropertyChanged("Order");
            OnPropertyChanged("Order.Amount");
            OnPropertyChanged("Order.ID");
        }

        public void clearOrder()
        {
            Model.CustomerOrder order = new Model.CustomerOrder();
            this.Order = order;
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
