using HotelOpdrSolution.BL.Model;
using HotelOpdrSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
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
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        public EventHandler<FullCustomerDTO> CustomerEdited;
        private FullCustomerDTO _fullCustomerDTO;
        private ObservableCollection<PropertyViewModel> _properties;
        private bool _customerEdited;
        public CustomerPage(FullCustomerDTO fullCustomerDTO)
        {
            InitializeComponent();

            _customerEdited = false;
            _fullCustomerDTO = fullCustomerDTO;


            RefreshListView();

            // ListView loops over that list
            customerListView.ItemsSource = _properties;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if an item is selected
            if (customerListView.SelectedItem != null)
            {
                // Access the selected item and perform actions
                PropertyViewModel selectedProperty = (PropertyViewModel)customerListView.SelectedItem;

                if (selectedProperty.PropertyName.Equals("Id") || selectedProperty.PropertyName.Equals("NrOfMembers"))
                {
                    editPropertyButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    editPropertyStackPanel.Visibility = Visibility.Visible;
                    editPropertyLabel.Content = selectedProperty.PropertyName + ":";
                    editPropertyTextBox.Text = selectedProperty.PropertyValue;
                    editPropertyButton.Visibility = Visibility.Visible;
                }

            }
        }

        private void EditProperty_ButtonClicked(object sender, RoutedEventArgs e)
        {
            FullCustomerDTO editedCustomerDTO = null;
            // Check if an item is selected
            if (customerListView.SelectedItem != null)
            {
                // Access the selected item and perform actions
                PropertyViewModel selectedProperty = (PropertyViewModel)customerListView.SelectedItem;


                switch (selectedProperty.PropertyName)
                {
                    case "Name":
                        editedCustomerDTO = new FullCustomerDTO(_fullCustomerDTO.Id, editPropertyTextBox.Text, _fullCustomerDTO.Email, _fullCustomerDTO.Phone, _fullCustomerDTO.Street, _fullCustomerDTO.HouseNr, _fullCustomerDTO.Zipcode, _fullCustomerDTO.City);
                        break;
                    case "Email":
                        editedCustomerDTO = new FullCustomerDTO(_fullCustomerDTO.Id, _fullCustomerDTO.Name, editPropertyTextBox.Text, _fullCustomerDTO.Phone, _fullCustomerDTO.Street, _fullCustomerDTO.HouseNr, _fullCustomerDTO.Zipcode, _fullCustomerDTO.City);
                        break;
                    case "Phone":
                        editedCustomerDTO = new FullCustomerDTO(_fullCustomerDTO.Id, _fullCustomerDTO.Name, _fullCustomerDTO.Email, editPropertyTextBox.Text, _fullCustomerDTO.Street, _fullCustomerDTO.HouseNr, _fullCustomerDTO.Zipcode, _fullCustomerDTO.City);
                        break;
                    case "Street":
                        editedCustomerDTO = new FullCustomerDTO(_fullCustomerDTO.Id, _fullCustomerDTO.Name, _fullCustomerDTO.Email, _fullCustomerDTO.Phone, editPropertyTextBox.Text, _fullCustomerDTO.HouseNr, _fullCustomerDTO.Zipcode, _fullCustomerDTO.City);
                        break;
                    case "HouseNr":
                        editedCustomerDTO = new FullCustomerDTO(_fullCustomerDTO.Id, _fullCustomerDTO.Name, _fullCustomerDTO.Email, _fullCustomerDTO.Phone, _fullCustomerDTO.Street, editPropertyTextBox.Text, _fullCustomerDTO.Zipcode, _fullCustomerDTO.City);
                        break;
                    case "Zipcode":
                        editedCustomerDTO = new FullCustomerDTO(_fullCustomerDTO.Id, _fullCustomerDTO.Name, _fullCustomerDTO.Email, _fullCustomerDTO.Phone, _fullCustomerDTO.Street, _fullCustomerDTO.HouseNr, editPropertyTextBox.Text, _fullCustomerDTO.City);
                        break;
                    case "City":
                        editedCustomerDTO = new FullCustomerDTO(_fullCustomerDTO.Id, _fullCustomerDTO.Name, _fullCustomerDTO.Email, _fullCustomerDTO.Phone, _fullCustomerDTO.Street, _fullCustomerDTO.HouseNr, _fullCustomerDTO.Zipcode, editPropertyTextBox.Text);
                        break;
                }


            }
            _fullCustomerDTO = editedCustomerDTO;
            _customerEdited = true;
            RefreshListView();
        }
        private void RefreshListView()
        {
            // create a list of objects that each contain property name and property value
            _properties = new ObservableCollection<PropertyViewModel>();

            foreach (var property in _fullCustomerDTO.GetType().GetProperties())
            {
                _properties.Add(new PropertyViewModel
                {
                    PropertyName = property.Name,
                    PropertyValue = property.GetValue(_fullCustomerDTO)?.ToString()
                });
            }
            customerListView.ItemsSource = _properties;
        }

        private void GoBack_ButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet.");
            if (_customerEdited)
            {
                CustomerEdited.Invoke(this, _fullCustomerDTO);
            }
            else
            {
                CustomerEdited.Invoke(this, null);
            }
        }
    }



    public class PropertyViewModel
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
}
