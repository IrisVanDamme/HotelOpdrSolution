using HotelOpdrSolution.BL;
using HotelOpdrSolution.BL.Model;
using HotelOpdrSolution.DTOs;
using HotelOpdrSolution.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.WPF
{
    public class WPFManager
    {
        private Window1 _mainWindow;
        private DomainManager _dM;

        private WelcomePage _welcomePage;
        private ShowCustomersPage _showCustomersPage;
        private CustomerPage _customerPage;

        public WPFManager(Window1 mainWindow, DomainManager dM)
        {
            _mainWindow = mainWindow;
            _mainWindow.Show();

            _dM = dM;

            _welcomePage = new WelcomePage();
            _welcomePage.ChooseCustomerSelected += ShowChooseCustomerPage;
            _mainWindow.frame.NavigationService.Navigate(_welcomePage);

        }
        private void ShowChooseCustomerPage(object sender, EventArgs e)
        {
            _showCustomersPage = new ShowCustomersPage(_dM.GetCustomerListDTOs());
            _showCustomersPage.ChooseCustomerSelected += ShowCustomerPage;
            _mainWindow.frame.NavigationService.Navigate(_showCustomersPage);

        }
        private void ShowCustomerPage(object sender, int id)
        {
            _dM.setCurrentCustomer(id);
            _customerPage = new CustomerPage(_dM.GetCurrentCustomerListDTO());
            _mainWindow.frame.NavigationService.Navigate(_customerPage);

        }
    }
}
