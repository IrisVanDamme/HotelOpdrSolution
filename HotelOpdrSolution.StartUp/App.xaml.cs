using HotelOpdrSolution.BL;
using HotelOpdrSolution.DL;
using HotelOpdrSolution.DL.Mappers;
using HotelOpdrSolution.WPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HotelOpdrSolution.StartUp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            new WPFManager(new Window1(), new DomainManager(new CustomerMapper(new DataContext())));
        }
    }
}
