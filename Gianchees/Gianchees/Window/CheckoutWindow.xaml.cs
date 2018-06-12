using System;
using System.Collections.Generic;
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
    public partial class CheckoutWindow : Window
    {
        ModelView modelView = ModelView.Instance;

        public CheckoutWindow()
        {
            InitializeComponent();
            this.DataContext = modelView;
        }

        private void removeCustomerOrder(object sender, SelectionChangedEventArgs args)
        {
            Model.CustomerOrder selectedCustomerOrder = ListViewCustomerOrders.SelectedItem as Model.CustomerOrder;
            if (selectedCustomerOrder != null)
            {
                modelView.removeCustomerOrder(selectedCustomerOrder);
            }
        }

        private void showSelectedFoodDetails(object sender, SelectionChangedEventArgs args)
        {
            Model.Order order = (sender as ListView).SelectedItem as Model.Order;
            if (order != null)
            {
                MessageBox.Show(modelView.showSelectedFoodDetails(order.Food));
            }
        }
    }
}
