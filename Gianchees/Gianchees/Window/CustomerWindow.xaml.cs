using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gianchees
{
    public partial class CustomerWindow : Window
    {
        ModelView modelView = ModelView.Instance;
        CustomerModelView customerModelView = new CustomerModelView();

        public CustomerWindow()
        {
            InitializeComponent();
            this.DataContext = new {
                Model = modelView,
                Local = customerModelView
            };
            comboBoxFoodtypes.SelectedItem = modelView.Foodtypes[0];
        }

        private void selectFoodtype(object sender, SelectionChangedEventArgs args)
        {
            customerModelView.SelectedFoodtype = (sender as ComboBox).SelectedItem as Model.Foodtype;
        }

        private void addFoodToOrder(object sender, SelectionChangedEventArgs args)
        {
            customerModelView.addFoodToOrder((sender as ListView).SelectedItem as Model.Food);
        }

        private void selectFood(object sender, SelectionChangedEventArgs args)
        {
            customerModelView.SelectedFood = (sender as ListView).SelectedItem as Model.Food;
        }

        private void clearOrders(object sender, RoutedEventArgs e)
        {
            customerModelView.clearOrder();
        }

        private void order(object sender, RoutedEventArgs e)
        {
            modelView.addOrder(customerModelView.Order);
            customerModelView.Order = new Model.CustomerOrder();
        }
    }
}
