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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gianchees
{
    public partial class CashWindow : Window
    {
        ModelView modelView = ModelView.Instance;

        public CashWindow()
        {
            InitializeComponent();
            this.DataContext = this.modelView;
        }

        private void openCashWindow(object sender, RoutedEventArgs e)
        {
            this.modelView.openCashWindow();
        }

        private void openCheckoutWindow(object sender, RoutedEventArgs e)
        {
            this.modelView.openCheckoutWindow();
        }

        private void openCustomerWindow(object sender, RoutedEventArgs e)
        {
            this.modelView.openCustomerWindow();
        }

        private void showSelectedFoodDetails(object sender, SelectionChangedEventArgs args)
        {
            Model.Order order = (sender as ListView).SelectedItem as Model.Order;
            if (order != null)
            {
                MessageBox.Show(modelView.showSelectedFoodDetails(order.Food));
            }
        }

        private void selectedOrderComplete(object sender, RoutedEventArgs e)
        {
            Model.CustomerOrder selectedCustomerOrder = ListViewCustomerOrders.SelectedItem as Model.CustomerOrder;
            if (selectedCustomerOrder != null)
            {
                modelView.selectedOrderComplete(selectedCustomerOrder);
            }
        }
    }
}
