using HotelOpdrSolution.DTOs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelOpdrSolution.WPF.Views
{
    /// <summary>
    /// Interaction logic for ShowCustomersPage.xaml
    /// </summary>
    public partial class ShowCustomersPage : Page
    {
        public EventHandler<int> ChooseCustomerSelected;
        private List<CustomerListDTO> _customerListDTOs;
        public ShowCustomersPage(List<CustomerListDTO> customerListDTOs)
        {
            InitializeComponent();

            _customerListDTOs = customerListDTOs;
            customerDataGrid.ItemsSource = customerListDTOs;
        }
        private void ChooseCustomer_ButtonClicked(object sender, RoutedEventArgs e)
        {
            if (customerDataGrid.SelectedIndex != null)
            {
                ChooseCustomerSelected?.Invoke(this, _customerListDTOs[customerDataGrid.SelectedIndex].Id); // Id doorgeven
            }
        }
    }
}
